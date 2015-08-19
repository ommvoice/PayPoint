namespace Common
{
    using System.Web.Http.Dependencies;

    /// <summary>
    /// Extension methods for the service resolver
    /// </summary>
    public static class ServiceResolverExtensions
    {
        /// <summary>
        /// Extension method to create a custom dependency resolver for the web api
        /// </summary>
        /// <param name="dependencyResolver">The dependency resolver.</param>
        /// <returns>A service resolver instance</returns>
        public static IDependencyResolver ToServiceResolver(this System.Web.Mvc.IDependencyResolver dependencyResolver)
        {
            return new WebApiResolverAdapter(dependencyResolver);
        }
    }
}
