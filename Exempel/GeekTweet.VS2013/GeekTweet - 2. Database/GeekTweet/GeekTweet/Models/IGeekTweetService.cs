using System;
using System.Collections.Generic;

namespace GeekTweet.Models
{
    public interface IGeekTweetService : IDisposable
    {
        User GetUser(string screenName);
        void RefreshTweets(User user);
    }
}
