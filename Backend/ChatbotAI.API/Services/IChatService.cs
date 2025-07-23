namespace ChatbotAI.Services
{
    public interface IChatService
    {
        Task<string> GetAIResponseAsync(string question);
    }
}