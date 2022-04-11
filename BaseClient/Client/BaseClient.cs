using System;

namespace BaseClient
{
    using System;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Threading.Tasks;
    using System.Net.Http.Headers;
    using System.Collections.Generic;
    using BaseClientNS.Entities.Requests;

    namespace BaseClient.Client
    {
        public class BaseClient
        {
            private string Url { get; set; } = "https://localhost:44386/";
            private HttpClient Client;
            public BaseClient(string url) : this()
            {
                Url = url;
            }

            public BaseClient()
            {
                Client = new HttpClient();
            }

            public HttpResponseMessage HttpPost<T>(string requestUri, T requestBody) where T : TokenProvider
            {
                StringContent content = this.ConvertToJson(requestBody);
                Dictionary<string, string> headers = GetHeaders(requestBody);

                HttpResponseMessage response = SendHttpAsync(HttpMethod.Post, requestUri, content, null, headers);
                return response;
            }

            public HttpResponseMessage HttpGet<T>(string requestUri, T requestBody) where T : TokenProvider
            {
                StringContent content = this.ConvertToJson(requestBody);
                string queryParams = requestBody.GetUriParams();
                Dictionary<string, string> headers = GetHeaders(requestBody);

                HttpResponseMessage response = SendHttpAsync(HttpMethod.Get, requestUri, content, queryParams, headers);
                return response;
            }

            public HttpResponseMessage HttpPut<T>(string requestUri, T requestBody) where T : TokenProvider
            {
                StringContent content = this.ConvertToJson(requestBody);
                Dictionary<string, string> headers = GetHeaders(requestBody);

                HttpResponseMessage response = SendHttpAsync(HttpMethod.Put, requestUri, content, null, headers);
                return response;
            }

            public HttpResponseMessage HttpDelete<T>(string requestUri, T requestBody) where T : TokenProvider
            {
                StringContent content = this.ConvertToJson(requestBody);
                string queryParams = requestBody.GetUriParams();
                Dictionary<string, string> headers = GetHeaders(requestBody);

                HttpResponseMessage response = SendHttpAsync(HttpMethod.Delete, requestUri, content, queryParams, headers);
                return response;
            }

            private HttpResponseMessage SendHttpAsync(HttpMethod method, string requestUri, StringContent content, string queryParams = null, Dictionary<string, string> headers = null)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = method;
                request.RequestUri = new Uri(Url + requestUri);

                if (new List<HttpMethod>() { HttpMethod.Post, HttpMethod.Put }.Contains(method))
                {
                    request.Content = content;
                }

                if (new List<HttpMethod> { HttpMethod.Delete, HttpMethod.Get }.Contains(method))
                {
                    request.RequestUri = new Uri(Url + requestUri + "?" + queryParams);
                }

                if (headers != null)
                {
                    foreach (var header in headers)
                        request.Headers.Add(header.Key, header.Value);
                }

                HttpResponseMessage response = Task.Run(async () => await Client.SendAsync(request)).Result;

                return response;
            }

            public T ProcessResponse<T>(HttpResponseMessage jsonContent)
            {
                return JsonConvert.DeserializeObject<T>(jsonContent.Content.ReadAsStringAsync().Result);
            }

            private StringContent ConvertToJson<T>(T body)
            {
                return new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            }


            private Dictionary<string, string> GetHeaders<T>(T request) where T : TokenProvider
            {
                Dictionary<string, string> headers = new Dictionary<string, string>();

                if (!String.IsNullOrEmpty(request.Token))
                {
                    headers.Add("Authorization", "Bearer " + request.Token);
                }

                return headers;
            }
        }
    }
}
