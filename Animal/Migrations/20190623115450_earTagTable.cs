using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class earTagTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "earTagId",
                table: "dbug_animal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EarTags",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    earTagNo = table.Column<long>(nullable: false),
                    earTagNoStr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EarTags", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbug_animal_earTagId",
                table: "dbug_animal",
                column: "earTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_animal_EarTags_earTagId",
                table: "dbug_animal",
                column: "earTagId",
                principalTable: "EarTags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_animal_EarTags_earTagId",
                table: "dbug_animal");

            migrationBuilder.DropTable(
                name: "EarTags");

            migrationBuilder.DropIndex(
                name: "IX_dbug_animal_earTagId",
                table: "dbug_animal");

            migrationBuilder.DropColumn(
                name: "earTagId",
                table: "dbug_animal");
        }
    }
}
