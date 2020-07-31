using Microsoft.EntityFrameworkCore.Migrations;

namespace accounting.Migrations
{
    public partial class ee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_PersonID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "People",
                type: "int",
                nullable: true);

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
        }
    }
}
