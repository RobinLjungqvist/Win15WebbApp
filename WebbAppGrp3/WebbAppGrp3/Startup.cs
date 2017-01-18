using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebbAppGrp3.Startup))]
namespace WebbAppGrp3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
