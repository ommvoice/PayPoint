using PayPoint.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPoint.WebApi.Providers.Culture
{
    public interface ICultureProvider
    {
        /// <summary>
        /// Gets the culture value by culture name and key
        /// </summary>
        /// <param name="cultureName">the cultureName</param>
        /// <param name="key">the key</param>
        /// <returns>the Resource</returns>
        Resource GetCulutreResource(string cultureName, string key);
    }
}
