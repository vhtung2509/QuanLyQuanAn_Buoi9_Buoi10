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
    public partial class frmChiTiet_PhieuNhap : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        int id;
        BindingList<DanhSachPhieuNhap_ChiTiet> phieuNhapChiTiet = new BindingList<DanhSachPhieuNhap_ChiTiet>();
        bool CoThayDoiChuaLuu = false;

        System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
        PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

        public frmChiTiet_PhieuNhap(int maPhieuNhap = 0)
        {
            InitializeComponent();
            id = maPhieuNhap;
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            this.FormClosing += FrmChiTiet_PhieuNhap_FormClosing;
        }

        #region Load ComboBox - Tối ưu để né lỗi NULL cột phụ
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVienLap.DataSource = context.NhanVien.Select(x => new { x.ID, x.HoVaTen }).ToList();
            cboNhanVienLap.ValueMember = "ID";
            cboNhanVienLap.DisplayMember = "HoVaTen";
            cboNhanVienLap.SelectedIndex = -1;
        }
        public void LayNhaCungCapVaoComboBox()
        {
            cboNhaCungCap.DataSource = context.NhaCungCap.Select(x => new { x.ID, x.TenNCC }).ToList();
            cboNhaCungCap.ValueMember = "ID";
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.SelectedIndex = -1;
        }
        public void LayNguyenLieuVaoComboBox()
        {
            cboNguyenLieu.DataSource = context.NguyenLieu.Select(x => new { x.ID, x.TenNguyenLieu }).ToList();
            cboNguyenLieu.ValueMember = "ID";
            cboNguyenLieu.DisplayMember = "TenNguyenLieu";
            cboNguyenLieu.SelectedIndex = -1;
        }
        public void LayDonViTinhVaoComboBox()
        {
            cboDonViTinh.Items.Clear();
            cboDonViTinh.Items.AddRange(new string[] { "kg", "gram", "lít", "ml", "hộp", "thùng", "gói", "chai", "bó", "ổ", "quả" });
        }
        #endregion

        private void frmChiTiet_PhieuNhap_Load(object? sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayNhaCungCapVaoComboBox();
            LayNguyenLieuVaoComboBox();
            LayDonViTinhVaoComboBox();

            cboNguyenLieu.SelectedIndexChanged += (s, ev) =>
            {
                if (cboNguyenLieu.SelectedValue is int maNL)
                {
                    var nl = context.NguyenLieu.Find(maNL);
                    if (nl != null) cboDonViTinh.Text = nl.DonViTinh ?? "";
                }
            };

            dataGridView.AutoGenerateColumns = false;

            if (id != 0)
            {
                var phieuNhap = context.PhieuNhap.Find(id);
                if (phieuNhap != null)
                {
                    cboNhanVienLap.SelectedValue = phieuNhap.NhanVienID ?? 0;
                    cboNhaCungCap.SelectedValue = phieuNhap.NhaCungCapID ?? 0;
                    dtpNgayNhapHang.Value = phieuNhap.NgayNhap ?? DateTime.Now;

                    // FIX CHỐT: Select trước khi ToList để ép kiểu an toàn ngay từ SQL
                    var ct = context.ChiTiet_PhieuNhap
                        .Where(r => r.PhieuNhapID == id)
                        .Select(r => new DanhSachPhieuNhap_ChiTiet
                        {
                            ID = r.ID,
                            PhieuNhapID = r.PhieuNhapID ?? 0,
                            NguyenLieuID = r.NguyenLieuID ?? 0,
                            NguyenLieu = r.NguyenLieuNavigation.TenNguyenLieu ?? "",
                            DonViTinh = r.NguyenLieuNavigation.DonViTinh ?? "",
                            SoLuong = (int)(r.SoLuong ?? 0),
                            DonGia = (int)(r.DonGia ?? 0),
                            ThanhTien = (int)((r.SoLuong ?? 0) * (double)(r.DonGia ?? 0))
                        }).ToList();

                    phieuNhapChiTiet = new BindingList<DanhSachPhieuNhap_ChiTiet>(ct);
                }
            }

            dataGridView.DataSource = phieuNhapChiTiet;
            CoThayDoiChuaLuu = false;
        }

        private void btnXacNhanMua_Click(object? sender, EventArgs e)
        {
            if (cboNguyenLieu.SelectedIndex == -1 || numSoLuong.Value <= 0) return;

            int maNL = Convert.ToInt32(cboNguyenLieu.SelectedValue);
            var itemExisted = phieuNhapChiTiet.FirstOrDefault(x => x.NguyenLieuID == maNL);

            if (itemExisted != null)
            {
                itemExisted.SoLuong += (int)numSoLuong.Value;
                itemExisted.DonGia = (int)numDonGia.Value;
                itemExisted.ThanhTien = itemExisted.SoLuong * itemExisted.DonGia;
                phieuNhapChiTiet.ResetBindings();
            }
            else
            {
                phieuNhapChiTiet.Add(new DanhSachPhieuNhap_ChiTiet
                {
                    ID = 0,
                    PhieuNhapID = id,
                    NguyenLieuID = maNL,
                    NguyenLieu = cboNguyenLieu.Text ?? "",
                    DonViTinh = cboDonViTinh.Text ?? "",
                    SoLuong = (int)numSoLuong.Value,
                    DonGia = (int)numDonGia.Value,
                    ThanhTien = (int)(numSoLuong.Value * numDonGia.Value)
                });
            }
            CoThayDoiChuaLuu = true;
        }

        private void btnLuuPhieuNhap_Click(object? sender, EventArgs e)
        {
            if (phieuNhapChiTiet.Count == 0)
            {
                MessageBox.Show("Phiếu nhập chưa có nguyên liệu nào! Vui lòng thêm ít nhất 1 nguyên liệu trước khi lưu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (cboNhanVienLap.SelectedValue == null || cboNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên và nhà cung cấp!");
                    return;
                }

                if (id != 0)
                {
                    var pn = context.PhieuNhap.Find(id);
                    if (pn != null)
                    {
                        pn.NhanVienID = Convert.ToInt32(cboNhanVienLap.SelectedValue);
                        pn.NhaCungCapID = Convert.ToInt32(cboNhaCungCap.SelectedValue);
                        pn.NgayNhap = dtpNgayNhapHang.Value;
                    }

                    var old = context.ChiTiet_PhieuNhap.Where(r => r.PhieuNhapID == id).ToList();
                    context.ChiTiet_PhieuNhap.RemoveRange(old);
                    context.SaveChanges();
                }
                else
                {
                    PhieuNhap pn = new PhieuNhap
                    {
                        NhanVienID = Convert.ToInt32(cboNhanVienLap.SelectedValue),
                        NhaCungCapID = Convert.ToInt32(cboNhaCungCap.SelectedValue),
                        NgayNhap = dtpNgayNhapHang.Value
                    };
                    context.PhieuNhap.Add(pn);
                    context.SaveChanges();
                    id = pn.ID;
                }

                foreach (var item in phieuNhapChiTiet)
                {
                    context.ChiTiet_PhieuNhap.Add(new ChiTiet_PhieuNhap
                    {
                        PhieuNhapID = id,
                        NguyenLieuID = item.NguyenLieuID,
                        SoLuong = item.SoLuong,
                        DonGia = (decimal)item.DonGia
                    });
                }

                context.SaveChanges();
                CoThayDoiChuaLuu = false;
                MessageBox.Show("Lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FrmChiTiet_PhieuNhap_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (CoThayDoiChuaLuu && MessageBox.Show("Chưa lưu, thoát?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object? sender, EventArgs e) { this.Close(); }

        private void btnHuyBo_Click(object? sender, EventArgs e) { frmChiTiet_PhieuNhap_Load(sender, e); }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Times New Roman", 18, FontStyle.Bold);
            Font fontBold = new Font("Times New Roman", 12, FontStyle.Bold);
            Font fontRegular = new Font("Times New Roman", 12, FontStyle.Regular);
            Brush brush = Brushes.Black;

            int y = 50, leftMargin = 50;
            g.DrawString("PHIẾU NHẬP HÀNG", fontTitle, brush, new PointF(300, y));
            y += 40;

            g.DrawString($"Ngày nhập: {dtpNgayNhapHang.Value.ToString("dd/MM/yyyy")}", fontRegular, brush, new PointF(leftMargin, y));
            y += 30;
            g.DrawString($"Nhân viên lập: {cboNhanVienLap.Text}", fontRegular, brush, new PointF(leftMargin, y));
            y += 30;
            g.DrawString($"Nhà cung cấp: {cboNhaCungCap.Text}", fontRegular, brush, new PointF(leftMargin, y));
            y += 40;

            g.DrawString("STT", fontBold, brush, new PointF(leftMargin, y));
            g.DrawString("Nguyên liệu", fontBold, brush, new PointF(leftMargin + 50, y));
            g.DrawString("ĐVT", fontBold, brush, new PointF(leftMargin + 250, y));
            g.DrawString("SL", fontBold, brush, new PointF(leftMargin + 350, y));
            g.DrawString("Đơn giá", fontBold, brush, new PointF(leftMargin + 450, y));
            g.DrawString("Thành tiền", fontBold, brush, new PointF(leftMargin + 550, y));
            y += 30;
            g.DrawLine(new Pen(Color.Black), leftMargin, y, 750, y);
            y += 10;

            int stt = 1;
            long tongTien = 0;
            foreach (var item in phieuNhapChiTiet)
            {
                g.DrawString(stt.ToString(), fontRegular, brush, new PointF(leftMargin, y));
                g.DrawString(item.NguyenLieu, fontRegular, brush, new PointF(leftMargin + 50, y));
                g.DrawString(item.DonViTinh, fontRegular, brush, new PointF(leftMargin + 250, y));
                g.DrawString(item.SoLuong.ToString(), fontRegular, brush, new PointF(leftMargin + 350, y));
                g.DrawString(item.DonGia.ToString("N0"), fontRegular, brush, new PointF(leftMargin + 450, y));
                g.DrawString(item.ThanhTien.ToString("N0"), fontRegular, brush, new PointF(leftMargin + 550, y));

                tongTien += item.ThanhTien;
                stt++;
                y += 30;
            }

            y += 10;
            g.DrawLine(new Pen(Color.Black), leftMargin, y, 750, y);
            y += 20;
            g.DrawString($"Tổng cộng: {tongTien.ToString("N0")} VNĐ", fontBold, brush, new PointF(leftMargin + 450, y));
        }

        private void btnInPhieuNhap_Click(object sender, EventArgs e)
        {
            if (phieuNhapChiTiet.Count == 0) return;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}