using Common;
using PayPoint.WebUI.Repository.Culture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayPoint.WebUI.Extensions
{
    public static class HtmlExtensions
    {
        #region Properties

        /// <summary>
        /// Gets the culture repository.
        /// </summary>
        private static ICultureRepository cultureRepository
        {
            get
            {
                // Create the culture repository by dependency injection
                return DependencyResolver.Current.GetService<ICultureRepository>();
            }
        }

        #endregion

        #region Public Methods

        public static MvcHtmlString GetChinaCultureValue(this HtmlHelper html)
        {
            string currentCulture = (string)HttpContext.Current.Session["currentCulture"];
            string value = cultureRepository.Get(currentCulture, CultureConstants.UserNameKey);

            return new MvcHtmlString(value);
        }

        public static MvcHtmlString GetUSCultureValue(this HtmlHelper html)
        {
            string currentCulture = (string)HttpContext.Current.Session["currentCulture"];
            string value = cultureRepository.Get(currentCulture, CultureConstants.UserNameKey);

            return new MvcHtmlString(value);
        }

        public static MvcHtmlString GetUserName(this HtmlHelper html)
        {
            string currentCulture = (string)HttpContext.Current.Session["currentCulture"];
            string value = cultureRepository.Get(currentCulture, CultureConstants.UserNameKey);

            return new MvcHtmlString(value);
        }

        #endregion

    }
}