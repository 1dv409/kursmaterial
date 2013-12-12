using System;
using System.Collections.Generic;
using GeekTweet.Domain.Entities;

namespace GeekTweet.Domain.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGeekTweetService : IDisposable
    {
        IEnumerable<string> GetScreenNames(string term);
        IEnumerable<Tweet> GetTweets(string screenName);
    }
}
