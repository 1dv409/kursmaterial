using System;
using GeekTweet.Domain.Entities;
namespace GeekTweet.Domain.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Tweet> TweetRepository { get; }
        IRepository<User> UserRepository { get; }
        void Save();
    }
}
