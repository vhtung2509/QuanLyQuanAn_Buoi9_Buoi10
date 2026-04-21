using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace QuanLyQuanAn.Data
{
    internal class QLQADbcontext : DbContext
    {
        // Đồng bộ thêm từ khóa "virtual" cho tất cả các bảng
        public virtual DbSet<LoaiMonAn> LoaiMonAn { get; set; }
        public virtual DbSet<MonAn> MonAn { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; } // <--- Nơi chứa tài khoản đây rồi!
        public virtual DbSet<NguyenLieu> NguyenLieu { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        public virtual DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public virtual DbSet<BanAn> BanAn { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhap { get; set; }
        public virtual DbSet<ChiTiet_PhieuNhap> ChiTiet_PhieuNhap { get; set; }
        public virtual DbSet<CongThuc> CongThuc { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Lấy chuỗi kết nối từ file App.config (cách làm rất bảo mật và chuyên nghiệp)
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLQAConnection"].ConnectionString);
            }
        }
    }
}