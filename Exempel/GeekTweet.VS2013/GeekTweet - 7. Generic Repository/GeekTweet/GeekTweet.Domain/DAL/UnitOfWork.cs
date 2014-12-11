using System;
using GeekTweet.Domain.Entities;
using System.Data.Entity;

namespace GeekTweet.Domain.DAL
{
    internal class UnitOfWork : IUnitOfWork
    {
        private DbContext _context = new GeekTweetContext();
        private IGenericRepository<Tweet> _tweetRepository;
        private IGenericRepository<User> _userRepository;

        public IGenericRepository<Tweet> TweetRepository
        {
            get { return _tweetRepository ?? (_tweetRepository = new GenericRepository<Tweet>(_context)); }
        }

        public IGenericRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new GenericRepository<User>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
