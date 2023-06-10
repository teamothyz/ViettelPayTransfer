using Newtonsoft.Json;

namespace VTPLibrary.Models
{
    public class ResponseModel
    {
        [JsonProperty("data")]
        public string Data { get; set; } = null!;

        [JsonProperty("status")]
        public ResponseStatusModel Status { get; set; } = null!;

        public string GetData(string key)
        {
            return Data == null ? string.Empty : Security.TripleDesDecrypt(Data, key);
        }

        public T? GetData<T>(string key)
        {
            if (Data == null) return default;
            var content = Security.TripleDesDecrypt(Data, key);
            return JsonConvert.DeserializeObject<T>(content);
        }
    }

    public class ResponseStatusModel
    {
        [JsonProperty("code")]
        public string Code { get; set; } = null!;

        [JsonProperty("displayMessage")]
        public string DisplayMessage { get; set; } = null!;

        [JsonProperty("message")]
        public string Message { get; set; } = null!;

        [JsonProperty("responseTime")]
        public string ResponseTime { get; set; } = null!;
    }
}
