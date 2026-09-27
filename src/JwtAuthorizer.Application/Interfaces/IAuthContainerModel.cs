using System.Security.Claims;

public interface IAuthContainerModel
{
	int ExpirationInSeconds { get; }
	Task<bool> hasPermission(User user);
	IReadOnlyCollection<Claim> Claims { get; }
}