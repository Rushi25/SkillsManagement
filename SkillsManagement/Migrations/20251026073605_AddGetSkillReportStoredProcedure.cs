using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillsManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddGetSkillReportStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetSkillReport");
            
            var sp = @"
CREATE PROCEDURE GetSkillReport
    @CustomerId INT
AS
BEGIN
    SELECT
        SkillName,
        COUNT(DISTINCT EmployeeId) AS NoOfEmployees,
        MIN(Rating) AS MinRating,
        MAX(Rating) AS MaxRating,
        AVG(CAST(Rating AS FLOAT)) AS AvgRating
    FROM
        EmployeeSkills
    WHERE
        CustomerId = @CustomerId
    GROUP BY
        SkillName
END";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetSkillReport");
        }
    }
}
