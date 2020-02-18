using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class RemovedZipCodeFromCustomerClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f4fc039b-8e55-4633-9726-320718ae68ba", "f18e8bf9-1b4b-463a-8fd7-9e8e44c898c1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "149969fd-f31d-4a7f-9c91-f413c350f9fe", "6f56b19d-faf9-462b-96c1-78e963362139", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "82400ad8-74f0-4244-9919-22966a8516ef", "f540a10b-acad-4a88-8353-720952be4089", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "149969fd-f31d-4a7f-9c91-f413c350f9fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82400ad8-74f0-4244-9919-22966a8516ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4fc039b-8e55-4633-9726-320718ae68ba");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Customer",
                type: "int",
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
    }
}
