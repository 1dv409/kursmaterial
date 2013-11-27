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

            // Authorized call to Twitter's API.
            var requestUriString = String.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count=5", screenName);
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Headers.Add("Authorization",
                String.Format("{0} {1}", accessToken["token_type"], accessToken["access_token"]));
            request.Method = "GET";
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            #endregion

            #region JSON from file

            //using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/scottgu.json")))
            //{
            //    rawJson = reader.ReadToEnd();
            //}

            #endregion

            var tweetsArray = JArray.Parse(rawJson);

            return (from tweetToken in tweetsArray
                    select new Tweet(tweetToken)
                   ).ToList();
        }
    }
}