using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VariantId = table.Column<int>(type: "integer", nullable: false),
                    WarehouseId = table.Column<int>(type: "integer", nullable: false),
                    CurrentStock = table.Column<int>(type: "integer", nullable: false),
                    CriticalLevel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    SKU = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CriticalLevel", "CurrentStock", "VariantId", "WarehouseId" },
                values: new object[,]
                {
                    { 1, 5, 25, 1, 1 },
                    { 2, 10, 4, 2, 1 },
                    { 3, 10, 50, 3, 1 },
                    { 4, 5, 12, 4, 1 },
                    { 5, 5, 8, 5, 2 },
                    { 6, 3, 15, 9, 2 },
                    { 7, 5, 2, 10, 2 },
                    { 8, 4, 20, 12, 3 },
                    { 9, 10, 30, 15, 3 },
                    { 10, 5, 7, 19, 4 },
                    { 11, 2, 3, 23, 4 },
                    { 12, 5, 18, 27, 5 },
                    { 13, 4, 9, 30, 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "Color", "ProductId", "SKU", "Size" },
                values: new object[,]
                {
                    { 1, "Siyah", 1, "TIS-SIY-S", "S" },
                    { 2, "Siyah", 1, "TIS-SIY-M", "M" },
                    { 3, "Siyah", 1, "TIS-SIY-L", "L" },
                    { 4, "Beyaz", 1, "TIS-BEY-S", "S" },
                    { 5, "Beyaz", 1, "TIS-BEY-M", "M" },
                    { 6, "Beyaz", 1, "TIS-BEY-L", "L" },
                    { 7, "Gri", 1, "TIS-GRI-M", "M" },
                    { 8, "Gri", 1, "TIS-GRI-L", "L" },
                    { 9, "Mavi", 2, "AYA-MAV-40", "40" },
                    { 10, "Mavi", 2, "AYA-MAV-42", "42" },
                    { 11, "Mavi", 2, "AYA-MAV-44", "44" },
                    { 12, "Siyah", 2, "AYA-SIY-41", "41" },
                    { 13, "Siyah", 2, "AYA-SIY-42", "42" },
                    { 14, "Siyah", 2, "AYA-SIY-43", "43" },
                    { 15, "Mavi", 3, "PAN-MAV-30", "30/32" },
                    { 16, "Mavi", 3, "PAN-MAV-32", "32/32" },
                    { 17, "Siyah", 3, "PAN-SIY-32", "32/32" },
                    { 18, "Siyah", 3, "PAN-SIY-34", "34/32" },
                    { 19, "Kırmızı", 4, "SWE-KIR-M", "M" },
                    { 20, "Kırmızı", 4, "SWE-KIR-L", "L" },
                    { 21, "Lacivert", 4, "SWE-LAC-M", "M" },
                    { 22, "Lacivert", 4, "SWE-LAC-L", "L" },
                    { 23, "Siyah", 5, "CEK-SIY-L", "L" },
                    { 24, "Kahverengi", 5, "CEK-KAH-XL", "XL" },
                    { 25, "Haki", 6, "KAR-HAK-32", "32" },
                    { 26, "Haki", 6, "KAR-HAK-34", "34" },
                    { 27, "Bej", 7, "CAN-BEJ-STD", "Standart" },
                    { 28, "Siyah", 7, "CAN-SIY-STD", "Standart" },
                    { 29, "Siyah", 8, "SAP-SIY-AYR", "Ayarlanabilir" },
                    { 30, "Sarı", 10, "YAG-SAR-L", "L" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Pamuklu Günlük Tişört", "Oversize Tişört", 299.99m },
                    { 2, "Hafif Spor Ayakkabı", "Koşu Ayakkabısı", 1299.99m },
                    { 3, "Esnek Denim Pantolon", "Slim Fit Kot Pantolon", 699.99m },
                    { 4, "Kışlık Polar Sweatshirt", "Kapşonlu Sweatshirt", 549.99m },
                    { 5, "Hakiki Deri Mont", "Deri Ceket", 2499.99m },
                    { 6, "Çok Cepli Rahat Pantolon", "Kargo Pantolon", 799.99m },
                    { 7, "Günlük Kullanım Çantası", "Canvas Sırt Çantası", 449.99m },
                    { 8, "İşlemeli Pamuklu Şapka", "Beyzbol Şapkası", 199.99m },
                    { 9, "Nefes Alabilir Kumaş", "Sporcu Atleti", 149.99m },
                    { 10, "Su Geçirmez Rüzgarlık", "Yağmurluk", 899.99m }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "İstanbul", "İstanbul Merkez Depo" },
                    { 2, "Trabzon", "Trabzon Şube Depo" },
                    { 3, "İzmir", "İzmir Lojistik Merkezi" },
                    { 4, "Ankara", "Ankara Bölge Deposu" },
                    { 5, "Antalya", "Antalya Dağıtım Deposu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
