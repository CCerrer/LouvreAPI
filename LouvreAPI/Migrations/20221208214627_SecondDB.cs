using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LouvreAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Pinturas");

            migrationBuilder.AddColumn<int>(
                name: "YearMade",
                table: "Pinturas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearMade",
                table: "Pinturas");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Pinturas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
