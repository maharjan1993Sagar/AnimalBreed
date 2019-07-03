using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class realtionwithlabtomilkRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "labId",
                table: "dbug_milkRecord",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "lab",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    proprietor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lab", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbug_milkRecord_labId",
                table: "dbug_milkRecord",
                column: "labId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_milkRecord_lab_labId",
                table: "dbug_milkRecord",
                column: "labId",
                principalTable: "lab",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_milkRecord_lab_labId",
                table: "dbug_milkRecord");

            migrationBuilder.DropTable(
                name: "lab");

            migrationBuilder.DropIndex(
                name: "IX_dbug_milkRecord_labId",
                table: "dbug_milkRecord");

            migrationBuilder.AlterColumn<string>(
                name: "labId",
                table: "dbug_milkRecord",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
