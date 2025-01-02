using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class Add_Slug_To_Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "23939c13-80f1-4fce-ac4c-d36c7058d62a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d8ff49e3-1f52-4a2a-914b-054555850d09");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Term",
                table: "Flashcards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageFileName",
                table: "Flashcards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Definition",
                table: "Flashcards",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1612), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1615), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1616) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1617), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1618) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1619), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1621), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1623), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1625), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1627), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1630), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1632), new DateTime(2025, 1, 1, 16, 23, 43, 983, DateTimeKind.Local).AddTicks(1632) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4b26219-76e0-4243-9978-4d18b54ae0dc", null, "Admin", "ADMIN" },
                    { "b0242484-1b5c-44b0-a48d-2d9c1442bf8f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a4b26219-76e0-4243-9978-4d18b54ae0dc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b0242484-1b5c-44b0-a48d-2d9c1442bf8f");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Languages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Term",
                table: "Flashcards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageFileName",
                table: "Flashcards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Definition",
                table: "Flashcards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5492), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5493) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5495), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5497), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5497) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5499), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5499) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5501), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5502) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5503), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5503) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5505), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5506) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5507), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5507) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5509), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5509) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5511), new DateTime(2024, 12, 30, 15, 39, 35, 179, DateTimeKind.Local).AddTicks(5511) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23939c13-80f1-4fce-ac4c-d36c7058d62a", null, "Admin", "ADMIN" },
                    { "d8ff49e3-1f52-4a2a-914b-054555850d09", null, "User", "USER" }
                });
        }
    }
}
