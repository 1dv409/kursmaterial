using Microsoft.Practices.Unity;
using NextBirthdayUnity.Models.Repositories;
using System.Web.Mvc;
using Unity.Mvc5;

namespace NextBirthdayUnity
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IRepository, EFRepository>(new HierarchicalLifetimeManager());

            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}