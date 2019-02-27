using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(desafio2019.WEB.Startup))]
namespace desafio2019.WEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
