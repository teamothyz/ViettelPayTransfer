using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Threading;
using VTPLibrary.Models;

namespace VTPLibrary
{
    public class VTPClient
    {
        private readonly HttpClient _client;
        private readonly string _threadId;
        private readonly string _key;

        public VTPClient(string key, string threadId, MyProxy? proxy = null)
        {
            _key = key;
            _threadId = threadId;
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
        }

        public async Task SyncKey(string phone, CancellationToken token)
        {
            var hash = Security.CreateKey(_key, phone, _threadId);
            var body = JsonConvert.SerializeObject(new { hash });
            var res = await _client.PostAsync("https://m.vtmoney.vn/webvtp-service/public/v1/syncKey",
                new StringContent(body, Encoding.UTF8, "application/json"), token);
            var content = await res.Content.ReadAsStringAsync(token);
            var resModel = JsonConvert.DeserializeObject<ResponseModel>(content);
            if (resModel?.Status.Code != "00") throw new Exception(content);
            SetThreadId(_threadId);
        }

        public async Task<ResponseModel?> GetByCmd<TRequest>(string cmd, TRequest requestEntity, CancellationToken token)
        {
            var requestModel = new RequestModel<TRequest>(cmd, requestEntity, _key);
            var body = JsonConvert.SerializeObject(requestModel);
            var res = await _client.PostAsync("https://m.vtmoney.vn/webvtp-service/public/v1/api",
                new StringContent(body, Encoding.UTF8, "application/json"), token);
            var content = await res.Content.ReadAsStringAsync(token);
            var resModel = JsonConvert.DeserializeObject<ResponseModel>(content);
            if (resModel?.Status.Code != "00")
            {
                if (resModel?.Data != null) throw new Exception(resModel.GetData(_key));
                else throw new Exception(content);
            }
            return resModel;
        }

        public void SetThreadId(string threadId)
        {
            _client.DefaultRequestHeaders.Remove("Thread-Id");
            _client.DefaultRequestHeaders.Add("Thread-Id", threadId);
        }

        public void SetSessionId(string sessionId)
        {
            _client.DefaultRequestHeaders.Remove("Session-Id");
            _client.DefaultRequestHeaders.Add("Session-Id", sessionId);
        }
    }
}
