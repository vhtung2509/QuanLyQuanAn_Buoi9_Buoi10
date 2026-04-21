using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanAn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanAn.Forms
{
    public partial class frmPhieuNhap : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        int id; // Giữ lại đúng ý Tùng nhé!

        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            HienThiDuLieuLenLuoi("");
        }

        private void HienThiDuLieuLenLuoi(string tuKhoa = "")
        {
            try
            {
                context.ChangeTracker.Clear();
                context = new QLQADbcontext();

                var query = context.PhieuNhap
                    .Include(r => r.NhanVien)
                    .Include(r => r.NhaCungCap)
                    .Include(r => r.ChiTiet_PhieuNhap)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(r =>
                        r.ID.ToString().Contains(tuKhoa) ||
                        (r.NhaCungCap != null && r.NhaCungCap.TenNCC.ToLower().Contains(tuKhoa)) ||
                        (r.NhanVien != null && r.NhanVien.HoVaTen.ToLower().Contains(tuKhoa))
                    );
                }

                List<DanhSachPhieuNhap> pn = query.ToList().Select(r => new DanhSachPhieuNhap
                {
                    ID = r.ID,
                    NhanVienID = r.NhanVienID ?? 0,
                    HoVaTenNhanVien = r.NhanVien != null ? r.NhanVien.HoVaTen : "Chưa xác định",
                    NhaCungCapID = r.NhaCungCapID ?? 0,
                    TenNCC = r.NhaCungCap != null ? r.NhaCungCap.TenNCC : "Nhà cung cấp lẻ",
                    NgayNhap = r.NgayNhap ?? DateTime.Now,
                    TongTienHoaDon = r.ChiTiet_PhieuNhap.Sum(ct => (double?)((ct.SoLuong ?? 0) * (double)(ct.DonGia ?? 0))) ?? 0,
                    XemChiTiet = "Xem chi tiết"
                })
                .OrderBy(r => r.NgayNhap)
                .ToList();

                if (pn.Count == 0 && !string.IsNullOrWhiteSpace(tuKhoa))
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi("");
                    return;
                }

                dataGridView.DataSource = pn;
                DinhDangLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangLuoi()
        {
            if (dataGridView.Columns.Contains("TongTienHoaDon"))
            {
                dataGridView.Columns["TongTienHoaDon"].DefaultCellStyle.Format = "#,##0 VNĐ";
                dataGridView.Columns["TongTienHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmChiTiet_PhieuNhap chiTiet = new frmChiTiet_PhieuNhap())
            {
                chiTiet.ShowDialog();
            }
            HienThiDuLieuLenLuoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            // Đã gọi đích danh cột "ID"
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmChiTiet_PhieuNhap chiTiet = new frmChiTiet_PhieuNhap(id))
            {
                chiTiet.ShowDialog();
            }
            HienThiDuLieuLenLuoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này cùng toàn bộ chi tiết của nó?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Đã gọi đích danh cột "ID"
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());

                    using (var dbDelete = new QLQADbcontext())
                    {
                        var pn = dbDelete.PhieuNhap.Find(id);
                        if (pn != null)
                        {
                            var chiTiets = dbDelete.ChiTiet_PhieuNhap.Where(ct => ct.PhieuNhapID == id);
                            dbDelete.ChiTiet_PhieuNhap.RemoveRange(chiTiets);
                            dbDelete.PhieuNhap.Remove(pn);
                            dbDelete.SaveChanges();
                        }
                    }

                    MessageBox.Show("Đã xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = NhapTuKhoaPopUp("Nhập Mã Phiếu, Tên Nhà Cung Cấp hoặc Nhân Viên cần tìm:", "Tìm kiếm Phiếu Nhập");
            if (tuKhoa != null)
            {
                HienThiDuLieuLenLuoi(tuKhoa.Trim());
            }
        }

        private string NhapTuKhoaPopUp(string loiNhan, string tieuDe)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 160;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = tieuDe;
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label lblText = new Label() { Left = 20, Top = 20, Width = 350, Text = loiNhan };
                TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button btnXacNhan = new Button() { Text = "Tìm kiếm", Left = 260, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(lblText);
                prompt.Controls.Add(txtInput);
                prompt.Controls.Add(btnXacNhan);
                prompt.AcceptButton = btnXacNhan;

                return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : null;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet" && e.RowIndex >= 0)
            {
                btnSua_Click(sender, e);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất danh sách phiếu nhập ra Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = "DanhSachPhieuNhap_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Mã PN", typeof(int)),
                        new DataColumn("Nhân Viên", typeof(string)),
                        new DataColumn("Nhà Cung Cấp", typeof(string)),
                        new DataColumn("Ngày Lập", typeof(string)),
                        new DataColumn("Tổng Tiền", typeof(double))
                    });

                    using (var dbExport = new QLQADbcontext())
                    {
                        var dsPhieuNhap = dbExport.PhieuNhap
                            .Include(r => r.NhanVien)
                            .Include(r => r.NhaCungCap)
                            .Include(r => r.ChiTiet_PhieuNhap)
                            .OrderBy(r => r.NgayNhap)
                            .ToList();

                        foreach (var pn in dsPhieuNhap)
                        {
                            string tenNV = pn.NhanVien?.HoVaTen ?? "Chưa xác định";
                            string tenNCC = pn.NhaCungCap?.TenNCC ?? "Nhà cung cấp lẻ";
                            string ngayLap = (pn.NgayNhap ?? DateTime.Now).ToString("dd/MM/yyyy HH:mm");

                            double tongTien = pn.ChiTiet_PhieuNhap.Sum(ct => (double?)((ct.SoLuong ?? 0) * (double)(ct.DonGia ?? 0))) ?? 0;

                            table.Rows.Add(pn.ID, tenNV, tenNCC, ngayLap, tongTien);
                        }
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "DanhSachPhieuNhap");
                        sheet.Column(5).Style.NumberFormat.Format = "#,##0";
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất danh sách phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}