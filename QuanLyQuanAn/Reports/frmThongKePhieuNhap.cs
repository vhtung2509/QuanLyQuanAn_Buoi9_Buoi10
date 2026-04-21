using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyQuanAn.Data;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanAn.Reports // Đổi namespace chuẩn về Reports
{
    public partial class frmThongKePhieuNhap : Form
    {
        QLQADbcontext context = new QLQADbcontext();

        // Gọi thẳng QLQADataSet (vì form này đang nằm cùng namespace Reports)
        QLQADataSet.DanhSachPhieuNhapDataTable dtPhieuNhap = new QLQADataSet.DanhSachPhieuNhapDataTable();

        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");

        public frmThongKePhieuNhap()
        {
            InitializeComponent();
        }

        private void frmThongKePhieuNhap_Load(object sender, EventArgs e)
        {
            // Mặc định load tất cả lên khi vừa mở form
            btnHienTatCa_Click(sender, e);
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            // Kéo dữ liệu từ DB, lọc theo ngày, sau đó .ToList() để xử lý tính toán an toàn trên RAM
            var danhSachPhieuNhap = context.PhieuNhap
                .Include(r => r.NhanVien)
                .Include(r => r.NhaCungCap)
                .Include(r => r.ChiTiet_PhieuNhap)
                .Where(r => r.NgayNhap >= tuNgay && r.NgayNhap <= denNgay)
                .ToList()
                .Select(r => new
                {
                    ID = (int)r.ID,
                    NgayNhap = (r.NgayNhap ?? DateTime.Now).ToString("dd/MM/yyyy"),
                    TenNhanVien = r.NhanVien?.HoVaTen ?? "",
                    TenNCC = r.NhaCungCap?.TenNCC ?? "",
                    // Convert ép về Int32 ngay từ lúc nhân để tránh xung đột kiểu số
                    TongTien = (int)r.ChiTiet_PhieuNhap.Sum(ct => Convert.ToInt32(ct.SoLuong) * Convert.ToInt32(ct.DonGia))
                })
                .OrderByDescending(r => r.ID)
                .ToList();

            dtPhieuNhap.Clear();
            foreach (var row in danhSachPhieuNhap)
            {
                dtPhieuNhap.AddDanhSachPhieuNhapRow(
                    row.ID,
                    row.NgayNhap,
                    row.TenNhanVien,
                    row.TenNCC,
                    row.TongTien
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachPhieuNhap";
            reportDataSource.Value = dtPhieuNhap;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKePhieuNhap.rdlc");

            string moTa = $"Từ ngày {tuNgay.ToString("dd/MM/yyyy")} đến ngày {dtpDenNgay.Value.ToString("dd/MM/yyyy")}";
            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaLoc", moTa);
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            var danhSachPhieuNhap = context.PhieuNhap
                .Include(r => r.NhanVien)
                .Include(r => r.NhaCungCap)
                .Include(r => r.ChiTiet_PhieuNhap)
                .ToList() // Ép về RAM xử lý an toàn
                .Select(r => new
                {
                    ID = (int)r.ID,
                    NgayNhap = (r.NgayNhap ?? DateTime.Now).ToString("dd/MM/yyyy"),
                    TenNhanVien = r.NhanVien?.HoVaTen ?? "",
                    TenNCC = r.NhaCungCap?.TenNCC ?? "",
                    TongTien = (int)r.ChiTiet_PhieuNhap.Sum(ct => Convert.ToInt32(ct.SoLuong) * Convert.ToInt32(ct.DonGia))
                })
                .OrderByDescending(r => r.ID)
                .ToList();

            dtPhieuNhap.Clear();
            foreach (var row in danhSachPhieuNhap)
            {
                dtPhieuNhap.AddDanhSachPhieuNhapRow(
                    row.ID,
                    row.NgayNhap,
                    row.TenNhanVien,
                    row.TenNCC,
                    row.TongTien
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachPhieuNhap";
            reportDataSource.Value = dtPhieuNhap;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKePhieuNhap.rdlc");

            string moTa = "Hiển thị tất cả các phiếu nhập trong hệ thống";
            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaLoc", moTa);
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}