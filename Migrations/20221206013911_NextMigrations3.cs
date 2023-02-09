using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingModule.Migrations
{
    /// <inheritdoc />
    public partial class NextMigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_courses_course_id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_students_stud_id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherCourses_courses_course_id",
                table: "teacherCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_teacherCourses_teachers_teacher_id",
                table: "teacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_teacherCourses_course_id",
                table: "teacherCourses");

            migrationBuilder.DropIndex(
                name: "IX_Categories_course_id",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_teacherCourses_course_id",
                table: "teacherCourses",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_course_id",
                table: "Categories",
                column: "course_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_courses_course_id",
                table: "Categories",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_students_stud_id",
                table: "Categories",
                column: "stud_id",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherCourses_courses_course_id",
                table: "teacherCourses",
                column: "course_id",
                principalTable: "courses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacherCourses_teachers_teacher_id",
                table: "teacherCourses",
                column: "teacher_id",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
