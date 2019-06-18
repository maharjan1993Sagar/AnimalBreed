using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class TableName_changed_animalowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalOwner_dbug_animal_AnimalId",
                table: "AnimalOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimalOwner_dbug_ownerKeeper_OwnerId",
                table: "AnimalOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalOwner",
                table: "AnimalOwner");

            migrationBuilder.RenameTable(
                name: "AnimalOwner",
                newName: "dbug_animalOwner");

            migrationBuilder.RenameIndex(
                name: "IX_AnimalOwner_OwnerId",
                table: "dbug_animalOwner",
                newName: "IX_dbug_animalOwner_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbug_animalOwner",
                table: "dbug_animalOwner",
                columns: new[] { "AnimalId", "OwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animalOwner_dbug_animal_AnimalId",
                table: "dbug_animalOwner",
                column: "AnimalId",
                principalTable: "dbug_animal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animalOwner_dbug_ownerKeeper_OwnerId",
                table: "dbug_animalOwner",
                column: "OwnerId",
                principalTable: "dbug_ownerKeeper",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animalOwner_dbug_animal_AnimalId",
                table: "dbug_animalOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animalOwner_dbug_ownerKeeper_OwnerId",
                table: "dbug_animalOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbug_animalOwner",
                table: "dbug_animalOwner");

            migrationBuilder.RenameTable(
                name: "dbug_animalOwner",
                newName: "AnimalOwner");

            migrationBuilder.RenameIndex(
                name: "IX_dbug_animalOwner_OwnerId",
                table: "AnimalOwner",
                newName: "IX_AnimalOwner_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalOwner",
                table: "AnimalOwner",
                columns: new[] { "AnimalId", "OwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalOwner_dbug_animal_AnimalId",
                table: "AnimalOwner",
                column: "AnimalId",
                principalTable: "dbug_animal",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalOwner_dbug_ownerKeeper_OwnerId",
                table: "AnimalOwner",
                column: "OwnerId",
                principalTable: "dbug_ownerKeeper",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
