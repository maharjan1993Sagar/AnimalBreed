using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "weight",
                table: "dbug_pregnancyBawseNutrition",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "weight",
                table: "dbug_pregnancyBawseNutrition");
        }
    }
}
