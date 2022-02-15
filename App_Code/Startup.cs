using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnantMatrimony.Startup))]
namespace AnantMatrimony
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
