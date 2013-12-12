using System.Web.Http;
using GeekTweet.Domain;
using GeekTweet.Domain.Abstract;
using Microsoft.Practices.Unity;
using Unity.WebApi;

namespace GeekTweet
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Use the parameterless constructor of the GeekTweetService class.
            container.RegisterType<IGeekTweetService, GeekTweetService>(new InjectionConstructor());

            //// Use the constructor of the GeekTweetService class with the parameter 
            //// of the type IUnitOfWork (if there is no parameterless constructor,
            //// UnitOfWork is internal and need to be public).
            //container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IGeekTweetService, GeekTweetService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}