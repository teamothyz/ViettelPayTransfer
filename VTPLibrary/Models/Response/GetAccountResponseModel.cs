using Newtonsoft.Json;

namespace VTPLibrary.Models.Response
{
    public class GetAccountResponseModel
    {
        [JsonProperty("otherData")]
        public GetAccountOtherDataResponseModel OtherData { get; set; } = null!;

        [JsonProperty("sources")]
        public GetAccountSourcesResponseModel Sources { get; set; } = null!;
    }

    public class GetAccountOtherDataResponseModel
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; } = null!;
    }

    public class GetAccountSourcesResponseModel
    {
        [JsonProperty("infra")]
        public List<GetAccountVTPCardResponseModel> VTPCards { get; set; } = new();
    }

    public class GetAccountVTPCardResponseModel
    {
        [JsonProperty("accNo")]
        public string CardNumber { get; set; } = null!;

        [JsonProperty("accName")]
        public string CardName { get; set; } = null!;
    }
}
