using QuanLyQuanAn.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanAn.Forms
{
    public partial class frmNguyenLieu : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        bool XuLyThem = false;
        int id;

        public frmNguyenLieu()
        {
            InitializeComponent();
        }

        // --- HÀM BẬT/TẮT CÁC Ô NHẬP LIỆU ---
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            txtTenNguyenLieu.Enabled = giaTri;
            cboDonViTinh.Enabled = giaTri;
            txtSoLuongTon.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmNguyenLieu_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            if (cboDonViTinh.Items.Count == 0)
            {
                cboDonViTinh.Items.AddRange(new string[] { "kg", "gram", "lít", "ml", "bó", "quả", "hộp", "chai", "gói", "ổ" });
            }

            HienThiDuLieuLenLuoi();
        }

        private void HienThiDuLieuLenLuoi(string tuKhoa = "")
        {
            try
            {
                context.ChangeTracker.Clear();
                var query = context.NguyenLieu.AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(n => n.TenNguyenLieu.ToLower().Contains(tuKhoa));
                }

                // Sắp xếp nguyên liệu mới tạo lên trên cùng
                var dsNguyenLieu = query.OrderBy(n => n.ID).ToList();

                if (dsNguyenLieu.Count == 0 && !string.IsNullOrWhiteSpace(tuKhoa))
                {
                    MessageBox.Show("Không tìm thấy nguyên liệu nào khớp với từ khóa: " + tuKhoa, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi("");
                    return;
                }

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dsNguyenLieu;

                txtTenNguyenLieu.DataBindings.Clear();
                txtTenNguyenLieu.DataBindings.Add("Text", bindingSource, "TenNguyenLieu", false, DataSourceUpdateMode.Never);

                cboDonViTinh.DataBindings.Clear();
                cboDonViTinh.DataBindings.Add("Text", bindingSource, "DonViTinh", false, DataSourceUpdateMode.Never);

                txtSoLuongTon.DataBindings.Clear();
                txtSoLuongTon.DataBindings.Add("Text", bindingSource, "SoLuongTon", false, DataSourceUpdateMode.Never);

                dataGridView.DataSource = bindingSource;
                DinhDangLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangLuoi()
        {
            if (dataGridView.Columns.Count >= 4)
            {
                dataGridView.Columns[0].DataPropertyName = "ID";
                dataGridView.Columns[1].DataPropertyName = "TenNguyenLieu";
                dataGridView.Columns[2].DataPropertyName = "DonViTinh";
                dataGridView.Columns[3].DataPropertyName = "SoLuongTon";

                dataGridView.Columns[0].Visible = true;
                dataGridView.Columns[0].HeaderText = "Mã NL";
                dataGridView.Columns[1].HeaderText = "Tên Nguyên Liệu";
                dataGridView.Columns[2].HeaderText = "Đơn Vị Tính";
                dataGridView.Columns[3].HeaderText = "Số Lượng Tồn";
            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLyThem = true;
            BatTatChucNang(true);

            txtTenNguyenLieu.Clear();
            cboDonViTinh.SelectedIndex = -1;
            txtSoLuongTon.Text = "0";

            txtTenNguyenLieu.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            XuLyThem = false;
            BatTatChucNang(true);

            id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
            txtTenNguyenLieu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string tenNL = txtTenNguyenLieu.Text;

            if (MessageBox.Show("Xác nhận xóa nguyên liệu: " + tenNL + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                    var nl = context.NguyenLieu.Find(id);
                    if (nl != null)
                    {
                        context.NguyenLieu.Remove(nl);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDuLieuLenLuoi();
                }
                catch
                {
                    // Cảnh báo nếu xóa nguyên liệu đang được dùng trong Công Thức hoặc Phiếu Nhập
                    MessageBox.Show("Không thể xóa nguyên liệu này vì nó đang được sử dụng trong Công thức món ăn hoặc Phiếu nhập kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenNLMoi = txtTenNguyenLieu.Text.Trim();

            // 1. Kiểm tra rỗng Tên NL
            if (string.IsNullOrWhiteSpace(tenNLMoi))
            {
                MessageBox.Show("Vui lòng nhập Tên nguyên liệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguyenLieu.Focus();
                return;
            }

            // 2. Kiểm tra rỗng Đơn vị tính
            if (string.IsNullOrWhiteSpace(cboDonViTinh.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Đơn vị tính!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDonViTinh.Focus();
                return;
            }

            // 3. RÀNG BUỘC MỚI: Bắt lỗi Số lượng tồn (Chặn rỗng, chặn chữ copy-paste, chặn số âm)
            int tonKho = 0;
            if (!int.TryParse(txtSoLuongTon.Text.Trim(), out tonKho) || tonKho < 0)
            {
                MessageBox.Show("Số lượng tồn không hợp lệ! Vui lòng nhập số nguyên lớn hơn hoặc bằng 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongTon.Focus();
                return;
            }

            try
            {
                // Ràng buộc trùng tên Nguyên liệu
                bool trungTen = XuLyThem ? context.NguyenLieu.Any(n => n.TenNguyenLieu.ToLower() == tenNLMoi.ToLower())
                                         : context.NguyenLieu.Any(n => n.TenNguyenLieu.ToLower() == tenNLMoi.ToLower() && n.ID != id);
                if (trungTen)
                {
                    MessageBox.Show("Tên nguyên liệu này đã tồn tại trong kho! Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNguyenLieu.Focus();
                    return;
                }

                if (XuLyThem)
                {
                    var nl = new NguyenLieu();
                    nl.TenNguyenLieu = tenNLMoi;
                    nl.DonViTinh = cboDonViTinh.Text.Trim();
                    nl.SoLuongTon = tonKho;
                    context.NguyenLieu.Add(nl);
                }
                else
                {
                    var nl = context.NguyenLieu.Find(id);
                    if (nl != null)
                    {
                        nl.TenNguyenLieu = tenNLMoi;
                        nl.DonViTinh = cboDonViTinh.Text.Trim();
                        nl.SoLuongTon = tonKho;
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Đã lưu dữ liệu kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                HienThiDuLieuLenLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            HienThiDuLieuLenLuoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                prompt.Text = "Tìm kiếm nguyên liệu";
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập tên nguyên liệu cần tìm:" };
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

        // CHỈ CHO PHÉP NHẬP SỐ VÀO Ô SỐ LƯỢNG TỒN (Chặn gõ tay ký tự lạ)
        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Kiểm tra an toàn tồn kho
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang ở cột Số Lượng Tồn (Cột thứ 4, index là 3)
            if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "SoLuongTon")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int tonKho))
                {
                    // Định mức an toàn là 10. Nếu dưới 10 thì tô màu đỏ cho cả dòng
                    if (tonKho < 100)
                    {
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192); // Màu đỏ nhạt
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red; // Chữ đỏ đậm
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
                    }
                    else
                    {
                        // Reset lại màu bình thường cho các dòng an toàn
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}