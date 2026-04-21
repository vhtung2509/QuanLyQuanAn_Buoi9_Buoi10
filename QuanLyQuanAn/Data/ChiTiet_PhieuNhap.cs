using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyQuanAn.Data
{
    // 1. Class này để lưu xuống Database (Phải khớp với SQL)
    internal class ChiTiet_PhieuNhap
    {
        public int ID { get; set; }

        // THÊM DẤU "?" ĐỂ C# CHẤP NHẬN SQL BỊ RỖNG
        public int? PhieuNhapID { get; set; }
        public int? NguyenLieuID { get; set; }
        public double? SoLuong { get; set; }
        public decimal? DonGia { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; } = null!;
        [ForeignKey("NguyenLieuID")]
        public virtual NguyenLieu NguyenLieuNavigation { get; set; } = null!;
    }

    [NotMapped]
    public class DanhSachPhieuNhap_ChiTiet
    {
        public int ID { get; set; }
        public int PhieuNhapID { get; set; }
        public int NguyenLieuID { get; set; }
        public string NguyenLieu { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }
}