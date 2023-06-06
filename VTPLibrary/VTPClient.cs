using Newtonsoft.Json;
using System.Net;
using System.Text;
using VTPLibrary.Models;

namespace VTPLibrary
{
    public class VTPClient
    {
        public readonly HttpClient _client;
        public readonly string Key;
        private readonly string _threadId;

        public VTPClient(MyProxy? proxy = null)
        {
            var handler = new HttpClientHandler
            {
                UseCookies = true
            };
            if (proxy != null)
            {
                var webProxy = new WebProxy(proxy.Host, proxy.Port);
                if (proxy.Username != null)
                {
                    webProxy.Credentials = new NetworkCredential(proxy.Username, proxy.Password);
                }
                handler.Proxy = webProxy;
            }
            _client = new HttpClient(handler)
            {
                DefaultRequestVersion = HttpVersion.Version11
            };
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36 Edg/114.0.1823.37");
            _client.DefaultRequestHeaders.Add("Referer", "https://m.vtmoney.vn/account/login");
            _client.DefaultRequestHeaders.Add("Origin", "https://m.vtmoney.vn");
            _client.DefaultRequestHeaders.Add("Sec-Ch-Ua", @"""Not.A/Brand"";v=""8"", ""Chromium"";v=""114"", ""Microsoft Edge"";v=""114""");
            _client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Mobile", "?1");
            _client.DefaultRequestHeaders.Add("Sec-Ch-Ua-Platform", @"""Android""");

            Key = Guid.NewGuid().ToString().Replace("-", "").ToLower()[8..];
            _threadId = Guid.NewGuid().ToString().Replace("-", "").ToLower();
        }

        public async Task<bool> SyncKey(string phone, CancellationToken token)
        {
            var hash = Security.CreateKey(Key, phone, _threadId);
            var body = JsonConvert.SerializeObject(new { hash });
            var res = await _client.PostAsync("https://m.vtmoney.vn/webvtp-service/public/v1/syncKey",
                new StringContent(body, Encoding.UTF8, "application/json"), token);
            var content = await res.Content.ReadAsStringAsync(token);
            var resModel = JsonConvert.DeserializeObject<ResponseModel>(content);
            _client.DefaultRequestHeaders.Add("Thread-Id", _threadId);
            return resModel?.Status.Code == "00";
        }

        public async Task<ResponseModel?> GetByCmd<TRequest>(string cmd, TRequest requestEntity, CancellationToken token)
        {
            var requestModel = new RequestModel<TRequest>(cmd, requestEntity, Key);
            var body = JsonConvert.SerializeObject(requestModel);
            var res = await _client.PostAsync("https://m.vtmoney.vn/webvtp-service/public/v1/api",
                new StringContent(body, Encoding.UTF8, "application/json"), token);
            var content = await res.Content.ReadAsStringAsync(token);
            var resModel = JsonConvert.DeserializeObject<ResponseModel>(content);
            return resModel;
        }
    }
}
