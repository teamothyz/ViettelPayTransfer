using Newtonsoft.Json;

namespace VTPLibrary.Models.Response
{
    public class TransferResponseModel
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; } = null!;

        [JsonProperty("session_id")]
        public string SessionId { get; set; } = null!;
    }
}
