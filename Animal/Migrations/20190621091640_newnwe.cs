using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newnwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal");

            migrationBuilder.AlterColumn<int>(
                name: "speciesId",
                table: "dbug_animal",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal",
                column: "speciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal");

            migrationBuilder.AlterColumn<int>(
                name: "speciesId",
                table: "dbug_animal",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal",
                column: "speciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
