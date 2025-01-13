using AuthAPI.Models;
using AuthAPI.Models.DTOs;
using AuthAPI.Services.IService;

namespace AuthAPI.Services
{
    public class AuthService : IAuth
    {
        private readonly AppDbContext _appDbContext;

        public AuthService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<object> Login(Dto.LoginRequestDTO loginRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<object> Register(Dto.RegisterRequestDTO registerRequestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
