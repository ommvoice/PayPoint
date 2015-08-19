using Castle.Windsor;
using Castle.Windsor.Installer;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PayPoint.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Initialise the dependency injection
            IWindsorContainer container = RegisterWindsorContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        #region Private Methods

        /// <summary>
        /// Registers the Windsor container.
        /// </summary>
        /// <returns>
        /// The IoC container
        /// </returns>
        private static IWindsorContainer RegisterWindsorContainer()
        {
            // Create the Windsor container and run all installers
            IWindsorContainer container = new WindsorContainer().Install(FromAssembly.This());

            // Setup the MVC DependencyResolver
            DependencyResolver.SetResolver(new WindsorDependencyResolver(container.Kernel));

            // Use an adapter to setup the WebApi Dependency 
            //GlobalConfiguration.Configuration.DependencyResolver = DependencyResolver.Current.ToServiceResolver();

            return container;
        }

        #endregion

    }
}
