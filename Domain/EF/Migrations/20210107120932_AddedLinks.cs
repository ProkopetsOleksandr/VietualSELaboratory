using Microsoft.EntityFrameworkCore.Migrations;

namespace VietualSELaboratory.Migrations
{
    public partial class AddedLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Statistics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_StatisticsId",
                table: "UserAnswers",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_ExerciseId",
                table: "Statistics",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Exercise_ExerciseId",
                table: "Statistics",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Question_QuestionId",
                table: "UserAnswers",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Statistics_StatisticsId",
                table: "UserAnswers",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Exercise_ExerciseId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Question_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Statistics_StatisticsId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_StatisticsId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_ExerciseId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Statistics");
        }
    }
}
