using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class AccountsHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryOfTransactions");

            migrationBuilder.RenameColumn(
                name: "PoundFunds",
                table: "PoundAccounts",
                newName: "Funds");

            migrationBuilder.RenameColumn(
                name: "EuroFunds",
                table: "EuroAccounts",
                newName: "Funds");

            migrationBuilder.RenameColumn(
                name: "DollarFunds",
                table: "DollarAccounts",
                newName: "Funds");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "PoundAccounts",
                type: "TEXT",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "EuroAccounts",
                type: "TEXT",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "DollarAccounts",
                type: "TEXT",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DollarAccountHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "TEXT", nullable: false),
                    DollarAccountFK = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DollarAccountHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DollarAccountHistory_DollarAccounts_DollarAccountFK",
                        column: x => x.DollarAccountFK,
                        principalTable: "DollarAccounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EuroAccountHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "TEXT", nullable: false),
                    EuroAccountFK = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EuroAccountHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EuroAccountHistory_EuroAccounts_EuroAccountFK",
                        column: x => x.EuroAccountFK,
                        principalTable: "EuroAccounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoundAccountHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "TEXT", nullable: false),
                    PoundAccountFK = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoundAccountHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoundAccountHistory_PoundAccounts_PoundAccountFK",
                        column: x => x.PoundAccountFK,
                        principalTable: "PoundAccounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DollarAccountHistory_DollarAccountFK",
                table: "DollarAccountHistory",
                column: "DollarAccountFK");

            migrationBuilder.CreateIndex(
                name: "IX_EuroAccountHistory_EuroAccountFK",
                table: "EuroAccountHistory",
                column: "EuroAccountFK");

            migrationBuilder.CreateIndex(
                name: "IX_PoundAccountHistory_PoundAccountFK",
                table: "PoundAccountHistory",
                column: "PoundAccountFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DollarAccountHistory");

            migrationBuilder.DropTable(
                name: "EuroAccountHistory");

            migrationBuilder.DropTable(
                name: "PoundAccountHistory");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "PoundAccounts");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "EuroAccounts");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "DollarAccounts");

            migrationBuilder.RenameColumn(
                name: "Funds",
                table: "PoundAccounts",
                newName: "PoundFunds");

            migrationBuilder.RenameColumn(
                name: "Funds",
                table: "EuroAccounts",
                newName: "EuroFunds");

            migrationBuilder.RenameColumn(
                name: "Funds",
                table: "DollarAccounts",
                newName: "DollarFunds");

            migrationBuilder.CreateTable(
                name: "HistoryOfTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DollarAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    EuroAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    PoundAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    TransferFK = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryOfTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryOfTransactions_DollarAccounts_DollarAccountFK",
                        column: x => x.DollarAccountFK,
                        principalTable: "DollarAccounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_HistoryOfTransactions_EuroAccounts_EuroAccountFK",
                        column: x => x.EuroAccountFK,
                        principalTable: "EuroAccounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_HistoryOfTransactions_PoundAccounts_PoundAccountFK",
                        column: x => x.PoundAccountFK,
                        principalTable: "PoundAccounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_HistoryOfTransactions_Transfers_TransferFK",
                        column: x => x.TransferFK,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfTransactions_DollarAccountFK",
                table: "HistoryOfTransactions",
                column: "DollarAccountFK");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfTransactions_EuroAccountFK",
                table: "HistoryOfTransactions",
                column: "EuroAccountFK");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfTransactions_PoundAccountFK",
                table: "HistoryOfTransactions",
                column: "PoundAccountFK");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryOfTransactions_TransferFK",
                table: "HistoryOfTransactions",
                column: "TransferFK",
                unique: true);
        }
    }
}
