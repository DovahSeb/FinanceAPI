using FinanceAPI.Application.Auth;
using FinanceAPI.Application.Department;
using FinanceAPI.Application.Employee;
using FinanceAPI.Application.PostTitle;
using FinanceAPI.Infrastructure.Database;
using FinanceAPI.Infrastructure.Email;
using FinanceAPI.Infrastructure.Email.Interface;
using FinanceAPI.Infrastructure.Services;
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

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        services.AddScoped<IAuth, AuthService>();
        services.AddScoped<IEmployee, EmployeeService>();
        services.AddScoped<IDepartment, DepartmentsService>();
        services.AddScoped<IPostTitle, PostTitlesService>();

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}

