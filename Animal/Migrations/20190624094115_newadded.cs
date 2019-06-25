using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Speciesid",
                table: "dbug_milkBaseNutrition",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dbug_milkBaseNutrition_Speciesid",
                table: "dbug_milkBaseNutrition",
                column: "Speciesid");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_milkBaseNutrition_dbug_Species_Speciesid",
                table: "dbug_milkBaseNutrition",
                column: "Speciesid",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_milkBaseNutrition_dbug_Species_Speciesid",
                table: "dbug_milkBaseNutrition");

            migrationBuilder.DropIndex(
                name: "IX_dbug_milkBaseNutrition_Speciesid",
                table: "dbug_milkBaseNutrition");

            migrationBuilder.DropColumn(
                name: "Speciesid",
                table: "dbug_milkBaseNutrition");
        }
    }
}
