using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetStore.Migrations
{
    public partial class SeedProductData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02f46f26-b512-4aee-a04b-eb0b60169b84"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Red", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) },
                    { new Guid("1aefd651-111f-478b-addf-238b23877e7d"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Green", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) },
                    { new Guid("894c4752-4df0-4afc-8a10-059fb1a6f829"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Black", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) },
                    { new Guid("e90d27dd-6294-4a3f-b198-3f1b08f50a52"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Blue", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) },
                    { new Guid("fe724679-27fe-4074-9e53-a6b008384e80"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Yellow", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new Guid("89c6d235-f7e5-44fd-a25c-c0a373212e87"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "00000000-0000-0000-0000-000000000001.png", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("6b67888f-4a4d-4f72-b4de-abda56c3d3a6"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Extra Large", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) },
                    { new Guid("bbaf06e1-593b-403f-ba2b-64828a788f26"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Small", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) },
                    { new Guid("ccd0a2f3-70b2-4f59-9194-f2f70ced34ee"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Medium", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) },
                    { new Guid("f08d874b-2d41-46f3-a61d-527383f4cca5"), new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090), "Large", new DateTime(2022, 1, 8, 19, 46, 18, 297, DateTimeKind.Local).AddTicks(8090) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("02f46f26-b512-4aee-a04b-eb0b60169b84"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("1aefd651-111f-478b-addf-238b23877e7d"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("894c4752-4df0-4afc-8a10-059fb1a6f829"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("e90d27dd-6294-4a3f-b198-3f1b08f50a52"));

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumn: "Id",
                keyValue: new Guid("fe724679-27fe-4074-9e53-a6b008384e80"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("89c6d235-f7e5-44fd-a25c-c0a373212e87"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("6b67888f-4a4d-4f72-b4de-abda56c3d3a6"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("bbaf06e1-593b-403f-ba2b-64828a788f26"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("ccd0a2f3-70b2-4f59-9194-f2f70ced34ee"));

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumn: "Id",
                keyValue: new Guid("f08d874b-2d41-46f3-a61d-527383f4cca5"));
        }
    }
}
