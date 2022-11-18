using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class IdentityTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DollarAccounts_Clients_IDnumberFK",
                table: "DollarAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_EuroAccounts_Clients_IDnumberFK",
                table: "EuroAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Clients_IDnumberFK",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_PoundAccounts_Clients_IDnumberFK",
                table: "PoundAccounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IDnumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IDnumber);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DollarAccounts_Clients_IDnumberFK",
                table: "DollarAccounts",
                column: "IDnumberFK",
                principalTable: "Clients",
                principalColumn: "IDnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EuroAccounts_Clients_IDnumberFK",
                table: "EuroAccounts",
                column: "IDnumberFK",
                principalTable: "Clients",
                principalColumn: "IDnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Clients_IDnumberFK",
                table: "LoanApplications",
                column: "IDnumberFK",
                principalTable: "Clients",
                principalColumn: "IDnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoundAccounts_Clients_IDnumberFK",
                table: "PoundAccounts",
                column: "IDnumberFK",
                principalTable: "Clients",
                principalColumn: "IDnumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
