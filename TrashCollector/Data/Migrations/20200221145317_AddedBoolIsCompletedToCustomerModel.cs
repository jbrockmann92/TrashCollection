using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedBoolIsCompletedToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Pickup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c84b0ceb-36c3-492f-ad93-053cc5c2ba3b", "72566f8c-7289-4efb-a043-bb3f8b61ed90", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86f9bf14-1d70-45ae-9ffc-6213ceb38b18", "22dfa9d2-d270-4cc8-ba83-625e3b24be88", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50191f39-9a73-48e7-9450-10c06ecc4a7c", "e480cddb-26f0-4343-bcbc-988f6bf95ef5", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50191f39-9a73-48e7-9450-10c06ecc4a7c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86f9bf14-1d70-45ae-9ffc-6213ceb38b18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c84b0ceb-36c3-492f-ad93-053cc5c2ba3b");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Pickup");

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
    }
}
