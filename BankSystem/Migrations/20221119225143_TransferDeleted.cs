using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class TransferDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PoundAccountHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                table: "PoundAccountHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EuroAccountHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                table: "EuroAccountHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DollarAccountHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BeneficiaryName",
                table: "DollarAccountHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "PoundAccountHistory");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                table: "PoundAccountHistory");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "EuroAccountHistory");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                table: "EuroAccountHistory");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DollarAccountHistory");

            migrationBuilder.DropColumn(
                name: "BeneficiaryName",
                table: "DollarAccountHistory");

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DollarAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    EuroAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    PoundAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "TEXT", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsInstant = table.Column<bool>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_DollarAccounts_DollarAccountFK",
                        column: x => x.DollarAccountFK,
                        principalTable: "DollarAccounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_Transfers_EuroAccounts_EuroAccountFK",
                        column: x => x.EuroAccountFK,
                        principalTable: "EuroAccounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_Transfers_PoundAccounts_PoundAccountFK",
                        column: x => x.PoundAccountFK,
                        principalTable: "PoundAccounts",
                        principalColumn: "AccountNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_DollarAccountFK",
                table: "Transfers",
                column: "DollarAccountFK");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_EuroAccountFK",
                table: "Transfers",
                column: "EuroAccountFK");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_PoundAccountFK",
                table: "Transfers",
                column: "PoundAccountFK");
        }
    }
}
