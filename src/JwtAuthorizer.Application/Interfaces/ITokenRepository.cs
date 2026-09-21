public interface ITokenRepository
{
    Task<string> GenerateTokenAsync(User user);
    Task<bool> ValidateTokenAsync(string token);
    Task<User> GetUserFromTokenAsync(string token);
}