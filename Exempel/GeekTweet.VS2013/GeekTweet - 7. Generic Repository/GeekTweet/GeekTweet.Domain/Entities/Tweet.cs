using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace GeekTweet.Domain.Entities
{
    public class Tweet
    {
        [Key]
        public int TweetId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Tweet()
        {
            // Empty!
        }

        public Tweet(JToken tweetToken, User user)
        {
            Text = tweetToken.Value<string>("text");
            CreatedAt = DateTime.ParseExact(tweetToken.Value<string>("created_at"),
                "ddd MMM dd HH:mm:ss zz00 yyyy", CultureInfo.InvariantCulture);
            UserId = user.UserId;
            User = user;
        }
    }
}