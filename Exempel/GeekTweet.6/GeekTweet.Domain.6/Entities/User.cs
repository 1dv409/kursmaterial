using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime NextUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Tweet> Tweets { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public User()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userToken"></param>
        public User(JToken userToken)
        {
            Id = (string)userToken["id_str"];
            Name = (string)userToken["name"];
            ScreenName = (string)userToken["screen_name"];

            this.Tweets = new HashSet<Tweet>();
        }
    }
}