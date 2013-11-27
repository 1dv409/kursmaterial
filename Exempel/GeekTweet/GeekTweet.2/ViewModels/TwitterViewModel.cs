using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GeekTweet.Models;

namespace GeekTweet.ViewModels
{
    public class TwitterViewModel
    {
        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        public string ScreenName { get; set; }

        public ReadOnlyCollection<Tweet> Tweets { get; set; }
    }
}