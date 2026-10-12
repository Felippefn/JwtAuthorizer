using System.ComponentModel.DataAnnotations;

public record SignupRequest(
    [param: Required]
    [param: EmailAddress] 
    string EmailAddress,

    [param: Required]
    string FirstName,

    [param: Required]
    string LastName,

    [param: Phone]
    string? PrimaryPhoneNumber,

    [param: Required]
    [param: StringLength(100, MinimumLength = 6)]
    string Password
);
