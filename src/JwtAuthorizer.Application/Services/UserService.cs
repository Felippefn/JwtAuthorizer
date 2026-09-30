public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<string> SignupAsync(string username, string email, string password, Permission? role)
    {
        var existing = await _userRepository.GetByUserName(username);
        if (existing is not null)
            throw new InvalidOperationException("User already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            EmailAddress = email,
            PasswordHash = _passwordHasher.Hash(password),
            Role = role ?? Permission.User
        };

        await _userRepository.AddAsync(user);
        return await _tokenService.GenerateTokenAsync(user);
    }

    public async Task<string?> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetByUserName(username);
        if (user is null || !_passwordHasher.Verify(password, user.PasswordHash))
            return null;

        return await _tokenService.GenerateTokenAsync(user);
    }
}
