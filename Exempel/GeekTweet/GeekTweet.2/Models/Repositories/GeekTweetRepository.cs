using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeekTweet.Models.Abstract;

namespace GeekTweet.Models.Repositories
{
    public class GeekTweetRepository : GeekTweetRepositoryBase
    {
        // Tweet
        public override IQueryable<Tweet> QueryTweets()
        {
            throw new NotImplementedException();
        }

        public override void InsertTweet(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public override void UpdateTweet(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public override void DeleteTweet(int tweetId)
        {
            throw new NotImplementedException();
        }

        // Query
        public override IQueryable<User> QueryUsers()
        {
            throw new NotImplementedException();
        }

        public override void InsertUser(User user)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public override void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        // Dispose
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}