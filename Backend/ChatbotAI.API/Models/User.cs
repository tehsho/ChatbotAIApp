﻿using System.ComponentModel.DataAnnotations;

namespace ChatbotAI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; } = null!;

        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } = null!;

        [MaxLength(50)]
        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }

}