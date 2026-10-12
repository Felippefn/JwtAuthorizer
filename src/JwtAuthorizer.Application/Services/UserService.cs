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

    public async Task<string> SignupAsync(SignupData data)
    {
        var existing = await _userRepository.GetByEmail(data.Email);
        if (existing is not null)
            throw new InvalidOperationException("User already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = data.Email,
            FirstName = data.FirstName,
            LastName = data.LastName,
            PrimaryPhoneNumber = data?.PrimaryPhoneNumber,
            PasswordHash = _passwordHasher.Hash(data.PasswordHash),
            Role = Permission.USER
        };

        await _userRepository.AddAsync(user);
        return await _tokenService.GenerateTokenAsync(user);
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmail(email);
        if (user is null || !_passwordHasher.Verify(password, user.PasswordHash))
            return null;

        user.LastSignInAt = DateTimeHelper.HorarioBrasilia;
        await _userRepository.UpdateAsync(user);

        return await _tokenService.GenerateTokenAsync(user);
    }
}
