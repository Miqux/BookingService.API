using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingService.Infrastructure.Persistence.Migrations
{
    public partial class temp55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_User_CompanyBossId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_CompanyEmployee_EmployeeId",
                table: "Service");

            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropIndex(
                name: "IX_Service_EmployeeId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyBossId",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalendarId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CalendarId",
                table: "Company",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Calendar_CalendarId",
                table: "Company",
                column: "CalendarId",
                principalTable: "Calendar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_CompanyBossId",
                table: "Company",
                column: "CompanyBossId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Calendar_CalendarId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_User_CompanyBossId",
                table: "Company");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropIndex(
                name: "IX_Company_CalendarId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyBossId",
                table: "Company",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_EmployeeId",
                table: "Service",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_CompanyId",
                table: "CompanyEmployee",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_CompanyBossId",
                table: "Company",
                column: "CompanyBossId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_CompanyEmployee_EmployeeId",
                table: "Service",
                column: "EmployeeId",
                principalTable: "CompanyEmployee",
                principalColumn: "Id");
        }
    }
}
