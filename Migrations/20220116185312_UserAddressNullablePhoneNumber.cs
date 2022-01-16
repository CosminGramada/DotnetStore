using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetStore.Migrations
{
    public partial class UserAddressNullablePhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserAddresses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                    name: "PhoneNumber",
                    table: "UserAddresses",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
