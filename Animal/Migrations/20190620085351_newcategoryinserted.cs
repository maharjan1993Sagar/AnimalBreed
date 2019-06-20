using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class newcategoryinserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "dbug_FeedFooder",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "dbug_FeedFooder");
        }
    }
}
