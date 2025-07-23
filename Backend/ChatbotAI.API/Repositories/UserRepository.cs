using ChatbotAI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatbotAI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .Include(u => u.Messages)
                .FirstOrDefaultAsync(u => u.Username == username);
        }       
    }
}
