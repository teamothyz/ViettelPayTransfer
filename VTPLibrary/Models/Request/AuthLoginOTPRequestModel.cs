using Newtonsoft.Json;

namespace VTPLibrary.Models.Request
{
    public class AuthLoginOTPRequestModel : AuthLoginRequestModel
    {
        [JsonProperty("otp")]
        public string Otp { get; set; } = null!;

        [JsonProperty("requestId")]
        public string RequestId { get; set; } = null!;

        public AuthLoginOTPRequestModel() { }

        public AuthLoginOTPRequestModel(string phone, string password, string otp, string requestId) 
            : base(phone, password) 
        {
            Otp = otp;
            RequestId = requestId;
        }
    }
}
