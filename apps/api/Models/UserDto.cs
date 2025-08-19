using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class UserDto
    {
        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
