using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekTweet.Domain.Entities;

namespace GeekTweet.Domain.Abstract
{
    public interface IGeekTweetRepository : IDisposable
    {
        IEnumerable<Tweet> GetTweets();
        Tweet GetTweetById(int tweetId);
        void InsertTweet(Tweet tweet);
        void UpdateTweet(Tweet tweet);
        void DeleteTweet(int tweetId);

        IEnumerable<User> GetUsers();
        User GetUserById(int userId);
        User GetUserByScreenName(string screenname);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);

        IEnumerable<string> GetScreenNames(string term);

        void Save();
    }
}
