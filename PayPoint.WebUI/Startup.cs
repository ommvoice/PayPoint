using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayPoint.WebUI.Startup))]
namespace PayPoint.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
