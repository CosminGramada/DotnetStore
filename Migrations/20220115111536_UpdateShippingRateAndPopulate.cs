using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetStore.Migrations
{
    public partial class UpdateShippingRateAndPopulate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "ShippingOptions",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "ShippingOptions",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Rate", "UpdatedAt" },
                values: new object[] { new Guid("69ba739d-d8cd-4ca5-82ee-9df8f778b679"), new DateTime(2022, 1, 15, 13, 15, 35, 890, DateTimeKind.Local).AddTicks(2120), "Free (2-3 weeks)", "Free", 0m, new DateTime(2022, 1, 15, 13, 15, 35, 890, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.InsertData(
                table: "ShippingOptions",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Rate", "UpdatedAt" },
                values: new object[] { new Guid("992c3278-91c3-4ea1-b598-cce842b37bda"), new DateTime(2022, 1, 15, 13, 15, 35, 890, DateTimeKind.Local).AddTicks(2120), "Express (1-2 days)", "Express", 49.8m, new DateTime(2022, 1, 15, 13, 15, 35, 890, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.InsertData(
                table: "ShippingOptions",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Rate", "UpdatedAt" },
                values: new object[] { new Guid("c82493ac-4f9d-4f6b-9a85-f12015f8ae9b"), new DateTime(2022, 1, 15, 13, 15, 35, 890, DateTimeKind.Local).AddTicks(2120), "Standard (6-7 days)", "Standard", 20.57m, new DateTime(2022, 1, 15, 13, 15, 35, 890, DateTimeKind.Local).AddTicks(2120) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShippingOptions",
                keyColumn: "Id",
                keyValue: new Guid("69ba739d-d8cd-4ca5-82ee-9df8f778b679"));

            migrationBuilder.DeleteData(
                table: "ShippingOptions",
                keyColumn: "Id",
                keyValue: new Guid("992c3278-91c3-4ea1-b598-cce842b37bda"));

            migrationBuilder.DeleteData(
                table: "ShippingOptions",
                keyColumn: "Id",
                keyValue: new Guid("c82493ac-4f9d-4f6b-9a85-f12015f8ae9b"));

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "ShippingOptions");
        }
    }
}
