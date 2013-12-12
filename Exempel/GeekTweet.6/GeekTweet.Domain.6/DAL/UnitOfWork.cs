using System;
using GeekTweet.Domain.Abstract;
using GeekTweet.Domain.Entities;

namespace GeekTweet.Domain.DAL
{
    /// <summary>
    /// 
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        private GeekTweetContext _context = new GeekTweetContext();

        /// <summary>
        /// 
        /// </summary>
        private IRepository<Tweet> _tweetRepository;

        /// <summary>
        /// 
        /// </summary>
        private IRepository<User> _userRepository;

        /// <summary>
        /// 
        /// </summary>
        public IRepository<Tweet> TweetRepository
        {
            get
            {
                return _tweetRepository ?? (_tweetRepository = new Repository<Tweet>(_context));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IRepository<User> UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new Repository<User>(_context));
            }
        }

        /// <summary>
        /// Saves all changes made in the unit of work to the underlying database.
        /// </summary>
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
