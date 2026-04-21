namespace QuanLyQuanAn.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuTichHopAI = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripSeparator();
            mnuThoat = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuLoaiMonAn = new ToolStripMenuItem();
            mnuDatBan = new ToolStripMenuItem();
            mnuNguyenLieu = new ToolStripMenuItem();
            mnuCongThuc = new ToolStripMenuItem();
            mnuMonAn = new ToolStripMenuItem();
            mnuManHinhOrder = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripSeparator();
            mnuNhanVien = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            mnuNhaCungCap = new ToolStripMenuItem();
            mnuHoaDon = new ToolStripMenuItem();
            mnuHoaDonChiTiet = new ToolStripMenuItem();
            mnuPhieuNhap = new ToolStripMenuItem();
            mnuHoaDonPhieuNhap = new ToolStripMenuItem();
            mnuMaVoucher = new ToolStripMenuItem();
            mnuBaoCaoThongKe = new ToolStripMenuItem();
            mnuThongKeMonAn = new ToolStripMenuItem();
            mnuThongKeDoanhThu = new ToolStripMenuItem();
            mnuThongKePhieuNhap = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuHuongDanSuDung = new ToolStripMenuItem();
            mnuThongTinPhanMem = new ToolStripMenuItem();
            mnuMenu = new ToolStripMenuItem();
            mnuLienHeQuanLy = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblLienKet = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.DarkSlateGray;
            menuStrip1.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuBaoCaoThongKe, mnuTroGiup });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(18, 10, 0, 18);
            menuStrip1.Size = new Size(1330, 60);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, mnuTichHopAI, thoátToolStripMenuItem, mnuThoat });
            mnuHeThong.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mnuHeThong.ForeColor = Color.White;
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(114, 32);
            mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangNhap
            // 
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Size = new Size(234, 32);
            mnuDangNhap.Text = "Đăng nhập";
            mnuDangNhap.Click += mnuDangNhap_Click;
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(234, 32);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(234, 32);
            mnuDoiMatKhau.Text = "Đổi mật khẩu";
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;
            // 
            // mnuTichHopAI
            // 
            mnuTichHopAI.Name = "mnuTichHopAI";
            mnuTichHopAI.Size = new Size(234, 32);
            mnuTichHopAI.Text = "Tích hợp AI";
            mnuTichHopAI.Click += mnuTichHopAI_Click;
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(231, 6);
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeyDisplayString = "ALT F4";
            mnuThoat.Size = new Size(234, 32);
            mnuThoat.Text = "Thoát ";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuLoaiMonAn, mnuDatBan, mnuNguyenLieu, mnuCongThuc, mnuMonAn, mnuManHinhOrder, kháchHàngToolStripMenuItem, mnuNhanVien, mnuKhachHang, toolStripMenuItem1, mnuNhaCungCap, mnuHoaDon, mnuHoaDonChiTiet, mnuPhieuNhap, mnuHoaDonPhieuNhap, mnuMaVoucher });
            mnuQuanLy.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mnuQuanLy.ForeColor = Color.White;
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(99, 32);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuLoaiMonAn
            // 
            mnuLoaiMonAn.Name = "mnuLoaiMonAn";
            mnuLoaiMonAn.Size = new Size(279, 32);
            mnuLoaiMonAn.Text = "Loại món ăn ";
            mnuLoaiMonAn.Click += mnuLoaiMonAn_Click;
            // 
            // mnuDatBan
            // 
            mnuDatBan.Name = "mnuDatBan";
            mnuDatBan.Size = new Size(279, 32);
            mnuDatBan.Text = "Đặt bàn";
            mnuDatBan.Click += mnuDatBan_Click;
            // 
            // mnuNguyenLieu
            // 
            mnuNguyenLieu.Name = "mnuNguyenLieu";
            mnuNguyenLieu.Size = new Size(279, 32);
            mnuNguyenLieu.Text = "Nguyên liệu";
            mnuNguyenLieu.Click += mnuNguyenLieu_Click;
            // 
            // mnuCongThuc
            // 
            mnuCongThuc.Name = "mnuCongThuc";
            mnuCongThuc.Size = new Size(279, 32);
            mnuCongThuc.Text = "Công thức nấu";
            mnuCongThuc.Click += mnuCongThuc_Click;
            // 
            // mnuMonAn
            // 
            mnuMonAn.Name = "mnuMonAn";
            mnuMonAn.Size = new Size(279, 32);
            mnuMonAn.Text = "Món ăn";
            mnuMonAn.Click += mnuMonAn_Click;
            // 
            // mnuManHinhOrder
            // 
            mnuManHinhOrder.Name = "mnuManHinhOrder";
            mnuManHinhOrder.Size = new Size(279, 32);
            mnuManHinhOrder.Text = "Màn hình order";
            mnuManHinhOrder.Click += mnuManHinhOrder_Click;
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(276, 6);
            // 
            // mnuNhanVien
            // 
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Size = new Size(279, 32);
            mnuNhanVien.Text = "Nhân viên";
            mnuNhanVien.Click += mnuNhanVien_Click;
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(279, 32);
            mnuKhachHang.Text = "Khách hàng";
            mnuKhachHang.Click += mnuKhachHang_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(276, 6);
            // 
            // mnuNhaCungCap
            // 
            mnuNhaCungCap.Name = "mnuNhaCungCap";
            mnuNhaCungCap.Size = new Size(279, 32);
            mnuNhaCungCap.Text = "Nhà cung cấp";
            mnuNhaCungCap.Click += mnuNhaCungCap_Click;
            // 
            // mnuHoaDon
            // 
            mnuHoaDon.Name = "mnuHoaDon";
            mnuHoaDon.Size = new Size(279, 32);
            mnuHoaDon.Text = "Hóa đơn bán hàng";
            mnuHoaDon.Click += mnuHoaDon_Click;
            // 
            // mnuHoaDonChiTiet
            // 
            mnuHoaDonChiTiet.Name = "mnuHoaDonChiTiet";
            mnuHoaDonChiTiet.Size = new Size(279, 32);
            mnuHoaDonChiTiet.Text = "Hóa đơn chi tiết";
            // 
            // mnuPhieuNhap
            // 
            mnuPhieuNhap.Name = "mnuPhieuNhap";
            mnuPhieuNhap.Size = new Size(279, 32);
            mnuPhieuNhap.Text = "Phiếu nhập";
            mnuPhieuNhap.Click += mnuPhieuNhap_Click;
            // 
            // mnuHoaDonPhieuNhap
            // 
            mnuHoaDonPhieuNhap.Name = "mnuHoaDonPhieuNhap";
            mnuHoaDonPhieuNhap.Size = new Size(279, 32);
            mnuHoaDonPhieuNhap.Text = "Chi tiết phiếu nhập";
            mnuHoaDonPhieuNhap.Click += mnuHoaDonPhieuNhap_Click;
            // 
            // mnuMaVoucher
            // 
            mnuMaVoucher.Name = "mnuMaVoucher";
            mnuMaVoucher.Size = new Size(279, 32);
            mnuMaVoucher.Text = "Mã voucher";
            mnuMaVoucher.Click += mnuMaVoucher_Click;
            // 
            // mnuBaoCaoThongKe
            // 
            mnuBaoCaoThongKe.DropDownItems.AddRange(new ToolStripItem[] { mnuThongKeMonAn, mnuThongKeDoanhThu, mnuThongKePhieuNhap });
            mnuBaoCaoThongKe.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mnuBaoCaoThongKe.ForeColor = Color.White;
            mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            mnuBaoCaoThongKe.Size = new Size(209, 32);
            mnuBaoCaoThongKe.Text = "Báo cáo - Thống kê";
            // 
            // mnuThongKeMonAn
            // 
            mnuThongKeMonAn.Name = "mnuThongKeMonAn";
            mnuThongKeMonAn.Size = new Size(298, 32);
            mnuThongKeMonAn.Text = "Thống kê món ăn ";
            mnuThongKeMonAn.Click += mnuThongKeMonAn_Click;
            // 
            // mnuThongKeDoanhThu
            // 
            mnuThongKeDoanhThu.Name = "mnuThongKeDoanhThu";
            mnuThongKeDoanhThu.Size = new Size(298, 32);
            mnuThongKeDoanhThu.Text = "Thống kê doanh thu";
            mnuThongKeDoanhThu.Click += mnuThongKeDoanhThu_Click;
            // 
            // mnuThongKePhieuNhap
            // 
            mnuThongKePhieuNhap.Name = "mnuThongKePhieuNhap";
            mnuThongKePhieuNhap.Size = new Size(298, 32);
            mnuThongKePhieuNhap.Text = "Thống kê phiếu nhập";
            mnuThongKePhieuNhap.Click += mnuThongKePhieuNhap_Click;
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuHuongDanSuDung, mnuThongTinPhanMem, mnuMenu, mnuLienHeQuanLy });
            mnuTroGiup.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mnuTroGiup.ForeColor = Color.White;
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(105, 32);
            mnuTroGiup.Text = "Trợ giúp";
            // 
            // mnuHuongDanSuDung
            // 
            mnuHuongDanSuDung.Name = "mnuHuongDanSuDung";
            mnuHuongDanSuDung.Size = new Size(296, 32);
            mnuHuongDanSuDung.Text = "Hướng dẫn sử dụng";
            mnuHuongDanSuDung.Click += mnuHuongDanSuDung_Click;
            // 
            // mnuThongTinPhanMem
            // 
            mnuThongTinPhanMem.Name = "mnuThongTinPhanMem";
            mnuThongTinPhanMem.Size = new Size(296, 32);
            mnuThongTinPhanMem.Text = "Thông tin phần mềm";
            mnuThongTinPhanMem.Click += mnuThongTinPhanMem_Click;
            // 
            // mnuMenu
            // 
            mnuMenu.Name = "mnuMenu";
            mnuMenu.Size = new Size(296, 32);
            mnuMenu.Text = "Menu";
            mnuMenu.Click += mnuMenu_Click;
            // 
            // mnuLienHeQuanLy
            // 
            mnuLienHeQuanLy.Name = "mnuLienHeQuanLy";
            mnuLienHeQuanLy.Size = new Size(296, 32);
            mnuLienHeQuanLy.Text = "Liên hệ quản lý ";
            mnuLienHeQuanLy.Click += mnuLienHeQuanLy_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai, toolStripStatusLabel2, toolStripStatusLabel1, lblLienKet });
            statusStrip1.Location = new Point(0, 481);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 22, 0);
            statusStrip1.Size = new Size(1330, 29);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrangThai.ForeColor = Color.Black;
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(142, 23);
            lblTrangThai.Text = "Chưa đăng nhập";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(0, 23);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(1061, 23);
            toolStripStatusLabel1.Spring = true;
            // 
            // lblLienKet
            // 
            lblLienKet.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLienKet.IsLink = true;
            lblLienKet.Name = "lblLienKet";
            lblLienKet.Size = new Size(104, 23);
            lblLienKet.Text = "© 2026 FIT ";
            lblLienKet.Click += lblLienKet_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1330, 510);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            IsMdiContainer = true;
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 4, 5, 4);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Quán Ăn ";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            KeyDown += frmMain_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuLoaiMonAn;
        private ToolStripMenuItem mnuMonAn;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuBaoCaoThongKe;
        private ToolStripMenuItem mnuThongKeMonAn;
        private ToolStripMenuItem mnuThongKeDoanhThu;
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuHuongDanSuDung;
        private ToolStripMenuItem mnuThongTinPhanMem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel lblLienKet;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSeparator thoátToolStripMenuItem;
        private ToolStripMenuItem mnuThoat;
        private ToolStripSeparator kháchHàngToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem mnuHoaDon;
        private ToolStripMenuItem mnuDatBan;
        private ToolStripMenuItem mnuNguyenLieu;
        private ToolStripMenuItem mnuCongThuc;
        private ToolStripMenuItem mnuNhaCungCap;
        private ToolStripMenuItem mnuPhieuNhap;
        private ToolStripMenuItem mnuHoaDonPhieuNhap;
        private ToolStripMenuItem mnuThongKePhieuNhap;
        private ToolStripMenuItem mnuMenu;
        private ToolStripMenuItem mnuLienHeQuanLy;
        private ToolStripMenuItem mnuHoaDonChiTiet;
        private ToolStripMenuItem mnuManHinhOrder;
        private ToolStripMenuItem mnuMaVoucher;
        private ToolStripMenuItem mnuTichHopAI;
    }
}