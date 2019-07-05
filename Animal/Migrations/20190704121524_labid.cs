using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class labid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_milkRecord_lab_labId",
                table: "dbug_milkRecord");

            migrationBuilder.AlterColumn<int>(
                name: "labId",
                table: "dbug_milkRecord",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_milkRecord_lab_labId",
                table: "dbug_milkRecord",
                column: "labId",
                principalTable: "lab",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbug_milkRecord_lab_labId",
                table: "dbug_milkRecord");

            migrationBuilder.AlterColumn<int>(
                name: "labId",
                table: "dbug_milkRecord",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dbug_milkRecord_lab_labId",
                table: "dbug_milkRecord",
                column: "labId",
                principalTable: "lab",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
