using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusDepot.Startup))]
namespace BusDepot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
