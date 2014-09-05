using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HickoryPTASite.Startup))]
namespace HickoryPTASite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
