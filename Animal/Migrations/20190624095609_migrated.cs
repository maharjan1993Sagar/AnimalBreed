using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class migrated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_milkBaseNutrition_dbug_Species_Speciesid",
                table: "dbug_milkBaseNutrition");

            migrationBuilder.DropColumn(
                name: "animalSpecies",
                table: "dbug_milkBaseNutrition");

            migrationBuilder.RenameColumn(
                name: "Speciesid",
                table: "dbug_milkBaseNutrition",
                newName: "SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_milkBaseNutrition_Speciesid",
                table: "dbug_milkBaseNutrition",
                newName: "IX_dbug_milkBaseNutrition_SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_milkBaseNutrition_dbug_Species_SpeciesId",
                table: "dbug_milkBaseNutrition",
                column: "SpeciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_milkBaseNutrition_dbug_Species_SpeciesId",
                table: "dbug_milkBaseNutrition");

            migrationBuilder.RenameColumn(
                name: "SpeciesId",
                table: "dbug_milkBaseNutrition",
                newName: "Speciesid");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_milkBaseNutrition_SpeciesId",
                table: "dbug_milkBaseNutrition",
                newName: "IX_dbug_milkBaseNutrition_Speciesid");

            migrationBuilder.AddColumn<string>(
                name: "animalSpecies",
                table: "dbug_milkBaseNutrition",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_milkBaseNutrition_dbug_Species_Speciesid",
                table: "dbug_milkBaseNutrition",
                column: "Speciesid",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
