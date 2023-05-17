﻿using System.ComponentModel.DataAnnotations;

namespace MercadonaStudi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email requis")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mot de passe requis")]
        public string? Password { get; set; }
    }
}
