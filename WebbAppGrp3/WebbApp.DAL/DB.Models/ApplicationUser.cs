using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace WebbApp.DAL.DB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Items = new HashSet<Item>();
        }

        //public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        //public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string UserRole { get; set; }
        public string City { get; set; }
        public string Region { get; set; }

        //[ForeignKey("City"), ScaffoldColumn(false)]
        //public Image CityId { get; set; }
        //[ForeignKey("Region"), ScaffoldColumn(false)]
        //public Image RegionId { get; set; }
        //public virtual Region Region { get; set; }
        //public virtual City city { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
