using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NnmLesson12EFCore.Migrations.App
{
    public partial class NnmCreateCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NnmBanner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NnmName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NnmImage = table.Column<string>(type: "varchar(150)", nullable: true),
                    NnmDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NnmCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NnmStatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NnmBanner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NnmCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NnmName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NnmStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    NnmCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NnmCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NnmProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NnmName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NnmImage = table.Column<string>(type: "varchar(150)", nullable: true),
                    NnmPrice = table.Column<float>(type: "real", nullable: false),
                    NnmSalePrice = table.Column<float>(type: "real", nullable: false),
                    NnmStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    NnmDescriptions = table.Column<string>(type: "ntext", maxLength: 1000, nullable: true),
                    NnmCategoryId = table.Column<int>(type: "int", nullable: false),
                    NnmCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NnmProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NnmProduct_NnmCategory_NnmCategoryId",
                        column: x => x.NnmCategoryId,
                        principalTable: "NnmCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "NnmBanner",
                columns: new[] { "Id", "NnmCreatedDate", "NnmDescription", "NnmImage", "NnmName", "NnmStatus" },
                values: new object[] { 1, new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Nguyễn Ngọc Mạnh - 2410900051 - K24-CNT2", "lesson12.svg", "Chào mừng đến với Lesson12", (byte)1 });

            migrationBuilder.InsertData(
                table: "NnmCategory",
                columns: new[] { "Id", "NnmCreatedDate", "NnmName", "NnmStatus" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Sách", (byte)1 },
                    { 2, new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Đồ dùng học tập", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "NnmProduct",
                columns: new[] { "Id", "NnmCategoryId", "NnmCreatedDate", "NnmDescriptions", "NnmImage", "NnmName", "NnmPrice", "NnmSalePrice", "NnmStatus" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Sổ tay dùng để ghi chép bài học.", "notebook.svg", "Sổ tay", 45000f, 39000f, (byte)1 },
                    { 2, 1, new DateTime(2026, 9, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), "Sách tham khảo lập trình.", "book.svg", "Sách lập trình", 150000f, 0f, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NnmProduct_NnmCategoryId",
                table: "NnmProduct",
                column: "NnmCategoryId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NnmBanner");

            migrationBuilder.DropTable(
                name: "NnmProduct");

            migrationBuilder.DropTable(
                name: "NnmCategory");
        }
    }
}
