using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetStore.Migrations
{
    public partial class SeedCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("445fc913-87c3-4ca4-93de-1cd342d30f8c"), new DateTime(2022, 1, 8, 23, 49, 28, 814, DateTimeKind.Local).AddTicks(6040), "Unisex", new DateTime(2022, 1, 8, 23, 49, 28, 814, DateTimeKind.Local).AddTicks(6040) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("5b4c5fd0-7004-457a-b833-136b56eafd74"), new DateTime(2022, 1, 8, 23, 49, 28, 814, DateTimeKind.Local).AddTicks(6040), "Men", new DateTime(2022, 1, 8, 23, 49, 28, 814, DateTimeKind.Local).AddTicks(6040) });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("e026a1b8-8154-4627-b064-a914880f4fc9"), new DateTime(2022, 1, 8, 23, 49, 28, 814, DateTimeKind.Local).AddTicks(6040), "Women", new DateTime(2022, 1, 8, 23, 49, 28, 814, DateTimeKind.Local).AddTicks(6040) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("445fc913-87c3-4ca4-93de-1cd342d30f8c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5b4c5fd0-7004-457a-b833-136b56eafd74"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e026a1b8-8154-4627-b064-a914880f4fc9"));
        }
    }
}
