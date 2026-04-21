using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanAn.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QuanLyQuanAn.Data.MonAn;

namespace QuanLyQuanAn.Forms
{
    public partial class frmMonAn : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        int id;
        bool xuLyThem = false;
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Images");

        public frmMonAn()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            cboLoaiMonAn.Enabled = giaTri;
            txtTenMonAn.Enabled = giaTri;
            numSoLuong.Enabled = giaTri;
            numDonGia.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;

            btnDoiAnh.Enabled = giaTri;
            btnXoayAnh.Enabled = giaTri;

            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        public void LayLoaiMonAnVaoComboBox()
        {
            cboLoaiMonAn.DataSource = context.LoaiMonAn.ToList();
            cboLoaiMonAn.ValueMember = "ID";
            cboLoaiMonAn.DisplayMember = "TenLoai";
        }

        private void frmMonAn_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LayLoaiMonAnVaoComboBox();
            dataGridView.AutoGenerateColumns = false;

            HienThiDuLieuLenLuoi(); // Gọi hàm Load tối ưu
        }

        // =========================================================
        // TỐI ƯU 4: GỘP CHUNG HÀM LOAD DỮ LIỆU VÀ TÌM KIẾM
        // =========================================================
        private void HienThiDuLieuLenLuoi(string tuKhoa = "")
        {
            try
            {
                context.ChangeTracker.Clear();

                var query = context.MonAn.Include(m => m.LoaiMonAn).AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(m => m.TenMon.ToLower().Contains(tuKhoa));
                }

                List<DanhSachMonAn> sp = query.Select(r => new DanhSachMonAn
                {
                    ID = r.ID,
                    LoaiMonAnID = r.LoaiMonAnID,
                    TenLoai = r.LoaiMonAn.TenLoai,
                    TenMonAn = r.TenMon,
                    SoLuong = r.SoLuong,
                    DonGia = r.DonGia,
                    MoTa = r.MoTa,
                    HinhAnh = r.HinhAnh
                })
                .OrderBy(m => m.ID)
                .ToList();

                if (sp.Count == 0 && !string.IsNullOrWhiteSpace(tuKhoa))
                {
                    MessageBox.Show("Không tìm thấy món ăn nào có chứa chữ: " + tuKhoa, "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi(""); // Trả về toàn bộ danh sách
                    return;
                }

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sp;

                cboLoaiMonAn.DataBindings.Clear();
                cboLoaiMonAn.DataBindings.Add("SelectedValue", bindingSource, "LoaiMonAnID", false, DataSourceUpdateMode.Never);

                txtTenMonAn.DataBindings.Clear();
                txtTenMonAn.DataBindings.Add("Text", bindingSource, "TenMonAn", false, DataSourceUpdateMode.Never);

                numSoLuong.DataBindings.Clear();
                numSoLuong.DataBindings.Add("Value", bindingSource, "SoLuong", false, DataSourceUpdateMode.Never);

                numDonGia.DataBindings.Clear();
                numDonGia.DataBindings.Add("Value", bindingSource, "DonGia", false, DataSourceUpdateMode.Never);

                txtMoTa.DataBindings.Clear();
                txtMoTa.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);

                // TỐI ƯU 1: FIX LỖI GDI+ CRASH KHI LOAD ẢNH BINDING
                picHinhAnh.DataBindings.Clear();
                Binding hinhAnh = new Binding("Tag", bindingSource, "HinhAnh");
                hinhAnh.Format += (s, ev) =>
                {
                    // Dọn dẹp ảnh cũ trước khi load ảnh mới để chống tràn RAM
                    if (picHinhAnh.Image != null)
                    {
                        picHinhAnh.Image.Dispose();
                        picHinhAnh.Image = null;
                    }

                    if (ev.Value != null && !string.IsNullOrEmpty(ev.Value.ToString()))
                    {
                        string fullPath = Path.Combine(imagesFolder, ev.Value.ToString());
                        if (File.Exists(fullPath))
                        {
                            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                using (Image tempImg = Image.FromStream(fs))
                                {
                                    picHinhAnh.Image = new Bitmap(tempImg); // Nhân bản ảnh lên RAM, an toàn tuyệt đối
                                }
                            }
                        }
                    }
                };
                picHinhAnh.DataBindings.Add(hinhAnh);

                dataGridView.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            cboLoaiMonAn.SelectedIndex = -1;
            txtTenMonAn.Clear();
            txtMoTa.Clear();
            numSoLuong.Value = 0;
            numDonGia.Value = 0;

            if (picHinhAnh.Image != null)
            {
                picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
            }
            picHinhAnh.Tag = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Xác nhận xóa món ăn: " + txtTenMonAn.Text + "?", "Cảnh báo Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                    MonAn sp = context.MonAn.Find(id);
                    if (sp != null)
                    {
                        context.MonAn.Remove(sp);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDuLieuLenLuoi();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa Món ăn này vì đã được sử dụng trong Hóa Đơn hoặc Công thức!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            HienThiDuLieuLenLuoi();
            BatTatChucNang(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenMoi = txtTenMonAn.Text.Trim();

            // 1. RÀNG BUỘC CHỐT: Kiểm tra loại món ăn (Chặn trường hợp gõ chữ linh tinh không có trong danh sách)
            if (cboLoaiMonAn.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một Loại món ăn hợp lệ từ danh sách xổ xuống!", "Yêu cầu nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiMonAn.Focus();
                return;
            }

            // 2. Kiểm tra tên món
            if (string.IsNullOrWhiteSpace(tenMoi))
            {
                MessageBox.Show("Tên món ăn không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenMonAn.Focus();
                return;
            }

            // 3. Kiểm tra đơn giá
            if (numDonGia.Value <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0 VNĐ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numDonGia.Focus();
                return;
            }

            try
            {
                // Kiểm tra trùng tên món ăn (Không tính chính nó khi đang sửa)
                bool trungTen = xuLyThem ? context.MonAn.Any(m => m.TenMon.ToLower() == tenMoi.ToLower())
                                         : context.MonAn.Any(m => m.TenMon.ToLower() == tenMoi.ToLower() && m.ID != id);
                if (trungTen)
                {
                    MessageBox.Show("Tên món ăn này đã tồn tại trong thực đơn! Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMonAn.Focus();
                    return;
                }

                if (xuLyThem)
                {
                    MonAn sp = new MonAn();
                    sp.TenMon = tenMoi;
                    sp.LoaiMonAnID = Convert.ToInt32(cboLoaiMonAn.SelectedValue);
                    sp.SoLuong = Convert.ToInt32(numSoLuong.Value);
                    sp.DonGia = Convert.ToInt32(numDonGia.Value);
                    sp.MoTa = txtMoTa.Text;
                    if (picHinhAnh.Tag != null) sp.HinhAnh = picHinhAnh.Tag.ToString();

                    context.MonAn.Add(sp);
                }
                else
                {
                    MonAn sp = context.MonAn.Find(id);
                    if (sp != null)
                    {
                        sp.TenMon = tenMoi;
                        sp.LoaiMonAnID = Convert.ToInt32(cboLoaiMonAn.SelectedValue);
                        sp.SoLuong = Convert.ToInt32(numSoLuong.Value);
                        sp.DonGia = Convert.ToInt32(numDonGia.Value);
                        sp.MoTa = txtMoTa.Text;
                        if (picHinhAnh.Tag != null) sp.HinhAnh = picHinhAnh.Tag.ToString();

                        context.MonAn.Update(sp);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Đã lưu thông tin món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDuLieuLenLuoi();
                BatTatChucNang(false);
            }
            catch (Exception ex)
            {
                string loi = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi hệ thống khi lưu: " + loi, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 160;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Tìm kiếm món ăn";
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập tên món ăn cần tìm:" };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "Tìm kiếm", Left = 260, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    HienThiDuLieuLenLuoi(textBox.Text.Trim());
                }
            }
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn hình ảnh món ăn";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(sourcePath);
                string ext = Path.GetExtension(sourcePath);

                string newFileName = fileName.GenerateSlug() + ext;
                string fileSavePath = Path.Combine(imagesFolder, newFileName);

                if (!Directory.Exists(imagesFolder)) Directory.CreateDirectory(imagesFolder);

                try
                {
                    if (picHinhAnh.Image != null)
                    {
                        picHinhAnh.Image.Dispose();
                        picHinhAnh.Image = null;
                    }
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    if (!sourcePath.Equals(fileSavePath, StringComparison.OrdinalIgnoreCase))
                    {
                        File.Copy(sourcePath, fileSavePath, true);
                    }

                    using (FileStream fs = new FileStream(fileSavePath, FileMode.Open, FileAccess.Read))
                    {
                        using (Image tempImg = Image.FromStream(fs))
                        {
                            picHinhAnh.Image = new Bitmap(tempImg);
                        }
                    }

                    picHinhAnh.Tag = newFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đổi ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoayAnh_Click(object sender, EventArgs e)
        {
            if (picHinhAnh.Image != null && picHinhAnh.Tag != null)
            {
                picHinhAnh.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                picHinhAnh.Refresh();

                try
                {
                    string filePath = Path.Combine(imagesFolder, picHinhAnh.Tag.ToString());
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    picHinhAnh.Image.Save(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh xoay: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value != null)
            {
                try
                {
                    string path = Path.Combine(imagesFolder, e.Value.ToString());
                    if (File.Exists(path))
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                        {
                            using (Image tempImg = Image.FromStream(fs))
                            {
                                e.Value = new Bitmap(tempImg, 40, 40);
                            }
                        }
                    }
                    else e.Value = null;
                }
                catch { e.Value = null; }
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";

                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString().Trim());
                                firstRow = false;
                            }
                            else
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        if (table.Rows.Count > 0)
                        {
                            int demThanhCong = 0;
                            foreach (DataRow r in table.Rows)
                            {
                                string tenExcel = table.Columns.Contains("TenMon") ? r["TenMon"].ToString().Trim() : "";

                                // TỐI ƯU 3: Chống nạp rỗng và chống nạp trùng tên món ăn từ file Excel
                                if (!string.IsNullOrWhiteSpace(tenExcel) && !context.MonAn.Any(m => m.TenMon.ToLower() == tenExcel.ToLower()))
                                {
                                    MonAn ma = new MonAn();
                                    int loaiId = 1, soLuong = 0, donGia = 0;

                                    if (table.Columns.Contains("LoaiMonAnID")) int.TryParse(r["LoaiMonAnID"].ToString(), out loaiId);
                                    if (table.Columns.Contains("SoLuong")) int.TryParse(r["SoLuong"].ToString(), out soLuong);
                                    if (table.Columns.Contains("DonGia")) int.TryParse(r["DonGia"].ToString(), out donGia);

                                    // Ràng buộc nếu giá <= 0 thì không nạp
                                    if (donGia > 0)
                                    {
                                        ma.LoaiMonAnID = loaiId;
                                        ma.TenMon = tenExcel;
                                        ma.SoLuong = soLuong;
                                        ma.DonGia = donGia;
                                        ma.MoTa = table.Columns.Contains("MoTa") ? r["MoTa"].ToString() : "";
                                        ma.HinhAnh = table.Columns.Contains("HinhAnh") ? r["HinhAnh"].ToString() : "";

                                        context.MonAn.Add(ma);
                                        demThanhCong++;
                                    }
                                }
                            }
                            context.SaveChanges();

                            MessageBox.Show($"Đã nạp thành công {demThanhCong} món ăn mới.\n(Bỏ qua các món trùng tên, lỗi giá hoặc rỗng)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDuLieuLenLuoi();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nhập Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
            saveFileDialog.Title = "Xuất danh sách món ăn ra Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = "DanhSachMonAn_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("LoaiMonAnID", typeof(int)),
                        new DataColumn("TenMon", typeof(string)),
                        new DataColumn("SoLuong", typeof(int)),
                        new DataColumn("DonGia", typeof(int)),
                        new DataColumn("MoTa", typeof(string)),
                        new DataColumn("HinhAnh", typeof(string))
                    });

                    var danhSach = context.MonAn.OrderByDescending(m => m.ID).ToList();
                    foreach (var ma in danhSach)
                    {
                        table.Rows.Add(ma.ID, ma.LoaiMonAnID, ma.TenMon, ma.SoLuong, ma.DonGia, ma.MoTa, ma.HinhAnh);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "MonAn");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public static class StringExtensions
    {
        public static string GenerateSlug(this string phrase)
        {
            if (string.IsNullOrEmpty(phrase)) return "";

            string str = phrase.ToLower();
            str = str.Replace("đ", "d").Replace("Đ", "d");
            str = str.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in str)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            str = sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", "");
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim();
            str = str.Replace(" ", "-");
            return str;
        }

        public static string ChuyenTiengVietKhongDau(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            str = str.Replace("đ", "d").Replace("Đ", "D");
            str = str.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in str)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
    }
}