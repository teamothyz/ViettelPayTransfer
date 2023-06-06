using Newtonsoft.Json;

namespace VTPLibrary.Models.Request
{
    public class TransferRequestModel
    {
        public static readonly string Cmd = "MONEY_TRANSFER_INSIDE_SMS";

        [JsonProperty("type_os")]
        public string TypeOS { get; set; } = null!;

        [JsonProperty("app_version")]
        public string AppVersion { get; set; } = null!;

        [JsonProperty("os_version")]
        public string OSVersion { get; set; } = null!;

        [JsonProperty("service_type")]
        public string ServiceType { get; set; } = null!;

        [JsonProperty("is_lixi")]
        public string IsLixi { get; set; } = null!;

        [JsonProperty("recv_cust_mobile")]
        public string Receiver { get; set; } = null!;

        [JsonProperty("bank_code")]
        public string BankCode { get; set; } = null!;

        [JsonProperty("money_source_bank_code")]
        public string SourceBankCode { get; set; } = null!;

        [JsonProperty("trans_amount")]
        public int Amount { get; set; }

        [JsonProperty("pin")]
        public string Password { get; set; } = null!;

        [JsonProperty("recv_bankcode")]
        public string ReceiverBankCode { get; set; } = null!;

        [JsonProperty("trans_content")]
        public string Content { get; set; } = null!;

        public TransferRequestModel() { }

        public TransferRequestModel(string password, string receiver, int amount)
        {
            TypeOS = "android";
            AppVersion = "1.0.0_chrome_113.0.0.0";
            OSVersion = "113.0.0.0";
            ServiceType = "0";
            IsLixi = "0";
            Receiver = receiver;
            BankCode = "VTT";
            SourceBankCode = "VTT";
            Amount = amount;
            Password = password;
            ReceiverBankCode = "VTT";
            Content = "Chuyen tien tu Viettel Money";
        }
    }
}
