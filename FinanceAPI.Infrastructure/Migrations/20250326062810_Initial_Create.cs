using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateOnly>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PostTitleId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_PostTitles_PostTitleId",
                        column: x => x.PostTitleId,
                        principalTable: "PostTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, "Accountant", "I" },
                    { 2, "Accountant General", "I" },
                    { 3, "Accounts Administrator", "I" },
                    { 4, "Accounts Technician", "I" },
                    { 5, "Administrative Offcier", "I" },
                    { 6, "Adviser, Technical", "I" },
                    { 7, "Asset Management Controller", "I" },
                    { 8, "Asset Management Officer", "I" },
                    { 9, "Assistant Accountant", "I" },
                    { 10, "Assistant Accounts Administrator", "I" },
                    { 11, "Assistant Administrative Officer", "I" },
                    { 12, "Assistant Asset Management Officer", "I" },
                    { 13, "Assistant Data Processing", "I" },
                    { 14, "Assistant Finance Analyst", "I" },
                    { 15, "Assistant Finance Officer", "I" },
                    { 16, "Assistant Internal Auditor", "I" },
                    { 17, "Assistant Procurement Analyst", "I" },
                    { 18, "Assistant Procurement Inspector", "I" },
                    { 19, "Assistant Systems Support Officer", "I" },
                    { 20, "Assistant Treasury Accountant - Payroll", "I" },
                    { 21, "Bursar", "I" },
                    { 22, "Chairman", "I" },
                    { 23, "Chief Accountant (Treasury)", "I" },
                    { 24, "Chief Executive Officer", "I" },
                    { 25, "Chief Internal Auditor", "I" },
                    { 26, "Comptroller General", "I" },
                    { 27, "Contract Manager", "I" },
                    { 28, "Customer Service Assistant", "I" },
                    { 29, "Debt Analyst", "I" },
                    { 30, "Deputy Chief Internal Auditior", "I" },
                    { 31, "Director", "I" },
                    { 32, "Director Asset Management", "I" },
                    { 33, "Director General", "I" },
                    { 34, "Director General HRM", "I" },
                    { 35, "Director General MFAB", "I" },
                    { 36, "Director Oversight Procurement Unit", "I" },
                    { 37, "Director, Administration", "I" },
                    { 38, "Driver", "I" },
                    { 39, "Driver, Senior", "I" },
                    { 40, "Driver/ Messenger", "I" },
                    { 41, "Economist", "I" },
                    { 42, "Executive Director", "I" },
                    { 43, "Facilities Technician", "I" },
                    { 44, "Finance Analyst", "I" },
                    { 45, "Financial Analyst", "I" },
                    { 46, "Financial Controller", "I" },
                    { 47, "Housekeeper", "I" },
                    { 48, "HR & Budget Management Officer", "I" },
                    { 49, "Information and Communication Officer", "I" },
                    { 50, "Internal Audit Technician", "I" },
                    { 51, "Internal Auditor", "I" },
                    { 52, "Office Assistant", "I" },
                    { 53, "Personal Assistant", "I" },
                    { 54, "Policy Analyst", "I" },
                    { 55, "Postal Regulator", "I" },
                    { 56, "Principal Debt Analyst", "I" },
                    { 57, "Principal Economist", "I" },
                    { 58, "Principal Finance Analyst", "I" },
                    { 59, "Principal Internal Auditor", "I" },
                    { 60, "Principal Procurement Analyst", "I" },
                    { 61, "Principal Project Accountant", "I" },
                    { 62, "Principal Secretary", "I" },
                    { 63, "Principal Secretary, Finance", "I" },
                    { 64, "Principal Trade Officer", "I" },
                    { 65, "Private Secretary", "I" },
                    { 66, "Private Secretary, Senior", "I" },
                    { 67, "Procurement Analyst", "I" },
                    { 68, "Procurement Inspector", "I" },
                    { 69, "Procurement Officer", "I" },
                    { 70, "Records Assistant", "I" },
                    { 71, "Secretary of State", "I" },
                    { 72, "Senior Accountant", "I" },
                    { 73, "Senior Accounts Administrator", "I" },
                    { 74, "Senior Accounts Assistant", "I" },
                    { 75, "Senior Administrator Officer", "I" },
                    { 76, "Senior Analyst Programmer", "I" },
                    { 77, "Senior Asset Management Officer", "I" },
                    { 78, "Senior Debt Analyst", "I" },
                    { 79, "Senior Economist", "I" },
                    { 80, "Senior Finance Analyst", "I" },
                    { 81, "Senior Internal Auditor", "I" },
                    { 82, "Senior Investigation Officer", "I" },
                    { 83, "Senior Office Assistant", "I" },
                    { 84, "Senior Office Officer", "I" },
                    { 85, "Senior Policy Analyst", "I" },
                    { 86, "Senior Processing Officer", "I" },
                    { 87, "Senior Procurement Analyst", "I" },
                    { 88, "Senior Procurement Officer", "I" },
                    { 89, "Senior Project Accountant", "I" },
                    { 90, "Senior Project Officer", "I" },
                    { 91, "Senior Quantity Surveyor", "I" },
                    { 92, "Senior Trade Officer", "I" },
                    { 93, "Senior Trades Officer", "I" },
                    { 94, "Store Officer", "I" },
                    { 95, "Systems Support Manager", "I" },
                    { 96, "Systems Support Officer", "I" },
                    { 97, "Telephone Operator", "I" },
                    { 98, "Trades Officer", "I" },
                    { 99, "Transport Officer", "I" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PostTitleId",
                table: "Employees",
                column: "PostTitleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "PostTitles");
        }
    }
}
