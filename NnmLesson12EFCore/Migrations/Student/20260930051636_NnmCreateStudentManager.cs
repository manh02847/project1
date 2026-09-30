using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NnmLesson12EFCore.Migrations.Student
{
    public partial class NnmCreateStudentManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NnmStdClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NnmClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NnmStdClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NnmSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NnmSubjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NnmSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NnmStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NnmStudentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NnmStudentEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NnmStudentPhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NnmStudentAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NnmStudentAvatar = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NnmStudentBirthday = table.Column<DateTime>(type: "date", nullable: false),
                    NnmClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NnmStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NnmStudent_NnmStdClass_NnmClassId",
                        column: x => x.NnmClassId,
                        principalTable: "NnmStdClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NnmMarks",
                columns: table => new
                {
                    NnmSubjectId = table.Column<int>(type: "int", nullable: false),
                    NnmStudentId = table.Column<int>(type: "int", nullable: false),
                    NnmScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NnmMarks", x => new { x.NnmSubjectId, x.NnmStudentId });
                    table.ForeignKey(
                        name: "FK_NnmMarks_NnmStudent_NnmStudentId",
                        column: x => x.NnmStudentId,
                        principalTable: "NnmStudent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NnmMarks_NnmSubjects_NnmSubjectId",
                        column: x => x.NnmSubjectId,
                        principalTable: "NnmSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "NnmStdClass",
                columns: new[] { "Id", "NnmClassName" },
                values: new object[,]
                {
                    { 1, "K24-CNT2" },
                    { 2, "K24-CNT1" }
                });

            migrationBuilder.InsertData(
                table: "NnmSubjects",
                columns: new[] { "Id", "NnmSubjectName" },
                values: new object[,]
                {
                    { 1, "ASP.NET Core MVC" },
                    { 2, "Cơ sở dữ liệu" }
                });

            migrationBuilder.InsertData(
                table: "NnmStudent",
                columns: new[] { "Id", "NnmClassId", "NnmStudentAddress", "NnmStudentAvatar", "NnmStudentBirthday", "NnmStudentEmail", "NnmStudentName", "NnmStudentPhone" },
                values: new object[] { 1, 1, "Địa chỉ mẫu", "student.svg", new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sinhviena@example.com", "Nguyễn Văn A", "0900000001" });

            migrationBuilder.InsertData(
                table: "NnmMarks",
                columns: new[] { "NnmStudentId", "NnmSubjectId", "NnmScore" },
                values: new object[] { 1, 1, 8.0 });

            migrationBuilder.CreateIndex(
                name: "IX_NnmMarks_NnmStudentId",
                table: "NnmMarks",
                column: "NnmStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_NnmStudent_NnmClassId",
                table: "NnmStudent",
                column: "NnmClassId");

            migrationBuilder.CreateIndex(
                name: "IX_NnmStudent_NnmStudentEmail",
                table: "NnmStudent",
                column: "NnmStudentEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NnmStudent_NnmStudentPhone",
                table: "NnmStudent",
                column: "NnmStudentPhone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NnmSubjects_NnmSubjectName",
                table: "NnmSubjects",
                column: "NnmSubjectName",
                unique: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NnmMarks");

            migrationBuilder.DropTable(
                name: "NnmStudent");

            migrationBuilder.DropTable(
                name: "NnmSubjects");

            migrationBuilder.DropTable(
                name: "NnmStdClass");
        }
    }
}
