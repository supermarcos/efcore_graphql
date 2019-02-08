using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreCodeFirstSample.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsEmployeeContext_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Employees",
                newName: "MobilePhone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MobilePhone",
                table: "Employees",
                newName: "PhoneNumber");
        }
    }
}
