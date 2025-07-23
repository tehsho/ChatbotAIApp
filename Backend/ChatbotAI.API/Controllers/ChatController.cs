using ChatbotAI.Models;
using ChatbotAI.Repositories;
using ChatbotAI.Services;
using Microsoft.AspNetCore.Mvc;
using ChatbotAI.DTOs;

namespace ChatbotAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMessageRepository _messageRepo;

        public ChatController(IChatService chatService, IMessageRepository messageRepo)
        {
            _chatService = chatService;
            _messageRepo = messageRepo;
        }

        // GET: /api/chat/messages/user/{username}
        [HttpGet("messages/user/{username}")]
        public async Task<IActionResult> GetMessagesByUsername(string username)
        {
            var messages = await _messageRepo.GetByUsernameAsync(username);
            if (messages == null || !messages.Any())
                return NotFound($"No messages found for user '{username}'.");

            var result = messages.Select(m => new MessageDto
            {
                Id = m.Id,
                UserId = m.UserId,
                Content = m.MessageText,
                Response = m.ResponseText,
                Timestamp = m.CreatedAt.ToString("o")
            });

            return Ok(result);
        } 

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] MessageDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Content))
                return BadRequest("Message content is required.");

            if (input.UserId == null || input.UserId <= 0)
                return BadRequest("Valid UserId is required.");

            var response = await _chatService.GetAIResponseAsync(input.Content);

            var entity = new Message
            {
                UserId = input.UserId.Value,
                MessageText = input.Content,
                ResponseText = response,
                CreatedAt = DateTime.UtcNow
            };

            var saved = await _messageRepo.CreateAsync(entity);

            // Optional response DTO
            var result = new MessageDto
            {
                Id = saved.Id,
                UserId = saved.UserId,
                Content = saved.MessageText,
                Response = saved.ResponseText,
                Timestamp = saved.CreatedAt.ToString("o")
            };

            return Ok(result);
        }

    }
}
