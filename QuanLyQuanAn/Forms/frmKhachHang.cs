using ClosedXML.Excel;
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
    public partial class frmKhachHang : Form
    {
        QLQADbcontext context = new QLQADbcontext(); // Khởi tạo biến ngữ cảnh CSDL
        bool XuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không?
        int id; // Lấy mã khách hàng (dùng cho Sửa và Xóa)

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            HienThiDuLieuLenLuoi(); // Gọi hàm load tối ưu
        }

        // TỐI ƯU: GỘP CHUNG HÀM LOAD DỮ LIỆU VÀ TÌM KIẾM
        private void HienThiDuLieuLenLuoi(string tuKhoa = "")
        {
            try
            {
                context.ChangeTracker.Clear(); // Xóa cache, lấy data mới nhất

                var query = context.KhachHang.AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(kh => kh.HoVaTen.ToLower().Contains(tuKhoa) || kh.DienThoai.Contains(tuKhoa));
                }

                // Sắp xếp khách hàng mới nhất lên đầu
                var kh = query.OrderBy(k => k.ID).ToList();

                if (kh.Count == 0 && !string.IsNullOrWhiteSpace(tuKhoa))
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi(""); // Trả về toàn bộ danh sách
                    return;
                }

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = kh;

                txtHoVaTen.DataBindings.Clear();
                txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);

                txtDienThoai.DataBindings.Clear();
                txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);

                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

                dataGridView.DataSource = bindingSource;
                DinhDangLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangLuoi()
        {
            if (dataGridView.Columns.Count >= 4)
            {
                dataGridView.Columns[0].DataPropertyName = "ID";
                dataGridView.Columns[1].DataPropertyName = "HoVaTen";
                dataGridView.Columns[2].DataPropertyName = "DienThoai";
                dataGridView.Columns[3].DataPropertyName = "DiaChi";

                dataGridView.Columns[0].HeaderText = "Mã KH";
                dataGridView.Columns[1].HeaderText = "Họ và Tên";
                dataGridView.Columns[2].HeaderText = "Số điện thoại";
                dataGridView.Columns[3].HeaderText = "Địa chỉ";
            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtHoVaTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            XuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            txtHoVaTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            if (MessageBox.Show("Xác nhận xóa khách hàng " + txtHoVaTen.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    KhachHang kh = context.KhachHang.Find(id);
                    if (kh != null)
                    {
                        context.KhachHang.Remove(kh);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDuLieuLenLuoi();
                }
                catch (Exception)
                {
                    // TỐI ƯU: Bẫy lỗi không cho xóa khách hàng đã có hóa đơn
                    MessageBox.Show("Không thể xóa khách hàng này vì đã có dữ liệu Hóa đơn hoặc Đặt bàn liên quan!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoVaTen.Text.Trim();
            string sdt = txtDienThoai.Text.Trim();

            // TỐI ƯU: Ràng buộc nhập liệu chặt chẽ
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(sdt) || sdt.Length < 10)
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại hợp lệ (từ 10 số trở lên)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            try
            {
                // TỐI ƯU: Kiểm tra trùng lặp Số điện thoại (Chỉ kiểm tra những khách khác ID hiện tại nếu đang sửa)
                bool trungSDT = XuLyThem ? context.KhachHang.Any(k => k.DienThoai == sdt)
                                         : context.KhachHang.Any(k => k.DienThoai == sdt && k.ID != id);
                if (trungSDT)
                {
                    MessageBox.Show("Số điện thoại này đã tồn tại trong hệ thống! Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDienThoai.Focus();
                    return;
                }

                if (XuLyThem)
                {
                    KhachHang kh = new KhachHang();
                    kh.HoVaTen = hoTen;
                    kh.DienThoai = sdt;
                    kh.DiaChi = txtDiaChi.Text.Trim();
                    context.KhachHang.Add(kh);
                }
                else
                {
                    KhachHang kh = context.KhachHang.Find(id);
                    if (kh != null)
                    {
                        kh.HoVaTen = hoTen;
                        kh.DienThoai = sdt;
                        kh.DiaChi = txtDiaChi.Text.Trim();
                        context.KhachHang.Update(kh);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu thông tin khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                HienThiDuLieuLenLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            HienThiDuLieuLenLuoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtHoVaTen.Text.Trim();
            HienThiDuLieuLenLuoi(tuKhoa);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        bool firstRow = true;
                        string readRange = "1:1";

                        foreach (IXLRow row in worksheet.RowsUsed())
                        {
                            if (firstRow)
                            {
                                readRange = string.Format("{0}:{1}", 1, row.LastCellUsed().Address.ColumnNumber);
                                foreach (IXLCell cell in row.Cells(readRange))
                                    table.Columns.Add(cell.Value.ToString().Trim());
                                firstRow = false;
                            }
                            else
                            {
                                table.Rows.Add();
                                int cellIndex = 0;
                                foreach (IXLCell cell in row.Cells(readRange))
                                {
                                    table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                                    cellIndex++;
                                }
                            }
                        }

                        if (table.Rows.Count > 0)
                        {
                            int demThanhCong = 0;
                            foreach (DataRow r in table.Rows)
                            {
                                string sdtExcel = r["DienThoai"].ToString().Trim();

                                // TỐI ƯU: Kiểm tra trước khi nạp để chống nạp trùng khách hàng cũ
                                if (!context.KhachHang.Any(k => k.DienThoai == sdtExcel))
                                {
                                    KhachHang kh = new KhachHang
                                    {
                                        HoVaTen = r["HoVaTen"].ToString().Trim(),
                                        DienThoai = sdtExcel,
                                        DiaChi = r["DiaChi"].ToString().Trim()
                                    };
                                    context.KhachHang.Add(kh);
                                    demThanhCong++;
                                }
                            }
                            context.SaveChanges();

                            MessageBox.Show($"Đã nạp thành công {demThanhCong} khách hàng mới.\n(Bỏ qua các số điện thoại đã tồn tại)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDuLieuLenLuoi();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi nạp Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất danh sách khách hàng ra Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = "DanhSachKhachHang_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("HoVaTen", typeof(string)),
                        new DataColumn("DienThoai", typeof(string)),
                        new DataColumn("DiaChi", typeof(string))
                    });

                    // Lấy dữ liệu mới nhất
                    var danhSach = context.KhachHang.OrderBy(k => k.ID).ToList();
                    foreach (var kh in danhSach)
                    {
                        table.Rows.Add(kh.ID, kh.HoVaTen, kh.DienThoai, kh.DiaChi);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "KhachHang");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn phím không phải là số
            }
        }
    }
}