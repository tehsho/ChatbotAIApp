using ChatbotAI.Models;
using ChatbotAI.Repositories;
using ChatbotAI.Services;
// TODO: using BCrypt.Net;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

public async Task<User?> AuthenticateAsync(string username, string password)
{
    var user = await _userRepository.GetByUsernameAsync(username);
    if (user is null)
        return null;

        // TODO: Implement this in a future release
        // Compare input password with stored hash
        //if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        //    return null;

        if (password != user.PasswordHash)
        return null;

        return user;
}

 
}
