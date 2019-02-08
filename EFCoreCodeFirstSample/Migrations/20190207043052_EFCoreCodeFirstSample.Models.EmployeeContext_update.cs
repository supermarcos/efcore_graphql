using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirstSample.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsEmployeeContext_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");
        }
    }
}
