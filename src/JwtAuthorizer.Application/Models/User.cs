using System;

public class User : BaseEntity
{
    public string EmailAddress { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PrimaryPhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public Permission Role { get; set; }
    public DateTime? LastSignInAt { get; set; }
}