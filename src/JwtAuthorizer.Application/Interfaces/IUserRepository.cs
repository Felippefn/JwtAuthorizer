public interface IUserRepository
{
    Task<User> GetByEmail(string email);
    Task<User> GetById(string id);
    Task AddAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(string id);
}