using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class CorrectCustomerAccountANDaddSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchId",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "customersAccount",
                columns: table => new
                {
                    accountId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    OwnerShipDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ownershipType = table.Column<int>(type: "int", nullable: false),
                    accountStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customersAccount", x => new { x.customerId, x.accountId });
                    table.ForeignKey(
                        name: "FK_customersAccount_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customersAccount_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Financial St", "Main Branch", "555-0100" },
                    { 2, "456 Market Ave", "Downtown Branch", "555-0200" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Name", "NationalID", "PhoneNumber", "Type" },
                values: new object[,]
                {
                    { 1, "789 Oak Rd", new DateOnly(1985, 4, 12), "john@example.com", "John Doe", "NAT-1001", "555-3333", 0 },
                    { 2, "100 Industrial Pkwy", new DateOnly(2010, 1, 1), "contact@acme.com", "Acme Corp", "NAT-2002", "555-4444", 1 }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "BranchId", "Balance", "OpeningDate", "accountType" },
                values: new object[,]
                {
                    { 1, "ACC-9001-2026", 1, 15430.75m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), 0 },
                    { 2, "ACC-9002-2026", 2, 2450m, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), 1 }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "BranchId", "Email", "Name", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "alice.smith@bank.com", "Alice Smith", new DateOnly(2020, 5, 10), "555-1111" },
                    { 2, 2, "bob.jones@bank.com", "Bob Jones", new DateOnly(2021, 8, 15), "555-2222" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionNumber", "AccountId", "Amount", "Date", "Note", "Type" },
                values: new object[,]
                {
                    { 1, 1, 500m, new DateTime(2026, 1, 10, 10, 30, 0, 0, DateTimeKind.Utc), "Initial Deposit", 0 },
                    { 2, 2, 150.5m, new DateTime(2026, 2, 1, 14, 15, 0, 0, DateTimeKind.Utc), "ATM Withdrawal", 1 }
                });

            migrationBuilder.InsertData(
                table: "customersAccount",
                columns: new[] { "accountId", "customerId", "OwnerShipDate", "accountStatus", "ownershipType" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), 0, 0 },
                    { 2, 2, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchId",
                table: "Accounts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_customersAccount_accountId",
                table: "customersAccount",
                column: "accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchId",
                table: "Managers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchId",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_AccountId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "customersAccount");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_BranchId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionNumber",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Accounts");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchId",
                table: "Managers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
