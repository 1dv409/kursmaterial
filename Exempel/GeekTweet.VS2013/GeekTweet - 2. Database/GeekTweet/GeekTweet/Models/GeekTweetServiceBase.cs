using System;
using System.Collections.Generic;

namespace GeekTweet.Models
{
    public abstract class GeekTweetServiceBase : IGeekTweetService
    {
        public abstract User GetUser(string screenName);
        public abstract void RefreshTweets(User user);

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