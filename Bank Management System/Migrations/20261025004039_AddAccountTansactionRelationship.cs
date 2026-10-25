using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountTansactionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchId",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OwnerShipDate",
                table: "customersAccount",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

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

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Transactions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OwnerShipDate",
                table: "customersAccount",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Branches_BranchId",
                table: "Accounts",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

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
