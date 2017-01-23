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

        public DbSet<Image> Images { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
