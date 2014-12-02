using Newtonsoft.Json.Linq;

namespace GeekTweet.Models
{
    public partial class User
    {
        public User(JToken userToken)
            : this()
        {
            Id = (string)userToken["id_str"];
            Name = (string)userToken["name"];
            ScreenName = (string)userToken["screen_name"];
        }
    }
}