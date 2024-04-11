using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbOpeationsWithEFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedTwoNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Book_Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CurrenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Book_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Book_Prices_tbl_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "tbl_Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Book_Prices_tbl_Currencies_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "tbl_Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Book_Prices_BookId",
                table: "tbl_Book_Prices",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Book_Prices_CurrenciesId",
                table: "tbl_Book_Prices",
                column: "CurrenciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Book_Prices");

            migrationBuilder.DropTable(
                name: "tbl_Currencies");
        }
    }
}
