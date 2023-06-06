using GSMLibrary.Services;
using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using VTPLibrary;

namespace GSMLibrary.Models
{
    public class GSMCom : INotifyPropertyChanged
    {
        private string _name = null!;
        private string _phoneNumber = null!;
        private SIMType _simType;
        private string _balance = null!;
        private string _portStatus = null!;

        private string _accountNum = null!;
        private string _accountOwner = null!;
        private int _accountBalance = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public VTPClient Client { get; set; } = null!;

        public string LastOtp { get; set; } = null!;

        public string AccessToken { get; set; } = null!;

        public string Key { get; private set; }

        public ModemType ModemType { get; set; }

        public SerialPort Port { get; private set; }

        public SIMType SIMType
        {
            get => _simType;
            set
            {
                _simType = value;
                NotifyPropertyChanged(nameof(SIMType));
            }
        }

        public int AccountBalance
        {
            get => _accountBalance;
            set
            {
                _accountBalance = value;
                NotifyPropertyChanged(nameof(AccountBalance));
            }
        }

        public string AccountOwner
        {
            get => _accountOwner;
            set
            {
                _accountOwner = value;
                NotifyPropertyChanged(nameof(AccountOwner));
            }
        }

        public string AccountNumber
        {
            get => _accountNum;
            set
            {
                _accountNum = value;
                NotifyPropertyChanged(nameof(AccountNumber));
            }
        }

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                NotifyPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                NotifyPropertyChanged(nameof(Balance));
            }
        }

        public string PortStatus
        {
            get => _portStatus;
            set
            {
                _portStatus = value;
                NotifyPropertyChanged(nameof(PortStatus));
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public GSMCom(string portName, string index)
        {
            Key = Guid.NewGuid().ToString().Replace("-", "")[8..].ToLower();
            Name = $"SIM {index}";
            Port = new SerialPort()
            {
                PortName = portName,
                BaudRate = 115200,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.RequestToSend,
                RtsEnable = true,
                DtrEnable = true,
                Encoding = Encoding.UTF8,
                ReceivedBytesThreshold = 1,
                NewLine = Environment.NewLine,
                WriteTimeout = 60000,
                ReadTimeout = 60000
            };
        }

        public void GetSimInfo()
        {
            try
            {
                Connect();
                PortStatus = "Đổi Text Mode";
                GSMService.SwitchTextMode(this);

                PortStatus = "Xác định Modem";
                GSMService.GetModemType(this);

                PortStatus = "Xác định SIM";
                GSMService.GetSIMType(this);

                if (SIMType != SIMType.Viettel)
                {
                    Disconnect();
                    PortStatus = $"{PortStatus} -> SIM không được hỗ trợ";
                    return;
                }

                PortStatus = "Xác định SĐT";
                GSMService.GetPhoneNumberAndBalance(this);

                PortStatus = "Kết nối thành công";
            }
            catch
            {
                PhoneNumber = string.Empty;
                PortStatus = $"{PortStatus} -> Lỗi -> Bấm [Kết nối] lại";
                try { Port.Close(); } catch { }
            }
        }

        public void Reset()
        {
            PortStatus = "Đang reset";
            try
            {
                lock (Port)
                {
                    Connect();
                    Port.Write("AT+CFUN=1,1\r");
                }
                Disconnect();
                Thread.Sleep(5000);
                GetSimInfo();
            }
            catch
            {
                PortStatus = $"{PortStatus} -> Lỗi khi reset";
            }
        }

        public void Connect()
        {
            try
            {
                if (Port.IsOpen)
                {
                    PortStatus = "Đã kết nối";
                    return;
                }
                Port.Open();
                PortStatus = "Đã kết nối";
            }
            catch { PortStatus = "Lỗi khi kết nối"; }
        }

        public void Disconnect()
        {
            try
            {
                if (!Port.IsOpen)
                {
                    PortStatus = "Đã ngắt kết nối";
                    return;
                }
                Port.Close();
                PortStatus = "Đã ngắt kết nối";
            }
            catch { PortStatus = "Lỗi khi ngắt kết nối"; }
        }
    }

    public enum SIMType
    {
        None,
        Viettel,
        Vinaphone,
        VNMobile,
        Mobifone,
        Unsupported
    }

    public enum ModemType
    {
        None,
        UNSUPPORTED,
        CINTERION,
        WAVECOME,
        QUECTEL,
        SIEMENS
    }
}
