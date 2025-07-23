using ChatbotAI.Models;

namespace ChatbotAI.Repositories
{
    public interface IMessageRepository
    {    
        Task AddAsync(Message message);
        Task SaveChangesAsync();
        Task<Message> CreateAsync(Message message);
        Task<IEnumerable<Message>> GetByUsernameAsync(string username);       
    }
}
