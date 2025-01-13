using Microsoft.AspNetCore.Identity.Data;
using static AuthAPI.Models.DTOs.Dto;

namespace AuthAPI.Services.IService
{
    public interface IAuth
    {
        Task<object> Login(LoginRequestDTO loginRequestDTO);
        Task<object> Register(RegisterRequestDTO registerRequestDTO);
    }
}
