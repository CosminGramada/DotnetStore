using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetStore.Migrations
{
    public partial class SeedDiscountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("1a5c9cd1-bdec-4647-b826-07a3e2fa31ec"), new DateTime(2022, 1, 8, 19, 52, 37, 278, DateTimeKind.Local).AddTicks(5040), "Order", new DateTime(2022, 1, 8, 19, 52, 37, 278, DateTimeKind.Local).AddTicks(5040) });

            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("1f4cbe59-3a92-4de0-b0cc-d58ae83ddf87"), new DateTime(2022, 1, 8, 19, 52, 37, 278, DateTimeKind.Local).AddTicks(5040), "Category", new DateTime(2022, 1, 8, 19, 52, 37, 278, DateTimeKind.Local).AddTicks(5040) });

            migrationBuilder.InsertData(
                table: "DiscountTypes",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("2679fb22-0777-42e1-9338-03fcefbb9070"), new DateTime(2022, 1, 8, 19, 52, 37, 278, DateTimeKind.Local).AddTicks(5040), "Product", new DateTime(2022, 1, 8, 19, 52, 37, 278, DateTimeKind.Local).AddTicks(5040) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountTypes",
                keyColumn: "Id",
                keyValue: new Guid("1a5c9cd1-bdec-4647-b826-07a3e2fa31ec"));

            migrationBuilder.DeleteData(
                table: "DiscountTypes",
                keyColumn: "Id",
                keyValue: new Guid("1f4cbe59-3a92-4de0-b0cc-d58ae83ddf87"));

            migrationBuilder.DeleteData(
                table: "DiscountTypes",
                keyColumn: "Id",
                keyValue: new Guid("2679fb22-0777-42e1-9338-03fcefbb9070"));
        }
    }
}
