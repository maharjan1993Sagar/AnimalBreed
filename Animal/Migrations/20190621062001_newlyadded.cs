using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newlyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalRegistrationid",
                table: "dbug_Species",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speciesid",
                table: "dbug_Species",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "speciesId",
                table: "dbug_animal",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_dbug_Species_AnimalRegistrationid",
                table: "dbug_Species",
                column: "AnimalRegistrationid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_Species_Speciesid",
                table: "dbug_Species",
                column: "Speciesid");

            migrationBuilder.CreateIndex(
                name: "IX_dbug_animal_speciesId",
                table: "dbug_animal",
                column: "speciesId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_Species_dbug_Species_Speciesid",
                table: "dbug_Species",
                column: "Speciesid",
                principalTable: "dbug_Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_dbug_Species_speciesId",
                table: "dbug_animal");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_Species_dbug_animal_AnimalRegistrationid",
                table: "dbug_Species");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_Species_dbug_Species_Speciesid",
                table: "dbug_Species");

            migrationBuilder.DropIndex(
                name: "IX_dbug_Species_AnimalRegistrationid",
                table: "dbug_Species");

            migrationBuilder.DropIndex(
                name: "IX_dbug_Species_Speciesid",
                table: "dbug_Species");

            migrationBuilder.DropIndex(
                name: "IX_dbug_animal_speciesId",
                table: "dbug_animal");

            migrationBuilder.DropColumn(
                name: "AnimalRegistrationid",
                table: "dbug_Species");

            migrationBuilder.DropColumn(
                name: "Speciesid",
                table: "dbug_Species");

            migrationBuilder.DropColumn(
                name: "speciesId",
                table: "dbug_animal");
        }
    }
}
