public interface IUserService
{
    Task<string> SignupAsync(string email,string password, Permission? role);
    Task<string> LoginAsync(string username, string password);
}
