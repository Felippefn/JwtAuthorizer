public interface IUserService
{
    Task<string> SignupAsync(SignupData data);
    Task<string> LoginAsync(string email, string password);
}
