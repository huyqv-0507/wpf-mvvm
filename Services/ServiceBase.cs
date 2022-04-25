using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WpfAppLogin.Services
{
    public class ServiceBase<T> where T: class
    {
        private static string _baseDomain = APIConst.BASE_DOMAIN;
        private static HttpClient GetHttpClient(string contentType = null)
        {
            string authorization = null;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            if (contentType != null)
            {
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(contentType)
            );
            }
            if (authorization != null)
            {
                client.DefaultRequestHeaders
                    .Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authorization);
            }
            return client;
        }
        public static async Task<T> DoGet(
            string url,
            Dictionary<string, string> requestContent = null,
            string contentType = null,
            Dictionary<string, string> queryParams = null)
        {
            if (queryParams != null)
            {
                url = QueryHelpers.AddQueryString(url, queryParams);
            }
            HttpClient client = GetHttpClient(contentType);
            HttpRequestMessage request = new HttpRequestMessage(
               HttpMethod.Get, _baseDomain + url);

            if (requestContent != null)
            {
                request.Content = GetHttpContent(requestContent, contentType);
            }
            var response = await client.SendAsync(request);
            string stringResponse = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(stringResponse);
            return result;
        }
        public static async Task<T> DoPost(
            string url,
            Dictionary<string, string> requestContent = null,
            string contentType = null,
            Dictionary<string, string> queryParams = null)
        {
            if (queryParams != null)
            {
                url = QueryHelpers.AddQueryString(url, queryParams);
            }
            HttpClient client = GetHttpClient(contentType);
            HttpRequestMessage request = new HttpRequestMessage(
               HttpMethod.Post, _baseDomain + url);
            
            if (requestContent != null)
            {
                request.Content = GetHttpContent(requestContent, contentType);
            }
            var response = await client.SendAsync(request);
            string stringResponse = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(stringResponse);
            return result;
        }
        public static void DoPut() { }
        public static void DoDelete() { }

        private static HttpContent GetHttpContent(Dictionary<string, string> requestContent, string contentType)
        {
            if (contentType == APIConst.ContentType.APPLICATION_FORM_URLENCODED)
            {
                return new FormUrlEncodedContent(requestContent);
            }
            else
            {
                return JsonContent.Create(requestContent);
            }
        }

    }
}
