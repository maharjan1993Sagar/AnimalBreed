using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class virtualfarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_dbug_animal_farmId",
                table: "dbug_animal",
                column: "farmId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_dbug_farm_farmId",
                table: "dbug_animal",
                column: "farmId",
                principalTable: "dbug_farm",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_farm_farmId",
                table: "dbug_animal");

            migrationBuilder.DropIndex(
                name: "IX_dbug_animal_farmId",
                table: "dbug_animal");
        }
    }
}
