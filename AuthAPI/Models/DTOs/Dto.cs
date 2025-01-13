namespace AuthAPI.Models.DTOs
{
    public class Dto
    {
        public record LoginRequestDTO(string UserName, string Password);
        public record RegisterRequestDTO(string UserName, string Password, string Email, string FullName);
    }
}
