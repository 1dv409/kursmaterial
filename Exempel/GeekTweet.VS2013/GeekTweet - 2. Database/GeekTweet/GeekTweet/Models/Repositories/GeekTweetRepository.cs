using GeekTweet.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeekTweet.Models.Repositories
{
    public class GeekTweetRepository : GeekTweetRepositoryBase
    {
        private GeekTweetEntities _context = new GeekTweetEntities();

        // Tweet
        protected override IQueryable<Tweet> QueryTweets()
        {
            return _context.Tweets.AsQueryable();
        }

        public override void AddTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
        }

        public override void UpdateTweet(Tweet tweet)
        {
            _context.Entry(tweet).State = EntityState.Modified;
        }

        public override void RemoveTweet(int id)
        {
            Tweet tweet = _context.Tweets.Find(id);
            _context.Tweets.Remove(tweet);
        }

        // User
        protected override IQueryable<User> QueryUsers()
        {
            return _context.Users.AsQueryable();
        }

        public override void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public override void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public override void RemoveUser(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
        }

        // Context
        public override void Save()
        {
            _context.SaveChanges();
        }

        #region IDisposable

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;

            base.Dispose(disposing);
        }

        #endregion
    }
}