using System;
using System.Collections.Generic;
using System.Linq;
using GeekTweet.Domain.Abstract;
using GeekTweet.Domain.DAL;
using GeekTweet.Domain.Entities;
using GeekTweet.Domain.Webservices;

namespace GeekTweet.Domain
{
    public class GeekTweetService : GeekTweetServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        public GeekTweetService()
            : this(new UnitOfWork())
        {
            // Empty!
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public GeekTweetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public override IEnumerable<string> GetScreenNames(string term)
        {
            var users = _unitOfWork.UserRepository.Get(u => u.ScreenName.Contains(term));
            return users
                .Select(u => u.ScreenName)
                .OrderBy(s => s)
                .ToList();

            //return _unitOfWork.UserRepository
            //    .Get(u => u.ScreenName.Contains(term))
            //    .Select(u => u.ScreenName)
            //    .OrderBy(s => s)
            //    .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="screenName"></param>
        /// <returns></returns>
        public override IEnumerable<Tweet> GetTweets(string screenName)
        {
            // Try to get the user from the database.
            var user = _unitOfWork.UserRepository
                .Get(u => u.ScreenName == screenName)
                .SingleOrDefault();

            // If there is no user in the database...
            if (user == null)
            {
                // ...get the user from the web service, and...
                var webservice = new TwitterWebservice();
                user = webservice.LookupUser(screenName);

                // ...save the changes in the repository to the database.
                this._unitOfWork.UserRepository.Insert(user);
                this._unitOfWork.Save();
            }

            // If there are no tweets or if it is time to uppdate the tweets...
            if (!user.Tweets.Any() || user.NextUpdate < DateTime.Now)
            {
                // ...delete the old(?) tweets (if there are any),...
                user.Tweets.ToList()
                    .ForEach(t => _unitOfWork.TweetRepository.Delete(t));

                // ...get the tweets from the web service, and insert them,...
                var webservice = new TwitterWebservice();
                webservice.GetUserTimeLine(user)
                    .ForEach(t => _unitOfWork.TweetRepository.Insert(t));

                // ...set the time of the next update and ...
                user.NextUpdate = DateTime.Now.AddMinutes(1);

                // ...save the changes in the repository to the database.
                _unitOfWork.Save();
            }

            return user.Tweets.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}