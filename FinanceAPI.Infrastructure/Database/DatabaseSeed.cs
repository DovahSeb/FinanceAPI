using FinanceAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Infrastructure.Database;
public static class DatabaseSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Office of the Minister", Status = "I" },
            new Department { Id = 2, Name = "Office of Secretary of State ", Status = "I" },
            new Department { Id = 3, Name = "Accounts", Status = "I" },
            new Department { Id = 4, Name = "Asset Management Unit", Status = "I" },
            new Department { Id = 5, Name = "Debt Management Unit", Status = "I" },
            new Department { Id = 6, Name = "Procurement Oversight Unity (POU)", Status = "I" },
            new Department { Id = 7, Name = "Macro-Economic Forecasting Analyst Branch (MFAB)", Status = "I" },
            new Department { Id = 8, Name = "Human Resources", Status = "I" },
            new Department { Id = 9, Name = "Administration", Status = "I" },
            new Department { Id = 10, Name = "System Support", Status = "I" },
            new Department { Id = 11, Name = "Financial Planning and Control", Status = "I" },
            new Department { Id = 12, Name = "Public Investment Management", Status = "I" },
            new Department { Id = 13, Name = "Public Budget Management", Status = "I" },
            new Department { Id = 14, Name = "Public Accounts Management", Status = "I" },
            new Department { Id = 15, Name = "Treasury", Status = "I" },
            new Department { Id = 16, Name = "Tax & Sectorial Policy", Status = "I" },
            new Department { Id = 17, Name = "Financial Services Development", Status = "I" },
            new Department { Id = 18, Name = "Internal Audit", Status = "I" },
            new Department { Id = 19, Name = "Trade", Status = "I" },
            new Department { Id = 20, Name = "National Planning", Status = "I" }
        );

        modelBuilder.Entity<PostTitle>().HasData(
            new PostTitle { Id = 1, Name = "Secretary of State", Status = "I"},
            new PostTitle { Id = 2, Name = "Principal Secretary", Status = "I"},
            new PostTitle { Id = 3, Name = "Chairman", Status = "I"},
            new PostTitle { Id = 4, Name = "Senior Analyst Programmer", Status = "I"}
        );
    }
}
