using ChatbotAI.Models;

namespace ChatbotAI.Services
{
    public interface IAuthService
    {
        Task<User?> AuthenticateAsync(string username, string password);        
    }
}