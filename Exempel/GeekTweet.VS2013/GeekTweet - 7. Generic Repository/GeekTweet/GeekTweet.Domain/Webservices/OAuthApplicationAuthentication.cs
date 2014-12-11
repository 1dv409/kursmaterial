using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace GeekTweet.Domain
{
    public class OAuthApplicationAuthentication
    {
        /// <summary>
        /// Gets an access token from the service provider.
        /// </summary>
        /// <returns>Returns an OAuthTwitterAccessToken object containing the parsed OAuth response.</returns>
        public string GetAuthorizationString(string oAuthUrl, string oAuthConsumerKey, string oAuthConsumerSecret)
        {
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
            using (var authResponse = request.GetResponse())
            using (var reader = new StreamReader(authResponse.GetResponseStream()))
            {
                return JsonConvert.DeserializeObject<OAuthTwitterAccessToken>(reader.ReadToEnd()).ToString();
            }

            // TODO: Använd, om möjligt på ett enkelt sätt, instans av WebClient istället för WebRequest.
            //using (var client = new WebClient())
            //{
            //    var authorizationHeader = string.Format("Basic {0}",
            //        Convert.ToBase64String(Encoding.UTF8.GetBytes(
            //            Uri.EscapeDataString(oAuthConsumerKey) + ":" + Uri.EscapeDataString((oAuthConsumerSecret)))
            //    ));
            //    client.Headers.Add("Authorization", authorizationHeader);
            //    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            //    client.Headers.Add("Accept-Encoding", "gzip");

            //    var response = client.UploadString(oAuthUrl, "grant_type=client_credentials");

            //    return JsonConvert.DeserializeObject<OAuthTwitterAccessToken>(response);
            //}
        }

        private class OAuthTwitterAccessToken
        {
            [JsonProperty("access_token")]
            public string Token { get; set; }

            [JsonProperty("token_type")]
            public string Type { get; set; }

            public override string ToString()
            {
                return String.Format("{0} {1}", Type, Token);
            }
        }
    }
}