using Newtonsoft.Json;

namespace VTPLibrary.Models.Response
{
    public class GetBalanceResponseModel
    {
        [JsonProperty("balance")]
        public string Balance { get; set; } = null!;
    }
}
