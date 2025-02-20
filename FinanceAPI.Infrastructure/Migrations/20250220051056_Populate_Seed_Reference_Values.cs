using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Populate_Seed_Reference_Values : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Office of the Minister", "I" },
                    { 2, "Office of Secretary of State ", "I" },
                    { 3, "Accounts", "I" },
                    { 4, "Asset Management Unit", "I" },
                    { 5, "Debt Management Unit", "I" },
                    { 6, "Procurement Oversight Unity (POU)", "I" },
                    { 7, "Macro-Economic Forecasting Analyst Branch (MFAB)", "I" },
                    { 8, "Human Resources", "I" },
                    { 9, "Administration", "I" },
                    { 10, "System Support", "I" },
                    { 11, "Financial Planning and Control", "I" },
                    { 12, "Public Investment Management", "I" },
                    { 13, "Public Budget Management", "I" },
                    { 14, "Public Accounts Management", "I" },
                    { 15, "Treasury", "I" },
                    { 16, "Tax & Sectorial Policy", "I" },
                    { 17, "Financial Services Development", "I" },
                    { 18, "Internal Audit", "I" },
                    { 19, "Trade", "I" },
                    { 20, "National Planning", "I" }
                });

            migrationBuilder.InsertData(
                table: "PostTitles",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Secretary of State", "I" },
                    { 2, "Principal Secretary", "I" },
                    { 3, "Chairman", "I" },
                    { 4, "Senior Analyst Programmer", "I" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
