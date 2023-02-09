using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingModule.Migrations
{
    /// <inheritdoc />
    public partial class NextMigrations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registerations_courses_course_id",
                table: "registerations");

            migrationBuilder.DropForeignKey(
                name: "FK_registerations_students_stud_id",
                table: "registerations");

            migrationBuilder.DropIndex(
                name: "IX_registerations_course_id",
                table: "registerations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_registerations_course_id",
                table: "registerations",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_registerations_courses_course_id",
                table: "registerations",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_registerations_students_stud_id",
                table: "registerations",
                column: "stud_id",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
