using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirstSample.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsEmployeeContext_update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "Employees",
                nullable: true);
        }
    }
}
