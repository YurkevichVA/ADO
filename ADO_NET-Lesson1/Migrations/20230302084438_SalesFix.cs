using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADO_NET_Lesson1.Migrations
{
    /// <inheritdoc />
    public partial class SalesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MSales",
                table: "MSales");

            migrationBuilder.RenameTable(
                name: "MSales",
                newName: "Sales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "MSales");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MSales",
                table: "MSales",
                column: "Id");
        }
    }
}
