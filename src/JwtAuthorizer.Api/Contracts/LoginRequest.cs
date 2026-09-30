
using System.ComponentModel.DataAnnotations;

public record LoginRequest(
    [property: Required, EmailAddress] string EmailAddress,
    [property: Required] string Password
);