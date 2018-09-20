using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GlobalSoft.Startup))]
namespace GlobalSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
