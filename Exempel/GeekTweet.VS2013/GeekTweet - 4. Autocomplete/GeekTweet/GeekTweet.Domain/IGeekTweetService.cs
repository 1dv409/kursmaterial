using System;
using System.Collections.Generic;

namespace GeekTweet.Domain
{
    public interface IGeekTweetService : IDisposable
    {
        IEnumerable<string> GetScreenNames(string term);
        User GetUser(string screenName);
        void RefreshTweets(User user);
    }
}
