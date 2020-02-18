using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ChangedIdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4011080e-4121-4c75-ac9b-eebc8a7f0d9f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8f252cc-6221-42c8-bbbd-b4057100d810", "70ffe248-d62f-408b-96d1-f5144af1a29e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bf2b0290-b901-414c-aa80-7ca8926a3599", "1ace6d5c-ff84-4266-8c45-80295744d66d", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7f5ab7c-f19c-4f5b-b377-982091570c01", "2d2abeda-0956-48fa-8a00-f42be6301caa", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7f5ab7c-f19c-4f5b-b377-982091570c01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf2b0290-b901-414c-aa80-7ca8926a3599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8f252cc-6221-42c8-bbbd-b4057100d810");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4011080e-4121-4c75-ac9b-eebc8a7f0d9f", "9f7b9a4d-e84a-423a-b98d-5a724b0e903c", "Admin", "ADMIN" });
        }
    }
}
