using Microsoft.EntityFrameworkCore.Migrations;

namespace PromoApp.Migrations
{
    public partial class PromoValueType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "valueType",
                table: "Promotions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valueType",
                table: "Promotions");
        }
    }
}
