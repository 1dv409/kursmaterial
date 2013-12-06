using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using GeekTweet.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Domain.Webservices
{
    public class TwitterWebservice
    {
        public User LookupUser(string screenName)
        {
            var rawJson = string.Empty;

            #region JSON from api.twitter.com

            //// Get access token.
            //var oAuthTwitterWrapper = new OAuthTwitterWrapper();
            //var accessToken = oAuthTwitterWrapper.GetAccessToken();

            //// Authorized call to Twitter's API (protected resources).
            //var requestUriString = String.Format("https://api.twitter.com/1.1/users/lookup.json?screen_name={0}", screenName);
            //var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            //request.Headers.Add("Authorization", String.Format("{0} {1}", accessToken.Type, accessToken.Token));
            //request.Method = "GET";
            //using (var response = request.GetResponse())
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{
            //    rawJson = reader.ReadToEnd();
            //}

            #endregion

            #region JSON from resource

            rawJson = GeekTweet.Domain.Properties.Resources.ScottGuUser;

            #endregion

            // Parse the JSON and return a user.
            return JArray.Parse(rawJson).Select(u => new User(u)).SingleOrDefault();
        }

        public List<Tweet> GetUserTimeLine(User user)
        {
            var rawJson = string.Empty;

            #region JSON from api.twitter.com

            //// Get access token.
            //var oAuthTwitterWrapper = new OAuthTwitterWrapper();
            //var accessToken = oAuthTwitterWrapper.GetAccessToken();

            //// Authorized call to Twitter's API (protected resources).
            //var requestUriString = String.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count=5", user.ScreenName);
            //var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            //request.Headers.Add("Authorization", String.Format("{0} {1}", accessToken.Type, accessToken.Token));
            //request.Method = "GET";
            //using (var response = request.GetResponse())
            //using (var reader = new StreamReader(response.GetResponseStream()))
            //{
            //    rawJson = reader.ReadToEnd();
            //}

            #endregion

            #region JSON from resource

            rawJson = GeekTweet.Domain.Properties.Resources.ScottGuTimeline;

            #endregion

            // Parse the JSON and return a list with tweets.
            return JArray.Parse(rawJson).Select(t => new Tweet(t, user)).ToList();
        }
    }
}