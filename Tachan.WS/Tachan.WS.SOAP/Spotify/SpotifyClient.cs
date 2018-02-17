using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json;
using Tachan.WS.SOAP.Model;
using Tachan.WS.Tools;

namespace Tachan.WS.SOAP.Spotify
{
    public class SpotifyClient
    {
        private string token = string.Empty;

        public SpotifyClient()
        {
            token = GenerateValidToken();
        }

        public dynamic GetAlbum(string album)
        {
            var element = Client.CreateClient()
                .SetMimeType("application/json")
                .AddAuthorizationHeader("Bearer", token)
                .HttpGet<SpotifyWrapper>(CreateSpotifyUri(album)).Result;
            if (element == null)
            {
                GenerateValidToken();
                element = Client.CreateClient()
                    .SetMimeType("application/json")
                    .AddAuthorizationHeader("Bearer", token)
                    .HttpGet<SpotifyWrapper>(CreateSpotifyUri(album)).Result;
            }

            return element;
        }

        public string CreateSpotifyUri(string query = null)
        {
            if (query == null)
                return $"{WebConfigurationManager.AppSettings["TOKENURI"]}{query}";
            else
                return $"{WebConfigurationManager.AppSettings["SPOTIFYURI"]}search?type=album&q={query}";
        }

        public string GenerateValidToken()
        {
            NameValueCollection col = new NameValueCollection
            {
                {"grant_type", "client_credentials"}
            };

            var response = GetAccessToken();

            //var response = Client.CreateClient().SetMimeType("application/json").AddAuthorizationHeader("Basic", WebConfigurationManager.AppSettings["APIKEY"])
            //    .HttpPost<string>(CreateSpotifyUri(), col).Result;

            return response;
        }

        public string GetAccessToken()
        {
            SpotifyToken token = new SpotifyToken();

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(CreateSpotifyUri());

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + WebConfigurationManager.AppSettings["APIKEY"]);

            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    //should get back a string i can then turn to json and parse for accesstoken
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }

            token = JsonConvert.DeserializeObject<SpotifyToken>(json);

            return token.Access_Token;
        }
    }
}