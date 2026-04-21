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
    public partial class frmThanhToanQR : Form
    {
        public frmThanhToanQR(string tongTien)
        {
            InitializeComponent();
            // Ép cái số tiền vào Label để hiển thị cho khách xem
            lblTongTien.Text = "Số tiền cần thanh toán:\n\n" + tongTien + " VNĐ";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Trả về kết quả OK cho Form Bán hàng biết là tiền đã vào tài khoản
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Trả về Cancel nếu khách đổi ý muốn trả tiền mặt hoặc quét lỗi
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}