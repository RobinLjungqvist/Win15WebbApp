using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL;

namespace WebbApp.App_Start
{
    public class IdentityConfig
    {
        public class ApplicationUserStore : UserStore<ApplicationUser>
        {
            public ApplicationUserStore(ApplicationContext context) : base(context)
            {
            }
        }

        public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationContext>()));
                return manager;
            }
        }

        
        public class ApplicationRoleStore : RoleStore<IdentityRole>
        {
            public ApplicationRoleStore(ApplicationContext context) : base(context)
            {
            }
        }

        public class ApplicationRoleManager : RoleManager<IdentityRole>
        {
            public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
            {
            }
            public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
            {
                var roleStore = new RoleStore<IdentityRole>(context.Get<ApplicationContext>());
                return new ApplicationRoleManager(roleStore);
            }
        }

        public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
        {
            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
            {
            }

            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
            {
                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            }
        }
    }
}