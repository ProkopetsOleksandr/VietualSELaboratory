using Microsoft.EntityFrameworkCore.Migrations;

namespace VietualSELaboratory.Migrations
{
    public partial class AddTextPropertyToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Question");
        }
    }
}
