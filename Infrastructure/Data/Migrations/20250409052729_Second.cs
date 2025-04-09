using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R2ETien.EFCore.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { new Guid("23716b2f-115d-4a99-ae32-2e34d18f30b6"), new Guid("36bb2475-a10b-445c-9735-16e399dfaacb") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { new Guid("8db1e41b-e756-4b85-a26f-7d1162f34346"), new Guid("36bb2475-a10b-445c-9735-16e399dfaacb") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { new Guid("97dfa0ee-d1c5-4b54-b9bb-77e737725429"), new Guid("4d6b8dde-ff43-4e7f-84c5-409da7d9d0f1") });

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("28546848-9293-435d-bab4-57fff8ac666c"));

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("c2a53dff-c0c6-4686-9cbb-448d896398ee"));

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("eed9fc38-ac26-4bc2-b997-c0877b6b8398"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("23716b2f-115d-4a99-ae32-2e34d18f30b6"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("8db1e41b-e756-4b85-a26f-7d1162f34346"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("97dfa0ee-d1c5-4b54-b9bb-77e737725429"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("36bb2475-a10b-445c-9735-16e399dfaacb"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("4d6b8dde-ff43-4e7f-84c5-409da7d9d0f1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("3555b647-ab77-49a9-8800-3acf50b01737"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7c9cf760-db1b-4014-888b-1a3a768e3f43"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e9f05c98-f19c-40e9-97a2-099dc63fcfb0"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "HR" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "IT" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "Apollo" },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "Hermes" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "JoinedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob" },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2021, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "EmployeeId", "ProjectId", "Enable" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), true },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), true },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), true }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "Amount", "EmployeeId" },
                values: new object[,]
                {
                    { new Guid("fa111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 5000m, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("fa222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), 6000m, new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb") },
                    { new Guid("fa333333-cccc-cccc-cccc-cccccccccccc"), 5500m, new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") });

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("fa111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("fa222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: new Guid("fa333333-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

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
        }
    }
}
