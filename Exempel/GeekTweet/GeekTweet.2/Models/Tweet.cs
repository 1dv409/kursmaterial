using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Models
{
    public partial class Tweet
    {
        public Tweet(JToken tweetToken)
        {
           // Name = (tweetToken["user"]["name"]).ToString();
            Text = (tweetToken["text"]).ToString();
            CreatedAt = DateTime.ParseExact((tweetToken["created_at"]).ToString(),
                "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture);
        }
    }
}