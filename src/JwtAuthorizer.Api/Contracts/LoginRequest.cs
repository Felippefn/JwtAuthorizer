
using System.ComponentModel.DataAnnotations;

public record LoginRequest(
    [param: Required]
    [param: EmailAddress] 
    string EmailAddress,
    
    [param: Required] 
    string Password
);