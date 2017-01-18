using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbApp.Mockup.Models
{
    public class MockupUser
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public Guid CityID { get; set; }
        public Guid Region { get; set; }
    }
}