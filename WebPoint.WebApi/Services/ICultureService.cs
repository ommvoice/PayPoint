using PayPoint.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPoint.WebApi.Services
{
    public interface ICultureService
    {
        /// <summary>
        /// Gets the culture value by culture name and key
        /// </summary>
        /// <param name="cultureName">the cultureName</param>
        /// <param name="key">the key</param>
        /// <returns>the value</returns>
        string GetCultureValue(string cultureName, string key);
    }
}
