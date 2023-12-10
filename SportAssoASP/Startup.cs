using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportAssoASP.Startup))]
namespace SportAssoASP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
