using Newtonsoft.Json;

namespace VTPLibrary.Models.Response
{
    public class TransferOTPResponseModel
    {
        [JsonProperty("trans_id")]
        public string TransactionId { get; set; } = null!;

        [JsonProperty("order_id")]
        public string OrderId { get; set; } = null!;

        [JsonProperty("request_id")]
        public string RequestId { get; set; } = null!;

        [JsonProperty("session_id")]
        public string SessionId { get; set; } = null!;
    }
}
