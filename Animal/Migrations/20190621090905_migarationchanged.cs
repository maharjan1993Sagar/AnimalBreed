using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class migarationchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_Species_dbug_animal_AnimalRegistrationid",
                table: "dbug_Species");

            migrationBuilder.DropIndex(
                name: "IX_dbug_Species_AnimalRegistrationid",
                table: "dbug_Species");

            migrationBuilder.DropColumn(
                name: "AnimalRegistrationid",
                table: "dbug_Species");

            migrationBuilder.DropColumn(
                name: "species",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal");

            migrationBuilder.AddColumn<int>(
                name: "AnimalRegistrationid",
                table: "dbug_Species",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "speciesId",
                table: "dbug_animal",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "species",
                table: "dbug_animal",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dbug_Species_AnimalRegistrationid",
                table: "dbug_Species",
                column: "AnimalRegistrationid");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal",
                column: "speciesId",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_Species_dbug_animal_AnimalRegistrationid",
                table: "dbug_Species",
                column: "AnimalRegistrationid",
                principalTable: "dbug_animal",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
