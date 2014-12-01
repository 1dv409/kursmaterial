using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace GeekTweet.Models.Webservices
{
    public class OAuthTwitterAccessToken
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }

        [JsonProperty("token_type")]
        public string Type { get; set; }
    }

    public class OAuthTwitterWrapper
    {
        /// <summary>
        /// Gets an access token from the service provider.
        /// </summary>
        /// <returns>Returns an OAuthTwitterAccessToken object containing the parsed OAuth response.</returns>
        public OAuthTwitterAccessToken GetAccessToken()
        {
            // Get settings from Web.config.
            var oAuthConsumerKey = ConfigurationManager.AppSettings["OAuthConsumerKey"];
            var oAuthConsumerSecret = ConfigurationManager.AppSettings["OAuthConsumerSecret"];
            var oAuthUrl = ConfigurationManager.AppSettings["OAuthUrl"];

            // Create OAuth request.
            var authorizationHeader = string.Format("Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    Uri.EscapeDataString(oAuthConsumerKey) + ":" + Uri.EscapeDataString((oAuthConsumerSecret)))
            ));

            var request = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            request.Headers.Add("Authorization", authorizationHeader);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream stream = request.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes("grant_type=client_credentials");
                stream.Write(content, 0, content.Length);
            }

            request.Headers.Add("Accept-Encoding", "gzip");

            // Request for an access token.
            OAuthTwitterAccessToken accessToken;
            using (var authResponse = request.GetResponse())
            using (var reader = new StreamReader(authResponse.GetResponseStream()))
            {
                accessToken = JsonConvert.DeserializeObject<OAuthTwitterAccessToken>(reader.ReadToEnd());
            }

            return accessToken;
        }
    }
}