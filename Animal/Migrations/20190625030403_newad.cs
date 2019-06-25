using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_pregnancyBawseNutrition_dbug_Species_speciesId",
                table: "dbug_pregnancyBawseNutrition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_pregnancyBawseNutrition",
                table: "dbug_pregnancyBawseNutrition");

            migrationBuilder.RenameTable(
                name: "dbug_pregnancyBawseNutrition",
                newName: "dbug_pregnancyBaseNutrition");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_pregnancyBawseNutrition_speciesId",
                table: "dbug_pregnancyBaseNutrition",
                newName: "IX_dbug_pregnancyBaseNutrition_speciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_pregnancyBaseNutrition",
                table: "dbug_pregnancyBaseNutrition",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_pregnancyBaseNutrition_dbug_Species_speciesId",
                table: "dbug_pregnancyBaseNutrition",
                column: "speciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_pregnancyBaseNutrition_dbug_Species_speciesId",
                table: "dbug_pregnancyBaseNutrition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_pregnancyBaseNutrition",
                table: "dbug_pregnancyBaseNutrition");

            migrationBuilder.RenameTable(
                name: "dbug_pregnancyBaseNutrition",
                newName: "dbug_pregnancyBawseNutrition");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_pregnancyBaseNutrition_speciesId",
                table: "dbug_pregnancyBawseNutrition",
                newName: "IX_dbug_pregnancyBawseNutrition_speciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_pregnancyBawseNutrition",
                table: "dbug_pregnancyBawseNutrition",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_pregnancyBawseNutrition_dbug_Species_speciesId",
                table: "dbug_pregnancyBawseNutrition",
                column: "speciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
