using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class LoanChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "City",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "NetIncome",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "LoanApplications");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "LoanApplications",
                newName: "IDnumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDnumber",
                table: "LoanApplications",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "LoanApplications",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "LoanApplications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "NetIncome",
                table: "LoanApplications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "LoanApplications",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
