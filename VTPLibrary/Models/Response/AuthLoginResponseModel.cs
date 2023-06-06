using Newtonsoft.Json;

namespace VTPLibrary.Models.Response
{
    public class AuthLoginResponseModel
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; } = null!;
    }
}
