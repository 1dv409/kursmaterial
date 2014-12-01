using System;

namespace GeekTweet.Domain
{
    public interface IGeekTweetService : IDisposable
    {
        User GetUser(string screenName);
        void RefreshTweets(User user);
    }
}
