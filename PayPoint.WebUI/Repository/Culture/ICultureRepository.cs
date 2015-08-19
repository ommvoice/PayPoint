using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPoint.WebUI.Repository.Culture
{
    public interface ICultureRepository
    {
        string Get(string cultureName, string key);
    }
}
