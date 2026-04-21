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
    public partial class frmHoaDon_ChiTiet : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        int id;
        BindingList<DanhSachHoaDon_ChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();

        // TỐI ƯU 1: Thêm cờ theo dõi xem người dùng có đang nhập dở tay mà chưa lưu không
        bool CoThayDoiChuaLuu = false;

        // --- KHAI BÁO CÔNG CỤ IN BILL VÀ XEM TRƯỚC (Bằng Code) ---
        System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;

            // Kích hoạt sự kiện vẽ tờ Bill khi Form vừa khởi tạo
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

            // Bắt sự kiện tắt form đột ngột (Bấm dấu X góc phải)
            this.FormClosing += FrmHoaDon_ChiTiet_FormClosing;
        }

        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
            cboNhanVien.SelectedIndex = -1;
        }

        public void LayKhachHangVaoComboBox()
        {
            cboKhachHang.DataSource = context.KhachHang.ToList();
            cboKhachHang.ValueMember = "ID";
            cboKhachHang.DisplayMember = "HoVaTen";
            cboKhachHang.SelectedIndex = -1;
        }

        public void LayMonAnVaoComboBox()
        {
            cboMonAn.DataSource = context.MonAn.ToList();
            cboMonAn.ValueMember = "ID";
            cboMonAn.DisplayMember = "TenMon";
            cboMonAn.SelectedIndex = -1;
        }

        public void BatTatChucNang()
        {
            btnLuuHoaDon.Enabled = hoaDonChiTiet.Count > 0;
            btnXoa.Enabled = dataGridView.CurrentRow != null;
        }

        private void TinhTongTien()
        {
            int tongTien = 0;
            foreach (var item in hoaDonChiTiet)
            {
                tongTien += item.ThanhTien;
            }
            if (txtTongTien != null)
            {
                txtTongTien.Text = tongTien.ToString("#,##0") + " VNĐ";
            }
        }

        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayKhachHangVaoComboBox();
            LayMonAnVaoComboBox();

            cboMonAn.SelectedIndexChanged += CboMonAn_SelectedIndexChanged;
            dataGridView.AutoGenerateColumns = false;

            if (id != 0) // NẾU LÀ SỬA (Đã tồn tại chi tiết)
            {
                var hoaDon = context.HoaDon.Where(r => r.ID == id).SingleOrDefault();
                if (hoaDon != null)
                {
                    cboNhanVien.SelectedValue = hoaDon.NhanVienID;
                    cboKhachHang.SelectedValue = hoaDon.KhachHangID;
                    txtGhiChuHoaDon.Text = hoaDon.GhiChuHoaDon;

                    var ct = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDon_ChiTiet
                    {
                        ID = r.ID,
                        HoaDonID = r.HoaDonID,
                        MonAnID = r.MonAnID,
                        TenMonAn = r.MonAn.TenMon,
                        SoLuongBan = r.SoLuongBan,
                        DonGiaBan = r.DonGiaBan,
                        ThanhTien = Convert.ToInt32(r.SoLuongBan * r.DonGiaBan)
                    }).ToList();

                    hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>(ct);
                }
            }

            dataGridView.DataSource = hoaDonChiTiet;
            BatTatChucNang();
            TinhTongTien();
            CoThayDoiChuaLuu = false; // Vừa load lên thì chưa có thay đổi gì
        }

        private void CboMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonAn.SelectedIndex != -1 && cboMonAn.SelectedValue is int maMon)
            {
                var mon = context.MonAn.Find(maMon);
                if (mon != null)
                {
                    numDonGiaBan.Value = mon.DonGia;
                }
            }
        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            if (cboMonAn.SelectedIndex == -1) return;
            if (numSoLuongBan.Value <= 0) return;

            int maMon = Convert.ToInt32(cboMonAn.SelectedValue.ToString());
            var itemExisted = hoaDonChiTiet.FirstOrDefault(x => x.MonAnID == maMon);

            if (itemExisted != null)
            {
                itemExisted.SoLuongBan += (short)numSoLuongBan.Value;
                itemExisted.DonGiaBan = (int)numDonGiaBan.Value;
                itemExisted.ThanhTien = itemExisted.SoLuongBan * itemExisted.DonGiaBan;

                // TỐI ƯU 2: ResetBindings thay vì Refresh để lưới cập nhật mượt và chính xác 100%
                hoaDonChiTiet.ResetBindings();
            }
            else
            {
                hoaDonChiTiet.Add(new DanhSachHoaDon_ChiTiet
                {
                    ID = 0,
                    HoaDonID = id,
                    MonAnID = maMon,
                    TenMonAn = cboMonAn.Text,
                    SoLuongBan = (short)numSoLuongBan.Value,
                    DonGiaBan = (int)numDonGiaBan.Value,
                    ThanhTien = (int)(numSoLuongBan.Value * numDonGiaBan.Value)
                });
            }

            cboMonAn.SelectedIndex = -1;
            numSoLuongBan.Value = 1;
            CoThayDoiChuaLuu = true; // Đánh dấu đã có thay đổi

            BatTatChucNang();
            TinhTongTien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            var item = (DanhSachHoaDon_ChiTiet)dataGridView.CurrentRow.DataBoundItem;
            hoaDonChiTiet.Remove(item);

            CoThayDoiChuaLuu = true; // Đánh dấu đã có thay đổi

            BatTatChucNang();
            TinhTongTien();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            //Kiểm tra hóa đơn trống
            if (hoaDonChiTiet.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có món ăn nào! Vui lòng thêm món trước khi thanh toán.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNhanVien.SelectedIndex == -1 || cboKhachHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Nhân viên và Khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TỐI ƯU 3: Bọc Try-Catch để chống văng phần mềm khi lưu Database
            try
            {
                if (id != 0) // NẾU LÀ SỬA
                {
                    var hd = context.HoaDon.Find(id);
                    if (hd != null)
                    {
                        hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                        hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                        hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;

                        var old = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                        context.HoaDon_ChiTiet.RemoveRange(old);

                        foreach (var item in hoaDonChiTiet.ToList())
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                            ct.HoaDonID = id;
                            ct.MonAnID = item.MonAnID;
                            ct.SoLuongBan = item.SoLuongBan;
                            ct.DonGiaBan = item.DonGiaBan;
                            context.HoaDon_ChiTiet.Add(ct);
                        }
                        context.SaveChanges();
                    }
                }
                else // NẾU LÀ THÊM MỚI
                {
                    HoaDon hd = new HoaDon();
                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                    hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                    hd.NgayLap = DateTime.Now;
                    hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                    context.HoaDon.Add(hd);
                    context.SaveChanges();

                    id = hd.ID; // Lấy ID vừa tạo

                    foreach (var item in hoaDonChiTiet.ToList())
                    {
                        HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                        ct.HoaDonID = hd.ID;
                        ct.MonAnID = item.MonAnID;
                        ct.SoLuongBan = item.SoLuongBan;
                        ct.DonGiaBan = item.DonGiaBan;
                        context.HoaDon_ChiTiet.Add(ct);
                    }
                    context.SaveChanges();
                }

                CoThayDoiChuaLuu = false; // Đã lưu thành công
                MessageBox.Show("Lưu hóa đơn thành công! Bạn có thể nhấn In Hóa Đơn để xuất Bill.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================
        // TỐI ƯU 1: Bẫy lỗi tắt form khi chưa lưu
        // =========================================================
        private void FrmHoaDon_ChiTiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CoThayDoiChuaLuu)
            {
                DialogResult rep = MessageBox.Show("Hóa đơn này đang có thay đổi nhưng CHƯA ĐƯỢC LƯU.\nNếu bạn thoát, các thay đổi sẽ bị mất.\n\nBạn có chắc chắn muốn thoát không?",
                                                   "Cảnh báo mất dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rep == DialogResult.No)
                {
                    e.Cancel = true; // Hủy lệnh tắt form
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close(); // Sẽ tự động kích hoạt FrmHoaDon_ChiTiet_FormClosing ở trên
        }

        // =========================================================
        // CÁC HÀM IN ẤN (GIỮ NGUYÊN VÌ ĐÃ RẤT CHUẨN)
        // =========================================================
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDonChiTiet.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có món ăn nào để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (id == 0 || CoThayDoiChuaLuu) // Tối ưu: Nếu có sửa mà chưa lưu thì bắt lưu lại
            {
                MessageBox.Show("Bạn đang có thay đổi chưa lưu. Vui lòng nhấn 'Lưu Hóa Đơn' trước khi in Bill!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            printPreviewDialog1.Text = "Hóa đơn tính tiền";
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Width = 550;
            printPreviewDialog1.Height = 700;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTieuDe = new Font("Courier New", 18, FontStyle.Bold);
            Font fontThuong = new Font("Courier New", 12, FontStyle.Regular);
            Font fontDam = new Font("Courier New", 12, FontStyle.Bold);
            Brush brush = Brushes.Black;
            int y = 20;

            g.DrawString("QUÁN ĂN SÁNG Núi Sập", fontTieuDe, brush, new PointF(250, y));
            y += 40;
            g.DrawString("Đ/c: Xã Thoại Sơn, Huyện Núi Sập, Tỉnh An Giang", fontThuong, brush, new PointF(250, y));
            y += 30;
            g.DrawString("ĐT: 0914.965.676", fontThuong, brush, new PointF(330, y));
            y += 40;

            g.DrawString("----------------------------------------------------------------------", fontThuong, brush, new PointF(50, y));
            y += 30;

            g.DrawString("HÓA ĐƠN THANH TOÁN", fontTieuDe, brush, new PointF(280, y));
            y += 40;
            g.DrawString("Mã HĐ: " + id.ToString(), fontThuong, brush, new PointF(50, y));
            g.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontThuong, brush, new PointF(450, y));
            y += 30;
            g.DrawString("Khách hàng: " + cboKhachHang.Text, fontThuong, brush, new PointF(50, y));
            y += 30;
            g.DrawString("Nhân viên : " + cboNhanVien.Text, fontThuong, brush, new PointF(50, y));
            y += 30;

            g.DrawString("----------------------------------------------------------------------", fontThuong, brush, new PointF(50, y));
            y += 30;

            g.DrawString("Tên Món", fontDam, brush, new PointF(50, y));
            g.DrawString("SL", fontDam, brush, new PointF(400, y));
            g.DrawString("Đơn Giá", fontDam, brush, new PointF(500, y));
            g.DrawString("Thành Tiền", fontDam, brush, new PointF(650, y));
            y += 30;

            g.DrawString("----------------------------------------------------------------------", fontThuong, brush, new PointF(50, y));
            y += 30;

            int tongTien = 0;
            foreach (var item in hoaDonChiTiet)
            {
                g.DrawString(item.TenMonAn, fontThuong, brush, new PointF(50, y));
                g.DrawString(item.SoLuongBan.ToString(), fontThuong, brush, new PointF(400, y));
                g.DrawString(item.DonGiaBan.ToString("#,##0"), fontThuong, brush, new PointF(500, y));
                g.DrawString(item.ThanhTien.ToString("#,##0"), fontThuong, brush, new PointF(650, y));
                y += 30;
                tongTien += item.ThanhTien;
            }

            g.DrawString("----------------------------------------------------------------------", fontThuong, brush, new PointF(50, y));
            y += 30;

            g.DrawString("TỔNG CỘNG:", fontDam, brush, new PointF(400, y));
            g.DrawString(tongTien.ToString("#,##0") + " VNĐ", fontDam, brush, new PointF(620, y));
            y += 50;

            g.DrawString("Cảm ơn Quý khách & Hẹn gặp lại!", fontThuong, brush, new PointF(250, y));
        }
    }
}