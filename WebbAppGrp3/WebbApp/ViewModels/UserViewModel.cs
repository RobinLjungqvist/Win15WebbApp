using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebbApp.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid id { get; set; }
    }
}