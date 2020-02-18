using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedZipCodeToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53813485-8ee7-4c96-b93b-bb8b88c991d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3982926-3ceb-4483-89ef-2c5771099828");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef0696a9-61dd-4317-9c58-cec40ffb07a2");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55542ae2-7576-4008-b373-df06faa17c3c", "f3ff3e5a-8df1-4c86-b44e-cf60b9596fb2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d12df56-7a95-450c-b906-8263b2e78233", "d5187f82-8a40-463d-9874-a94514314296", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "460a5038-7508-4b3b-95dc-5d5de508e0c1", "6a20530a-16f5-4e78-b981-210011f96ac9", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d12df56-7a95-450c-b906-8263b2e78233");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "460a5038-7508-4b3b-95dc-5d5de508e0c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55542ae2-7576-4008-b373-df06faa17c3c");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef0696a9-61dd-4317-9c58-cec40ffb07a2", "fbe8fb6b-6d39-4196-9c7f-cf1ada11496b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53813485-8ee7-4c96-b93b-bb8b88c991d9", "5dd6dea4-a237-461d-884f-7dd2e248935b", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3982926-3ceb-4483-89ef-2c5771099828", "343198dc-99b0-471c-9ae4-f3f79fe7b8ea", "Customer", "CUSTOMER" });
        }
    }
}
