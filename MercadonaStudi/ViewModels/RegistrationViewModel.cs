using System.ComponentModel.DataAnnotations;

namespace MercadonaStudi.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Le mot de passe doit contenir 6 caractères minimum 1 majuscule, 1 minuscule, un caractère spécial et un chiffre")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        public string Role { get; set; }
    }
    
}
