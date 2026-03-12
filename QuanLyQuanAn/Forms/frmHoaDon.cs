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
using Microsoft.EntityFrameworkCore;

namespace QuanLyQuanAn.Forms
{
    public partial class frmHoaDon : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        int id;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;

            // BƯỚC 1: Dùng .Include để yêu cầu SQL lôi luôn dữ liệu bảng liên quan lên RAM
            var dsHoaDon = context.HoaDon
                .Include(r => r.NhanVien)      // Lôi cả bảng Nhân viên
                .Include(r => r.KhachHang)     // Lôi cả bảng Khách hàng
                .Include(r => r.HoaDon_ChiTiet) // Lôi cả bảng Chi tiết để tính tổng tiền
                .ToList();

            // BƯỚC 2: Đổ dữ liệu vào danh sách hiển thị
            List<DanhSachHoaDon> hd = dsHoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                // Bây giờ r.NhanVien đã có dữ liệu nên sẽ hiện được tên
                HoVaTenNhanVien = r.NhanVien?.HoVaTen ?? "Chưa xác định",

                KhachHangID = r.KhachHangID,
                // Bây giờ r.KhachHang đã có dữ liệu nên sẽ hiện được tên
                HoVaTenKhachHang = r.KhachHang?.HoVaTen ?? "Khách vãng lai",

                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,

                // Tính tổng tiền từ danh sách chi tiết đã được Include ở trên
                TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => (double?)((int)ct.SoLuongBan * ct.DonGiaBan)) ?? 0,

                XemChiTiet = "Xem chi tiết"
            }).ToList();

            dataGridView.DataSource = hd;
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet())
            {
                chiTiet.ShowDialog();
            }
            // Gọi lại Load để làm mới lưới sau khi lập hóa đơn
            frmHoaDon_Load(sender, e);
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
            {
                chiTiet.ShowDialog();
            }
            // Gọi lại Load để làm mới lưới sau khi sửa hóa đơn
            frmHoaDon_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                var hd = context.HoaDon.Find(id);
                if (hd != null)
                {
                    // Xóa chi tiết hóa đơn trước (để không bị lỗi khóa ngoại)
                    var chiTiets = context.HoaDon_ChiTiet.Where(ct => ct.HoaDonID == id);
                    context.HoaDon_ChiTiet.RemoveRange(chiTiets);

                    // Xóa hóa đơn chính
                    context.HoaDon.Remove(hd);
                    context.SaveChanges();

                    // Tải lại lưới
                    frmHoaDon_Load(sender, e);
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
            // Gọi hàm mở hộp thoại Pop-up để người dùng nhập từ khóa
            string tuKhoa = NhapTuKhoaPopUp("Nhập tên Khách hàng hoặc Nhân viên cần tìm:", "Tìm kiếm Hóa Đơn");

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = tuKhoa.ToLower(); // Chuyển thành chữ thường để dễ tìm

                // Lọc dữ liệu bằng LINQ
                var hd = context.HoaDon
                    .Where(r => r.KhachHang.HoVaTen.ToLower().Contains(tuKhoa) || r.NhanVien.HoVaTen.ToLower().Contains(tuKhoa))
                    .Select(r => new DanhSachHoaDon
                    {
                        ID = r.ID,
                        NhanVienID = r.NhanVienID,
                        HoVaTenNhanVien = r.NhanVien.HoVaTen,
                        KhachHangID = r.KhachHangID,
                        HoVaTenKhachHang = r.KhachHang.HoVaTen,
                        NgayLap = r.NgayLap,
                        GhiChuHoaDon = r.GhiChuHoaDon,
                        TongTienHoaDon = r.HoaDon_ChiTiet.Sum(ct => ct.SoLuongBan * ct.DonGiaBan),
                        XemChiTiet = "Xem chi tiết"
                    }).ToList();

                dataGridView.DataSource = hd;

                if (hd.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmHoaDon_Load(sender, e); // Không thấy thì load lại toàn bộ
                }
            }
            else
            {
                // Nếu bấm Hủy hoặc không nhập gì thì load lại toàn bộ danh sách
                frmHoaDon_Load(sender, e);
            }
        }

        // Hàm phụ trợ: Tự động tạo một Form Pop-up nhỏ để nhập từ khóa (Tránh phải tạo Form mới thủ công)
        private string NhapTuKhoaPopUp(string loiNhan, string tieuDe)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = tieuDe,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false
            };
            Label lblText = new Label() { Left = 20, Top = 20, Width = 350, Text = loiNhan };
            TextBox txtInput = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button btnXacNhan = new Button() { Text = "Tìm kiếm", Left = 260, Width = 100, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(lblText);
            prompt.Controls.Add(txtInput);
            prompt.Controls.Add(btnXacNhan);
            prompt.AcceptButton = btnXacNhan;

            return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : "";
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet" && e.RowIndex >= 0)
            {
                btnSua_Click(sender, e);
            }
        }
    }
}