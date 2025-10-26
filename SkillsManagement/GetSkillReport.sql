CREATE PROCEDURE GetSkillReport
AS
BEGIN
    SELECT
        SkillName,
        COUNT(DISTINCT EmployeeId) AS NoOfEmployees,
        MIN(Rating) AS MinRating,
        MAX(Rating) AS MaxRating,
        AVG(CAST(Rating AS FLOAT)) AS AvgRating
    FROM
        EmployeeSkill
    GROUP BY
        SkillName
END