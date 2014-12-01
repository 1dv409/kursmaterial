using Newtonsoft.Json.Linq;

namespace GeekTweet.Domain
{
    public partial class User
    {
        public User(JToken userToken)
        {
            Id = userToken.Value<string>("id_str");
            Name = userToken.Value<string>("name");
            ScreenName = userToken.Value<string>("screen_name");
        }
    }
}