using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrincePortalWeb.Startup))]
namespace PrincePortalWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
