using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientToolkit.Model;
using Newtonsoft.Json;

namespace HttpClientToolkit.Extension
{
    public static class HttpClientExtension {
        public static async Task<Response<T>> GetAsync<T>(this HttpClient httpClient,string uri) {
            var requestResult = new Response<T>();
            try {
                var response = await httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<T>(result);
                requestResult.Result = data;
                requestResult.Succeed = true;
            } catch(HttpRequestException e) {
                requestResult.Error.Type = ErrorType.RequestError;
            } catch(JsonReaderException e) {
                requestResult.Error.Type = ErrorType.JsonDeserizeError;
            } catch(InvalidOperationException invalidOperationException) {
                requestResult.Error.Type = ErrorType.JsonDeserizeError;
            } catch(TaskCanceledException e) {
                requestResult.Error.Type = ErrorType.Timeout;
            } catch(Exception e) {
                requestResult.Error.Type = ErrorType.Unknown;
                if(Debugger.IsAttached)
                    Debug.WriteLine(e);
            }
            return requestResult;
        }
    }
}