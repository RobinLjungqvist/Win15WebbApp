using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebbApp.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [MinLength(5, ErrorMessage ="Must be atleast 5 characters long")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email must be a valid Email adress.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Guid id { get; set; }
    }
}