using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekTweet.Domain.Entities
{
    public class User //: IValidatableObject
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public DateTime NextUpdate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ScreenName { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }

        public User()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public User(JToken userToken)
            : this()
        {
            Id = userToken.Value<string>("id_str");
            Name = userToken.Value<string>("name");
            ScreenName = userToken.Value<string>("screen_name");
        }

        //// This will only be called if no one of the validation attributes triggers.
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (NextUpdate < DateTime.Today)
        //    {
        //        yield return new ValidationResult("The date can't bee too past.", new string[] { "NextUpdate" });
        //    }
        //}

    }
}