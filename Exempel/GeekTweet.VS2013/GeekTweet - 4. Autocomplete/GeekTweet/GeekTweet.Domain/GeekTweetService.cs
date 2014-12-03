using GeekTweet.Domain.Repositories;
using GeekTweet.Domain.Webservices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekTweet.Domain
{
    public class GeekTweetService : GeekTweetServiceBase
    {
        private IGeekTweetRepository _repository;
        private ITwitterWebservice _webservice;

        public GeekTweetService()
            : this(new GeekTweetRepository(), new TwitterWebservice())
        {
            // Empty!
        }

        public GeekTweetService(IGeekTweetRepository repository, ITwitterWebservice webservice)
        {
            _repository = repository;
            _webservice = webservice;
        }

        public override IEnumerable<string> GetScreenNames(string term)
        {
            return _repository.GetScreenNames(term);
        }

        public override User GetUser(string screenName)
        {
            // Try to get the user from the database.
            var user = _repository.FindUserByScreenName(screenName);

            // If there is no user...
            if (user == null)
            {
                // ...get the user from the web service, and...
                user = _webservice.LookupUser(screenName);

                // ...save the changes in the repository to the database.
                _repository.AddUser(user);
                _repository.Save();
            }

            return user;
        }

        public override void RefreshTweets(User user)
        {
            // If there are no tweets or if it is time to uppdate the tweets...
            if (!user.Tweets.Any() || user.NextUpdate < DateTime.Now)
            {
                // ...delete the old(?) tweets (if there are any),...
                foreach (var tweet in user.Tweets.ToList())
                {
                    _repository.RemoveTweet(tweet.TweetId);
                }

                // ...get the tweets from the web service, and insert them,...
                foreach (var tweet in _webservice.GetUserTimeline(user))
                {
                    _repository.AddTweet(tweet);
                }

                // ...set the time of the next update and ...
                user.NextUpdate = DateTime.Now.AddMinutes(1);

                // ...save the changes in the repository to the database.
                _repository.Save();
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}