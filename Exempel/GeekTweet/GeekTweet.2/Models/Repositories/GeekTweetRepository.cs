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
        private GeekTweetEntities _entities = new GeekTweetEntities();

        // Tweet
        public override IQueryable<Tweet> QueryTweets()
        {
            return _entities.Tweets.AsQueryable();
        }

        public override void InsertTweet(Tweet tweet)
        {
            _entities.Tweets.Add(tweet);
        }

        public override void UpdateTweet(Tweet tweet)
        {
            _entities.Entry(tweet).State = EntityState.Modified;
        }

        public override void DeleteTweet(int tweetId)
        {
            throw new NotImplementedException();
        }

        // Query
        public override IQueryable<User> QueryUsers()
        {
            return _entities.Users.AsQueryable();
        }

        public override void InsertUser(User user)
        {
            _entities.Users.Add(user);
        }

        public override void UpdateUser(User user)
        {
            _entities.Entry(user).State = EntityState.Modified;
        }

        public override void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> FindDistinctScreenNames(string term)
        {
            return _entities.FindDistinctScreenNames(term).ToArray();
        }

        public override void Save()
        {
            _entities.SaveChanges();
        }

        // Dispose
        protected override void Dispose(bool disposing)
        {
            _entities.Dispose();
            base.Dispose(disposing);
        }
    }
}