using Microsoft.AspNet.Identity.EntityFramework;


namespace WebbApp.DAL.DB.Models
{
    public class ApplicationUser : IdentityUser
    {
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
    }
}
