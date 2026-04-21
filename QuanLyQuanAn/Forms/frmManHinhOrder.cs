using QuanLyQuanAn.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanAn.Forms
{
    public partial class frmManHinhOrder : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        bool isLoaded = false;

        // ==========================================
        // BỔ SUNG: BIẾN TOÀN CỤC LƯU THÔNG TIN GIẢM GIÁ
        // ==========================================
        decimal phanTramGiamGia = 0;
        string ghiChuKhuyenMai = "";

        public frmManHinhOrder()
        {
            InitializeComponent();
        }

        private void frmManHinhOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var dsBan = context.BanAn.ToList();
                cboBanAn.DataSource = dsBan;
                cboBanAn.DisplayMember = "TenBan";
                cboBanAn.ValueMember = "ID";
                cboBanAn.SelectedIndex = -1;

                LoadMenu(1);

                dataGridView.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                isLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int LayMaKhachVangLai()
        {
            var kh = context.KhachHang.FirstOrDefault(k => k.HoVaTen == "Khách vãng lai");
            if (kh == null)
            {
                kh = new KhachHang { HoVaTen = "Khách vãng lai", DienThoai = "0", DiaChi = "Tại quán" };
                context.KhachHang.Add(kh);
                context.SaveChanges();
            }
            return kh.ID;
        }

        private void cboBanAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded || cboBanAn.SelectedValue == null) return;

            try
            {
                int idBan = Convert.ToInt32(cboBanAn.SelectedValue);
                dataGridView.Rows.Clear();

                var ban = context.BanAn.Find(idBan);
                if (ban != null && (ban.TrangThai == "Có khách" || ban.TrangThai == "Đã đặt"))
                {
                    var hd = context.HoaDon.Where(h => h.BanAnID == idBan).OrderByDescending(h => h.ID).FirstOrDefault();
                    if (hd != null)
                    {
                        var chiTiets = context.HoaDon_ChiTiet.Where(ct => ct.HoaDonID == hd.ID).ToList();
                        foreach (var ct in chiTiets)
                        {
                            var mon = context.MonAn.Find(ct.MonAnID);
                            if (mon != null)
                            {
                                dataGridView.Rows.Add(mon.TenMon, ct.SoLuongBan, ct.DonGiaBan, ct.SoLuongBan * ct.DonGiaBan);
                            }
                        }
                    }
                }
                TinhTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatMon_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0 || (dataGridView.Rows.Count == 1 && dataGridView.Rows[0].IsNewRow))
            {
                MessageBox.Show("Chưa có món ăn nào để đặt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ketQuaLuu = LuuHoaDon("Có khách");
            if (ketQuaLuu > 0)
            {
                MessageBox.Show("Đã lưu Order thành công! Bàn đã chuyển sang trạng thái [Có khách].", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0 || (dataGridView.Rows.Count == 1 && dataGridView.Rows[0].IsNewRow))
            {
                if (cboBanAn.SelectedValue == null) return;
                int idBan = Convert.ToInt32(cboBanAn.SelectedValue);
                var ban = context.BanAn.Find(idBan);

                if (ban != null && (ban.TrangThai == "Có khách" || ban.TrangThai == "Đã đặt"))
                {
                    var hd = context.HoaDon.Where(h => h.BanAnID == idBan).OrderByDescending(h => h.ID).FirstOrDefault();
                    if (hd != null)
                    {
                        var chiTiets = context.HoaDon_ChiTiet.Where(ct => ct.HoaDonID == hd.ID).ToList();
                        context.HoaDon_ChiTiet.RemoveRange(chiTiets);
                        context.HoaDon.Remove(hd);
                        ban.TrangThai = "Trống";
                        context.SaveChanges();

                        MessageBox.Show("Đã hủy toàn bộ món ăn và dọn trống bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetGiaoDien();
                        return;
                    }
                }
                MessageBox.Show("Chưa có món ăn nào trong danh sách để thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult luaChon = MessageBox.Show(
                "Khách hàng thanh toán bằng phương thức nào?\n\n" +
                "- Bấm [Yes]: Chuyển khoản (Hiện mã QR)\n" +
                "- Bấm [No]: Tiền mặt (Lưu hóa đơn ngay)\n" +
                "- Bấm [Cancel]: Hủy bỏ thao tác",
                "Chọn phương thức thanh toán",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (luaChon == DialogResult.Cancel) return;

            if (luaChon == DialogResult.Yes)
            {
                string tongTienStr = txtTongTien.Text;
                using (frmThanhToanQR frmQR = new frmThanhToanQR(tongTienStr))
                {
                    if (frmQR.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Đã hủy quá trình thanh toán chuyển khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            int maHoaDonVuaLuu = LuuHoaDon("Trống");

            if (maHoaDonVuaLuu > 0)
            {
                TruKhoNguyenLieu(maHoaDonVuaLuu);
                MessageBox.Show("Thanh toán hoàn tất! Hệ thống sẽ xuất hóa đơn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(maHoaDonVuaLuu))
                {
                    chiTiet.ShowDialog();
                }

                ResetGiaoDien();
            }
        }

        // Tách hàm Reset để code gọn hơn
        private void ResetGiaoDien()
        {
            dataGridView.Rows.Clear();
            txtTongTien.Text = "0 VNĐ";
            txtVoucher.Clear();
            lblGiamGia.Text = "Giảm: 0%";
            phanTramGiamGia = 0;
            ghiChuKhuyenMai = "";
            cboBanAn.SelectedIndex = -1;
        }

        private int LuuHoaDon(string trangThaiBanSauKhiLuu)
        {
            if (cboBanAn.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thao tác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }

            try
            {
                int idBan = Convert.ToInt32(cboBanAn.SelectedValue);
                var ban = context.BanAn.Find(idBan);
                HoaDon hd = null;

                if (ban.TrangThai == "Có khách" || ban.TrangThai == "Đã đặt")
                {
                    hd = context.HoaDon.Where(h => h.BanAnID == idBan).OrderByDescending(h => h.ID).FirstOrDefault();
                }

                if (hd == null)
                {
                    hd = new HoaDon();
                    hd.BanAnID = idBan;
                    hd.NgayLap = DateTime.Now;
                    hd.NhanVienID = ThongTinDangNhap.ID;
                    hd.KhachHangID = LayMaKhachVangLai();
                    context.HoaDon.Add(hd);
                    context.SaveChanges();
                }

                // LƯU GHI CHÚ VOUCHER VÀO HÓA ĐƠN
                hd.GhiChuHoaDon = ghiChuKhuyenMai;

                var oldChiTiets = context.HoaDon_ChiTiet.Where(ct => ct.HoaDonID == hd.ID).ToList();
                context.HoaDon_ChiTiet.RemoveRange(oldChiTiets);

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells[0].Value != null && !row.IsNewRow)
                    {
                        string tenMon = row.Cells[0].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells[1].Value);
                        int donGia = Convert.ToInt32(row.Cells[2].Value);

                        var monAn = context.MonAn.FirstOrDefault(m => m.TenMon == tenMon);
                        if (monAn != null)
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                            ct.HoaDonID = hd.ID;
                            ct.MonAnID = monAn.ID;
                            ct.SoLuongBan = (short)soLuong;
                            ct.DonGiaBan = donGia;
                            context.HoaDon_ChiTiet.Add(ct);
                        }
                    }
                }

                ban.TrangThai = trangThaiBanSauKhiLuu;
                context.SaveChanges();

                return hd.ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void LoadMenu(int maLoaiMon)
        {
            try
            {
                flpDanhSachMon.Controls.Clear();
                context.ChangeTracker.Clear();

                var dsMonAn = context.MonAn.Where(m => m.LoaiMonAnID == maLoaiMon).ToList();
                foreach (var mon in dsMonAn)
                {
                    ThemMonAn(mon.TenMon, Convert.ToDecimal(mon.DonGia), mon.ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thực đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemMonAn(string tenMon, decimal donGia, int idMon)
        {
            ReaLTaiizor.Controls.CyberButton btn = new ReaLTaiizor.Controls.CyberButton();
            btn.TextButton = tenMon + "\n" + donGia.ToString("N0") + "đ";
            btn.ForeColor = Color.White;
            btn.Tag = idMon;
            btn.Size = new Size(140, 90);
            btn.Rounding = true;
            btn.ColorBackground = Color.FromArgb(52, 73, 94);
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.Click += (sender, e) =>
            {
                bool daCoTrongHoaDon = false;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == tenMon)
                    {
                        int slCu = Convert.ToInt32(row.Cells[1].Value);
                        int slMoi = slCu + 1;
                        row.Cells[1].Value = slMoi;
                        row.Cells[3].Value = slMoi * donGia;
                        daCoTrongHoaDon = true;
                        break;
                    }
                }

                if (!daCoTrongHoaDon)
                {
                    dataGridView.Rows.Add(tenMon, 1, donGia, donGia);
                }
                TinhTongTien();
            };
            flpDanhSachMon.Controls.Add(btn);
        }

        private void TinhTongTien()
        {
            decimal tongGoc = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    tongGoc += Convert.ToDecimal(row.Cells[3].Value);
                }
            }

            // TÍNH TOÁN TIỀN SAU GIẢM GIÁ
            decimal soTienGiam = tongGoc * phanTramGiamGia;
            decimal tongThanhToan = tongGoc - soTienGiam;

            txtTongTien.Text = tongThanhToan.ToString("N0") + " VNĐ";
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                dataGridView.Rows.Remove(dataGridView.CurrentRow);
                TinhTongTien();
            }
        }

        private void btnMonNuoc_Click(object sender, EventArgs e) { LoadMenu(1); }
        private void btnMonKho_Click(object sender, EventArgs e) { LoadMenu(2); }
        private void btnNuocGiaiKhat_Click(object sender, EventArgs e) { LoadMenu(3); }

        private void TruKhoNguyenLieu(int maHoaDon)
        {
            try
            {
                var chiTietHoaDon = context.HoaDon_ChiTiet.Where(ct => ct.HoaDonID == maHoaDon).ToList();
                foreach (var item in chiTietHoaDon)
                {
                    var congThucMonAn = context.CongThuc.Where(ct => ct.MonAnID == item.MonAnID).ToList();
                    foreach (var nguyenLieuCanDung in congThucMonAn)
                    {
                        int tongLuongTru = (int)(nguyenLieuCanDung.HamLuong * item.SoLuongBan);
                        var nl = context.NguyenLieu.Find(nguyenLieuCanDung.NguyenLieuID);
                        if (nl != null)
                        {
                            nl.SoLuongTon -= tongLuongTru;
                        }
                    }
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tự động trừ kho nguyên liệu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // SỰ KIỆN NÚT ÁP DỤNG VOUCHER
        // ==========================================
        private void btnApDung_Click(object sender, EventArgs e)
        {
            string ma = txtVoucher.Text.Trim().ToUpper();
            DateTime homNay = DateTime.Now;

            // Truy vấn Database soi mã Voucher
            var v = context.Vouchers.FirstOrDefault(x => x.MaVoucher == ma
                                            && x.TrangThai == true
                                            && homNay >= x.NgayBatDau
                                            && homNay <= x.NgayHetHan);

            if (v != null)
            {
                phanTramGiamGia = (decimal)v.PhanTramGiam / 100;
                ghiChuKhuyenMai = $"Voucher {v.MaVoucher} (-{v.PhanTramGiam}%)";

                lblGiamGia.Text = $"Giảm: {v.PhanTramGiam}%";
                MessageBox.Show($"Áp dụng thành công mã {v.MaVoucher}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                phanTramGiamGia = 0;
                ghiChuKhuyenMai = "";
                lblGiamGia.Text = "Giảm: 0%";
                MessageBox.Show("Mã voucher không hợp lệ, đã hết hạn hoặc đang bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVoucher.Clear();
            }

            // Cập nhật lại con số hiển thị
            TinhTongTien();
        }
    }
}