using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADO_NET_Lesson1.Migrations
{
    /// <inheritdoc />
    public partial class SalesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Manager_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeleteDt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSales");
        }
    }
}
