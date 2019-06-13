using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbug_feedFooder",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fooderNameNep = table.Column<string>(nullable: true),
                    fooderNameEng = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    municipility = table.Column<string>(nullable: true),
                    district = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    shortNote = table.Column<string>(nullable: true),
                    cultivation = table.Column<string>(nullable: true),
                    seedingMethod = table.Column<string>(nullable: true),
                    seedHarvestingStorage = table.Column<string>(nullable: true),
                    grassProduct = table.Column<string>(nullable: true),
                    dm = table.Column<string>(nullable: true),
                    cp = table.Column<string>(nullable: true),
                    tdn = table.Column<string>(nullable: true),
                    ndf = table.Column<string>(nullable: true),
                    c = table.Column<string>(nullable: true),
                    p = table.Column<string>(nullable: true),
                    df = table.Column<string>(nullable: true),
                    adl = table.Column<string>(nullable: true),
                    tanni = table.Column<string>(nullable: true),
                    nitrateScore = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbug_feedFooder", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbug_feedFooder");
        }
    }
}
