using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyQuanAn.Migrations
{
    /// <inheritdoc />
    public partial class ThemBangVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_PhieuNhaps_NguyenLieu_NguyenLieuID",
                table: "ChiTiet_PhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_PhieuNhaps_PhieuNhaps_PhieuNhapID",
                table: "ChiTiet_PhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_CongThucs_MonAn_MonAnID",
                table: "CongThucs");

            migrationBuilder.DropForeignKey(
                name: "FK_CongThucs_NguyenLieu_NguyenLieuID",
                table: "CongThucs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_NhaCungCaps_NhaCungCapID",
                table: "PhieuNhaps");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhaps_NhanVien_NhanVienID",
                table: "PhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuNhaps",
                table: "PhieuNhaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhaCungCaps",
                table: "NhaCungCaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CongThucs",
                table: "CongThucs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTiet_PhieuNhaps",
                table: "ChiTiet_PhieuNhaps");

            migrationBuilder.DropColumn(
                name: "MaVatTu",
                table: "NguyenLieu");

            migrationBuilder.DropColumn(
                name: "TongTien",
                table: "PhieuNhaps");

            migrationBuilder.RenameTable(
                name: "PhieuNhaps",
                newName: "PhieuNhap");

            migrationBuilder.RenameTable(
                name: "NhaCungCaps",
                newName: "NhaCungCap");

            migrationBuilder.RenameTable(
                name: "CongThucs",
                newName: "CongThuc");

            migrationBuilder.RenameTable(
                name: "ChiTiet_PhieuNhaps",
                newName: "ChiTiet_PhieuNhap");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuNhaps_NhanVienID",
                table: "PhieuNhap",
                newName: "IX_PhieuNhap_NhanVienID");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuNhaps_NhaCungCapID",
                table: "PhieuNhap",
                newName: "IX_PhieuNhap_NhaCungCapID");

            migrationBuilder.RenameIndex(
                name: "IX_CongThucs_NguyenLieuID",
                table: "CongThuc",
                newName: "IX_CongThuc_NguyenLieuID");

            migrationBuilder.RenameIndex(
                name: "IX_CongThucs_MonAnID",
                table: "CongThuc",
                newName: "IX_CongThuc_MonAnID");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_PhieuNhaps_PhieuNhapID",
                table: "ChiTiet_PhieuNhap",
                newName: "IX_ChiTiet_PhieuNhap_PhieuNhapID");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_PhieuNhaps_NguyenLieuID",
                table: "ChiTiet_PhieuNhap",
                newName: "IX_ChiTiet_PhieuNhap_NguyenLieuID");

            migrationBuilder.AlterColumn<string>(
                name: "Quyen",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienID",
                table: "PhieuNhap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NhaCungCapID",
                table: "PhieuNhap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayNhap",
                table: "PhieuNhap",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "TongTienHoaDon",
                table: "PhieuNhap",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SoLuong",
                table: "ChiTiet_PhieuNhap",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PhieuNhapID",
                table: "ChiTiet_PhieuNhap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NguyenLieuID",
                table: "ChiTiet_PhieuNhap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGia",
                table: "ChiTiet_PhieuNhap",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuNhap",
                table: "PhieuNhap",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhaCungCap",
                table: "NhaCungCap",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CongThuc",
                table: "CongThuc",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTiet_PhieuNhap",
                table: "ChiTiet_PhieuNhap",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVoucher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhanTramGiam = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_PhieuNhap_NguyenLieu_NguyenLieuID",
                table: "ChiTiet_PhieuNhap",
                column: "NguyenLieuID",
                principalTable: "NguyenLieu",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_PhieuNhap_PhieuNhap_PhieuNhapID",
                table: "ChiTiet_PhieuNhap",
                column: "PhieuNhapID",
                principalTable: "PhieuNhap",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CongThuc_MonAn_MonAnID",
                table: "CongThuc",
                column: "MonAnID",
                principalTable: "MonAn",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CongThuc_NguyenLieu_NguyenLieuID",
                table: "CongThuc",
                column: "NguyenLieuID",
                principalTable: "NguyenLieu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_NhaCungCap_NhaCungCapID",
                table: "PhieuNhap",
                column: "NhaCungCapID",
                principalTable: "NhaCungCap",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhap_NhanVien_NhanVienID",
                table: "PhieuNhap",
                column: "NhanVienID",
                principalTable: "NhanVien",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_PhieuNhap_NguyenLieu_NguyenLieuID",
                table: "ChiTiet_PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_PhieuNhap_PhieuNhap_PhieuNhapID",
                table: "ChiTiet_PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_CongThuc_MonAn_MonAnID",
                table: "CongThuc");

            migrationBuilder.DropForeignKey(
                name: "FK_CongThuc_NguyenLieu_NguyenLieuID",
                table: "CongThuc");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_NhaCungCap_NhaCungCapID",
                table: "PhieuNhap");

            migrationBuilder.DropForeignKey(
                name: "FK_PhieuNhap_NhanVien_NhanVienID",
                table: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhieuNhap",
                table: "PhieuNhap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhaCungCap",
                table: "NhaCungCap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CongThuc",
                table: "CongThuc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChiTiet_PhieuNhap",
                table: "ChiTiet_PhieuNhap");

            migrationBuilder.DropColumn(
                name: "TongTienHoaDon",
                table: "PhieuNhap");

            migrationBuilder.RenameTable(
                name: "PhieuNhap",
                newName: "PhieuNhaps");

            migrationBuilder.RenameTable(
                name: "NhaCungCap",
                newName: "NhaCungCaps");

            migrationBuilder.RenameTable(
                name: "CongThuc",
                newName: "CongThucs");

            migrationBuilder.RenameTable(
                name: "ChiTiet_PhieuNhap",
                newName: "ChiTiet_PhieuNhaps");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuNhap_NhanVienID",
                table: "PhieuNhaps",
                newName: "IX_PhieuNhaps_NhanVienID");

            migrationBuilder.RenameIndex(
                name: "IX_PhieuNhap_NhaCungCapID",
                table: "PhieuNhaps",
                newName: "IX_PhieuNhaps_NhaCungCapID");

            migrationBuilder.RenameIndex(
                name: "IX_CongThuc_NguyenLieuID",
                table: "CongThucs",
                newName: "IX_CongThucs_NguyenLieuID");

            migrationBuilder.RenameIndex(
                name: "IX_CongThuc_MonAnID",
                table: "CongThucs",
                newName: "IX_CongThucs_MonAnID");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_PhieuNhap_PhieuNhapID",
                table: "ChiTiet_PhieuNhaps",
                newName: "IX_ChiTiet_PhieuNhaps_PhieuNhapID");

            migrationBuilder.RenameIndex(
                name: "IX_ChiTiet_PhieuNhap_NguyenLieuID",
                table: "ChiTiet_PhieuNhaps",
                newName: "IX_ChiTiet_PhieuNhaps_NguyenLieuID");

            migrationBuilder.AlterColumn<bool>(
                name: "Quyen",
                table: "NhanVien",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MaVatTu",
                table: "NguyenLieu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "NhanVienID",
                table: "PhieuNhaps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NhaCungCapID",
                table: "PhieuNhaps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NgayNhap",
                table: "PhieuNhaps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TongTien",
                table: "PhieuNhaps",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<double>(
                name: "SoLuong",
                table: "ChiTiet_PhieuNhaps",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhieuNhapID",
                table: "ChiTiet_PhieuNhaps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NguyenLieuID",
                table: "ChiTiet_PhieuNhaps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DonGia",
                table: "ChiTiet_PhieuNhaps",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhieuNhaps",
                table: "PhieuNhaps",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhaCungCaps",
                table: "NhaCungCaps",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CongThucs",
                table: "CongThucs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChiTiet_PhieuNhaps",
                table: "ChiTiet_PhieuNhaps",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_PhieuNhaps_NguyenLieu_NguyenLieuID",
                table: "ChiTiet_PhieuNhaps",
                column: "NguyenLieuID",
                principalTable: "NguyenLieu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_PhieuNhaps_PhieuNhaps_PhieuNhapID",
                table: "ChiTiet_PhieuNhaps",
                column: "PhieuNhapID",
                principalTable: "PhieuNhaps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CongThucs_MonAn_MonAnID",
                table: "CongThucs",
                column: "MonAnID",
                principalTable: "MonAn",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CongThucs_NguyenLieu_NguyenLieuID",
                table: "CongThucs",
                column: "NguyenLieuID",
                principalTable: "NguyenLieu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_NhaCungCaps_NhaCungCapID",
                table: "PhieuNhaps",
                column: "NhaCungCapID",
                principalTable: "NhaCungCaps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuNhaps_NhanVien_NhanVienID",
                table: "PhieuNhaps",
                column: "NhanVienID",
                principalTable: "NhanVien",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}