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
    public partial class frmThongKeMonAn : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        Reports.QLQADataSet.DanhSachMonAnDataTable danhSachMonAnDataTable = new Reports.QLQADataSet.DanhSachMonAnDataTable();

        // Lưu ý: Đổi "net8.0-windows"
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");

        public void LayLoaiMonAnVaoCombobox()
        {
            var danhSachLoai = context.LoaiMonAn.ToList();
            cboLoaiMonAn.DataSource = danhSachLoai;
            cboLoaiMonAn.DisplayMember = "TenLoai"; // Chữ hiển thị ra
            cboLoaiMonAn.ValueMember = "ID";        // Giá trị ngầm bên dưới
            cboLoaiMonAn.SelectedIndex = -1;        // Mặc định không chọn gì
        }
        public frmThongKeMonAn()
        {
            InitializeComponent();
        }

        private void frmThongKeMonAn_Load(object sender, EventArgs e)
        {
            LayLoaiMonAnVaoCombobox();
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

            // ĐÃ ĐỔI DÒNG CHỮ Ở ĐÂY (Lúc mới mở Form)
            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaLoc", "Hiển thị tất cả các món ăn đã bán trong hệ thống");
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.RefreshReport();
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            // 1. Lấy toàn bộ danh sách món ăn từ CSDL
            var query = context.MonAn.Include(r => r.LoaiMonAn).AsQueryable();

            string moTaLoai = "";
            string moTaTimKiem = "";

            // 2. Lọc theo Loại món (nếu ComboBox có chọn)
            if (cboLoaiMonAn.SelectedIndex != -1 && cboLoaiMonAn.Text != "")
            {
                int loaiID = Convert.ToInt32(cboLoaiMonAn.SelectedValue);
                query = query.Where(r => r.LoaiMonAnID == loaiID);
                moTaLoai = "Loại món: " + cboLoaiMonAn.Text;
            }

            // 3. Tìm kiếm theo Tên món ăn (nếu TextBox có gõ chữ)
            if (!string.IsNullOrEmpty(txtTrangThai.Text))
            {
                // Sử dụng Contains để tìm các món có chứa từ khóa vừa gõ
                query = query.Where(r => r.TenMon.Contains(txtTrangThai.Text)); // Lưu ý: Nếu cột của bạn tên là TenMonAn thì sửa lại chỗ này nhé
                moTaTimKiem = " | Tìm kiếm: '" + txtTrangThai.Text + "'";
            }

            // 4. Ghép dòng chữ hiển thị lên Report cho logic (ĐÃ ĐỔI DÒNG CHỮ Ở ĐÂY)
            string moTaChung = "Hiển thị tất cả các món ăn đã bán trong hệ thống";
            if (moTaLoai != "" || moTaTimKiem != "")
            {
                // Nếu chỉ tìm kiếm mà không chọn loại món, thì bỏ cái dấu " | " ở đầu đi cho đẹp
                if (moTaLoai == "" && moTaTimKiem != "")
                {
                    moTaChung = "(Tìm kiếm: '" + txtTrangThai.Text + "')";
                }
                else
                {
                    moTaChung = "(" + moTaLoai + moTaTimKiem + ")";
                }
            }

            // 5. Lấy dữ liệu cuối cùng sau khi đã lọc/tìm
            var danhSachMonAn = query.Select(r => new
            {
                ID = r.ID,
                LoaiMonAnID = r.LoaiMonAnID,
                TenLoai = r.LoaiMonAn.TenLoai,
                TenMonAn = r.TenMon, // Sửa lại thành r.TenMonAn nếu class của bạn đặt thế
                DonGia = r.DonGia,
                HinhAnh = r.HinhAnh,
                SoLuong = r.SoLuong
            }).ToList();

            // 6. Đổ vào DataTable (Đã dùng đúng tên biến danhSachMonAnDataTable của bạn)
            danhSachMonAnDataTable.Clear();
            foreach (var row in danhSachMonAn)
            {
                danhSachMonAnDataTable.AddDanhSachMonAnRow(row.ID, row.LoaiMonAnID, row.TenLoai, row.TenMonAn, row.DonGia, row.HinhAnh, row.SoLuong);
            }

            // 7. Đẩy lên Report
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachMonAn";
            reportDataSource.Value = danhSachMonAnDataTable;

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);

            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaLoc", moTaChung);
            reportViewer.LocalReport.SetParameters(reportParameter);

            reportViewer.RefreshReport();
        }
    }
}