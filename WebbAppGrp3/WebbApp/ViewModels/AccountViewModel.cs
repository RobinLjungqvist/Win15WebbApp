﻿using System.ComponentModel.DataAnnotations;

namespace WebbApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public enum UserRoles
        {
            Admin,
            User
        }

        public enum Regions
        {
            Blekinge, Dalarna, Gotland, Gävleborg, Halland, Jämtland, Jönköping,
            Kalmar, Kronoberg, Norrbotten, Skåne, Stockholm, Södermanland, Uppsala,
            Värmland, Västerbotten, Västernorrland, Västmanland, Västra_Götaland,
            Örebro, Östergötland
        }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Region")]
        public Regions Region { get; set; }

        //[Required]
        //[Display(Name = "Role")]
        public string UserRole { get; set; }
    }
}