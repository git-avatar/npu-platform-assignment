using NicePartUsagePlatform.Auth.Models;

namespace NicePartUsagePlatform.Auth.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
