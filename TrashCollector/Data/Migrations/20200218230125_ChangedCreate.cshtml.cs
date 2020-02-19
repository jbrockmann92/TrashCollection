using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ChangedCreatecshtml : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2ee8a25-0794-4711-9f27-32aea3cbfdc0", "a68d078e-6e5a-4cdc-ad43-e557be62ad05", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85e3c593-e4c2-4f20-8cd4-b7e9b9dcbece", "d8911e86-2214-4c8f-bb9f-19e76710bda8", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17708125-15fe-4fa9-befe-a300ce013a6c", "1add5bd8-b871-4164-87d3-9ce32a6823cf", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17708125-15fe-4fa9-befe-a300ce013a6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85e3c593-e4c2-4f20-8cd4-b7e9b9dcbece");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2ee8a25-0794-4711-9f27-32aea3cbfdc0");

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
    }
}
