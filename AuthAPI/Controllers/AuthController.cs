using AuthAPI.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using static AuthAPI.Models.DTOs.Dto;

namespace AuthAPI.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth auth;

        public AuthController(IAuth auth)
        {
            this.auth = auth;
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginPost(LoginRequestDTO loginRequestDTO)
        {
            var log = await auth.Login(loginRequestDTO);
            
            if (log != null)
            {
                return Ok(log);
            }

            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterPost(RegisterRequestDTO registerRequestDTO)
        {
            var result = await auth.Register(registerRequestDTO);

            if (result == "")
            {
                return Ok(result);  
            }

            return BadRequest();
        }
    }
}
