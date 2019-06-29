using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class milkVolumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "milkVolumn",
                table: "dbug_pregnancyBaseNutrition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "milkVolumn",
                table: "dbug_milkBaseNutrition",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "milkVolumn",
                table: "dbug_pregnancyBaseNutrition");

            migrationBuilder.DropColumn(
                name: "milkVolumn",
                table: "dbug_milkBaseNutrition");
        }
    }
}
