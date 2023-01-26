using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class OnDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_DollarAccounts_AspNetUsers_ClientFK",
                table: "DollarAccounts",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EuroAccounts_AspNetUsers_ClientFK",
                table: "EuroAccounts",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AspNetUsers_ClientFK",
                table: "LoanApplications",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoundAccounts_AspNetUsers_ClientFK",
                table: "PoundAccounts",
                column: "ClientFK",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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
    }
}
