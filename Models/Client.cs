using System.ComponentModel.DataAnnotations;

namespace FreelanceHub.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Client name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; }

        [RegularExpression(@"^\d{10}$",
        ErrorMessage = "Phone number must be 10 digits.")]
        public string? Phone { get; set; }

        [MaxLength(150,
            ErrorMessage = "Company name cannot exceed 150 characters.")]
        public string CompanyName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Project> Projects { get; set; } = new();

    }
}
