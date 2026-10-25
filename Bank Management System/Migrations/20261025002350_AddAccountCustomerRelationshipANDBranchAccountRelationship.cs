using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountCustomerRelationshipANDBranchAccountRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    cutomerId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    OwnerShipDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ownershipType = table.Column<int>(type: "int", nullable: false),
                    accountStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customersAccount", x => new { x.cutomerId, x.accountId });
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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchId",
                table: "Accounts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_customersAccount_accountId",
                table: "customersAccount",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_customersAccount_customerId",
                table: "customersAccount",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "customersAccount");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_BranchId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Accounts");
        }
    }
}
