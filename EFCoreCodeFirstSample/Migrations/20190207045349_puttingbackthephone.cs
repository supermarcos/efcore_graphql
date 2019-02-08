using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirstSample.Migrations
{
    public partial class puttingbackthephone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Employees");
        }
    }
}
