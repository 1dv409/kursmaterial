using GeekTweet.Domain.DAL;
using GeekTweet.Domain.Entities;
using GeekTweet.Domain.Webservices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekTweet.Domain
{
    public class GeekTweetService : IGeekTweetService
    {
        private IUnitOfWork _unitOfWork;
        private ITwitterWebservice _webservice;

        public GeekTweetService()
            : this(new UnitOfWork(), new TwitterWebservice())
        {
            // Empty!
        }

        public GeekTweetService(IUnitOfWork unitOfWork, ITwitterWebservice webservice)
        {
            _unitOfWork = unitOfWork;
            _webservice = webservice;
        }

        public IEnumerable<string> GetScreenNames(string term)
        {
            return _unitOfWork.UserRepository
                .Get(u => u.ScreenName.Contains(term))
                .Select(u => u.ScreenName)
                .OrderBy(s => s)
                .ToList();
        }

        public User GetUser(string screenName)
        {
            // Try to get the user from the database.
            var user = _unitOfWork.UserRepository
                .Get(u => u.ScreenName == screenName)
                .SingleOrDefault();

            // If there is no user...
            if (user == null)
            {
                // ...get the user from the web service, and...
                user = _webservice.LookupUser(screenName);

                // ...save the changes to the database.
                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Save();
            }

            return user;
        }

        public void RefreshTweets(User user)
        {
            // If there are no tweets or if it is time to uppdate the tweets...
            if (!user.Tweets.Any() || user.NextUpdate < DateTime.Now)
            {
                // ...delete the old(?) tweets (if there are any),...
                foreach (var tweet in user.Tweets.ToList())
                {
                    _unitOfWork.TweetRepository.Remove(tweet.TweetId);
                }

                // ...get the tweets from the web service, and insert them,...
                foreach (var tweet in _webservice.GetUserTimeline(user))
                {
                    _unitOfWork.TweetRepository.Add(tweet);
                }

                // ...set the time of the next update and ...
                user.NextUpdate = DateTime.Now.AddMinutes(1);

                // ...save the changes to the database.
                _unitOfWork.Save();
            }
        }

        #region IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}