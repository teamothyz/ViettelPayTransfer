using GSMLibrary.Models;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace GSMLibrary.Services
{
    public class GSMService
    {
        public static void SwitchTextMode(GSMCom com)
        {
            GetResponse(com.Port, "AT+CMGF=1");
            GetResponse(com.Port, "AT+CLIP=1");
        }

        public static void GetModemType(GSMCom com)
        {
            string response = GetResponse(com.Port, "ATI").ToUpper();
            var type = ModemType.UNSUPPORTED;
            if (response.Contains(ModemType.CINTERION.ToString()))
                type = ModemType.CINTERION;
            if (response.Contains(ModemType.SIEMENS.ToString()))
                type = ModemType.SIEMENS;
            if (response.Contains(ModemType.QUECTEL.ToString()))
                type = ModemType.QUECTEL;
            if (response.Contains(ModemType.WAVECOME.ToString()))
                type = ModemType.WAVECOME;
            com.ModemType = type;
        }

        public static void ClearSMS(GSMCom com)
        {
            GetResponse(com.Port, "AT+CMGD=1,4");
        }

        public static void GetSIMType(GSMCom com)
        {
            var command = "AT+COPS?";
            var response = GetResponse(com.Port, command).ToUpper();
            var type = SIMType.None;
            if (response.Contains("VIETTEL") || response.Contains("45204")) type = SIMType.Viettel;
            else if (response.Contains("VINAPHONE") || response.Contains("45202")) type = SIMType.Vinaphone;
            else if (response.Contains("VIETNAMOBILE")) type = SIMType.VNMobile;
            else if (response.Contains("MOBIFONE")) type = SIMType.Mobifone;
            else if (response.Contains("OK")) type = SIMType.Unsupported;
            com.SIMType = type;
        }

        public static void GetPhoneNumberAndBalance(GSMCom com)
        {
            var simInfo = GetSIMInfoUSSD(com.Port, com.SIMType, com.ModemType);
            var retry = 0;
            while (retry++ < 5 && (simInfo.Contains("ERROR") || string.IsNullOrEmpty(simInfo)))
            {
                Task.Delay(1000).Wait();
                simInfo = GetSIMInfoUSSD(com.Port, com.SIMType, com.ModemType);
            }

            var phoneNumber = string.Empty;
            var match = Regex.Match(simInfo, "(\\d{9,11})");
            if (match.Success)
            {
                phoneNumber = match.Value;
                if (phoneNumber.Length == 9)
                    phoneNumber = phoneNumber.Insert(0, "0");
                if (phoneNumber.StartsWith("84"))
                    phoneNumber = phoneNumber.Remove(0, 2).Insert(0, "0");
            }
            com.PhoneNumber = phoneNumber;
            com.Balance = string.Empty;

            //Match balanceMatch;
            //var balance = string.Empty;
            //switch (com.SIMType)
            //{
            //    case SIMType.Viettel:
            //        balanceMatch = Regex.Match(simInfo, "TKG:.*\\d{1,}d,");
            //        if (balanceMatch.Success)
            //            balance = balanceMatch.Value.Replace("TKG:", "")
            //                .Replace("d,", "d").Trim();
            //        break;
            //    case SIMType.Vinaphone:
            //        balanceMatch = Regex.Match(simInfo, "TK chinh=.*\\d{1,} VND,");
            //        if (balanceMatch.Success)
            //            balance = balanceMatch.Value.Replace("TK chinh=", "")
            //                .Replace(" VND,", "d").Trim();
            //        break;
            //    default: break;
            //}
            //com.Balance = balance;
        }

        private static string GetSIMInfoUSSD(SerialPort port, SIMType simType, ModemType modemType)
        {
            var command = modemType switch
            {
                ModemType.SIEMENS or ModemType.CINTERION => $"ATDT*101#;",
                _ => $@"AT+CUSD=1,""*101#"",15"
            };
            var response = GetResponse(port, command);
            GetResponse(port, "AT+CUSD=2");
            return response;
        }

        public static string GetOTP(GSMCom com, CancellationToken token)
        {
            try
            {
                string otp;
                var endTime = DateTime.Now.AddSeconds(2);
                do
                {
                    token.ThrowIfCancellationRequested();
                    otp = GetOTPUnreadMessage(com);

                    if (string.IsNullOrEmpty(otp)) Thread.Sleep(1000);
                } while (string.IsNullOrEmpty(otp) && endTime > DateTime.Now);
                if (string.IsNullOrEmpty(otp)) throw new Exception();
                com.LastOtp = otp;
                return otp;
            }
            catch 
            {
                if (token.IsCancellationRequested) throw new Exception("Người dùng yêu cầu dừng chương trình");
                if (com.LastOtp != null) return com.LastOtp;
                throw new Exception("Không tìm thấy OTP"); 
            }
        }

        public static string GetOTPUnreadMessage(GSMCom com)
        {
            var response = GetResponse(com.Port, @"AT+CMGL=""REC UNREAD""");
            GetResponse(com.Port, "AT+CMGD=1,4");
            var messages = response.Split("\r\n+CMGL:");

            var sender = "(\\s\\d{4}\\s)";
            var regex = "VTMONEY";
            //switch (com.SIMType)
            //{
            //    case SIMType.Vinaphone:
            //        regex = "(\\d{6}\\s)";
            //        sender = "MyVNPT";
            //        break;
            //    case SIMType.Viettel:
            //        regex = "(\\s\\d{4}\\s)";
            //        sender = "VTMONEY";
            //        break;
            //    default:
            //        regex = "UNSUPPORTED";
            //        sender = "UNSUPPORTED";
            //        break;
            //}

            var otp = string.Empty;
            foreach (var message in messages)
            {
                var match = Regex.Match(message, "(\\d{1,},\"REC.*READ\".*[+]\\d{1,}\"\r\n)");
                if (!match.Success)
                    continue;
                var messageHeader = match.Value;
                if (!messageHeader.Contains(sender))
                    continue;

                var messageContent = message.Replace(messageHeader, "").Replace("\r\nOK\r\n", "");
                var matchesOTP = Regex.Matches(messageContent, regex);
                if (matchesOTP.Count == 0)
                    continue;
                otp = matchesOTP.OrderBy(match => match.Value.Length).First().Value;
                break;
            }
            return otp.Trim();
        }

        public static string GetResponse(SerialPort port, string command)
        {
            lock (port)
            {
                var isSuccess = ThrottlePortManager.UsePort();
                while (!isSuccess)
                {
                    Task.Delay(1000).Wait();
                    isSuccess = ThrottlePortManager.UsePort();
                }

                try
                {
                    port.ReadExisting();
                    port.Write($"{command}\r");
                    string result = string.Empty;
                    var timeOut = DateTime.Now.AddSeconds(15);
                    while (true)
                    {
                        if (DateTime.Now > timeOut || !port.IsOpen)
                            return string.Empty;
                        string response = port.ReadExisting();
                        result += response;
                        if (!string.IsNullOrEmpty(response))
                            continue;
                        if ((result.Contains("OK") || result.Contains("ERROR")))
                            break;
                    }
                    return result;
                }
                catch
                {
                    return string.Empty;
                }
                finally
                {
                    ThrottlePortManager.ReleasePort();
                }
            }
        }
    }
}
