using System;
using GeekTweet.Domain.Entities;

namespace GeekTweet.Domain.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Tweet> TweetRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        void Save();
    }
}
