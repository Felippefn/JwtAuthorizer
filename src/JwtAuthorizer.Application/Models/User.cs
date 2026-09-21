using System;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Permission Role { get; set; }
}