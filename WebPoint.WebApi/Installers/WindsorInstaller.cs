using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using PayPoint.WebApi.Providers.Culture;
using PayPoint.WebApi.Services;
using System.Web.Mvc;

namespace WebPoint.WebApi.Installers
{
    public class WindsorInstaller : IWindsorInstaller
    {
        #region Public Methods

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register the IHttpControllers (for web api controllers)
            container.Register(
                Classes.FromThisAssembly()
                .BasedOn<IHttpController>()
                .LifestylePerWebRequest());

             // Register any providers
            RegisterProviders(container);

            // Register any services
            RegisterServices(container);
        }

        #endregion

        #region Private Methods

        private void RegisterProviders(IWindsorContainer container)
        {
            container.Register(
                Component.For<ICultureProvider>().ImplementedBy<CultureProvider>()
                .LifeStyle.Transient);
        }

        private void RegisterServices(IWindsorContainer container)
        {
            container.Register(
                Component.For<ICultureService>().ImplementedBy<CultureService>()
                .LifeStyle.Transient);
        }

        #endregion
    }
}