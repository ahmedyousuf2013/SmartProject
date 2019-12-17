using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartProject.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "AddedDate", "DateOfBirth", "Email", "FirstName", "Gender", "IP", "LastName", "ModifiedDate", "PhoneNumber" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "uncle.bob@gmail.com", "Uncle", null, null, "Bob", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "999-888-7777" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "AddedDate", "DateOfBirth", "Email", "FirstName", "Gender", "IP", "LastName", "ModifiedDate", "PhoneNumber" },
                values: new object[] { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jan.kirsten@gmail.com", "Jan", null, null, "Kirsten", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "111-222-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
