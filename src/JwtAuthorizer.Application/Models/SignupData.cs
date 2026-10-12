
public record SignupData(
    string Email,
    string FirstName,
    string LastName,
    string? PrimaryPhoneNumber,
    string PasswordHash
);
