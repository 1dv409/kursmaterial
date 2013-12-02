using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GeekTweet.Models.Abstract;
using GeekTweet.Models.Repositories;
using GeekTweet.Models.Webservices;

namespace GeekTweet.Models
{
    public class GeekTweetService : GeekTweetServiceBase
    {
        private IGeekTweetRepository _repository;

        public GeekTweetService()
            : this(new GeekTweetRepository())
        {
            // Empty!
        }

        public GeekTweetService(IGeekTweetRepository repository)
        {
            _repository = repository;
        }

        public override IEnumerable<Tweet> GetTweets(string screenName)
        {
            // Try to get the user from the database.
            var user = _repository.GetUserByScreenName(screenName);

            // If there is no user...
            if (user == null)
            {
                // ...get the user from the web service, and...
                var webservice = new TwitterWebservice();
                user = webservice.LookupUser(screenName);

                // ...save the changes in the repository to the database.
                this._repository.InsertUser(user);
                this._repository.Save();
            }

            // If there are no tweets or if it is time to uppdate the tweets...
            if (!user.Tweets.Any() || user.NextUpdate < DateTime.Now)
            {
                // ...delete the old(?) tweets (if there are any),...
                user.Tweets.ToList().ForEach(t => _repository.DeleteTweet(t.TweetId));

                // ...get the tweets from the web service, and insert them,...
                var webservice = new TwitterWebservice();
                webservice.GetUserTimeLine(user).ForEach(t => _repository.InsertTweet(t));

                // ...set the time of the next update and ...
                user.NextUpdate = DateTime.Now.AddMinutes(1);

                // ...save the changes in the repository to the database.
                _repository.Save();
            }

            return user.Tweets.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}