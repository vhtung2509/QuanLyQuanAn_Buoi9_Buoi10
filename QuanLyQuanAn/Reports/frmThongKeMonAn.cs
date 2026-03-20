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
    public partial class frmThongKeMonAn : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        Reports.QLQADataSet.DanhSachMonAnDataTable danhSachMonAnDataTable = new Reports.QLQADataSet.DanhSachMonAnDataTable();

        // Lưu ý: Đổi "net8.0-windows"
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        public frmThongKeMonAn()
        {
            InitializeComponent();
        }

        private void frmThongKeMonAn_Load(object sender, EventArgs e)
        {
            // Dùng object ẩn danh (new { ... }) để khỏi phải tạo thêm Class DTO như thầy, kết quả vẫn y hệt
            var danhSachMonAn = context.MonAn.Select(r => new
            {
                ID = r.ID,
                LoaiMonAnID = r.LoaiMonAnID,
                TenLoai = r.LoaiMonAn.TenLoai,
                TenMonAn = r.TenMon,
                DonGia = r.DonGia,
                SoLuong = r.SoLuong,
                HinhAnh = r.HinhAnh
            }).ToList();

            danhSachMonAnDataTable.Clear();
            foreach (var row in danhSachMonAn)
            {
                // Gọi hàm Add tự động sinh ra y hệt code thầy
                danhSachMonAnDataTable.AddDanhSachMonAnRow(
                    row.ID,
                    row.LoaiMonAnID,
                    row.TenLoai,
                    row.TenMonAn,
                    row.DonGia,
                    row.HinhAnh,
                    row.SoLuong
                );
            }

            ReportDataSource reportDataSource = new ReportDataSource();
            // Tên này phải TRÙNG KHỚP với tên bạn điền trong bảng Dataset Properties lúc nãy
            reportDataSource.Name = "DanhSachMonAn";
            reportDataSource.Value = danhSachMonAnDataTable;

            // Đổi tên reportViewer1 cho khớp với tên Control bạn kéo vào Form (Mặc định là reportViewer1)
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = Path.Combine(reportsFolder, "rptThongKeMonAn.rdlc");

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;

            reportViewer.RefreshReport();
        }
    }
}
