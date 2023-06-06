using Newtonsoft.Json;

namespace VTPLibrary.Models.Request
{
    public class GetAccountRequestModel
    {
        public static readonly string Cmd = "CUSTOMER_V1_GET_ACCOUNT";

        [JsonProperty("Authorization")]
        public string Authorization { get; set; } = null!;

        [JsonProperty("sources")]
        public string Sources { get; set; } = null!;

        [JsonProperty("msisdn")]
        public string Phone { get; set; } = null!;

        public GetAccountRequestModel() { }

        public GetAccountRequestModel(string accessToken, string phone)
        {
            Authorization = accessToken;
            Phone = phone.Length == 10 && phone.StartsWith("0") ? "84" + phone[1..] : phone;
            Sources = "1";
        }
    }
}
