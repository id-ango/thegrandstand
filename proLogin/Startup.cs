using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proLogin.Startup))]
namespace proLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
