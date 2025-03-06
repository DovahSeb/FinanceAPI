using FinanceAPI.Application.Department;
using FinanceAPI.Application.Employee;
using FinanceAPI.Application.PostTitle;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceAPI.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(defaultConnectionString));

        services.AddScoped<IEmployee, EmployeePersistence>();
        services.AddScoped<IDepartment, DepartmentsPersistence>();
        services.AddScoped<IPostTitle, PostTitlesPersistence>();

        return services;
    }
}

