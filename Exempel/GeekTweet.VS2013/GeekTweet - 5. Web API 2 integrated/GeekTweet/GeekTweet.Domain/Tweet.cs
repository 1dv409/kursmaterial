using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace GeekTweet.Domain
{
    public partial class Tweet
    {
        public Tweet()
        {
            // Empty!
        }

        public Tweet(JToken tweetToken, User user)
        {
            Text = tweetToken.Value<string>("text");
            CreatedAt = DateTime.ParseExact(tweetToken.Value<string>("created_at"),
                "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture);
            UserId = user.UserId;
            User = user;
        }
    }
}