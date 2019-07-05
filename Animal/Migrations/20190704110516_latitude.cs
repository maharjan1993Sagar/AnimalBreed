using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class latitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "dbug_animal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "dbug_animal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "latitude",
                table: "dbug_animal");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "dbug_animal");
        }
    }
}
