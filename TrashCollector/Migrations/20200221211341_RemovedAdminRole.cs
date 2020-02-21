using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class RemovedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b95a76c-8062-4ae0-b7b6-c6d9a23ee6ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8afbd44d-c5cd-46a7-8c66-28041372d490");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce91998c-c06a-495e-a0b5-cb15be6022ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1bd62f4a-e1b8-431f-9d8e-f3316f1e73d6", "d9073466-cf41-4f48-b3e6-620d0d41396a", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d29c619a-91a2-40d4-bea8-76a299c51be7", "a7de6ef3-71f5-40ba-8f6a-472c587cca84", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd62f4a-e1b8-431f-9d8e-f3316f1e73d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d29c619a-91a2-40d4-bea8-76a299c51be7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce91998c-c06a-495e-a0b5-cb15be6022ce", "0f68b2ed-9174-4725-8e44-d6018f461e34", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b95a76c-8062-4ae0-b7b6-c6d9a23ee6ee", "867b7ffb-999c-4b62-a3fb-d268f2aea0ed", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8afbd44d-c5cd-46a7-8c66-28041372d490", "0e2126e4-1127-4c0b-9d52-742ae16ed363", "Customer", "CUSTOMER" });
        }
    }
}
