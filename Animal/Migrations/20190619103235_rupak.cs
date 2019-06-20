using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class rupak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_breedAnimal_Species_speciesid",
                table: "dbug_breedAnimal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Species",
                table: "Species");

            migrationBuilder.RenameTable(
                name: "Species",
                newName: "dbug_Species");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_Species",
                table: "dbug_Species",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_breedAnimal_dbug_Species_speciesid",
                table: "dbug_breedAnimal",
                column: "speciesid",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_breedAnimal_dbug_Species_speciesid",
                table: "dbug_breedAnimal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_Species",
                table: "dbug_Species");

            migrationBuilder.RenameTable(
                name: "dbug_Species",
                newName: "Species");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Species",
                table: "Species",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_breedAnimal_Species_speciesid",
                table: "dbug_breedAnimal",
                column: "speciesid",
                principalTable: "Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
