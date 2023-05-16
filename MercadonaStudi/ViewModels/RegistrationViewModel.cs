using System.ComponentModel.DataAnnotations;

namespace MercadonaStudi.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le mot de passe ne correspond pas")]
        public string PasswordConfirm { get; set; }
    }
}
