using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Learning_Web.Migrations
{
    public partial class _dai1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserQuestions_AspNetUsers_AppUserId",
                table: "AppUserQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserQuestions_Questions_QuestionID",
                table: "AppUserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AppUserQuestions_AppUserId",
                table: "AppUserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AppUserQuestions_QuestionID",
                table: "AppUserQuestions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AppUserQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "AppUserQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "AppUsersId",
                table: "AppUserQuestions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserQuestions_AppUsersId",
                table: "AppUserQuestions",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserQuestions_QuestionsId",
                table: "AppUserQuestions",
                column: "QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserQuestions_AspNetUsers_AppUsersId",
                table: "AppUserQuestions",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserQuestions_Questions_QuestionsId",
                table: "AppUserQuestions",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserQuestions_AspNetUsers_AppUsersId",
                table: "AppUserQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserQuestions_Questions_QuestionsId",
                table: "AppUserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AppUserQuestions_AppUsersId",
                table: "AppUserQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AppUserQuestions_QuestionsId",
                table: "AppUserQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "AppUsersId",
                table: "AppUserQuestions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "AppUserQuestions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "AppUserQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserQuestions_AppUserId",
                table: "AppUserQuestions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserQuestions_QuestionID",
                table: "AppUserQuestions",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserQuestions_AspNetUsers_AppUserId",
                table: "AppUserQuestions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserQuestions_Questions_QuestionID",
                table: "AppUserQuestions",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
