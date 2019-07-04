using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class animalimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "dbug_animal",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "dbug_animal");
        }
    }
}
