using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ChangedCustomerFKsToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Pickup_PickupId",
                table: "Customer");

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

            migrationBuilder.AlterColumn<int>(
                name: "PickupId",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Pickup_PickupId",
                table: "Customer",
                column: "PickupId",
                principalTable: "Pickup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Pickup_PickupId",
                table: "Customer");

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

            migrationBuilder.AlterColumn<int>(
                name: "PickupId",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Address_AddressId",
                table: "Customer",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Pickup_PickupId",
                table: "Customer",
                column: "PickupId",
                principalTable: "Pickup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
