namespace FinanceAPI.Domain.Models;
public class User
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime DateCreated { get; init; }
    public DateTime DateModified { get; set; }
    public string Status { get; set; } = string.Empty;
}