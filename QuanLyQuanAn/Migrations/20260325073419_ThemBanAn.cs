using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyQuanAn.Migrations
{
    /// <inheritdoc />
    public partial class ThemBanAn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BanAnID",
                table: "HoaDon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BanAn",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanAn", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_BanAnID",
                table: "HoaDon",
                column: "BanAnID");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_BanAn_BanAnID",
                table: "HoaDon",
                column: "BanAnID",
                principalTable: "BanAn",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_BanAn_BanAnID",
                table: "HoaDon");

            migrationBuilder.DropTable(
                name: "BanAn");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_BanAnID",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "BanAnID",
                table: "HoaDon");
        }
    }
}
