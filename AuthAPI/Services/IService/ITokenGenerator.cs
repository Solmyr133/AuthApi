using AuthAPI.Models;

namespace AuthAPI.Services.IService
{
    public interface ITokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
