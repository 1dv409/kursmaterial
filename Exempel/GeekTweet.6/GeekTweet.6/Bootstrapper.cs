using System.Web.Mvc;
using GeekTweet.Domain;
using GeekTweet.Domain.Abstract;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace GeekTweet
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // Use the parameterless constructor of the GeekTweetService class.
            container.RegisterType<IGeekTweetService, GeekTweetService>(new InjectionConstructor());

            //// Use the constructor of the GeekTweetService class with the parameter 
            //// of the type IUnitOfWork (if there is no parameterless constructor,
            //// UnitOfWork is internal and need to be public).
            //container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IGeekTweetService, GeekTweetService>();
        }
    }
}