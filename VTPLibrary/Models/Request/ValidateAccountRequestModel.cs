using Newtonsoft.Json;

namespace VTPLibrary.Models.Request
{
    public class ValidateAccountRequestModel
    {
        public static readonly string Cmd = "CUSTOMER_V1_VALIDATE_ACCOUNT";

        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        [JsonProperty("username")]
        public string Username { get; set; } = null!;

        public ValidateAccountRequestModel() { }

        public ValidateAccountRequestModel(string phone)
        {
            Username = phone.Length == 10 && phone.StartsWith("0") ? "84" + phone[1..] : phone;
            Type = "msisdn";
        }
    }
}
