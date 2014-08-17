using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using HttpClientToolkit.Handler;

namespace HttpClientToolkit {
    public class HttpClientFactory {
        /// <summary>
        /// Factory Method of HttpClient.
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough]
        public static HttpClient Create() {
            var handler = new HttpClientHandler {
                AutomaticDecompression = DecompressionMethods.GZip,
            };
            var httpclient = new HttpClient(new RefineUriHandler(new RetryHandler(new LoggingHandler(handler))));
            httpclient.Timeout = TimeSpan.FromSeconds(60);
            return httpclient;
        }
    }
}