using System.ComponentModel.DataAnnotations;

namespace FreelanceHub.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
