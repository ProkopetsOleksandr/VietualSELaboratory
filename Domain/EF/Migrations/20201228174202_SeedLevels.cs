using Microsoft.EntityFrameworkCore.Migrations;

namespace VietualSELaboratory.Migrations
{
    public partial class SeedLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[Level] (Name) VALUES ('Low'), ('Middle'), ('High');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
