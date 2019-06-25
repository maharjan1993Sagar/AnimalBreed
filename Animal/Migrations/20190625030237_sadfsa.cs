using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class sadfsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbug_pregnancyBawseNutrition",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    speciesId = table.Column<int>(nullable: true),
                    breed = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true),
                    PregrenencyType = table.Column<string>(nullable: true),
                    ageOfAnimal = table.Column<string>(nullable: true),
                    fatPercentage = table.Column<string>(nullable: true),
                    snf = table.Column<string>(nullable: true),
                    dm = table.Column<string>(nullable: true),
                    cp = table.Column<string>(nullable: true),
                    tdn = table.Column<string>(nullable: true),
                    ndf = table.Column<string>(nullable: true),
                    c = table.Column<string>(nullable: true),
                    p = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_pregnancyBawseNutrition", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbug_pregnancyBawseNutrition_dbug_Species_speciesId",
                        column: x => x.speciesId,
                        principalTable: "dbug_Species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbug_pregnancyBawseNutrition_speciesId",
                table: "dbug_pregnancyBawseNutrition",
                column: "speciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbug_pregnancyBawseNutrition");
        }
    }
}
