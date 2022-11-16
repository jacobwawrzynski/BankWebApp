using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankSystem.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IDnumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IDnumber);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DollarAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DollarFunds = table.Column<double>(type: "REAL", nullable: false),
                    IDnumberFK = table.Column<string>(type: "TEXT", nullable: false)
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
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    EuroFunds = table.Column<double>(type: "REAL", nullable: false),
                    IDnumberFK = table.Column<string>(type: "TEXT", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    NetIncome = table.Column<double>(type: "REAL", nullable: false),
                    EmploymentType = table.Column<string>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    MonthToPayOff = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    IDnumberFK = table.Column<string>(type: "TEXT", nullable: false)
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
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PoundFunds = table.Column<double>(type: "REAL", nullable: false),
                    IDnumberFK = table.Column<string>(type: "TEXT", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeneficiaryAccount = table.Column<string>(type: "TEXT", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsInstant = table.Column<bool>(type: "INTEGER", nullable: false),
                    EuroAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    DollarAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    PoundAccountFK = table.Column<string>(type: "TEXT", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 6, nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "TEXT", nullable: false),
                    EuroAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    DollarAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    PoundAccountFK = table.Column<string>(type: "TEXT", nullable: false),
                    TransferFK = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "HistoryOfTransactions");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
