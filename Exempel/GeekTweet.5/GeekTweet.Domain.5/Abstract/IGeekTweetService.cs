using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekTweet.Domain.Entities;

namespace GeekTweet.Domain.Abstract
{
    public interface IGeekTweetService : IDisposable
    {
        IEnumerable<string> GetScreenNames(string term);
        IEnumerable<Tweet> GetTweets(string screenName);
    }
}
