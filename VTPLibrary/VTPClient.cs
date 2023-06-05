using System.Net;

namespace VTPLibrary
{
    public class VTPClient
    {
        private readonly HttpClient _client;

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
        }


    }
}
