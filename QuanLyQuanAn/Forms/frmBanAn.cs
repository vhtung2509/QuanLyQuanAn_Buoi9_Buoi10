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
    public partial class frmBanAn : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        bool XuLyThem = false;
        int idBan;

        public frmBanAn()
        {
            InitializeComponent();
        }

        // =========================================================
        // 1. HÀM BẬT / TẮT CHỨC NĂNG (GIỐNG NCC)
        // =========================================================
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            txtSoBan.Enabled = giaTri;
            cboTrangThai.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
        }

        private void frmBanAn_Load(object sender, EventArgs e)
        {
            LoadComboBoxTrangThai();
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            HienThiDuLieuLenLuoi();
        }

        private void LoadComboBoxTrangThai()
        {
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Trống", "Có khách" });
        }

        // =========================================================
        // 2. GỘP CHUNG HÀM LOAD DỮ LIỆU, TÌM KIẾM VÀ DATABINDING
        // =========================================================
        private void HienThiDuLieuLenLuoi(string tuKhoa = "")
        {
            try
            {
                context.ChangeTracker.Clear();
                var query = context.BanAn.AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(b => b.TenBan.ToLower().Contains(tuKhoa));
                }

                // Sắp xếp bàn theo ID tăng dần (Bàn 1, Bàn 2...) cho đẹp
                var dsBan = query.OrderBy(b => b.ID).ToList();

                if (dsBan.Count == 0 && !string.IsNullOrWhiteSpace(tuKhoa))
                {
                    MessageBox.Show("Không tìm thấy bàn nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi(""); // Trả về toàn bộ danh sách
                    return;
                }

                BindingSource bin = new BindingSource();
                bin.DataSource = dsBan;

                // Đồng bộ DataBinding
                txtSoBan.DataBindings.Clear();
                txtSoBan.DataBindings.Add("Text", bin, "TenBan", false, DataSourceUpdateMode.Never);

                cboTrangThai.DataBindings.Clear();
                cboTrangThai.DataBindings.Add("Text", bin, "TrangThai", false, DataSourceUpdateMode.Never);

                dataGridView.DataSource = bin;
                DinhDangLuoi();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load dữ liệu: " + ex.Message); }
        }

        private void DinhDangLuoi()
        {
            if (dataGridView.Columns.Count >= 3)
            {
                dataGridView.Columns[0].DataPropertyName = "ID";
                dataGridView.Columns[1].DataPropertyName = "TenBan";
                dataGridView.Columns[2].DataPropertyName = "TrangThai";

                dataGridView.Columns[0].Visible = true;
                dataGridView.Columns[0].HeaderText = "Mã Số Bàn";
                dataGridView.Columns[1].HeaderText = "Tên Bàn";
                dataGridView.Columns[2].HeaderText = "Trạng Thái";
            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =========================================================
        // 3. THAO TÁC THÊM, SỬA, XÓA, HỦY
        // =========================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLyThem = true;
            BatTatChucNang(true);
            txtSoBan.Clear();
            cboTrangThai.SelectedIndex = 0; // Mặc định Thêm mới là "Trống"
            txtSoBan.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            XuLyThem = false;
            BatTatChucNang(true);
            idBan = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
            txtSoBan.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string tenBan = txtSoBan.Text;

            if (MessageBox.Show($"Xóa bàn '{tenBan}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int idXoa = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                    var banXoa = context.BanAn.Find(idXoa);
                    if (banXoa != null)
                    {
                        context.BanAn.Remove(banXoa);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDuLieuLenLuoi();
                }
                catch
                {
                    MessageBox.Show("Không thể xóa Bàn này vì đang có Hóa đơn liên quan!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            HienThiDuLieuLenLuoi();
        }

        // =========================================================
        // 4. LƯU & RÀNG BUỘC (KIỂM TRA TRÙNG LẶP)
        // =========================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenBan = txtSoBan.Text.Trim();
            string trangThai = string.IsNullOrWhiteSpace(cboTrangThai.Text) ? "Trống" : cboTrangThai.Text;

            if (string.IsNullOrWhiteSpace(tenBan))
            {
                MessageBox.Show("Tên bàn/Số bàn không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoBan.Focus();
                return;
            }

            try
            {
                // Kiểm tra trùng tên bàn (VD: Không cho nhập 2 cái "Bàn 1")
                bool trungTenBan = XuLyThem ? context.BanAn.Any(b => b.TenBan.ToLower() == tenBan.ToLower())
                                            : context.BanAn.Any(b => b.TenBan.ToLower() == tenBan.ToLower() && b.ID != idBan);
                if (trungTenBan)
                {
                    MessageBox.Show("Tên bàn này đã tồn tại! Vui lòng đặt tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoBan.Focus();
                    return;
                }

                if (XuLyThem)
                {
                    var banMoi = new QuanLyQuanAn.Data.BanAn
                    {
                        TenBan = tenBan,
                        TrangThai = trangThai
                    };
                    context.BanAn.Add(banMoi);
                }
                else
                {
                    var banSua = context.BanAn.Find(idBan);
                    if (banSua != null)
                    {
                        banSua.TenBan = tenBan;
                        banSua.TrangThai = trangThai;
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Đã lưu dữ liệu bàn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                HienThiDuLieuLenLuoi();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu: " + ex.Message); }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rep = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rep == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // =========================================================
        // 5. CHUYỂN SANG DÙNG POP-UP TÌM KIẾM
        // =========================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 160;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Tìm kiếm Bàn Ăn";
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập tên bàn cần tìm:" };
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
    }
}