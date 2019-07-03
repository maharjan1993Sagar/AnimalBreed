using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class keeper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "keeper",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    category = table.Column<string>(nullable: true),
                    fullName = table.Column<string>(nullable: true),
                    occupation = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    municipililty = table.Column<string>(nullable: true),
                    wardNo = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    logitude = table.Column<string>(nullable: true),
                    dob = table.Column<string>(nullable: true),
                    academicQualification = table.Column<string>(nullable: true),
                    finantanceStatus = table.Column<string>(nullable: true),
                    mobileNumber = table.Column<string>(nullable: true),
                    otherNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    farmid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keeper", x => x.id);
                    table.ForeignKey(
                        name: "FK_keeper_dbug_farm_farmid",
                        column: x => x.farmid,
                        principalTable: "dbug_farm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbug_animal_keeperId",
                table: "dbug_animal",
                column: "keeperId");

            migrationBuilder.CreateIndex(
                name: "IX_keeper_farmid",
                table: "keeper",
                column: "farmid");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_keeper_keeperId",
                table: "dbug_animal",
                column: "keeperId",
                principalTable: "keeper",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_keeper_keeperId",
                table: "dbug_animal");

            migrationBuilder.DropTable(
                name: "keeper");

            migrationBuilder.DropIndex(
                name: "IX_dbug_animal_keeperId",
                table: "dbug_animal");
        }
    }
}
