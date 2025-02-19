namespace FinanceAPI.Domain.Models;
public class Department
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public DateTime DateCreated { get; init; }
    public DateTime DateModified { get; set; }
    public required string Status { get; set; }
}
