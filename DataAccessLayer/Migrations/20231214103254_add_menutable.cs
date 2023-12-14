using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class add_menutable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuTableId",
                table: "Baskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MenuTables",
                columns: table => new
                {
                    MenuTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuTableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuTableStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTables", x => x.MenuTableId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_MenuTableId",
                table: "Baskets",
                column: "MenuTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets",
                column: "MenuTableId",
                principalTable: "MenuTables",
                principalColumn: "MenuTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableId",
                table: "Baskets");

            migrationBuilder.DropTable(
                name: "MenuTables");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_MenuTableId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "MenuTableId",
                table: "Baskets");
        }
    }
}
