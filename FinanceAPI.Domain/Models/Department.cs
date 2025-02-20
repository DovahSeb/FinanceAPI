namespace FinanceAPI.Domain.Models;
public class Department
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required string Status { get; set; }
}
