using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class UserResponseDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public required string Email { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}