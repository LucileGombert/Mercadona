using Microsoft.AspNetCore.Identity;

namespace MercadonaStudi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}