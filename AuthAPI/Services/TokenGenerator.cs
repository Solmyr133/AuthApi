using AuthAPI.Models;
using AuthAPI.Services.IService;
using Microsoft.Extensions.Options;

namespace AuthAPI.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JwtOption jwtOption;

        public TokenGenerator(IOptions<JwtOption> jwtOption)
        {
            this.jwtOption = jwtOption.Value;
        }

        public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}
