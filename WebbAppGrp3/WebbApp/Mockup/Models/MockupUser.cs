using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


namespace WebbApp.Mockup.Models
{
    public class MockupUser 
    {
        public MockupUser() { }
        public MockupUser(Guid UserID, string Firstname, string LastName, string Email, string UserName,
            string Password, bool IsAdmin, string City, string Region)
        {
            this.UserID = UserID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.UserName = UserName;
            this.Password = Password;
            this.IsAdmin = IsAdmin;
            this.City = City;
            this.Region = Region;
        }
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}