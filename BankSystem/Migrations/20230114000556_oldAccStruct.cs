using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class oldAccStruct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DollarAccounts_AspNetUsers_IDnumberFK",
                table: "DollarAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_EuroAccounts_AspNetUsers_IDnumberFK",
                table: "EuroAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AspNetUsers_IDnumberFK",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_PoundAccounts_AspNetUsers_IDnumberFK",
                table: "PoundAccounts");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "PoundAccountHistory");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "EuroAccountHistory");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "DollarAccountHistory");

            migrationBuilder.RenameColumn(
                name: "IDnumberFK",
                table: "PoundAccounts",
                newName: "ClientFK");

            migrationBuilder.RenameIndex(
                name: "IX_PoundAccounts_IDnumberFK",
                table: "PoundAccounts",
                newName: "IX_PoundAccounts_ClientFK");

            migrationBuilder.RenameColumn(
                name: "IDnumberFK",
                table: "LoanApplications",
                newName: "ClientFK");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_IDnumberFK",
                table: "LoanApplications",
                newName: "IX_LoanApplications_ClientFK");

            migrationBuilder.RenameColumn(
                name: "IDnumberFK",
                table: "EuroAccounts",
                newName: "ClientFK");

            migrationBuilder.RenameIndex(
                name: "IX_EuroAccounts_IDnumberFK",
                table: "EuroAccounts",
                newName: "IX_EuroAccounts_ClientFK");

            migrationBuilder.RenameColumn(
                name: "IDnumberFK",
                table: "DollarAccounts",
                newName: "ClientFK");

            migrationBuilder.RenameIndex(
                name: "IX_DollarAccounts_IDnumberFK",
                table: "DollarAccounts",
                newName: "IX_DollarAccounts_ClientFK");

            migrationBuilder.CreateTable(
                name: "DepositViewModel",
                columns: table => new
                {
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DollarAccounts_AspNetUsers_ClientFK",
                table: "DollarAccounts",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EuroAccounts_AspNetUsers_ClientFK",
                table: "EuroAccounts",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AspNetUsers_ClientFK",
                table: "LoanApplications",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoundAccounts_AspNetUsers_ClientFK",
                table: "PoundAccounts",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DollarAccounts_AspNetUsers_ClientFK",
                table: "DollarAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_EuroAccounts_AspNetUsers_ClientFK",
                table: "EuroAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AspNetUsers_ClientFK",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_PoundAccounts_AspNetUsers_ClientFK",
                table: "PoundAccounts");

            migrationBuilder.DropTable(
                name: "DepositViewModel");

            migrationBuilder.RenameColumn(
                name: "ClientFK",
                table: "PoundAccounts",
                newName: "IDnumberFK");

            migrationBuilder.RenameIndex(
                name: "IX_PoundAccounts_ClientFK",
                table: "PoundAccounts",
                newName: "IX_PoundAccounts_IDnumberFK");

            migrationBuilder.RenameColumn(
                name: "ClientFK",
                table: "LoanApplications",
                newName: "IDnumberFK");

            migrationBuilder.RenameIndex(
                name: "IX_LoanApplications_ClientFK",
                table: "LoanApplications",
                newName: "IX_LoanApplications_IDnumberFK");

            migrationBuilder.RenameColumn(
                name: "ClientFK",
                table: "EuroAccounts",
                newName: "IDnumberFK");

            migrationBuilder.RenameIndex(
                name: "IX_EuroAccounts_ClientFK",
                table: "EuroAccounts",
                newName: "IX_EuroAccounts_IDnumberFK");

            migrationBuilder.RenameColumn(
                name: "ClientFK",
                table: "DollarAccounts",
                newName: "IDnumberFK");

            migrationBuilder.RenameIndex(
                name: "IX_DollarAccounts_ClientFK",
                table: "DollarAccounts",
                newName: "IX_DollarAccounts_IDnumberFK");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "PoundAccountHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "EuroAccountHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "DollarAccountHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DollarAccounts_AspNetUsers_IDnumberFK",
                table: "DollarAccounts",
                column: "IDnumberFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EuroAccounts_AspNetUsers_IDnumberFK",
                table: "EuroAccounts",
                column: "IDnumberFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AspNetUsers_IDnumberFK",
                table: "LoanApplications",
                column: "IDnumberFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoundAccounts_AspNetUsers_IDnumberFK",
                table: "PoundAccounts",
                column: "IDnumberFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
