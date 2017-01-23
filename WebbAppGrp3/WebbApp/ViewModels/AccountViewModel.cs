using System.ComponentModel.DataAnnotations;

namespace WebbApp.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Display(Name = "Kom ihåg?")]
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
            Blekinge,
            Dalarna,
            Gotland,
            Gävleborg,
            Halland,
            Jämtland,
            Jönköping,
            Kalmar,
            Kronoberg,
            Norrbotten,
            Skåne,
            Stockholm,
            Södermanland,
            Uppsala,
            Värmland,
            Västerbotten,
            Västernorrland,
            Västmanland,
            Västra_Götaland,
            Örebro,
            Östergötland
        }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta lösenordet")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Ort")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Län")]
        public Regions Region { get; set; }

        [Required]
        [Display(Name = "Behörighet")]
        public UserRoles UserRole { get; set; }
    }
}