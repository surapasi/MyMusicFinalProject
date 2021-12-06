using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMusic.Migrations
{
    public partial class CreateMyMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Artist = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_Songs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 1, "K-POP" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 2, "R&B" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[] { 3, "Instrumental" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongID", "CategoryID", "Name", "Artist" },
                values: new object[,]
                {
                    { 1, 1, "Life Goes On", "BTS" },
                    { 2, 1, "Wonderland", "ATEEZ" },
                    { 3, 1, "Spring Day", "BTS" },
                    { 4, 1, "New Rules", "TOMORROW X TOGETHER" },
                    { 5, 1, "Alcohol-Free", "TWICE" },
                    { 6, 1, "Middle of the Night", "MONSTA X" },
                    { 7, 2, "Woman", "Doja Cat" },
                    { 8, 2, "End of the Road", "Boyz II Men" },
                    { 9, 3, "Seul Ce Soir", "Swing 41" },
                    { 10, 3, "Cake Waltz (Jimin Theme)", "BTS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CategoryID",
                table: "Songs",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
