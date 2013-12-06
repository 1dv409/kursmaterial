using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Domain.Entities
{
    public partial class Tweet
    {
        public Tweet()
        {
            // Empty!
        }

        public Tweet(JToken tweetToken, User user)
        {
            Text = (string)tweetToken["text"];
            CreatedAt = DateTime.ParseExact((string)tweetToken["created_at"],
                "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture);
            UserId = user.UserId;
            User = user;
        }
    }
}