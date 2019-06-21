using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class dm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dm",
                table: "dbug_milkBaseNutrition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "weight",
                table: "dbug_milkBaseNutrition",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dm",
                table: "dbug_milkBaseNutrition");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "dbug_milkBaseNutrition");
        }
    }
}
