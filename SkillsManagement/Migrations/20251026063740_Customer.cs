using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillsManagement.Migrations
{
    /// <inheritdoc />
    public partial class Customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "EmployeeSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_CustomerId",
                table: "EmployeeSkills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CustomerId",
                table: "Employees",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Customers_CustomerId",
                table: "Employees",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Customers_CustomerId",
                table: "EmployeeSkills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Customers_CustomerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Customers_CustomerId",
                table: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSkills_CustomerId",
                table: "EmployeeSkills");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CustomerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "EmployeeSkills");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Employees");
        }
    }
}
