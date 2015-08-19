using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPoint.WebApi.DbContext;
using PayPoint.Domain;

namespace PayPoint.WebApi.Providers.Culture
{
    public class CultureProvider : ICultureProvider
    {
        #region Public Methods
        /// <summary>
        /// Gets the culture value by culture name and key
        /// </summary>
        /// <param name="cultureName">the cultureName</param>
        /// <param name="key">the key</param>
        /// <returns>the Resource</returns>
        public Resource GetCulutreResource(string cultureName, string key)
        {
            using (PayPointDbContext context = new PayPointDbContext())
            {
                return context.Resources
                    .FirstOrDefault(culture => culture.Key == key && culture.Culture == cultureName);
            }
        }

        #endregion
    }
}