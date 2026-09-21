public interface IAuthContainerModel
{
	int ExpirationInSeconds { get; }
	Task<bool> hasPermission(User user);
	IReadOnlyColletion<Claim> Claims { get; }
}