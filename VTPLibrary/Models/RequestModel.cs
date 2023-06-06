using Newtonsoft.Json;

namespace VTPLibrary.Models
{
    public class RequestModel<T>
    {
        [JsonProperty("cmd")]
        public string Command { get; set; } = null!;

        [JsonProperty("data")]
        public string Data { get; set; } = null!;

        [JsonIgnore]
        public T Source { get; set; } = default!;

        public RequestModel(string cmd, T source, string key)
        {
            Command = cmd;
            Source = source;
            Data = Security.TripleDesEncrypt(JsonConvert.SerializeObject(Source), key);
        }
    }
}
