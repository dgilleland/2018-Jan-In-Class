using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientWebApp.Startup))]
namespace ClientWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
