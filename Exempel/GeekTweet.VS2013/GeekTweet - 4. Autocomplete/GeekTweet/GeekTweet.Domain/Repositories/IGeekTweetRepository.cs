using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTweet.Domain.Repositories
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

        IEnumerable<string> GetScreenNames(string term);

        void Save();
    }
}
