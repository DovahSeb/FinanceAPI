using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_PostTitle_Reference_Values : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Accountant");

            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Accountant General");

            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Accounts Administrator");

            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Accounts Technician");

            migrationBuilder.InsertData(
                table: "PostTitles",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
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
                    { 57, "Principal Finance Analyst", "I" },
                    { 58, "Principal Internal Auditor", "I" },
                    { 59, "Principal Procurement Analyst", "I" },
                    { 60, "Principal Project Accountant", "I" },
                    { 61, "Principal Secretary, Finance", "I" },
                    { 62, "Principal Trade Officer", "I" },
                    { 63, "Prinicipal Economist", "I" },
                    { 64, "Prinicipal Secreatary", "I" },
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Secretary of State");

            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Principal Secretary");

            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Chairman");

            migrationBuilder.UpdateData(
                table: "PostTitles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Senior Analyst Programmer");
        }
    }
}
