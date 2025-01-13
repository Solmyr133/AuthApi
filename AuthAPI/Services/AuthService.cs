using AuthAPI.Models;
using AuthAPI.Models.DTOs;
using AuthAPI.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Services
{
    public class AuthService : IAuth
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenGenerator jwtTokenGenerator;

        public AuthService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenGenerator jwtTokenGenerator)
        {
            _appDbContext = appDbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<object> Login(Dto.LoginRequestDTO loginRequestDTO)
        {
            var user = await _appDbContext.applicationUsers.FirstOrDefaultAsync(user => user.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

            bool isValid = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

            if (user == null || isValid == false)
            {
                return new { result = "", Token = "" };
            }

            var roles = await userManager.GetRolesAsync(user);

            var token = jwtTokenGenerator.GenerateToken(user, roles);

            return new { Result = loginRequestDTO, Token = token };
        }

        public async Task<object> Register(Dto.RegisterRequestDTO registerRequestDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registerRequestDTO.UserName,
                NormalizedUserName = registerRequestDTO.UserName.ToUpper(),
                FullName = registerRequestDTO.FullName,
                Email = registerRequestDTO.Email
            };

            var result = await userManager.CreateAsync(user, registerRequestDTO.Password);

            if (result.Succeeded)
            {
                var userToReturn = await _appDbContext.applicationUsers.FirstOrDefaultAsync(user => user.UserName == registerRequestDTO.UserName);

                var userResponse = new
                {
                    Id = userToReturn.Id,
                    Email = userToReturn.Email,
                    UserName = userToReturn.UserName,
                    FullName = userToReturn.FullName
                };

                return new { result = userResponse, message = "" };
            }

            return result.Errors.FirstOrDefault().Description;
        }
    }
}
