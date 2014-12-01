using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekTweet.Models.Repositories
{
    public abstract class GeekTweetRepositoryBase : IGeekTweetRepository
    {
        // Tweet
        protected abstract IQueryable<Tweet> QueryTweets();

        public IEnumerable<Tweet> FindAllTweets()
        {
            return QueryTweets().ToList();
        }

        public Tweet FindTweetById(int id)
        {
            return QueryTweets().SingleOrDefault(t => t.TweetId == id);
        }

        public abstract void AddTweet(Tweet tweet);
        public abstract void UpdateTweet(Tweet tweet);
        public abstract void RemoveTweet(int id);

        // User
        protected abstract IQueryable<User> QueryUsers();

        public IEnumerable<User> FindAllUsers()
        {
            return QueryUsers().ToList();
        }

        public User FindUserById(int id)
        {
            return QueryUsers().SingleOrDefault(u => u.UserId == id);
        }

        public User FindUserByScreenName(string screenName)
        {
            return QueryUsers().SingleOrDefault(u => u.ScreenName == screenName);
        }

        public abstract void AddUser(User user);
        public abstract void UpdateUser(User user);
        public abstract void RemoveUser(int id);

        public abstract void Save();

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