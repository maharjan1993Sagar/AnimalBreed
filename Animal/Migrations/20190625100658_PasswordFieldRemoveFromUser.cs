using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class PasswordFieldRemoveFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);
        }
    }
}
