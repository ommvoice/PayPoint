using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PayPoint.WebApi.Services;

namespace PayPoint.WebApi.Controllers
{
    public class CulturesController : ApiController
    {
        #region Fields and Constants

        /// <summary>
        /// The CultureService  
        /// </summary>
        private readonly ICultureService cultureService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CulturesController" /> class.
        /// </summary>
        /// <param name="cultureService">The cultureService.</param>
        public CulturesController(ICultureService cultureService)
        {
            this.cultureService = cultureService;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Gets a specific Culture by id
        /// </summary>
        /// <param name="cultureName">The cultureName.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// A value of culutrename and key
        /// </returns>
        /// <exception cref="WebApiServiceException">No culture exists for this key.</exception>
        /// <remarks>GET: api/culturescultures?cultureName=en-Ud&key=UserName_Display</remarks>
        public string Get(string cultureName, string key)
        {
            return this.cultureService.GetCultureValue(cultureName, key);
        }

        #endregion
    }
}
