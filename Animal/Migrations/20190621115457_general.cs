using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class general : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbug_GeneralNutration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    animalSpecies = table.Column<string>(nullable: true),
                    weight = table.Column<string>(nullable: true),
                    snf = table.Column<string>(nullable: true),
                    dm = table.Column<string>(nullable: true),
                    dp = table.Column<string>(nullable: true),
                    cp = table.Column<string>(nullable: true),
                    tdn = table.Column<string>(nullable: true),
                    ndf = table.Column<string>(nullable: true),
                    c = table.Column<string>(nullable: true),
                    p = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_GeneralNutration", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbug_GeneralNutration");
        }
    }
}
