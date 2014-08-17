using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientToolkit.Handler
{
    public class RetryHandler : DelegatingHandler {
        private const int MaxRetries = 3;

        public RetryHandler(HttpMessageHandler innerHandler)
            : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) {
            HttpResponseMessage response;
            for(int i = 0;i < MaxRetries - 1;i++) {
                response = await base.SendAsync(request,cancellationToken);
                if(response.IsSuccessStatusCode) {
                    return response;
                }
            }
            //前两次未成功的情况下再请求第三次数据结果直接返回
            response = await base.SendAsync(request,cancellationToken);
            return response;
            }
    }
}