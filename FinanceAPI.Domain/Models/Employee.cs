namespace FinanceAPI.Domain.Models;
public class Employee
{
    public int Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required string Email { get; set; }
    public required DateOnly DateJoined { get; set; }
    public bool IsActive { get; set; }
    public required int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
    public required int PostTitleId { get; set; }
    public PostTitle PostTitle { get; set; } = null!;
    public DateTime DateCreated { get; init; }
    public DateTime DateModified { get; set; }
    public required string Status { get; set; }
}
