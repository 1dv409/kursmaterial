using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Tweet
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int TweetId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Tweet()
        {
            // Empty!
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tweetToken"></param>
        /// <param name="user"></param>
        public Tweet(JToken tweetToken, User user)
        {
            Text = (string)tweetToken["text"];
            CreatedAt = DateTime.ParseExact((string)tweetToken["created_at"],
                "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture);
            UserId = user.UserId;
            User = user;
        }
    }
}