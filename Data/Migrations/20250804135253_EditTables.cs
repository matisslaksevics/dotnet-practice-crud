using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetPracticeCrud.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "BookModel");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "ClientModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "ClientModel");

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "BookModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
