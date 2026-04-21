using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.Data; // Phải gọi thư viện Data để dùng DbContext

namespace QuanLyQuanAn.Forms
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
        }

        private void txtTenDangNhap_Click(object sender, EventArgs e)
        {
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu và loại bỏ khoảng trắng thừa
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // 2. Ràng buộc: Không được để trống
            if (string.IsNullOrWhiteSpace(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập để tiếp tục.", "Yêu cầu nhập liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Yêu cầu nhập liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // 3. KẾT NỐI DATABASE VÀ KIỂM TRA TÀI KHOẢN THẬT
            try
            {
                using (QLQADbcontext context = new QLQADbcontext())
                {
                    // Tìm nhân viên có tên đăng nhập và mật khẩu khớp 100%
                    var nhanVien = context.NhanVien.SingleOrDefault(nv => nv.TenDangNhap == tenDangNhap && nv.MatKhau == matKhau);

                    if (nhanVien != null)
                    {
                        // Đăng nhập thành công
                        MessageBox.Show($"Xác thực thành công. Chào mừng {nhanVien.HoVaTen}!", "Thành công",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // Sai tài khoản hoặc mật khẩu
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại!",
                                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtTenDangNhap.Focus();
        }

        private void cbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !cbHienMatKhau.Checked;
        }
    }
}