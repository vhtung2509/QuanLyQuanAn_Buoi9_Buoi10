using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Data
{
    internal class HoaDon
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public int KhachHangID { get; set; }
        public DateTime NgayLap { get; set; }
        public string? GhiChuHoaDon { get; set; }

        // Mối quan hệ: Một hóa đơn có nhiều chi tiết món ăn
        public virtual ICollection<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; } = new List<HoaDon_ChiTiet>();

        // Liên kết ngược lại bảng Nhân viên và Khách hàng
        public virtual KhachHang KhachHang { get; set; } = null!;
        public virtual NhanVien NhanVien { get; set; } = null!;
    }

    [NotMapped]
    public class DanhSachHoaDon
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public string HoVaTenNhanVien { get; set; }
        public int KhachHangID { get; set; }
        public string HoVaTenKhachHang { get; set; }
        public DateTime NgayLap { get; set; }
        public string? GhiChuHoaDon { get; set; }
        public double? TongTienHoaDon { get; set; }
        public string? XemChiTiet { get; set; }
    }
}
