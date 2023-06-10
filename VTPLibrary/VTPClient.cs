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
                DefaultRequestVersion = HttpVersion.Version11,
                Timeout = TimeSpan.FromSeconds(180),
            };
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36 Edg/114.0.1823.37");
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
            var tryTimes = 1;
            HttpResponseMessage res = null!;
            ResponseModel? resModel = null!;
            while (tryTimes <= 5)
            {
                try
                {
                    var requestModel = new RequestModel<TRequest>(cmd, requestEntity, _key);
                    var body = JsonConvert.SerializeObject(requestModel);
                    res = await _client.PostAsync("https://m.vtmoney.vn/webvtp-service/public/v1/api",
                        new StringContent(body, Encoding.UTF8, "application/json"), token);
                    var content = await res.Content.ReadAsStringAsync(token);
                    resModel = JsonConvert.DeserializeObject<ResponseModel>(content);
                    if (resModel?.Status.Code != "00")
                    {
                        if (resModel?.Status.Code == "0" || resModel?.Status.Code == "09")
                        {
                            tryTimes++;
                            await Task.Delay(1000, token);
                            continue;
                        }
                        if (cmd == "MONEY_TRANSFER_INSIDE_SMS" && resModel?.Status.Code == "OTP") return resModel;
                        if (cmd == "AUTH_LOGIN" && resModel?.Status.Code == "AUT0014") return resModel;
                        if (resModel?.Data != null) throw new Exception($"{resModel.GetData(_key)}\n{JsonConvert.SerializeObject(resModel.Status)}");
                        else throw new Exception(content);
                    }
                    return resModel;
                }
                catch
                {
                    if (tryTimes == 5) throw;
                    tryTimes++;
                    await Task.Delay(1000, token);
                    continue;
                }
            }
            return resModel;
        }

        public void SetReferer(bool isLogin)
        {
            _client.DefaultRequestHeaders.Remove("Referer");
            if (isLogin) _client.DefaultRequestHeaders.Add("Referer", "https://m.vtmoney.vn/account/login");
            else _client.DefaultRequestHeaders.Add("Referer", "https://m.vtmoney.vn/home");
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
