using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace accounting.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_People_PersonID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "CashPayments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonID",
                table: "People",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_PersonID",
                table: "People",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_People_PersonID",
                table: "Products",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_PersonID",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_People_PersonID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "CashPayments");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_People_PersonID",
                table: "Products",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
