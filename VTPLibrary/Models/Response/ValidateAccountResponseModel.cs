using Newtonsoft.Json;

namespace VTPLibrary.Models.Response
{
    public class ValidateAccountResponseModel
    {
        [JsonProperty("accountId")]
        public string AccountId { get; set; } = null!;

        [JsonProperty("displayName")]
        public string DisplayName { get; set; } = null!;

        [JsonProperty("twofaChannelValue")]
        public string Phone { get; set; } = null!;
    }
}
