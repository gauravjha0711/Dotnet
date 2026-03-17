using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Sheetdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Duration" },
                values: new object[,]
                {
                    { 1, "Asp.Net Core MVC", 6 },
                    { 2, "Entity Framework Core", 4 }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "Location" },
                values: new object[,]
                {
                    { 1, "Computer Science", "A-Block" },
                    { 2, "Mechanical Engineering", "B-Block" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "DepartmentId", "Email", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, 20, 1, "alice@example.com", "Female", "Alice Johnson" },
                    { 2, 22, 2, "bob@example.com", "Male", "Bob Smith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Departments");
        }
    }
}
