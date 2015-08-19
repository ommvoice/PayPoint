namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Castle.MicroKernel;

    /// <summary>
    /// Castle windsor implementation of IDependencyResolver interface
    /// </summary>
    public class WindsorDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        #region Fields and Constants

        /// <summary>
        /// The Castle Windsor kernel
        /// </summary>
        private readonly IKernel kernel;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorDependencyResolver"/> class.
        /// </summary>
        /// <param name="kernel">The Castle Windsor kernel.</param>
        public WindsorDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Resolves singly registered services that support arbitrary object creation.
        /// </summary>
        /// <param name="serviceType">The type of the requested service or object.</param>
        /// <returns>The requested service or object.</returns>
        public object GetService(Type serviceType)
        {
            return this.kernel.HasComponent(serviceType) ? this.kernel.Resolve(serviceType) : null;
        }

        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>The requested services.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.ResolveAll(serviceType) as IEnumerable<object>;
        }

        #endregion
    }
}
