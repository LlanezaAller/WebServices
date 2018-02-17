using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tachan.WS.Tools
{
    public static class Client
    {
        #region Methods

        public static HttpClient CreateClient()
        {
            return new HttpClient();
        }

        public static async Task<T> HttpGet<T>(this HttpClient client, string uri)
        {
            T result = default(T);

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }

            return result;
        }

        public static async Task<T> HttpPost<T>(this HttpClient client, string uri, NameValueCollection parameters)
        {
            T result = default(T);

            HttpResponseMessage response = await client.PostAsJsonAsync(uri, parameters);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }

            return result;
        }

        public static HttpClient SetMimeType(this HttpClient client, string mime)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mime));
            return client;
        }

        public static HttpClient AddAuthorizationHeader(this HttpClient client, string type, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(type, token);
            return client;
        }

        public static HttpClient SetUri(this HttpClient client, string uri)
        {
            client.BaseAddress = new Uri(uri);
            return client;
        }

        public static string WebGet(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        #endregion Methods
    }
}