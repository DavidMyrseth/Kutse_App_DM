using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kutse_App_DM.Startup))]
namespace Kutse_App_DM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
