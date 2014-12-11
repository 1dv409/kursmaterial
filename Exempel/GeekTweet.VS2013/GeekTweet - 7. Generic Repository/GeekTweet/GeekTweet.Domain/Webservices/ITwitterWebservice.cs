using GeekTweet.Domain.Entities;
using System.Collections.Generic;

namespace GeekTweet.Domain.Webservices
{
    public interface ITwitterWebservice
    {
        IEnumerable<Tweet> GetUserTimeline(User user);
        User LookupUser(string screenName);
    }
}
