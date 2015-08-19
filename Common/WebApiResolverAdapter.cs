namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    /// <summary>
    /// An adapter class that allows the webapi DependencyResolver to use the MVC DependencyResolver
    /// </summary>
    public sealed class WebApiResolverAdapter : IDependencyResolver
    {
        #region Fields and Constants

        /// <summary>
        /// The MVC dependency resolver
        /// </summary>
        private readonly System.Web.Mvc.IDependencyResolver dependencyResolver;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiResolverAdapter"/> class.
        /// </summary>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        public WebApiResolverAdapter(System.Web.Mvc.IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Resolves an interface to a concrete implementation
        /// </summary>
        /// <param name="serviceType">The type to resolve</param>
        /// <returns>A concrete implementation</returns>
        public object GetService(Type serviceType)
        {
            return this.dependencyResolver.GetService(serviceType);
        }

        /// <summary>
        /// Resolves an interface to concrete implementations
        /// </summary>
        /// <param name="serviceType">The type to resolve</param>
        /// <returns>A list of concrete implementation</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.dependencyResolver.GetServices(serviceType);
        }

        /// <summary>
        /// Begins the scope.
        /// </summary>
        /// <returns>An IDependencyScope</returns>
        public IDependencyScope BeginScope()
        {
            // Not interested in dealing with child scopes so just return 'this'
            return this;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // This must do nothing as we're not dealing with child scopes
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
