using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortalEmprego_Wth_MemberShip_And_mvc5.Startup))]
namespace PortalEmprego_Wth_MemberShip_And_mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
