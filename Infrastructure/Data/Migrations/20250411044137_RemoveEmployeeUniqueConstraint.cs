using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R2ETien.EFCore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmployeeUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Name_DepartmentId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name_DepartmentId",
                table: "Employees",
                columns: new[] { "Name", "DepartmentId" },
                unique: true);
        }
    }
}
