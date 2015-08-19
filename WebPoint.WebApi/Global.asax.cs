using Castle.Windsor;
using Castle.Windsor.Installer;
using Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PayPoint.WebApi.DbContext;
using WebPoint.WebApi;


namespace PayPoint.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Initialise the dependency injection
            IWindsorContainer container = RegisterWindsorContainer();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Instruct Entity Framework to always upgrade database to latest migration
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PayPointDbContext, PayPoint.WebApi.DbContext.Configuration>());
        }

        #region Private Methods
        /// <summary>
        /// Registers the windsor container.
        /// </summary>
        /// <returns>
        /// The IoC container
        /// </returns>
        private static IWindsorContainer RegisterWindsorContainer()
        {
            // Create the windsor container and run all installers
            IWindsorContainer container = new WindsorContainer().Install(FromAssembly.This());

            // Setup the MVC DependencyResolver
            DependencyResolver.SetResolver(new WindsorDependencyResolver(container.Kernel));

            // Use an adapter to setup the WebApi Dependency 
            GlobalConfiguration.Configuration.DependencyResolver = DependencyResolver.Current.ToServiceResolver();
 
            return container;
        }

        #endregion
    }
}
