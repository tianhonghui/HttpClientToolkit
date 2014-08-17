using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientToolkit.Handler
{
    public class RefineUriHandler : DelegatingHandler {
        public RefineUriHandler(HttpMessageHandler innerHandler)
            : base(innerHandler) {
            }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,CancellationToken cancellationToken) {
            request.RequestUri = new Uri(RefineUrl(request.RequestUri.ToString()),UriKind.Absolute);
            HttpResponseMessage response = await base.SendAsync(request,cancellationToken);
            return response;
        }

        public string RefineUrl(string url) {
            if(url.IndexOf('?') > 0) {
                url += '&';
            } else {
                url += '?';
            }
            url += "apikey=" + Constant.ApiKey;
            return url;
        }
    }
}