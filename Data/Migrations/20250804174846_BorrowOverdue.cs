using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetPracticeCrud.Data.Migrations
{
    /// <inheritdoc />
    public partial class BorrowOverdue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BorrowOverdue",
                table: "BorrowModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowOverdue",
                table: "BorrowModel");
        }
    }
}
