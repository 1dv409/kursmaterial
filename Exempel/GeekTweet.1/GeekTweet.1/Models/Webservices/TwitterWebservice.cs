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
        public IEnumerable<Tweet> GetUserTimeLine(string screenName)
        {
            var rawJson = string.Empty;

            #region JSON from api.twitter.com

            //// Get access token.
            //var oAuthTwitterWrapper = new OAuthTwitterWrapper();
            //var accessToken = oAuthTwitterWrapper.GetAccessToken();

            //// Authorized call to Twitter's API (protected resources).
            //var requestUriString = String.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count=5", screenName);
            //var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            //request.Headers.Add("Authorization", String.Format("{0} {1}", accessToken.Type, accessToken.Token));
            
            //using (var response = request.GetResponse())
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{
            //    rawJson = reader.ReadToEnd();
            //}

            #endregion

            #region JSON from file

            //dynamic parsedJson = JsonConvert.DeserializeObject(rawJson);
            //using (var writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/App_Data/scottgu_timeline.json")))
            //{
            //    writer.WriteLine(JsonConvert.SerializeObject(parsedJson, Formatting.Indented));
            //}

            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/scottgu_timeline.json")))
            {
                rawJson = reader.ReadToEnd();
            }

            #endregion

            // Parse the JSON and return a list with tweets.
            return JArray.Parse(rawJson).Select(t => new Tweet(t)).ToList();
        }
    }
}