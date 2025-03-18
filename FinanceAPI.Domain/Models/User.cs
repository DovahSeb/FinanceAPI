using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Domain.Models;
public class User : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateCreated { get; init; }
    public DateTime DateModified { get; set; }
    public required string Status { get; set; }
}