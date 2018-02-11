using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebService.Client
{
    public static class Client
    {
        private static async Task<T> Get<T>(this HttpClient client, string uri)
        {
            T result = default(T);

            HttpResponseMessage response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }

            return result;
        }

        public static HttpClient CreateClient()
        {
            return new HttpClient();
        }

        public static HttpClient SetUri(this HttpClient client, string uri)
        {
            client.BaseAddress = new Uri(uri);
            return client;
        }

        public static HttpClient SetMimeType(this HttpClient client, string mime)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mime));
            return client;
        }
    }
}
