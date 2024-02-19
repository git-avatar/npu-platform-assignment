using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NicePartUsagePlatform.Auth.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MinLength(3), MaxLength(40)]
        public string Name { get; set; }
        [MinLength(3), MaxLength(40)]
        public string Surname { get; set; }
        [Range(0, 150)]
        public int Age { get; set; }
    }
}
