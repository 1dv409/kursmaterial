using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeekTweet.Models.Abstract
{
    public abstract class GeekTweetServiceBase : IGeekTweetService
    {
        #region IGeekTweetService Members

        public abstract IEnumerable<string> GetScreenNames(string term);
        public abstract IEnumerable<Tweet> GetTweets(string screenName);

        #endregion

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