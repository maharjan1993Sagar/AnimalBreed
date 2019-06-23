using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class generalupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cp",
                table: "dbug_GeneralNutration");

            migrationBuilder.RenameColumn(
                name: "dp",
                table: "dbug_GeneralNutration",
                newName: "dcp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dcp",
                table: "dbug_GeneralNutration",
                newName: "dp");

            migrationBuilder.AddColumn<string>(
                name: "cp",
                table: "dbug_GeneralNutration",
                nullable: true);
        }
    }
}
