public interface IUserRepository
{
    Task<User> GetByUserName(string username);
    Task<User> GetById(string id);
    Task AddAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(string id);
}