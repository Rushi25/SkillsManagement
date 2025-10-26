using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillsManagement.Migrations
{
    /// <inheritdoc />
    public partial class Report : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillReport",
                columns: table => new
                {
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfEmployees = table.Column<int>(type: "int", nullable: false),
                    MinRating = table.Column<int>(type: "int", nullable: false),
                    MaxRating = table.Column<int>(type: "int", nullable: false),
                    AvgRating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillReport");
        }
    }
}
