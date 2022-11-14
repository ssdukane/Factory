using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OMB.App.Services
{
    public class HTTPClient : IHTTPClient
    {
        private HttpClient client
        {
            get
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                return new HttpClient(handler);
            }
        }
        public async Task<T> ExecutePostAsync<T>(string url, Dictionary<string, string> body = null, bool retry = true)
        {
            T response = default(T);
            try
            {
                var result = await client.PostAsync(url, new FormUrlEncodedContent(body));
                response = await ProcessHttpResponse(response, result);
            }
            catch (Exception ex)
            {
                throw;
            }
            return response;
        }
        public async Task<T> ExecutePostAsync<T>(string url, Dictionary<string, string> body = null, string accessToken = null, bool retry = true)
        {
            T response = default(T);
            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                HttpClient clientNew = new HttpClient(handler);
                clientNew.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                clientNew.DefaultRequestHeaders.Add("AccessToken", accessToken);

                var content = new StringContent(JsonConvert.SerializeObject(body), UnicodeEncoding.UTF8, "application/json");
                var result = await clientNew.PostAsync(url, content);

                response = await ProcessHttpResponse(response, result);

            }
            catch (Exception ex)
            {
            }
            return response;
        }

        private async Task<T> ProcessHttpResponse<T>(T response, HttpResponseMessage result)
        {
            var httpCallResult = await result.Content?.ReadAsStringAsync();

            if (result.IsSuccessStatusCode && httpCallResult != null)
            {
                response = JsonConvert.DeserializeObject<T>(httpCallResult);
            }
            else if (!result.IsSuccessStatusCode)
            {
                // Log the Exeception
                //new Exception(httpCallResult, new Exception(result.StatusCode.ToString()));
            }
            return response;
        }

    }
}
