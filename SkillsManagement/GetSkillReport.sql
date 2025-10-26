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
END