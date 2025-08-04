using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetPracticeCrud.Data.Migrations
{
    /// <inheritdoc />
    public partial class MajorDBStructureChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientModel_BookModel_bookId",
                table: "ClientModel");

            migrationBuilder.DropIndex(
                name: "IX_ClientModel_bookId",
                table: "ClientModel");

            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "ClientModel");

            migrationBuilder.DropColumn(
                name: "HasBook",
                table: "ClientModel");

            migrationBuilder.DropColumn(
                name: "bookId",
                table: "ClientModel");

            migrationBuilder.CreateTable(
                name: "BorrowModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowModel_BookModel_BookId",
                        column: x => x.BookId,
                        principalTable: "BookModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowModel_ClientModel_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowModel_BookId",
                table: "BorrowModel",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowModel_ClientId",
                table: "BorrowModel",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "ClientModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "HasBook",
                table: "ClientModel",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "bookId",
                table: "ClientModel",
                type: "int",
                nullable: true);

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
    }
}
