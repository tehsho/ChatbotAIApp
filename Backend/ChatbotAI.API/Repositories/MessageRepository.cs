using ChatbotAI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatbotAI.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public async Task<Message> CreateAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetByUsernameAsync(string username)
        {
            return await _context.Messages
                .Include(m => m.User)
                .Where(m => m.User.Username == username)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();
        }
    }
}
