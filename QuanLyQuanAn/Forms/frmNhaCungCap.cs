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
    public partial class frmNhaCungCap : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        bool XuLyThem = false;
        int idNCC;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;

            txtNhaCungCap.Enabled = giaTri;
            txtSoDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            HienThiDuLieuLenLuoi(); // Đã chuyển sang dùng hàm gộp tối ưu
        }

        // =========================================================
        // TỐI ƯU 1: GỘP CHUNG HÀM LOAD DỮ LIỆU VÀ TÌM KIẾM
        // =========================================================
        private void HienThiDuLieuLenLuoi(string tuKhoa = "")
        {
            try
            {
                context.ChangeTracker.Clear();
                var query = context.NhaCungCap.AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    tuKhoa = tuKhoa.ToLower();
                    query = query.Where(n => n.TenNCC.ToLower().Contains(tuKhoa) || n.SoDienThoai.Contains(tuKhoa));
                }

                // Sắp xếp nhà cung cấp mới nhất lên đầu
                var dsNCC = query.OrderBy(n => n.ID).ToList();

                if (dsNCC.Count == 0 && !string.IsNullOrWhiteSpace(tuKhoa))
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThiDuLieuLenLuoi(""); // Trả về toàn bộ danh sách
                    return;
                }

                BindingSource bin = new BindingSource();
                bin.DataSource = dsNCC;

                // Đồng bộ tên TextBox
                txtNhaCungCap.DataBindings.Clear();
                txtNhaCungCap.DataBindings.Add("Text", bin, "TenNCC", false, DataSourceUpdateMode.Never);

                txtSoDienThoai.DataBindings.Clear();
                txtSoDienThoai.DataBindings.Add("Text", bin, "SoDienThoai", false, DataSourceUpdateMode.Never);

                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", bin, "DiaChi", false, DataSourceUpdateMode.Never);

                dataGridView.DataSource = bin;
                DinhDangLuoi();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load dữ liệu: " + ex.Message); }
        }

        private void DinhDangLuoi()
        {
            if (dataGridView.Columns.Count >= 4)
            {
                dataGridView.Columns[0].DataPropertyName = "ID";
                dataGridView.Columns[1].DataPropertyName = "TenNCC";
                dataGridView.Columns[2].DataPropertyName = "SoDienThoai";
                dataGridView.Columns[3].DataPropertyName = "DiaChi";

                dataGridView.Columns[0].Visible = true;
                dataGridView.Columns[0].HeaderText = "Mã NCC";
                dataGridView.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
                dataGridView.Columns[2].HeaderText = "Số Điện Thoại";
                dataGridView.Columns[3].HeaderText = "Địa Chỉ";
            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLyThem = true;
            BatTatChucNang(true);
            txtNhaCungCap.Clear();
            txtSoDienThoai.Clear();
            txtDiaChi.Clear();
            txtNhaCungCap.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            XuLyThem = false;
            BatTatChucNang(true);
            idNCC = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
            txtNhaCungCap.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string ten = txtNhaCungCap.Text;

            if (MessageBox.Show($"Xóa nhà cung cấp '{ten}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int idXoa = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                    var ncc = context.NhaCungCap.Find(idXoa);
                    if (ncc != null)
                    {
                        context.NhaCungCap.Remove(ncc);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    HienThiDuLieuLenLuoi();
                }
                catch
                {
                    // Cảnh báo nếu xóa nhà cung cấp đang có Phiếu nhập kho
                    MessageBox.Show("Không thể xóa Nhà cung cấp này vì đang có dữ liệu Phiếu nhập kho liên quan!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            HienThiDuLieuLenLuoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenNCC = txtNhaCungCap.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();

            // TỐI ƯU 2: Ràng buộc nhập liệu
            if (string.IsNullOrWhiteSpace(tenNCC))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhaCungCap.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(sdt) || sdt.Length < 10)
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại hợp lệ (từ 10 số trở lên)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            try
            {
                // Kiểm tra trùng lặp Số điện thoại
                bool trungSDT = XuLyThem ? context.NhaCungCap.Any(n => n.SoDienThoai == sdt)
                                         : context.NhaCungCap.Any(n => n.SoDienThoai == sdt && n.ID != idNCC);
                if (trungSDT)
                {
                    MessageBox.Show("Số điện thoại này đã tồn tại trong hệ thống! Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoDienThoai.Focus();
                    return;
                }

                if (XuLyThem)
                {
                    var nccMoi = new QuanLyQuanAn.Data.NhaCungCap
                    {
                        TenNCC = tenNCC,
                        SoDienThoai = sdt,
                        DiaChi = txtDiaChi.Text.Trim()
                    };
                    context.NhaCungCap.Add(nccMoi);
                }
                else
                {
                    var nccSua = context.NhaCungCap.Find(idNCC);
                    if (nccSua != null)
                    {
                        nccSua.TenNCC = tenNCC;
                        nccSua.SoDienThoai = sdt;
                        nccSua.DiaChi = txtDiaChi.Text.Trim();
                    }
                }
                context.SaveChanges();
                MessageBox.Show("Đã lưu dữ liệu nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                HienThiDuLieuLenLuoi();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu: " + ex.Message); }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rep = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rep == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // =========================================================
        // TỐI ƯU 3: CHUYỂN SANG DÙNG POP-UP TÌM KIẾM
        // =========================================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 160;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Tìm kiếm Nhà cung cấp";
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "Nhập tên hoặc số điện thoại cần tìm:" };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "Tìm kiếm", Left = 260, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    HienThiDuLieuLenLuoi(textBox.Text.Trim());
                }
            }
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
                                {
                                    table.Columns.Add(cell.Value.ToString().Trim());
                                }
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
                                string sdtExcel = r["SoDienThoai"].ToString().Trim();

                                // TỐI ƯU 4: Chống nạp trùng nhà cung cấp cũ từ file Excel
                                if (!context.NhaCungCap.Any(n => n.SoDienThoai == sdtExcel))
                                {
                                    QuanLyQuanAn.Data.NhaCungCap ncc = new QuanLyQuanAn.Data.NhaCungCap
                                    {
                                        TenNCC = r["TenNCC"].ToString(),
                                        SoDienThoai = sdtExcel,
                                        DiaChi = r["DiaChi"].ToString()
                                    };
                                    context.NhaCungCap.Add(ncc);
                                    demThanhCong++;
                                }
                            }
                            context.SaveChanges();

                            MessageBox.Show($"Đã nhập thành công {demThanhCong} nhà cung cấp.\n(Bỏ qua các số điện thoại đã tồn tại)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HienThiDuLieuLenLuoi();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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
            saveFileDialog.Title = "Xuất danh sách ra Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = "DanhSachNhaCungCap_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenNCC", typeof(string)),
                        new DataColumn("SoDienThoai", typeof(string)),
                        new DataColumn("DiaChi", typeof(string))
                    });

                    // Lấy dữ liệu mới nhất
                    var danhSach = context.NhaCungCap.OrderBy(n => n.ID).ToList();
                    foreach (var ncc in danhSach)
                    {
                        table.Rows.Add(ncc.ID, ncc.TenNCC, ncc.SoDienThoai, ncc.DiaChi);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhaCungCap");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        // =========================================================
        // CHỈ CHO PHÉP NHẬP SỐ VÀO Ô ĐIỆN THOẠI
        // =========================================================
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn phím không phải là số
            }
        }
    }
}