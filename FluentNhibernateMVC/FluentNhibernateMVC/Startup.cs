using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FluentNhibernateMVC.Startup))]
namespace FluentNhibernateMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
