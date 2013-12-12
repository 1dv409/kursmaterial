using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using GeekTweet.Domain.Entities;

namespace GeekTweet.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class TwitterIndexViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        public string ScreenName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HasTweets
        {
            get { return Tweets != null && Tweets.Any(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return User != null ? User.Name : "[Unknown]";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Tweet> Tweets { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User User
        {
            get
            {
                return HasTweets ? Tweets.First().User : null;
            }
        }
    }
}