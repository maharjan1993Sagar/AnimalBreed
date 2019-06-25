using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "animalSpecies",
                table: "dbug_pregnancyBawseNutrition");

            migrationBuilder.AddColumn<int>(
                name: "speciesId",
                table: "dbug_pregnancyBawseNutrition",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dbug_pregnancyBawseNutrition_speciesId",
                table: "dbug_pregnancyBawseNutrition",
                column: "speciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_pregnancyBawseNutrition_dbug_Species_speciesId",
                table: "dbug_pregnancyBawseNutrition",
                column: "speciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_pregnancyBawseNutrition_dbug_Species_speciesId",
                table: "dbug_pregnancyBawseNutrition");

            migrationBuilder.DropIndex(
                name: "IX_dbug_pregnancyBawseNutrition_speciesId",
                table: "dbug_pregnancyBawseNutrition");

            migrationBuilder.DropColumn(
                name: "speciesId",
                table: "dbug_pregnancyBawseNutrition");

            migrationBuilder.AddColumn<string>(
                name: "animalSpecies",
                table: "dbug_pregnancyBawseNutrition",
                nullable: true);
        }
    }
}
