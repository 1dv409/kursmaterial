using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTweet.Models.Abstract
{
    public interface IGeekTweetService : IDisposable
    {
        IEnumerable<Tweet> GetTweets(string screenName);
    }
}
