using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchManagerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BranchId",
                table: "Managers",
                column: "BranchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Branches_BranchId",
                table: "Managers",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Branches_BranchId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_BranchId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Managers");
        }
    }
}
