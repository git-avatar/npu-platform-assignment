using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicePartUsagePlatform.Services.ScoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedScoreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 10, 11, 58, 46, 263, DateTimeKind.Unspecified).AddTicks(8540), new TimeSpan(0, 1, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "ScoreId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTimeOffset(new DateTime(2024, 2, 10, 11, 58, 14, 922, DateTimeKind.Unspecified).AddTicks(1661), new TimeSpan(0, 1, 0, 0, 0)));
        }
    }
}
