using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetPracticeCrud.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasActiveBook",
                table: "ClientModel",
                newName: "HasBook");

            migrationBuilder.AddColumn<int>(
                name: "bookId",
                table: "ClientModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookId",
                table: "ClientModel");

            migrationBuilder.RenameColumn(
                name: "HasBook",
                table: "ClientModel",
                newName: "HasActiveBook");
        }
    }
}
