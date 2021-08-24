using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromoApp.Migrations
{
    public partial class InitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    promoId = table.Column<string>(nullable: true),
                    promoDesc = table.Column<string>(nullable: true),
                    promoType = table.Column<string>(nullable: true),
                    promoStart = table.Column<DateTime>(nullable: false),
                    promoEnd = table.Column<DateTime>(nullable: false),
                    item = table.Column<string>(nullable: true),
                    store = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    storeId = table.Column<string>(nullable: true),
                    storeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
