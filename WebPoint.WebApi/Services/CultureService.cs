using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPoint.WebApi.Providers.Culture;
using PayPoint.Domain;

namespace PayPoint.WebApi.Services
{
    public class CultureService : ICultureService
    {
         #region Fields and Constants

        /// <summary>
        /// The culture provider
        /// </summary>
        private readonly ICultureProvider cultureProvider;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CultureService"/> class.
        /// </summary>
        /// <param name="cultureProvider">The culture provider.</param>
        public CultureService(ICultureProvider cultureProvider)
        {
            this.cultureProvider = cultureProvider;
        }

        #endregion

                /// <summary>
        /// Gets the culture value by culture name and key
        /// </summary>
        /// <param name="cultureName">the cultureName</param>
        /// <param name="key">the key</param>
        /// <returns>the value</returns>
        public string GetCultureValue(string cultureName, string key)
        {
            Resource resource = cultureProvider.GetCulutreResource(cultureName, key);

            // Check that the culture value xists
            if (resource == null)
            {
                // throw new WebApiServiceException(string.Format("The culture with cultureName '{0}' and key '{1}' does not exist.", cultureName, key), HttpStatusCode.NotFound);
            }

            return resource.Value;
        }
    }
}