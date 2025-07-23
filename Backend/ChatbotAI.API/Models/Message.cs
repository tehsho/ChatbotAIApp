using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChatbotAI.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string MessageText { get; set; } = null!;

        public string? ResponseText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
