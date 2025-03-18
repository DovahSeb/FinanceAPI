using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Domain.Models;
public class UserRole : IdentityUserRole<int>
{
    public DateTime DateCreated { get; init; }
    public DateTime DateModified { get; set; }
    public required string Status { get; set; }
}
