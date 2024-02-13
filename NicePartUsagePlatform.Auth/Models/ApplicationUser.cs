using Microsoft.AspNetCore.Identity;

namespace NicePartUsagePlatform.Auth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
