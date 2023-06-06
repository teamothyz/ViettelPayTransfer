using Newtonsoft.Json;

namespace VTPLibrary.Models.Request
{
    public class AuthLoginRequestModel
    {
        public static readonly string Cmd = "AUTH_LOGIN";

        [JsonProperty("msisdn")]
        public string Phone { get; set; } = null!;

        [JsonProperty("username")]
        public string Username { get; set; } = null!;

        [JsonProperty("userType")]
        public string UseType { get; set; } = null!;

        [JsonProperty("pin")]
        public string Password { get; set; } = null!;

        [JsonProperty("loginType")]
        public string LoginType { get; set; } = null!;

        [JsonProperty("notifyToken")]
        public string NotifyToken { get; set; } = null!;

        [JsonProperty("typeOs")]
        public string TypeOs { get; set; } = null!;

        [JsonProperty("imei")]
        public string Imei { get; set; } = null!;

        public AuthLoginRequestModel() { }

        public AuthLoginRequestModel(string phone, string password)
        {
            Phone = phone.Length == 10 && phone.StartsWith("0") ? "84" + phone[1..] : phone;
            Username = Phone;
            NotifyToken = Phone;
            Password = password;

            LoginType = "BASIC";
            UseType = "msisdn";
            TypeOs = "android";
            Imei = "WEB_VIETTELPAY";
        }
    }
}
