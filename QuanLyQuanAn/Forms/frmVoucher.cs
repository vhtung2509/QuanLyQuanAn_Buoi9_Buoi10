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

namespace QuanLyQuanAn.Forms
{
    public partial class frmVoucher : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        bool XuLyThem = false;
        int id;
        public frmVoucher()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtMaVoucher.Enabled = giaTri;
            txtPhanTramGiam.Enabled = giaTri;
            dtpNgayBatDau.Enabled = giaTri;
            dtpNgayHetHan.Enabled = giaTri;
            cboTrangThai.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void frmVoucher_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new string[] { "Hoạt động", "Đã khóa" });

            HienThiDuLieuLenLuoi();
        }

        private void HienThiDuLieuLenLuoi()
        {
            try
            {
                context.ChangeTracker.Clear();
                var vouchers = context.Vouchers.OrderByDescending(v => v.ID).ToList();

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = vouchers;

                // Xóa và gán lại sự kiện để tránh lỗi kích hoạt nhiều lần
                bindingSource.PositionChanged -= BindingSource_PositionChanged;
                bindingSource.PositionChanged += BindingSource_PositionChanged;

                // Ràng buộc (Binding) dữ liệu vào các ô nhập
                txtMaVoucher.DataBindings.Clear();
                txtMaVoucher.DataBindings.Add("Text", bindingSource, "MaVoucher", false, DataSourceUpdateMode.Never);

                txtPhanTramGiam.DataBindings.Clear();
                txtPhanTramGiam.DataBindings.Add("Text", bindingSource, "PhanTramGiam", false, DataSourceUpdateMode.Never);

                dtpNgayBatDau.DataBindings.Clear();
                dtpNgayBatDau.DataBindings.Add("Value", bindingSource, "NgayBatDau", true, DataSourceUpdateMode.Never);

                dtpNgayHetHan.DataBindings.Clear();
                dtpNgayHetHan.DataBindings.Add("Value", bindingSource, "NgayHetHan", true, DataSourceUpdateMode.Never);

                // Ép định dạng hiển thị cho cột Trạng thái
                dataGridView.CellFormatting -= dataGridView_CellFormatting;
                dataGridView.CellFormatting += dataGridView_CellFormatting;

                dataGridView.DataSource = bindingSource;

                // Gọi thủ công 1 lần để set cái ComboBox lúc mới load
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
            if (bs != null && bs.Current is Voucher item)
            {
                // Chuyển từ kiểu bool trong DB ra chữ cho ComboBox
                cboTrangThai.Text = item.TrangThai ? "Hoạt động" : "Đã khóa";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLyThem = true;
            BatTatChucNang(true);

            txtMaVoucher.Clear();
            txtPhanTramGiam.Clear();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddDays(7);
            cboTrangThai.SelectedIndex = 0;

            txtMaVoucher.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            string ma = txtMaVoucher.Text;
            if (MessageBox.Show("Xác nhận xóa mã khuyến mãi " + ma + "?", "Cảnh báo Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    Voucher v = context.Vouchers.Find(id);
                    if (v != null)
                    {
                        context.Vouchers.Remove(v);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa voucher thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDuLieuLenLuoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            XuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtMaVoucher.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaVoucher.Text.Trim().ToUpper();

            // ==========================================
            // BẮT ĐẦU: RÀNG BUỘC CHẶT CHẼ ĐẦU VÀO
            // ==========================================
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(txtPhanTramGiam.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã và Phần trăm giảm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaVoucher.Focus();
                return;
            }

            int phanTram;
            if (!int.TryParse(txtPhanTramGiam.Text, out phanTram) || phanTram <= 0 || phanTram > 100)
            {
                MessageBox.Show("Phần trăm giảm phải là số từ 1 đến 100!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhanTramGiam.Focus();
                return;
            }

            if (dtpNgayHetHan.Value.Date < dtpNgayBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày áp dụng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // ==========================================

            try
            {
                // Kiểm tra trùng mã thông minh như cách làm bên frmNhanVien
                bool trungMa = XuLyThem ? context.Vouchers.Any(v => v.MaVoucher == ma)
                                        : context.Vouchers.Any(v => v.MaVoucher == ma && v.ID != id);
                if (trungMa)
                {
                    MessageBox.Show("Mã voucher này đã tồn tại! Vui lòng chọn mã khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaVoucher.Focus();
                    return;
                }

                if (XuLyThem)
                {
                    Voucher v = new Voucher
                    {
                        MaVoucher = ma,
                        PhanTramGiam = phanTram,
                        NgayBatDau = dtpNgayBatDau.Value,
                        NgayHetHan = dtpNgayHetHan.Value,
                        TrangThai = (cboTrangThai.Text == "Hoạt động") // Chuyển chữ về bool
                    };
                    context.Vouchers.Add(v);
                }
                else
                {
                    Voucher v = context.Vouchers.Find(id);
                    if (v != null)
                    {
                        v.MaVoucher = ma;
                        v.PhanTramGiam = phanTram;
                        v.NgayBatDau = dtpNgayBatDau.Value;
                        v.NgayHetHan = dtpNgayHetHan.Value;
                        v.TrangThai = (cboTrangThai.Text == "Hoạt động");
                        context.Vouchers.Update(v);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu thông tin Voucher thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                HienThiDuLieuLenLuoi();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tự động biến đổi True/False thành chữ trên Lưới cho đẹp
            if (dataGridView.Columns[e.ColumnIndex].DataPropertyName == "TrangThai" && e.Value != null)
            {
                bool trangThai = Convert.ToBoolean(e.Value);
                e.Value = trangThai ? "Hoạt động" : "Đã khóa";
                e.FormattingApplied = true;
            }
        }
    }
}