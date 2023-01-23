using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class LoanForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MonthToPayOff",
                table: "LoanApplications",
                newName: "MonthsToPayOff");

            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "LoanApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MonthlyIncome",
                table: "LoanApplications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "MonthlyIncome",
                table: "LoanApplications");

            migrationBuilder.RenameColumn(
                name: "MonthsToPayOff",
                table: "LoanApplications",
                newName: "MonthToPayOff");
        }
    }
}
