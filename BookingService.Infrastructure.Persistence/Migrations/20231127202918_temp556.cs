using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingService.Infrastructure.Persistence.Migrations
{
    public partial class temp556 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfigurationJson",
                table: "Calendar",
                newName: "Universe_domain");

            migrationBuilder.AddColumn<string>(
                name: "Auth_provider_x509_cert_url",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Auth_uri",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Client_email",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Client_id",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Client_x509_cert_url",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Private_key",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Private_key_id",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Project_id",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Token_uri",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auth_provider_x509_cert_url",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Auth_uri",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Client_email",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Client_id",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Client_x509_cert_url",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Private_key",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Private_key_id",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Project_id",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Token_uri",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Calendar");

            migrationBuilder.RenameColumn(
                name: "Universe_domain",
                table: "Calendar",
                newName: "ConfigurationJson");
        }
    }
}
