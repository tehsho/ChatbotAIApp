namespace ChatbotAI.DTOs
{
    public class MessageDto
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; } = null!;
        public string? Response { get; set; }
        public string? Timestamp { get; set; }       
    }
}
