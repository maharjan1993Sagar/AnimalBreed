using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newspecies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "speciesid",
                table: "dbug_breedAnimal",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    speciesName = table.Column<string>(nullable: true),
                    originFrom = table.Column<string>(nullable: true),
                    shortNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbug_breedAnimal_speciesid",
                table: "dbug_breedAnimal",
                column: "speciesid");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_breedAnimal_Species_speciesid",
                table: "dbug_breedAnimal",
                column: "speciesid",
                principalTable: "Species",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_breedAnimal_Species_speciesid",
                table: "dbug_breedAnimal");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropIndex(
                name: "IX_dbug_breedAnimal_speciesid",
                table: "dbug_breedAnimal");

            migrationBuilder.DropColumn(
                name: "speciesid",
                table: "dbug_breedAnimal");
        }
    }
}
