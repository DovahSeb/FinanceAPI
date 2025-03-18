using Microsoft.AspNetCore.Identity;

namespace FinanceAPI.Domain.Models;
public class Role : IdentityRole<int>
{
    public required string Status { get; set; }
}
