using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Models
{
    public class Tweet
    {
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }

        public Tweet(JToken tweetToken)
        {
            Name = (tweetToken["user"]["name"]).ToString();
            Text = (tweetToken["text"]).ToString();
            CreatedAt = DateTime.ParseExact((tweetToken["created_at"]).ToString(),
                "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture);
        }
    }
}