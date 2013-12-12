using System.Web.Http;

namespace GeekTweet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ScreenNameApi",
                routeTemplate: "api/screenname/{term}",
                defaults: new { controller = "ScreenName" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
