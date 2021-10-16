using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DatabaseCore.Migrations.Migrations.Postgres
{
    public partial class AddProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    Box = table.Column<bool>(type: "boolean", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    DateOfPurchase = table.Column<string>(type: "text", nullable: true),
                    SaleDate = table.Column<string>(type: "text", nullable: true),
                    PurchasePrice = table.Column<double>(type: "double precision", nullable: false),
                    SellingPrice = table.Column<double>(type: "double precision", nullable: true),
                    ShippingPrice = table.Column<double>(type: "double precision", nullable: true),
                    PriceWithoutShipping = table.Column<double>(type: "double precision", nullable: true),
                    Profit = table.Column<double>(type: "double precision", nullable: true),
                    IsSold = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
