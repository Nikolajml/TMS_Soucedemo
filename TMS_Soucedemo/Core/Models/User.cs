using Core.Models.Enums;

namespace Core.Models;

public record User
{
    public UserType UserType { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserCode { get; set; }
}