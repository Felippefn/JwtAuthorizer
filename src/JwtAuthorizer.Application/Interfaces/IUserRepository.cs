public interface IUserRepository
{
    Task<User> GetUserByUsernameAsync(string username);
    Task<User> GetUserByIdAsync(string id);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(string id);
}