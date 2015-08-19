using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PayPoint.WebUI.Repository.Culture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace PayPoint.WebUI.Installers
{
    public class WindsorInstaller : IWindsorInstaller
    {
        #region Public Methods

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register the controllers
            container.Register(
                Classes.FromThisAssembly()
                       .BasedOn<IController>()
                       .LifestylePerWebRequest());

            // Register any repositories
            RegisterRepositories(container);
        }

        #endregion

        #region Private Methods

        private void RegisterRepositories(IWindsorContainer container)
        {
            container.Register(
                Component.For<ICultureRepository>().ImplementedBy<CultureRepository>()
                .LifeStyle.Transient);
        }

        #endregion
    }
}