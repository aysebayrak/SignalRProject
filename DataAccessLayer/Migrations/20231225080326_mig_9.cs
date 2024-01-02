using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "MenuTableId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets",
                column: "MenuTableId",
                principalTable: "MenuTables",
                principalColumn: "MenuTableId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Products_ProductId",
                table: "Baskets",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Products_ProductId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "MenuTableId",
                table: "Baskets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets",
                column: "MenuTableId",
                principalTable: "MenuTables",
                principalColumn: "MenuTableId");
        }
    }
}
