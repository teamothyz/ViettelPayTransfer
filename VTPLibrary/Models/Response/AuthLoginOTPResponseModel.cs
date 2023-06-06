using Newtonsoft.Json;

namespace VTPLibrary.Models.Response
{
    public class AuthLoginOTPResponseModel
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; } = null!;

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; } = null!;

        [JsonProperty("username")]
        public string Username { get; set; } = null!;
    }
}
