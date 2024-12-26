using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class Courses_CoursePermissions_Flashcards_Folders_CourseFolders_Language_Permission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "86c54653-fe0b-4c32-b771-fa1b1283543c");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "be1425de-dd91-48d9-bb98-bebfbf8b967b");

            migrationBuilder.AlterColumn<string>(
                name: "AvatarFileName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseFolder",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FolderId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFolder", x => new { x.CourseId, x.FolderId });
                    table.ForeignKey(
                        name: "FK_CourseFolder_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseFolder_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMark = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Term_LangId = table.Column<int>(type: "int", nullable: false),
                    Definition_LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flashcards_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flashcards_Languages_Definition_LangId",
                        column: x => x.Definition_LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Flashcards_Languages_Term_LangId",
                        column: x => x.Term_LangId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CoursePermissions",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ViewPermissionId = table.Column<int>(type: "int", nullable: false),
                    EditPermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePermissions", x => new { x.CourseId, x.EditPermissionId, x.ViewPermissionId });
                    table.ForeignKey(
                        name: "FK_CoursePermissions_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePermissions_Permissions_EditPermissionId",
                        column: x => x.EditPermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoursePermissions_Permissions_ViewPermissionId",
                        column: x => x.ViewPermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "en", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(722), "English", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(722) },
                    { 2, "fr", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(725), "French", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(725) },
                    { 3, "de", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(727), "German", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(728) },
                    { 4, "es", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(729), "Spanish", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(730) },
                    { 5, "it", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(731), "Italian", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(732) },
                    { 6, "pt", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(733), "Portuguese", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(734) },
                    { 7, "zh", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(735), "Chinese", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(736) },
                    { 8, "ja", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(737), "Japanese", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(738) },
                    { 9, "ru", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(739), "Russian", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(740) },
                    { 10, "ar", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(741), "Arabic", new DateTime(2024, 12, 24, 17, 45, 18, 902, DateTimeKind.Local).AddTicks(742) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "IsEdit", "Name" },
                values: new object[,]
                {
                    { 1, "Mọi người đều có thể sử dụng học phần này", false, "Mọi người" },
                    { 2, "Chỉ những người có mật khẩu mới có thể sử dụng học phần này", false, "Người có mật khẩu" },
                    { 3, "Chỉ tôi mới có thể sử dụng học phần này", false, "Chỉ tôi" },
                    { 4, "Chỉ tôi mới có thể chỉnh sửa học phần này", true, "Chỉ tôi" },
                    { 5, "Chỉ những người có mật khẩu mới có thể chỉnh sửa học phần này", true, "Người có mật khẩu" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d3669c8-4383-48dc-a284-94a08e624b5e", null, "User", "USER" },
                    { "ffd6f260-8df9-4ed4-9944-9be11aa04876", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFolder_FolderId",
                table: "CourseFolder",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePermissions_EditPermissionId",
                table: "CoursePermissions",
                column: "EditPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePermissions_ViewPermissionId",
                table: "CoursePermissions",
                column: "ViewPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_CourseId",
                table: "Flashcards",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_Definition_LangId",
                table: "Flashcards",
                column: "Definition_LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_Term_LangId",
                table: "Flashcards",
                column: "Term_LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_UserId1",
                table: "Folders",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseFolder");

            migrationBuilder.DropTable(
                name: "CoursePermissions");

            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d3669c8-4383-48dc-a284-94a08e624b5e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ffd6f260-8df9-4ed4-9944-9be11aa04876");

            migrationBuilder.AlterColumn<string>(
                name: "AvatarFileName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86c54653-fe0b-4c32-b771-fa1b1283543c", null, "User", "USER" },
                    { "be1425de-dd91-48d9-bb98-bebfbf8b967b", null, "Admin", "ADMIN" }
                });
        }
    }
}
