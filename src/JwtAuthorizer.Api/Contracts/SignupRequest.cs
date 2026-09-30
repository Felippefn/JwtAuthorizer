using System.ComponentModel.DataAnnotations;

public record SignupRequest(
    [property: Required, EmailAddress] string EmailAddress,
    [property: Required] string FirstName,
    [property: Required] string LastName,
    [property: Phone] string PrimaryPhoneNumber,
    [property: Required, MinLength(6)] string Password
);
