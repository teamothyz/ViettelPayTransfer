using Newtonsoft.Json;

namespace VTPLibrary.Models.Request
{
    public class GetBalanceRequestModel
    {
        public static readonly string Cmd = "BALANCE_INQUIRY_NO_PIN";
        
        [JsonProperty("type_os")]
        public string TypeOs { get; set; } = null!;

        [JsonProperty("os_version")]
        public string OsVersion { get; set; } = null!;

        [JsonProperty("app_version")]
        public string AppVersion { get; set; } = null!;

        [JsonProperty("money_source")]
        public string MoneySource { get; set; } = null!;

        [JsonProperty("order_id")]
        public string OrderId { get; set; } = null!;

        [JsonProperty("money_source_bank_code")]
        public string SourceBank { get; set; } = null!;

        public GetBalanceRequestModel() { }

        public GetBalanceRequestModel(string cardNumber)
        {
            TypeOs = "android";
            OsVersion = "113.0.0.0";
            AppVersion = "1.0.0_chrome_113.0.0.0";
            MoneySource = cardNumber;
            OrderId = DateTime.Now.ToString("yyyyMMddHHmmss");
            SourceBank = "VTT";
        }
    }
}
