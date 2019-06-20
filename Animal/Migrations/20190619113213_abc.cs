using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class abc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_breedAnimal_dbug_Species_speciesid",
                table: "dbug_breedAnimal");

            migrationBuilder.RenameColumn(
                name: "speciesid",
                table: "dbug_breedAnimal",
                newName: "speciesId");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_breedAnimal_speciesid",
                table: "dbug_breedAnimal",
                newName: "IX_dbug_breedAnimal_speciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_breedAnimal_dbug_Species_speciesId",
                table: "dbug_breedAnimal",
                column: "speciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_breedAnimal_dbug_Species_speciesId",
                table: "dbug_breedAnimal");

            migrationBuilder.RenameColumn(
                name: "speciesId",
                table: "dbug_breedAnimal",
                newName: "speciesid");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_breedAnimal_speciesId",
                table: "dbug_breedAnimal",
                newName: "IX_dbug_breedAnimal_speciesid");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_breedAnimal_dbug_Species_speciesid",
                table: "dbug_breedAnimal",
                column: "speciesid",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
