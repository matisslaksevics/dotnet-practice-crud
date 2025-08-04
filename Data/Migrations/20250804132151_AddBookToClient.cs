using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetPracticeCrud.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBookToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "ClientModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ClientModel_bookId",
                table: "ClientModel",
                column: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientModel_BookModel_bookId",
                table: "ClientModel",
                column: "bookId",
                principalTable: "BookModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientModel_BookModel_bookId",
                table: "ClientModel");

            migrationBuilder.DropIndex(
                name: "IX_ClientModel_bookId",
                table: "ClientModel");

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "ClientModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
