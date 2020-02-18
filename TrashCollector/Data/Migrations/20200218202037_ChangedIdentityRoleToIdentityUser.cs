using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ChangedIdentityRoleToIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1ac7dd74-fc3c-4569-95ef-802c25617da7", "ccb9710b-073d-4e97-a007-f63544da4faa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "089497a4-5c47-4c50-90d5-6434254eb2e6", "a631e9aa-8b39-473e-9159-c874ed316a09", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b25dd9f-fc43-4152-adbd-92f8abf83fd1", "54cd6b2c-6973-44c0-a267-610c2cb2ba1b", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "089497a4-5c47-4c50-90d5-6434254eb2e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ac7dd74-fc3c-4569-95ef-802c25617da7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b25dd9f-fc43-4152-adbd-92f8abf83fd1");

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
    }
}
