using ChatbotAI.Models;

namespace ChatbotAI.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}