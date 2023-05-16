using MercadonaStudi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MercadonaStudi.Context;

namespace MercadonaStudi.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
        public string Email { get; set; }
    }
}
