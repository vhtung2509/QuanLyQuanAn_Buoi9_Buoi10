using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Data
{
    internal class HoaDon_ChiTiet
    {
        public int ID { get; set; }

        public int HoaDonID { get; set; }

        // Đã đổi từ SanPhamID sang MonAnID cho đúng đồ án Quán ăn
        public int MonAnID { get; set; }

        public short SoLuongBan { get; set; }

        public int DonGiaBan { get; set; }

        // Liên kết tới Hóa đơn chính
        public virtual HoaDon HoaDon { get; set; } = null!;

        // Liên kết tới bảng Món ăn
        [ForeignKey("MonAnID")]
        public virtual MonAn MonAn { get; set; } = null!;
    }

    [NotMapped]
    public class DanhSachHoaDon_ChiTiet
    {
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int MonAnID { get; set; }
        public string TenMonAn { get; set; }
        public short SoLuongBan { get; set; }
        public int DonGiaBan { get; set; }
        public int ThanhTien { get; set; }
    }
}