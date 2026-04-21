using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanAn.Data
{
    internal class PhieuNhap
    {
        public int ID { get; set; }

        // THÊM DẤU "?" ĐỂ CHỐNG LỖI DATA IS NULL
        public DateTime? NgayNhap { get; set; } = DateTime.Now;
        public decimal? TongTienHoaDon { get; set; }
        public int? NhaCungCapID { get; set; }
        public int? NhanVienID { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<ChiTiet_PhieuNhap> ChiTiet_PhieuNhap { get; set; }
    }

    [NotMapped]
    public class DanhSachPhieuNhap
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public string HoVaTenNhanVien { get; set; }
        public int NhaCungCapID { get; set; }
        public string TenNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public double TongTienHoaDon { get; set; }
        public string XemChiTiet { get; set; } = "Xem chi tiết";
    }
}