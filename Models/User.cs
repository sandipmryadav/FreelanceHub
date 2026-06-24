using System.ComponentModel.DataAnnotations;

namespace FreelanceHub.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.Now; 

    }
}
