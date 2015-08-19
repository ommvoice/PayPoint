using Common;
using PayPoint.WebUI.Repository.Culture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayPoint.WebUI.Controllers
{
    public class HomeController : Controller
    {
        #region Fields and Constants

        /// <summary>
        /// The culture repository
        /// </summary>
        private readonly ICultureRepository cultureRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="cultureRepository">The cultureRepository.</param>
        public HomeController(ICultureRepository cultureRepository)
        {
            this.cultureRepository = cultureRepository;
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            //HttpContext.Session.Add("__MySessionObject", new MySessionObject());
            Session["currentCulture"] = culture;

            return RedirectToAction("Index");
        }
    }
}