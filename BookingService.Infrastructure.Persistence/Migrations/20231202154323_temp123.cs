using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingService.Infrastructure.Persistence.Migrations
{
    public partial class temp123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Company_CompanyId",
                table: "Service");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Service",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Company_CompanyId",
                table: "Service",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Company_CompanyId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Service");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Service",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Company_CompanyId",
                table: "Service",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
