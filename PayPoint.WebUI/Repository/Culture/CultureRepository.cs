using Common.Helpers;
using PayPoint.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PayPoint.WebUI.Repository.Culture
{
    public class CultureRepository : ICultureRepository
    {
        private string serviceEndpoint;

        public CultureRepository()
        {
            this.serviceEndpoint = ConfigurationManager.AppSettings["WebApiEndPoint"];
        }

        public string Get(string cultureName, string key) 
        {
            return HttpRequestHelper.Get<string>(serviceEndpoint, string.Format("api/cultures?culturename={0}&key={1}", cultureName, key));
        }
    }
}