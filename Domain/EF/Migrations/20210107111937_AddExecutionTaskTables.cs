using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VietualSELaboratory.Migrations
{
    public partial class AddExecutionTaskTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Grade = table.Column<double>(nullable: false),
                    ExecutionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatisticsId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    CorrectAnswers = table.Column<string>(nullable: true),
                    IncorrectAnswers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                });

          
            migrationBuilder.CreateIndex(
                name: "IX_Question_ExerciseId",
                table: "Question",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Exercise_ExerciseId",
                table: "Question",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Exercise_ExerciseId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Question_ExerciseId",
                table: "Question");
        }
    }
}
