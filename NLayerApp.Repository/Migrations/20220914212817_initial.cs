using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerApp.Repository.Migrations
{
	public partial class initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Stock = table.Column<int>(type: "int", nullable: false),
					CategoryId = table.Column<int>(type: "int", nullable: false),
					CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
					table.ForeignKey(
						name: "FK_Products_Categories_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Categories",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ProductFeatures",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Height = table.Column<int>(type: "int", maxLength: 20, nullable: false),
					Width = table.Column<int>(type: "int", maxLength: 20, nullable: false),
					ProductId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductFeatures", x => x.Id);
					table.ForeignKey(
						name: "FK_ProductFeatures_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Categories",
				columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
				values: new object[,]
				{
					{ 1, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(8796), "Ev & Mobilya", null },
					{ 2, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(8804), "Kozmetik", null },
					{ 3, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(8805), "Saat & Aksesuar", null },
					{ 4, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(8806), "Elektronik", null },
					{ 5, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(8807), "Sport & Outdoor", null }
				});

			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
				values: new object[,]
				{
					{ 1, 1, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(9078), "LAV Bardak Seti", 160.12m, 120, null },
					{ 2, 2, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(9082), "Laventin Cilt Beyazlatici Krem", 108.12m, 242, null },
					{ 3, 3, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(9083), "Casio A159wa-n1df Erkek Kol Saati", 370.12m, 58, null },
					{ 4, 4, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(9084), "Apple Iphone 11 64GB", 15549.12m, 87, null },
					{ 5, 5, new DateTime(2022, 9, 15, 0, 28, 17, 183, DateTimeKind.Local).AddTicks(9085), "Protein Ocean Whey Protein", 172.12m, 1200, null }
				});

			migrationBuilder.InsertData(
				table: "ProductFeatures",
				columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
				values: new object[,]
				{
					{ 1, "Mavi", 12, 1, 5 },
					{ 2, "Beyaz", 8, 2, 3 },
					{ 3, "Gri", 4, 3, 4 },
					{ 4, "Siyah", 15, 4, 6 },
					{ 5, "Kahverengi", 20, 5, 18 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_ProductFeatures_ProductId",
				table: "ProductFeatures",
				column: "ProductId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Products_CategoryId",
				table: "Products",
				column: "CategoryId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ProductFeatures");

			migrationBuilder.DropTable(
				name: "Products");

			migrationBuilder.DropTable(
				name: "Categories");
		}
	}
}
