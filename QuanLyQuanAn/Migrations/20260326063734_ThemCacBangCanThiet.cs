using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyQuanAn.Migrations
{
    /// <inheritdoc />
    public partial class ThemCacBangCanThiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CongThucs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonAnID = table.Column<int>(type: "int", nullable: false),
                    NguyenLieuID = table.Column<int>(type: "int", nullable: false),
                    HamLuong = table.Column<double>(type: "float", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongThucs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CongThucs_MonAn_MonAnID",
                        column: x => x.MonAnID,
                        principalTable: "MonAn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CongThucs_NguyenLieu_NguyenLieuID",
                        column: x => x.NguyenLieuID,
                        principalTable: "NguyenLieu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNCC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhieuNhaps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NhaCungCapID = table.Column<int>(type: "int", nullable: false),
                    NhanVienID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhaps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_NhaCungCaps_NhaCungCapID",
                        column: x => x.NhaCungCapID,
                        principalTable: "NhaCungCaps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuNhaps_NhanVien_NhanVienID",
                        column: x => x.NhanVienID,
                        principalTable: "NhanVien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_PhieuNhaps",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhieuNhapID = table.Column<int>(type: "int", nullable: false),
                    NguyenLieuID = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<double>(type: "float", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_PhieuNhaps", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChiTiet_PhieuNhaps_NguyenLieu_NguyenLieuID",
                        column: x => x.NguyenLieuID,
                        principalTable: "NguyenLieu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_PhieuNhaps_PhieuNhaps_PhieuNhapID",
                        column: x => x.PhieuNhapID,
                        principalTable: "PhieuNhaps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_PhieuNhaps_NguyenLieuID",
                table: "ChiTiet_PhieuNhaps",
                column: "NguyenLieuID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_PhieuNhaps_PhieuNhapID",
                table: "ChiTiet_PhieuNhaps",
                column: "PhieuNhapID");

            migrationBuilder.CreateIndex(
                name: "IX_CongThucs_MonAnID",
                table: "CongThucs",
                column: "MonAnID");

            migrationBuilder.CreateIndex(
                name: "IX_CongThucs_NguyenLieuID",
                table: "CongThucs",
                column: "NguyenLieuID");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_NhaCungCapID",
                table: "PhieuNhaps",
                column: "NhaCungCapID");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuNhaps_NhanVienID",
                table: "PhieuNhaps",
                column: "NhanVienID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTiet_PhieuNhaps");

            migrationBuilder.DropTable(
                name: "CongThucs");

            migrationBuilder.DropTable(
                name: "PhieuNhaps");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");
        }
    }
}
