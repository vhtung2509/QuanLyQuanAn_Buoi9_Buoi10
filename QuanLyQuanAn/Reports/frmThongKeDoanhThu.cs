using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyQuanAn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.Reports
{
    public partial class frmThongKeDoanhThu : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        Reports.QLQADataSet.DoanhThuDataTable dtDoanhThu = new Reports.QLQADataSet.DoanhThuDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu (Áp dụng cách FIX INT16 của bạn)
            var danhSachDoanhThu = context.HoaDon
                .Include(r => r.NhanVien)
                .Include(r => r.KhachHang)
                .Select(r => new
                {
                    ID = (int)r.ID, // 🔥 ép về Int32 cho chắc

                    TenNhanVien = r.NhanVien.HoVaTen ?? "",

                    TenKhachHang = r.KhachHang.HoVaTen ?? "",

                    NgayLap = r.NgayLap,

                    // 🔥 FIX CHÍNH: Ép kiểu bọc ngoài cả hàm Sum và ép kiểu bên trong phép nhân
                    TongTien = (int)r.HoaDon_ChiTiet
                        .Sum(ct => (int)(ct.SoLuongBan * ct.DonGiaBan))
                })
                .ToList();

            // 2. Đổ vào DataTable
            dtDoanhThu.Clear();

            foreach (var row in danhSachDoanhThu)
            {
                // Truyền đủ 5 tham số theo đúng thứ tự bảng DoanhThu
                dtDoanhThu.AddDoanhThuRow(
                    Convert.ToInt32(row.ID),          // ép lại lần nữa cho chắc
                    row.TenNhanVien,
                    row.TenKhachHang,
                    row.NgayLap,
                    Convert.ToInt32(row.TongTien)     // ép lại lần nữa
                );
            }

            // 3. Đổ lên Report
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DoanhThu";
            reportDataSource.Value = dtDoanhThu;

            // Lưu ý: Đổi reportViewer1 thành reportViewer nếu form của bạn tên control là reportViewer
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            reportViewer.LocalReport.ReportPath =
                Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

            // 4. Hiển thị
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;

            string moTa = "Hiển thị toàn bộ doanh thu của quán";
            ReportParameter reportParameter = new ReportParameter("MoTaDoanhThu", moTa);
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.RefreshReport();
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            // Lấy mốc thời gian từ 2 ô DateTimePicker
            DateTime tuNgay = dtpTuNgay.Value.Date; // 0h00 ngày bắt đầu
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1); // 23h59 ngày kết thúc

            // Lấy dữ liệu và LỌC THEO NGÀY
            var danhSachDoanhThu = context.HoaDon
                .Include(r => r.NhanVien)
                .Include(r => r.KhachHang)
                .Where(r => r.NgayLap >= tuNgay && r.NgayLap <= denNgay) // Dòng lọc quan trọng
                .Select(r => new
                {
                    ID = (int)r.ID,
                    TenNhanVien = r.NhanVien.HoVaTen ?? "",
                    TenKhachHang = r.KhachHang.HoVaTen ?? "",
                    NgayLap = r.NgayLap,
                    TongTien = (int)r.HoaDon_ChiTiet.Sum(ct => (int)(ct.SoLuongBan * ct.DonGiaBan))
                })
                .ToList();

            dtDoanhThu.Clear();
            foreach (var row in danhSachDoanhThu)
            {
                dtDoanhThu.AddDoanhThuRow(
                    Convert.ToInt32(row.ID),
                    row.TenNhanVien,
                    row.TenKhachHang,
                    row.NgayLap,
                    Convert.ToInt32(row.TongTien)
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DoanhThu";
            reportDataSource.Value = dtDoanhThu;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            // Tạo dòng chữ theo thời gian đã chọn (Khớp tên Parameter MoTaDoanhThu)
            string moTa = $"Từ ngày {dtpTuNgay.Value.ToString("dd/MM/yyyy")} đến ngày {dtpDenNgay.Value.ToString("dd/MM/yyyy")}";
            ReportParameter reportParameter = new ReportParameter("MoTaDoanhThu", moTa);
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.RefreshReport();
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu_Load(sender, e);
        }
    }
}