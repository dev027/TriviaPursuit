using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp.Migration.Data.Migrations
{
    public partial class Init1 : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheeseColour",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheeseColour",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");
        }
    }
}
