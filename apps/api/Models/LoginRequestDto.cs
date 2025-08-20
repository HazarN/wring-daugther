using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class LoginRequestDto
    {
        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
