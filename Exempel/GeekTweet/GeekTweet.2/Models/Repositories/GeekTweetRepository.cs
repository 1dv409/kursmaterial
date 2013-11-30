using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GeekTweet.Models.Abstract;
using GeekTweet.Models.DataModels;

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

        public override void InsertTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
        }

        public override void UpdateTweet(Tweet tweet)
        {
            _context.Entry(tweet).State = EntityState.Modified;
        }

        public override void DeleteTweet(int tweetId)
        {
            Tweet tweet = _context.Tweets.Find(tweetId);
            _context.Tweets.Remove(tweet);
        }

        // Query
        protected override IQueryable<User> QueryUsers()
        {
            return _context.Users.AsQueryable();
        }

        public override void InsertUser(User user)
        {
            _context.Users.Add(user);
        }

        public override void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public override void DeleteUser(int userId)
        {
            User user = _context.Users.Find(userId);
            _context.Users.Remove(user);
        }

        public override void Save()
        {
            _context.SaveChanges();
        }

        // Dispose

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
    }
}