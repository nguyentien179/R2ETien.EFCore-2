using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R2ETien.EFCore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3555b647-ab77-49a9-8800-3acf50b01737"), "IT" },
                    { new Guid("7c9cf760-db1b-4014-888b-1a3a768e3f43"), "HR" },
                    { new Guid("e9f05c98-f19c-40e9-97a2-099dc63fcfb0"), "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36bb2475-a10b-445c-9735-16e399dfaacb"), "Apollo" },
                    { new Guid("4d6b8dde-ff43-4e7f-84c5-409da7d9d0f1"), "Hermes" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "JoinedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("23716b2f-115d-4a99-ae32-2e34d18f30b6"), new Guid("7c9cf760-db1b-4014-888b-1a3a768e3f43"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice" },
                    { new Guid("8db1e41b-e756-4b85-a26f-7d1162f34346"), new Guid("3555b647-ab77-49a9-8800-3acf50b01737"), new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob" },
                    { new Guid("97dfa0ee-d1c5-4b54-b9bb-77e737725429"), new Guid("e9f05c98-f19c-40e9-97a2-099dc63fcfb0"), new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "EmployeeId", "ProjectId", "Enable" },
                values: new object[,]
                {
                    { new Guid("23716b2f-115d-4a99-ae32-2e34d18f30b6"), new Guid("36bb2475-a10b-445c-9735-16e399dfaacb"), true },
                    { new Guid("8db1e41b-e756-4b85-a26f-7d1162f34346"), new Guid("36bb2475-a10b-445c-9735-16e399dfaacb"), true },
                    { new Guid("97dfa0ee-d1c5-4b54-b9bb-77e737725429"), new Guid("4d6b8dde-ff43-4e7f-84c5-409da7d9d0f1"), true }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "Amount", "EmployeeId" },
                values: new object[,]
                {
                    { new Guid("28546848-9293-435d-bab4-57fff8ac666c"), 5000m, new Guid("23716b2f-115d-4a99-ae32-2e34d18f30b6") },
                    { new Guid("c2a53dff-c0c6-4686-9cbb-448d896398ee"), 5500m, new Guid("97dfa0ee-d1c5-4b54-b9bb-77e737725429") },
                    { new Guid("eed9fc38-ac26-4bc2-b997-c0877b6b8398"), 6000m, new Guid("8db1e41b-e756-4b85-a26f-7d1162f34346") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name_DepartmentId",
                table: "Employees",
                columns: new[] { "Name", "DepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeId",
                table: "ProjectEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
