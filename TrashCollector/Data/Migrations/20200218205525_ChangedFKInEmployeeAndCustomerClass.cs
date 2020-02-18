using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ChangedFKInEmployeeAndCustomerClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b24a392c-edd6-4460-910b-ed2a47224c0c", "878c7856-d7de-4d23-9a81-8a3bbc5be1a8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bc966cc-c7d6-4653-b261-611ea8a193b8", "ff8eec32-e08a-4a1d-90d5-c4dba8b98443", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8426995e-df76-412e-8402-7518cf800a44", "363080ea-277a-4857-ac82-89b93bbb697d", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bc966cc-c7d6-4653-b261-611ea8a193b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8426995e-df76-412e-8402-7518cf800a44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b24a392c-edd6-4460-910b-ed2a47224c0c");

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
    }
}
