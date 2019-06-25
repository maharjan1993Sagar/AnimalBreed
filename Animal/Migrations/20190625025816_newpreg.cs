using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newpreg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_pregnancyBawseNutrition_dbug_Species_Speciesid",
                table: "dbug_pregnancyBawseNutrition");

            migrationBuilder.RenameColumn(
                name: "Speciesid",
                table: "dbug_pregnancyBawseNutrition",
                newName: "speciesId");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_pregnancyBawseNutrition_Speciesid",
                table: "dbug_pregnancyBawseNutrition",
                newName: "IX_dbug_pregnancyBawseNutrition_speciesId");

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

            migrationBuilder.RenameColumn(
                name: "speciesId",
                table: "dbug_pregnancyBawseNutrition",
                newName: "Speciesid");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_pregnancyBawseNutrition_speciesId",
                table: "dbug_pregnancyBawseNutrition",
                newName: "IX_dbug_pregnancyBawseNutrition_Speciesid");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_pregnancyBawseNutrition_dbug_Species_Speciesid",
                table: "dbug_pregnancyBawseNutrition",
                column: "Speciesid",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
