using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public class ArtProductInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "ArtProduct",
               columns: table => new
               {
                   ArtId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   ArtName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                   ArtDesc = table.Column<DateTime>(type: "nvarchar(200)", nullable: false),
                   ArtPrice = table.Column<string>(type: "decimal(6,2)", nullable: true),
                   ArtDimensions = table.Column<decimal>(type: "nvarchar(50)", nullable: false),
                   ArtScore = table.Column<decimal>(type: "int", nullable: false),
                   IsAvailable = table.Column<decimal>(type: "BIT", nullable: false),
                   ImgBytes = table.Column<decimal>(type: "varbinary(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_ArtProduct", x => x.ArtId);
               });

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtProduct");
        }
    }
}
