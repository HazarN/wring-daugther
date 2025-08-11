using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "IsAdmin", "Password", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "hazar@example.com", true, "hashed_password_1", "HazarN" },
                    { 2, new DateTime(2001, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "john@example.com", false, "hashed_password_2", "JohnD" },
                    { 3, new DateTime(2001, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), "jane@example.com", false, "hashed_password_3", "JaneD" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
