using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace GeekTweet.Models.Webservices
{
    public class OAuthTwitterWrapper
    {
        public dynamic GetAccessToken()
        {
            // Obtain access token to Twitter's API.

            var oAuthConsumerKey = ConfigurationManager.AppSettings["OAuthConsumerKey"];
            var oAuthConsumerSecret = ConfigurationManager.AppSettings["OAuthConsumerSecret"];
            var oAuthUrl = ConfigurationManager.AppSettings["OAuthUrl"];

            var authorizationHeader = string.Format("Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    Uri.EscapeDataString(oAuthConsumerKey) + ":" + Uri.EscapeDataString((oAuthConsumerSecret)))
            ));

            var oAuthRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            oAuthRequest.Headers.Add("Authorization", authorizationHeader);
            oAuthRequest.Method = "POST";
            oAuthRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            oAuthRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (Stream stream = oAuthRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes("grant_type=client_credentials");
                stream.Write(content, 0, content.Length);
            }

            oAuthRequest.Headers.Add("Accept-Encoding", "gzip");

            dynamic accessToken;
            using (var authResponse = oAuthRequest.GetResponse())
            using (var reader = new StreamReader(authResponse.GetResponseStream()))
            {
                var objectText = reader.ReadToEnd();
                accessToken = JsonConvert.DeserializeObject<dynamic>(objectText);
            }

            return accessToken;
        }
    }
}