using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class WantedMeToUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52295ff3-d2e0-4839-b68f-961095b28835");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc90e4eb-2e84-4b4c-b989-897a24d4b255");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec7b51e-0cc4-4a41-8158-df1f2eb6279e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f5f726d-d735-4be8-af94-aaffe8b02e75", "05ddf7cd-d7d2-471f-a704-ca650a8425fd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "353f9143-b841-47a4-a0ec-27f17d07bce2", "199ea967-d3e4-4de3-b50b-a2bd2f855d4e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3c03f29b-da14-4f24-8fa7-f1a3fa86e4d4", "46e00fa8-9d29-48ce-83d1-ac1121472d70", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f5f726d-d735-4be8-af94-aaffe8b02e75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "353f9143-b841-47a4-a0ec-27f17d07bce2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c03f29b-da14-4f24-8fa7-f1a3fa86e4d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fec7b51e-0cc4-4a41-8158-df1f2eb6279e", "30d4eee7-9a83-4f1f-87ce-5defd50ad8ad", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52295ff3-d2e0-4839-b68f-961095b28835", "685a9de3-b211-4fc4-9bb2-3f1b06cb3e43", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc90e4eb-2e84-4b4c-b989-897a24d4b255", "0285dec0-12c4-4a82-ba60-c676acf19c05", "Customer", "CUSTOMER" });
        }
    }
}
