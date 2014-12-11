using GeekTweet.Domain.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

namespace GeekTweet.Domain.Webservices
{
    public class TwitterWebservice : ITwitterWebservice
    {
        public User LookupUser(string screenName)
        {
            var uriString = String.Format("https://api.twitter.com/1.1/users/lookup.json?screen_name={0}", screenName);
            var rawJson = DownloadJson(uriString);
            return JArray.Parse(rawJson).Select(u => new User(u)).SingleOrDefault();
        }

        public IEnumerable<Tweet> GetUserTimeline(User user)
        {
            var uriString = String.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&count=5", user.ScreenName);
            var rawJson = DownloadJson(uriString);
            return JArray.Parse(rawJson).Select(t => new Tweet(t, user)).ToList();
        }

        private static string DownloadJson(string uriString)
        {
            // Get access token.
            var oAuthApplicationAuthentication = new OAuthApplicationAuthentication();
            var authorizationString = oAuthApplicationAuthentication.GetAuthorizationString(
                ConfigurationManager.AppSettings["OAuthUrl"],
                ConfigurationManager.AppSettings["OAuthConsumerKey"], 
                ConfigurationManager.AppSettings["OAuthConsumerSecret"]);

            // Authorized call to Twitter's API (protected resources).
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", authorizationString);
                return client.DownloadString(uriString);
            }
        }

    }
}