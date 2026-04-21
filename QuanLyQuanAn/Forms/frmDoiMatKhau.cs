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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
         if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text) ||
         string.IsNullOrWhiteSpace(txtMatKhauMoi.Text) ||
         string.IsNullOrWhiteSpace(txtXacNhan.Text))
            {
                MessageBox.Show("Vui lòng không để trống bất kỳ ô nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMatKhauMoi.Text != txtXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu mới và Xác nhận mật khẩu phải giống nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXacNhan.Focus();
                return;
            }

            // Kiểm tra an toàn xem ID có hợp lệ không trước khi chọc vào Database
            int idHienTai = ThongTinDangNhap.ID;
            if (idHienTai <= 0)
            {
                MessageBox.Show("Hệ thống bị mất phiên đăng nhập. Vui lòng đăng xuất và đăng nhập lại!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new QLQADbcontext())
                {
                    var nv = db.NhanVien.SingleOrDefault(x => x.ID == idHienTai);

                    if (nv == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin tài khoản trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (nv.MatKhau != txtMatKhauCu.Text)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhauCu.Focus();
                        txtMatKhauCu.SelectAll();
                        return;
                    }

                    // Đổi pass và lưu lại
                    nv.MatKhau = txtMatKhauMoi.Text;
                    db.SaveChanges();

                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtXacNhan.Clear();
            txtMatKhauCu.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // Nếu đang ở chế độ ẩn (*)
            if (txtMatKhauCu.UseSystemPasswordChar)
            {
                txtMatKhauCu.UseSystemPasswordChar = false;
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtXacNhan.UseSystemPasswordChar = false;
                btnHienThi.Text = "Ẩn";
            }
            else // Nếu đang hiện chữ rõ ràng
            {
                txtMatKhauCu.UseSystemPasswordChar = true;
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtXacNhan.UseSystemPasswordChar = true;
                btnHienThi.Text = "Hiển thị";
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtXacNhan.UseSystemPasswordChar = true;
        }
    }
}