using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class testst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "c",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "cp",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "dp",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "ndf",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "p",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "tdn",
                table: "dbug_milkRecord");

            migrationBuilder.AlterColumn<string>(
                name: "milkingStatus",
                table: "dbug_milkRecord",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "milkingStatus",
                table: "dbug_milkRecord",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "c",
                table: "dbug_milkRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cp",
                table: "dbug_milkRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dp",
                table: "dbug_milkRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ndf",
                table: "dbug_milkRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "p",
                table: "dbug_milkRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tdn",
                table: "dbug_milkRecord",
                nullable: true);
        }
    }
}
