using System.ComponentModel.DataAnnotations;

namespace Agents.DTO
{
    public class AuthenticateRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
