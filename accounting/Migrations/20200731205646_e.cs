using Microsoft.EntityFrameworkCore.Migrations;

namespace accounting.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "People",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IsPeople",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDperson = table.Column<int>(nullable: false),
                    IDproduct = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsPeople", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IsPeople_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IsPeople_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonID",
                table: "People",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_IsPeople_PersonID",
                table: "IsPeople",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_IsPeople_ProductID",
                table: "IsPeople",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_PersonID",
                table: "People",
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

            migrationBuilder.DropTable(
                name: "IsPeople");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonID",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "People");
        }
    }
}
