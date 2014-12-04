using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GesVeh.Web.Startup))]
namespace GesVeh.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
