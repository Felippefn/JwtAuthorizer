public interface IUserRepository
{
    Task<User> GetByEmail(string email);
    Task<User> GetById(string id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteUser(string id);
}