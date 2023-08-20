using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCamp.Data.Migrations
{
    public partial class Ispassed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPassed",
                table: "Tests");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Tests",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsPassed",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
