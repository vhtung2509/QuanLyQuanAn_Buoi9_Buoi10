using QuanLyQuanAn.Data;
using QuanLyQuanAn.Reports;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanAn.Forms
{
    public partial class frmMain : Form
    {
        QLQADbcontext context = new QLQADbcontext();

        // Khai báo các biến chứa Form con
        frmLoaiMonAn loaiMonAn = null;
        frmMonAn monAn = null;
        frmKhachHang khachHang = null;
        frmNhanVien nhanVien = null;
        frmHoaDon hoaDon = null;
        frmHoaDon_ChiTiet hoaDon_ChiTiet = null;
        frmDangNhap dangNhap = null;
        frmBanAn banAn = null;
        frmNguyenLieu nguyenLieu = null;
        frmCongThuc congThuc = null;
        frmNhaCungCap nhaCungCap = null;
        frmChiTiet_PhieuNhap chiTiet_PhieuNhap = null;
        frmPhieuNhap phieuNhap = null;
        frmDoiMatKhau doiMatKhau = null;
        frmThongTinPhanMem thongTinPhanMem = null;
        frmManHinhOrder manHinhOrder = null;
        frmVoucher maVoucher = null;
        // BỔ SUNG: Khai báo 3 biến cho Form Thống kê để kiểm soát mở 1 Tab duy nhất
        frmThongKeMonAn thongKeMonAn = null;
        frmThongKeDoanhThu thongKeDoanhThu = null;
        frmThongKePhieuNhap thongKePhieuNhap = null;
        //Tích hợp AI
        frmTichHopAI tichHopAI = null;
        string hoVaTenNhanVien = "";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
            // Chế màu hover cho menuStrip
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MauHoverCustom());
        }

        private class MauHoverCustom : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.Teal;
            public override Color MenuItemSelectedGradientBegin => Color.Teal;
            public override Color MenuItemSelectedGradientEnd => Color.Teal;
            public override Color MenuItemPressedGradientBegin => Color.DarkSlateGray;
            public override Color MenuItemPressedGradientEnd => Color.DarkSlateGray;
            public override Color MenuItemBorder => Color.Transparent;
        }

        public void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;
            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;
            mnuTichHopAI.Enabled = false;

            mnuLoaiMonAn.Enabled = false;
            mnuMonAn.Enabled = false;
            mnuDatBan.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuHoaDonChiTiet.Enabled = false;
            mnuNguyenLieu.Enabled = false;
            mnuCongThuc.Enabled = false;
            mnuNhaCungCap.Enabled = false;
            mnuPhieuNhap.Enabled = false;
            mnuHoaDonPhieuNhap.Enabled = false;
            mnuMaVoucher.Enabled = false;

            mnuManHinhOrder.Enabled = false; // Khóa màn hình Order khi chưa đăng nhập

            mnuThongKeMonAn.Enabled = false;
            mnuThongKeDoanhThu.Enabled = false;
            mnuThongKePhieuNhap.Enabled = false;

            mnuThongTinPhanMem.Enabled = true;

            lblTrangThai.Text = "Trạng thái: Chưa đăng nhập.";
        }

        public void PhanQuyen(string quyen)
        {
            mnuDangNhap.Enabled = false;
            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuThongTinPhanMem.Enabled = true;

            // Mở khóa Màn hình Order cho TẤT CẢ nhân viên sau khi đăng nhập thành công
            mnuManHinhOrder.Enabled = true;

            mnuLoaiMonAn.Enabled = false;
            mnuDatBan.Enabled = false;
            mnuNguyenLieu.Enabled = false;
            mnuCongThuc.Enabled = false;
            mnuMonAn.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuNhaCungCap.Enabled = false;
            mnuPhieuNhap.Enabled = false;
            mnuHoaDonPhieuNhap.Enabled = false;
            mnuThongKeMonAn.Enabled = false;
            mnuThongKeDoanhThu.Enabled = false;
            mnuThongKePhieuNhap.Enabled = false;
            mnuHoaDonChiTiet.Enabled = false;
            mnuMaVoucher.Enabled = false;


            switch (quyen)
            {
                case "Quản lý":
                    mnuLoaiMonAn.Enabled = true;
                    mnuDatBan.Enabled = true;
                    mnuNguyenLieu.Enabled = true;
                    mnuCongThuc.Enabled = true;
                    mnuMonAn.Enabled = true;
                    mnuNhanVien.Enabled = true;
                    mnuKhachHang.Enabled = true;
                    mnuHoaDon.Enabled = true;
                    mnuHoaDonChiTiet.Enabled = false;
                    mnuNhaCungCap.Enabled = true;
                    mnuPhieuNhap.Enabled = true;
                    mnuHoaDonPhieuNhap.Enabled = false;
                    mnuThongKeMonAn.Enabled = true;
                    mnuThongKeDoanhThu.Enabled = true;
                    mnuThongKePhieuNhap.Enabled = true;
                    mnuMaVoucher.Enabled = true;
                    mnuTichHopAI.Enabled = true;
                    break;

                case "Kế toán":
                    mnuNguyenLieu.Enabled = true;
                    mnuNhaCungCap.Enabled = true;
                    mnuPhieuNhap.Enabled = true;
                    mnuHoaDon.Enabled = true;
                    break;

                case "Thu ngân":
                    mnuDatBan.Enabled = true;
                    mnuKhachHang.Enabled = true;
                    mnuHoaDon.Enabled = true;
                    mnuMonAn.Enabled = true;
                    mnuLoaiMonAn.Enabled = true;
                    break;

                case "Phục vụ":
                    mnuDatBan.Enabled = true;
                    mnuKhachHang.Enabled = true;
                    mnuMonAn.Enabled = true;
                    mnuLoaiMonAn.Enabled = true;
                    break;

                case "Nhân viên bếp":
                    mnuCongThuc.Enabled = true;
                    mnuNguyenLieu.Enabled = true;
                    mnuMonAn.Enabled = true;
                    mnuLoaiMonAn.Enabled = true;
                    break;

                default:
                    MessageBox.Show("Tài khoản này chưa được gán quyền hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

            lblTrangThai.Text = $"{quyen}: {hoVaTenNhanVien}";
            //Hàm mở dashboard ngay khi vừa đăng nhập

        }

        private void DangNhap()
        {
            bool dangNhapThanhCong = false;

            while (!dangNhapThanhCong)
            {
                if (dangNhap == null || dangNhap.IsDisposed)
                    dangNhap = new frmDangNhap();

                if (dangNhap.ShowDialog() == DialogResult.OK)
                {
                    string tenDangNhap = dangNhap.txtTenDangNhap.Text.Trim();
                    string matKhau = dangNhap.txtMatKhau.Text.Trim();

                    if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    context = new QLQADbcontext();
                    var nv = context.NhanVien.SingleOrDefault(r => r.TenDangNhap == tenDangNhap);

                    if (nv == null)
                    {
                        MessageBox.Show("Tên đăng nhập không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Clear();
                    }
                    else if (nv.MatKhau != matKhau)
                    {
                        MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtMatKhau.Clear();
                    }
                    else
                    {
                        hoVaTenNhanVien = nv.HoVaTen;
                        ThongTinDangNhap.ID = nv.ID;
                        PhanQuyen(nv.Quyen);
                        dangNhapThanhCong = true;
                    }
                }
                else
                {
                    Application.Exit();
                    break;
                }
            }
        }

        private void mnuLoaiMonAn_Click(object sender, EventArgs e)
        {
            if (loaiMonAn == null || loaiMonAn.IsDisposed) { loaiMonAn = new frmLoaiMonAn(); loaiMonAn.MdiParent = this; loaiMonAn.Show(); }
            else loaiMonAn.Activate();
        }

        private void mnuMonAn_Click(object sender, EventArgs e)
        {
            if (monAn == null || monAn.IsDisposed) { monAn = new frmMonAn(); monAn.MdiParent = this; monAn.Show(); }
            else monAn.Activate();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVien == null || nhanVien.IsDisposed) { nhanVien = new frmNhanVien(); nhanVien.MdiParent = this; nhanVien.Show(); }
            else nhanVien.Activate();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (khachHang == null || khachHang.IsDisposed) { khachHang = new frmKhachHang(); khachHang.MdiParent = this; khachHang.Show(); }
            else khachHang.Activate();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDon == null || hoaDon.IsDisposed) { hoaDon = new frmHoaDon(); hoaDon.MdiParent = this; hoaDon.Show(); }
            else hoaDon.Activate();
        }

        private void mnuDatBan_Click(object sender, EventArgs e)
        {
            if (banAn == null || banAn.IsDisposed) { banAn = new frmBanAn(); banAn.MdiParent = this; banAn.Show(); }
            else banAn.Activate();
        }

        private void mnuNguyenLieu_Click(object sender, EventArgs e)
        {
            if (nguyenLieu == null || nguyenLieu.IsDisposed) { nguyenLieu = new frmNguyenLieu(); nguyenLieu.MdiParent = this; nguyenLieu.Show(); }
            else nguyenLieu.Activate();
        }

        private void mnuCongThuc_Click(object sender, EventArgs e)
        {
            if (congThuc == null || congThuc.IsDisposed) { congThuc = new frmCongThuc(); congThuc.MdiParent = this; congThuc.Show(); }
            else congThuc.Activate();
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            if (nhaCungCap == null || nhaCungCap.IsDisposed) { nhaCungCap = new frmNhaCungCap(); nhaCungCap.MdiParent = this; nhaCungCap.Show(); }
            else nhaCungCap.Activate();
        }

        private void mnuPhieuNhap_Click(object sender, EventArgs e)
        {
            if (phieuNhap == null || phieuNhap.IsDisposed) { phieuNhap = new frmPhieuNhap(); phieuNhap.MdiParent = this; phieuNhap.Show(); }
            else phieuNhap.Activate();
        }

        private void mnuHoaDonPhieuNhap_Click(object sender, EventArgs e)
        {
            if (chiTiet_PhieuNhap == null || chiTiet_PhieuNhap.IsDisposed) { chiTiet_PhieuNhap = new frmChiTiet_PhieuNhap(); chiTiet_PhieuNhap.MdiParent = this; chiTiet_PhieuNhap.Show(); }
            else chiTiet_PhieuNhap.Activate();
        }

        // =========================================================================
        // SỬA LẠI 3 HÀM THỐNG KÊ CHO CHUẨN FORM CON (MDI)
        // =========================================================================
        private void mnuThongKeMonAn_Click(object sender, EventArgs e)
        {
            if (thongKeMonAn == null || thongKeMonAn.IsDisposed) { thongKeMonAn = new frmThongKeMonAn(); thongKeMonAn.MdiParent = this; thongKeMonAn.Show(); }
            else thongKeMonAn.Activate();
        }

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            if (thongKeDoanhThu == null || thongKeDoanhThu.IsDisposed) { thongKeDoanhThu = new frmThongKeDoanhThu(); thongKeDoanhThu.MdiParent = this; thongKeDoanhThu.Show(); }
            else thongKeDoanhThu.Activate();
        }

        private void mnuThongKePhieuNhap_Click(object sender, EventArgs e)
        {
            if (thongKePhieuNhap == null || thongKePhieuNhap.IsDisposed) { thongKePhieuNhap = new frmThongKePhieuNhap(); thongKePhieuNhap.MdiParent = this; thongKePhieuNhap.Show(); }
            else thongKePhieuNhap.Activate();
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren) child.Close();
            ChuaDangNhap();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void lblLienKet_Click(object sender, EventArgs e) { Process.Start(new ProcessStartInfo { FileName = "https://fit.agu.edu.vn", UseShellExecute = true }); }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (doiMatKhau == null || doiMatKhau.IsDisposed) { doiMatKhau = new frmDoiMatKhau(); doiMatKhau.MdiParent = this; doiMatKhau.Show(); }
            else doiMatKhau.Activate();
        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            if (thongTinPhanMem == null || thongTinPhanMem.IsDisposed) { thongTinPhanMem = new frmThongTinPhanMem(); thongTinPhanMem.MdiParent = this; thongTinPhanMem.Show(); }
            else thongTinPhanMem.Activate();
        }

        private void mnuManHinhOrder_Click(object sender, EventArgs e)
        {
            if (manHinhOrder == null || manHinhOrder.IsDisposed) { manHinhOrder = new frmManHinhOrder(); manHinhOrder.MdiParent = this; manHinhOrder.Show(); }
            else manHinhOrder.Activate();
        }

        private void mnuMaVoucher_Click(object sender, EventArgs e)
        {
            if (maVoucher == null || maVoucher.IsDisposed) { maVoucher = new frmVoucher(); maVoucher.MdiParent = this; maVoucher.Show(); }
            else maVoucher.Activate();
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            try { Process.Start(new ProcessStartInfo { FileName = @"E:\LTQL\QuanLyQuanAn\QuanLyQuanAn\HuongDanSuDung\huongdansudung.html", UseShellExecute = true }); }
            catch { MessageBox.Show("Không tìm thấy file Hướng dẫn sử dụng!"); }
        }

        private void mnuMenu_Click(object sender, EventArgs e)
        {
            try { Process.Start(new ProcessStartInfo { FileName = @"E:\LTQL\QuanLyQuanAn\QuanLyQuanAn\HuongDanSuDung\menu.html", UseShellExecute = true }); }
            catch { MessageBox.Show("Không tìm thấy file menu.html!"); }
        }

        private void mnuLienHeQuanLy_Click(object sender, EventArgs e)
        {
            try { Process.Start(new ProcessStartInfo { FileName = @"E:\LTQL\QuanLyQuanAn\QuanLyQuanAn\HuongDanSuDung\thongtinquanly.html", UseShellExecute = true }); }
            catch { MessageBox.Show("Không tìm thấy trang liên hệ quản lý!"); }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) mnuHuongDanSuDung_Click(sender, e);
            else if (e.KeyCode == Keys.F2) mnuMenu_Click(sender, e);
            else if (e.KeyCode == Keys.F3) mnuLienHeQuanLy_Click(sender, e);
        }

        private void mnuTichHopAI_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu form chưa được tạo hoặc đã bị người dùng đóng (Disposed)
            if (tichHopAI == null || tichHopAI.IsDisposed)
            {
                tichHopAI = new frmTichHopAI();
                tichHopAI.MdiParent = this; // Ép nó hiện bên trong form Main
                tichHopAI.Show();
            }
            else
            {
                // Nếu đang mở rồi thì chỉ cần kích hoạt cho nó nổi lên trên
                tichHopAI.Activate();
            }
        }
    }
}