using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintedMedia.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    YearBorn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Books_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBooks_Authors_BookId",
                        column: x => x.BookId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name", "YearBorn" },
                values: new object[,]
                {
                    { 1, "Kurt Weill", 1900 },
                    { 2, "Gillian Flynn", 1971 },
                    { 3, "Donald Reinertsen", 1950 },
                    { 4, "Yuri Lotman", 1922 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manning" },
                    { 2, "Sage" },
                    { 3, "Routledge" },
                    { 4, "Wiley" },
                    { 5, "O'Reilly" },
                    { 6, "Harvard Business Press" },
                    { 7, "Packt Publishing" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "PublisherId", "Title", "Year" },
                values: new object[,]
                {
                    { 5, 1, "Easy Performance", 2019 },
                    { 6, 1, "Continuous Breaks", 2010 },
                    { 1, 4, "C# – Up & Running", 2013 },
                    { 3, 4, "Event-Driven Development", 2019 },
                    { 4, 6, "Myths of management", 2021 },
                    { 2, 7, "Design Now", 1983 }
                });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "AuthorBooks",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[] { 1, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
