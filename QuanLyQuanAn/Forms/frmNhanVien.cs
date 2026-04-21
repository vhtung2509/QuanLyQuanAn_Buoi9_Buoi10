using ClosedXML.Excel;
using QuanLyQuanAn.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanAn.Forms
{
    public partial class frmNhanVien : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        bool XuLyThem = false;
        int id;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            // Xóa sạch dữ liệu cũ bị kẹt và nạp 4 quyền mới vào
            cboQuyenHan.Items.Clear();
            cboQuyenHan.Items.AddRange(new string[] { "Quản lý", "Kế toán", "Thu ngân", "Phục vụ", "Nhân viên bếp" });

            HienThiDuLieuLenLuoi();
        }

        private void HienThiDuLieuLenLuoi(string tuKhoa = "")
        {
            try
            {
                context.ChangeTracker.Clear();
                var query = context.NhanVien.AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(nv => nv.HoVaTen.ToLower().Contains(tuKhoa) || nv.DienThoai.Contains(tuKhoa) || nv.TenDangNhap.ToLower().Contains(tuKhoa));
                }

                var nv = query.OrderBy(n => n.ID).ToList();

                if (nv.Count == 0 && !string.IsNullOrWhiteSpace(tuKhoa))
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi("");
                    return;
                }

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = nv;

                bindingSource.PositionChanged -= BindingSource_PositionChanged;
                bindingSource.PositionChanged += BindingSource_PositionChanged;

                txtHoVaTen.DataBindings.Clear();
                txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);

                txtDienThoai.DataBindings.Clear();
                txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);

                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

                txtTenDangNhap.DataBindings.Clear();
                txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never);

                txtMatKhau.DataBindings.Clear();
                txtMatKhau.DataBindings.Add("Text", bindingSource, "MatKhau", false, DataSourceUpdateMode.Never);

                dataGridView.CellFormatting -= DataGridView_CellFormatting;
                dataGridView.CellFormatting += DataGridView_CellFormatting;

                dataGridView.DataSource = bindingSource;

                BindingSource_PositionChanged(bindingSource, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindingSource_PositionChanged(object sender, EventArgs e)
        {
            var bs = sender as BindingSource;
            if (bs != null && bs.Current is NhanVien item)
            {
                // Gán thẳng chữ từ Database vào ComboBox
                cboQuyenHan.Text = item.Quyen;
            }
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // TÔ MÀU PHÂN QUYỀN CHO ĐẸP MẮT
            if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "QuyenHan" || dataGridView.Columns[e.ColumnIndex].DataPropertyName == "Quyen")
            {
                var row = dataGridView.Rows[e.RowIndex].DataBoundItem as NhanVien;
                if (row != null && !string.IsNullOrEmpty(row.Quyen))
                {
                    e.Value = row.Quyen; // In thẳng chữ ra lưới

                    if (row.Quyen == "Quản lý") e.CellStyle.ForeColor = Color.Red;
                    else if (row.Quyen == "Kế toán") e.CellStyle.ForeColor = Color.Purple;
                    else if (row.Quyen == "Thu ngân") e.CellStyle.ForeColor = Color.Green;
                    else if (row.Quyen == "Phục vụ") e.CellStyle.ForeColor = Color.DarkOrange;
                    else if (row.Quyen == "Nhân viên bếp") e.CellStyle.ForeColor = Color.Brown;

                    e.FormattingApplied = true;
                }
            }

            if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "MatKhau" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.Text = "Phục vụ"; // Tài khoản mới mặc định là Phục vụ cho an toàn
            txtHoVaTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            XuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtHoVaTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            string tenNV = txtHoVaTen.Text;
            if (MessageBox.Show("Xác nhận xóa nhân viên " + tenNV + "?", "Cảnh báo Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());

                    if (id == 1)
                    {
                        MessageBox.Show("Đây là tài khoản Quản trị hệ thống mặc định, không thể xóa!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    NhanVien nv = context.NhanVien.Find(id);
                    if (nv != null)
                    {
                        context.NhanVien.Remove(nv);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDuLieuLenLuoi();
                }
                catch
                {
                    MessageBox.Show("Không thể xóa nhân viên này vì đã có dữ liệu do người này lập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoVaTen.Text.Trim();
            string tenDangNhapMoi = txtTenDangNhap.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();

            // ==========================================
            // BẮT ĐẦU: RÀNG BUỘC CHẶT CHẼ ĐẦU VÀO
            // ==========================================

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(tenDangNhapMoi))
            {
                MessageBox.Show("Vui lòng nhập đủ Họ tên và Tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            // 2. Kiểm tra Họ và tên không được chứa số (VD: "123")
            if (hoTen.Any(char.IsDigit))
            {
                MessageBox.Show("Họ và tên không hợp lệ! Không được chứa chữ số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            // 3. Kiểm tra Số điện thoại phải đủ từ 10 số trở lên (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(dienThoai) && dienThoai.Length < 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập từ 10 số trở lên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            // ==========================================
            // KẾT THÚC: RÀNG BUỘC
            // ==========================================

            try
            {
                bool trungTaiKhoan = XuLyThem ? context.NhanVien.Any(n => n.TenDangNhap.ToLower() == tenDangNhapMoi.ToLower())
                                              : context.NhanVien.Any(n => n.TenDangNhap.ToLower() == tenDangNhapMoi.ToLower() && n.ID != id);
                if (trungTaiKhoan)
                {
                    MessageBox.Show("Tên đăng nhập này đã có người sử dụng! Vui lòng chọn tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDangNhap.Focus();
                    return;
                }

                if (XuLyThem)
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu cho nhân viên mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau.Focus();
                        return;
                    }
                    NhanVien nv = new NhanVien
                    {
                        HoVaTen = hoTen,
                        DienThoai = dienThoai,
                        DiaChi = txtDiaChi.Text.Trim(),
                        TenDangNhap = tenDangNhapMoi,
                        MatKhau = txtMatKhau.Text.Trim(),
                        Quyen = cboQuyenHan.Text // Lấy thẳng chữ gán vào DB
                    };
                    context.NhanVien.Add(nv);
                }
                else
                {
                    NhanVien nv = context.NhanVien.Find(id);
                    if (nv != null)
                    {
                        nv.HoVaTen = hoTen;
                        nv.DienThoai = dienThoai;
                        nv.DiaChi = txtDiaChi.Text.Trim();
                        nv.TenDangNhap = tenDangNhapMoi;
                        nv.Quyen = cboQuyenHan.Text; // Lấy thẳng chữ gán vào DB

                        if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        {
                            nv.MatKhau = txtMatKhau.Text.Trim();
                        }
                        context.NhanVien.Update(nv);
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Lưu thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                HienThiDuLieuLenLuoi();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                                string sdtExcel = r["DienThoai"].ToString().Trim();

                                if (!context.NhanVien.Any(n => n.TenDangNhap == sdtExcel))
                                {
                                    NhanVien nv = new NhanVien();
                                    nv.HoVaTen = r["HoVaTen"].ToString().Trim();
                                    nv.DienThoai = sdtExcel;
                                    nv.DiaChi = r["DiaChi"].ToString().Trim();

                                    nv.TenDangNhap = sdtExcel;
                                    nv.MatKhau = "123";
                                    nv.Quyen = "Phục vụ"; // Chèn bằng file Excel mặc định là Phục vụ

                                    context.NhanVien.Add(nv);
                                    demThanhCong++;
                                }
                            }
                            context.SaveChanges();
                            MessageBox.Show($"Đã nhập thành công {demThanhCong} nhân viên mới.\n(Bỏ qua các tài khoản trùng SĐT)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            saveFileDialog.Title = "Xuất danh sách nhân viên ra Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = "DanhSachNhanVien_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                    new DataColumn("ID", typeof(int)),
                    new DataColumn("HoVaTen", typeof(string)),
                    new DataColumn("DienThoai", typeof(string)),
                    new DataColumn("DiaChi", typeof(string)),
                    new DataColumn("TenDangNhap", typeof(string)),
                    new DataColumn("QuyenHan", typeof(string))
                    });

                    var danhSach = context.NhanVien.OrderByDescending(n => n.ID).ToList();
                    foreach (var nv in danhSach)
                    {
                        // In thẳng chữ Quyền ra file Excel
                        table.Rows.Add(nv.ID, nv.HoVaTen, nv.DienThoai, nv.DiaChi, nv.TenDangNhap, nv.Quyen);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhanVien");
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            HienThiDuLieuLenLuoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400; prompt.Height = 160; prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Tìm kiếm nhân viên"; prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false; prompt.MinimizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập Tên, SĐT hoặc Tên đăng nhập:" };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "Tìm kiếm", Left = 260, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textBox); prompt.Controls.Add(confirmation); prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    HienThiDuLieuLenLuoi(textBox.Text.Trim());
                }
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}