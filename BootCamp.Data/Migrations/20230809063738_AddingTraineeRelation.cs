using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCamp.Data.Migrations
{
    public partial class AddingTraineeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TraineeId",
                table: "Tests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "PhoneNumbers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PhoneNumbers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "PhoneNumbers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "PhoneNumbers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tests_TraineeId",
                table: "Tests",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_TraineeId",
                table: "Tests",
                column: "TraineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_TraineeId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_TraineeId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "PhoneNumbers");
        }
    }
}
