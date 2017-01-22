using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WebbApp.DAL.DB.Models;

namespace WebbApp.DAL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("name=GiveItAwayCS")
        {
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
