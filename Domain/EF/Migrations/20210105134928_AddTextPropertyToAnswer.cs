using Microsoft.EntityFrameworkCore.Migrations;

namespace VietualSELaboratory.Migrations
{
    public partial class AddTextPropertyToAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Answer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Answer");
        }
    }
}
