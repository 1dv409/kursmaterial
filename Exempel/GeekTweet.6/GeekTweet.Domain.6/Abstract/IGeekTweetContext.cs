using System.Data.Entity;
using GeekTweet.Domain.Entities;

namespace GeekTweet.Domain.Abstract
{
    public interface IGeekTweetContext
    {
        IDbSet<Tweet> Tweets { get; set; }
        IDbSet<User> Users { get; set; }
    }
}
