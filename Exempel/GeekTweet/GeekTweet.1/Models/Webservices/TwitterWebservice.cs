using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Models.Webservices
{
    public class TwitterWebservice
    {
        public List<Tweet> GetUserTimeLine(string screenName)
        {
            var rawJson = string.Empty;

            #region JSON from api.twitter.com

            //// Obtain access token to Twitter's API.

            //var oAuthConsumerKey = ConfigurationManager.AppSettings["OAuthConsumerKey"];
            //var oAuthConsumerSecret = ConfigurationManager.AppSettings["OAuthConsumerSecret"];
            //var oAuthUrl = ConfigurationManager.AppSettings["OAuthUrl"];

            //var authorizationHeader = string.Format("Basic {0}",
            //    Convert.ToBase64String(Encoding.UTF8.GetBytes(
            //        Uri.EscapeDataString(oAuthConsumerKey) + ":" + Uri.EscapeDataString((oAuthConsumerSecret)))
            //));

            //var oAuthRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            //oAuthRequest.Headers.Add("Authorization", authorizationHeader);
            //oAuthRequest.Method = "POST";
            //oAuthRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            //oAuthRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            //using (Stream stream = oAuthRequest.GetRequestStream())
            //{
            //    byte[] content = ASCIIEncoding.ASCII.GetBytes("grant_type=client_credentials");
            //    stream.Write(content, 0, content.Length);
            //}

            //oAuthRequest.Headers.Add("Accept-Encoding", "gzip");

            //dynamic accessToken;
            //using (WebResponse authResponse = oAuthRequest.GetResponse())
            //{
            //    using (authResponse)
            //    {
            //        using (var reader = new StreamReader(authResponse.GetResponseStream()))
            //        {
            //            var objectText = reader.ReadToEnd();
            //            accessToken = JsonConvert.DeserializeObject<dynamic>(objectText);
            //        }
            //    }
            //}

            //// Authorized call to Twitter's API.
            //var requestUriString = String.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count=5", screenName);
            //var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            //request.Headers.Add("Authorization", 
            //    String.Format("{0} {1}", accessToken["token_type"], accessToken["access_token"]));
            //request.Method = "GET";
            //using (var response = request.GetResponse())
            //{
            //    using (var reader = new StreamReader(response.GetResponseStream()))
            //    {
            //        rawJson = reader.ReadToEnd();
            //    }
            //}
            
            #endregion

            #region JSON from file

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/scottgu.json")))
            {
                rawJson = reader.ReadToEnd();
            }

            #endregion

            var tweetsArray = JArray.Parse(rawJson);

            return (from tweetToken in tweetsArray
                    select new Tweet(tweetToken)
                   ).ToList();
        }
    }
}