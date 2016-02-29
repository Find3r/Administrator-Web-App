using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pineapple_AdminWeb.Startup))]
namespace Pineapple_AdminWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
