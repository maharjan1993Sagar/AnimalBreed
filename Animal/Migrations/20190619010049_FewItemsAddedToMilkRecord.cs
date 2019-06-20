using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class FewItemsAddedToMilkRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "fatPercentage",
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
                name: "snf",
                table: "dbug_milkRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tdn",
                table: "dbug_milkRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "fatPercentage",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "ndf",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "p",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "snf",
                table: "dbug_milkRecord");

            migrationBuilder.DropColumn(
                name: "tdn",
                table: "dbug_milkRecord");
        }
    }
}
