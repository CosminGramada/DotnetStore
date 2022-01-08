using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetStore.Migrations
{
    public partial class UpdateUserAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "UserAddresses",
                type: "char(36)", 
                nullable: false, 
                collation: "ascii_general_ci"
            );
            
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "UserAddresses",
                type: "char(36)", 
                nullable: true, 
                collation: "ascii_general_ci"
            );
            
            migrationBuilder.DropColumn(
                name: "Region",
                table: "UserAddresses"
            );
            
            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserAddresses"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
