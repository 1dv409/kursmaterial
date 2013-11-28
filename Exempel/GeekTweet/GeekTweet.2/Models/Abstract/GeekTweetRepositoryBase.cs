using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekTweet.Models.Abstract
{
    public abstract class GeekTweetRepositoryBase : IGeekTweetRepository
    {
        #region IGeekTweetRepository Members

        // Tweet
        public abstract IQueryable<Tweet> QueryTweets();

        public IEnumerable<Tweet> GetTweets()
        {
            return QueryTweets().ToList();
        }

        public Tweet GetTweetById(int tweetId)
        {
            return QueryTweets().SingleOrDefault(t => t.TweetId == tweetId);
        }

        public abstract void InsertTweet(Tweet tweet);
        public abstract void UpdateTweet(Tweet tweet);
        public abstract void DeleteTweet(int tweetId);

        // User
        public abstract IQueryable<User> QueryUsers();

        public IEnumerable<User> GetUsers()
        {
            return QueryUsers().ToList();
        }

        public User GetUserById(int userId)
        {
            return QueryUsers().SingleOrDefault(u => u.UserId == userId);
        }

        public abstract void InsertUser(User user);
        public abstract void UpdateUser(User user);
        public abstract void DeleteUser(int userId);

        public abstract IEnumerable<string> FindDistinctScreenNames(string term);

        public abstract void Save();

        #endregion

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}