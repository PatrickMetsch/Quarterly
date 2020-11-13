using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quarterly.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfHire = table.Column<DateTime>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SalesId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DateOfHire", "FirstName", "LastName", "ManagerId" },
                values: new object[] { 1, new DateTime(1968, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tommy", "Creo", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DateOfHire", "FirstName", "LastName", "ManagerId" },
                values: new object[] { 2, new DateTime(1970, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Izzy", "Creo", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DateOfHire", "FirstName", "LastName", "ManagerId" },
                values: new object[] { 3, new DateTime(2001, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donovan", "Sapien", 1 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[] { 2, 6715.0, 1, 2, 2013 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[] { 4, 76141.0, 1, 4, 2016 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[] { 1, 87192.0, 2, 3, 2018 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[] { 6, 11341.0, 2, 1, 2013 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[] { 3, 44511.0, 3, 4, 2015 });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[] { 5, 91671.0, 3, 1, 2017 });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
