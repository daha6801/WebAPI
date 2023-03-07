using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtProducts",
                columns: table => new
                {
                    ArtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtPrice = table.Column<float>(type: "real", nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ArtDimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtScore = table.Column<int>(type: "int", nullable: false),
                    imgBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtProducts", x => x.ArtId);
                });

            migrationBuilder.InsertData(
                table: "ArtProducts",
                columns: new[] { "ArtId", "ArtDesc", "ArtDimensions", "ArtName", "ArtPrice", "ArtScore", "imgBytes", "isAvailable" },
                values: new object[,]
                {
                    { 1, "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs.", "7*12", "Harry Potter and the Sorcerer's Stone", 2000f, 15, new byte[0], true },
                    { 2, "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. ", "7*12", "Harry Potter and the Chamber of Secrets", 3000f, 20, new byte[0], false },
                    { 3, "Walter Isaacson’s “enthralling” (The New Yorker) worldwide bestselling biography of Apple cofounder Steve Jobs.", "12*18", "Steve Jobs", 4000f, 35, new byte[0], true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtProducts");
        }
    }
}
