using System.Web.Http;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Purple.Business;
using Purple.DAL.UnitOfWork;

namespace Purple.WebAPI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();            
            container.RegisterType<IPropertyBusiness, PropertyBusiness>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserBusiness, UserBusiness>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IOfferBusiness, OfferBusiness>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}