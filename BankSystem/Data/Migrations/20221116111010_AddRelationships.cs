using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Data.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IDnumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IDnumber);
                });

            migrationBuilder.CreateTable(
                name: "DollarAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DollarFunds = table.Column<double>(type: "float", nullable: false),
                    IDnumberFK = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DollarAccounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_DollarAccounts_Clients_IDnumberFK",
                        column: x => x.IDnumberFK,
                        principalTable: "Clients",
                        principalColumn: "IDnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EuroAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EuroFunds = table.Column<double>(type: "float", nullable: false),
                    IDnumberFK = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EuroAccounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_EuroAccounts_Clients_IDnumberFK",
                        column: x => x.IDnumberFK,
                        principalTable: "Clients",
                        principalColumn: "IDnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NetIncome = table.Column<double>(type: "float", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    MonthToPayOff = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IDnumberFK = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplications_Clients_IDnumberFK",
                        column: x => x.IDnumberFK,
                        principalTable: "Clients",
                        principalColumn: "IDnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoundAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoundFunds = table.Column<double>(type: "float", nullable: false),
                    IDnumberFK = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoundAccounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_PoundAccounts_Clients_IDnumberFK",
                        column: x => x.IDnumberFK,
                        principalTable: "Clients",
                        principalColumn: "IDnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsInstant = table.Column<bool>(type: "bit", nullable: false),
                    EuroAccountFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DollarAccountFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoundAccountFK = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "HistoryOfTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EuroAccountFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DollarAccountFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoundAccountFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransferFK = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_DollarAccounts_IDnumberFK",
                table: "DollarAccounts",
                column: "IDnumberFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EuroAccounts_IDnumberFK",
                table: "EuroAccounts",
                column: "IDnumberFK",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_IDnumberFK",
                table: "LoanApplications",
                column: "IDnumberFK");

            migrationBuilder.CreateIndex(
                name: "IX_PoundAccounts_IDnumberFK",
                table: "PoundAccounts",
                column: "IDnumberFK",
                unique: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryOfTransactions");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "DollarAccounts");

            migrationBuilder.DropTable(
                name: "EuroAccounts");

            migrationBuilder.DropTable(
                name: "PoundAccounts");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
