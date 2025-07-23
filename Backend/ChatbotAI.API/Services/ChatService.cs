namespace ChatbotAI.Services
{
    public class ChatService : IChatService
    {
        public async Task<string> GetAIResponseAsync(string question)
        {
            // Simulate OpenAI call
            await Task.Delay(300);
            return $"Simulated response to: '{question}'";
        }
    }
}