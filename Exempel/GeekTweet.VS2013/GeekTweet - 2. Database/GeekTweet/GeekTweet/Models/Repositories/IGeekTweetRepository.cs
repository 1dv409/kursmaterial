using System;
using System.Collections.Generic;

namespace GeekTweet.Models.Repositories
{
    public interface IGeekTweetRepository : IDisposable
    {
        IEnumerable<Tweet> FindAllTweets();
        Tweet FindTweetById(int id);
        void AddTweet(Tweet tweet);
        void UpdateTweet(Tweet tweet);
        void RemoveTweet(int id);

        IEnumerable<User> FindAllUsers();
        User FindUserById(int id);
        User FindUserByScreenName(string screenName);
        void AddUser(User user);
        void UpdateUser(User user);
        void RemoveUser(int id);

        void Save();
    }
}
