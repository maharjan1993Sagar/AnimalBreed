using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class dpChangedToDmPregnancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dp",
                table: "dbug_pregnancyBawseNutrition",
                newName: "dm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dm",
                table: "dbug_pregnancyBawseNutrition",
                newName: "dp");
        }
    }
}
