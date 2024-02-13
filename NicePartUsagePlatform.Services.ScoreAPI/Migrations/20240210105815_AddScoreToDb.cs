using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicePartUsagePlatform.Services.ScoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddScoreToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NpuId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Creativity = table.Column<int>(type: "int", nullable: false),
                    Uniqueness = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreId);
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "ScoreId", "CreatedDate", "Creativity", "NpuId", "Uniqueness", "UserId" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2024, 2, 10, 11, 58, 14, 922, DateTimeKind.Unspecified).AddTicks(1661), new TimeSpan(0, 1, 0, 0, 0)), 8, 1, 7, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
