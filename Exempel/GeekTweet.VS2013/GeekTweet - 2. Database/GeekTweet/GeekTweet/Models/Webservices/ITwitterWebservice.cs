using System;
using System.Collections.Generic;

namespace GeekTweet.Models.Webservices
{
    public interface ITwitterWebservice
    {
        IEnumerable<Tweet> GetUserTimeline(User user);
        User LookupUser(string screenName);
    }
}
