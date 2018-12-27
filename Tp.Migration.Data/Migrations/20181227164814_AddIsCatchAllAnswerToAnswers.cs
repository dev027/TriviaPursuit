using Microsoft.EntityFrameworkCore.Migrations;

namespace Tp.Migration.Data.Migrations
{
    public partial class AddIsCatchAllAnswerToAnswers : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCatchAllAnswer",
                table: "Answers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCatchAllAnswer",
                table: "Answers");
        }
    }
}
