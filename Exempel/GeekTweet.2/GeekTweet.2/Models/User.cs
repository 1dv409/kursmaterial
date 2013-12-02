using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeekTweet.Models
{
    public partial class User
    {
        public User(JToken userToken)
        {
            Id = (string)userToken["id_str"];
            Name = (string)userToken["name"];
            ScreenName = (string)userToken["screen_name"];
        }
    }
}