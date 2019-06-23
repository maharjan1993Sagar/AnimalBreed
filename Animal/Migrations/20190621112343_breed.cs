using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class breed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_breedAnimal_breedId",
                table: "dbug_animal");

            migrationBuilder.AlterColumn<int>(
                name: "breedId",
                table: "dbug_animal",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_dbug_breedAnimal_breedId",
                table: "dbug_animal",
                column: "breedId",
                principalTable: "dbug_breedAnimal",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_breedAnimal_breedId",
                table: "dbug_animal");

            migrationBuilder.AlterColumn<int>(
                name: "breedId",
                table: "dbug_animal",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_dbug_breedAnimal_breedId",
                table: "dbug_animal",
                column: "breedId",
                principalTable: "dbug_breedAnimal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
