using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class someItemsAddedToUserPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "permission",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "permission",
                table: "Users");
        }
    }
}
