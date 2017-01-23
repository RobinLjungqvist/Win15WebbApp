using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using WebbApp.DAL;
using static WebbApp.App_Start.IdentityConfig;

[assembly: OwinStartup(typeof(WebbApp.Startup))]

namespace WebbApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
