using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradingModule.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    credithours = table.Column<int>(type: "int", nullable: false),
                    prerequisite = table.Column<string>(name: "pre_requisite", type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fname = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    depart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentbatch = table.Column<string>(name: "student_batch", type: "nvarchar(5)", maxLength: 5, nullable: false),
                    currentsem = table.Column<string>(name: "current_sem", type: "nvarchar(1)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contactnumber = table.Column<string>(name: "contact_number", type: "nvarchar(15)", maxLength: 15, nullable: false),
                    section = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cgpa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    designation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    studid = table.Column<string>(name: "stud_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    courseid = table.Column<string>(name: "course_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CategoryNameSequence = table.Column<int>(type: "int", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => new { x.studid, x.courseid, x.CategoryName, x.CategoryNameSequence });
                    table.ForeignKey(
                        name: "FK_Categories_courses_course_id",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_students_stud_id",
                        column: x => x.studid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "marks",
                columns: table => new
                {
                    studid = table.Column<string>(name: "stud_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    courseid = table.Column<string>(name: "course_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    marks = table.Column<int>(type: "int", nullable: false),
                    semester = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    grade = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marks", x => new { x.studid, x.courseid });
                    table.ForeignKey(
                        name: "FK_marks_courses_course_id",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_marks_students_stud_id",
                        column: x => x.studid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "registerations",
                columns: table => new
                {
                    studid = table.Column<string>(name: "stud_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    courseid = table.Column<string>(name: "course_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    section = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cstatus = table.Column<string>(name: "c_status", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    prerequisite = table.Column<string>(name: "pre_requisite", type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registerations", x => new { x.studid, x.courseid });
                    table.ForeignKey(
                        name: "FK_registerations_courses_course_id",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registerations_students_stud_id",
                        column: x => x.studid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacherCourses",
                columns: table => new
                {
                    teacherid = table.Column<string>(name: "teacher_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    courseid = table.Column<string>(name: "course_id", type: "nvarchar(10)", maxLength: 10, nullable: false),
                    section = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacherCourses", x => new { x.teacherid, x.courseid, x.section });
                    table.ForeignKey(
                        name: "FK_teacherCourses_courses_course_id",
                        column: x => x.courseid,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacherCourses_teachers_teacher_id",
                        column: x => x.teacherid,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_course_id",
                table: "Categories",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_marks_course_id",
                table: "marks",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_registerations_course_id",
                table: "registerations",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacherCourses_course_id",
                table: "teacherCourses",
                column: "course_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "marks");

            migrationBuilder.DropTable(
                name: "registerations");

            migrationBuilder.DropTable(
                name: "teacherCourses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
