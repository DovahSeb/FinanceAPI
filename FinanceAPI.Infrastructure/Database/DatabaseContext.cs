using FinanceAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Database;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<PostTitle> PostTitles { get; set; }
}
