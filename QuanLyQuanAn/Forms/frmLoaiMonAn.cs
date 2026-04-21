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
using ClosedXML.Excel;

namespace QuanLyQuanAn.Forms
{
    public partial class frmLoaiMonAn : Form
    {
        QLQADbcontext context = new QLQADbcontext();
        bool xuLyThem = false;
        int id;

        public frmLoaiMonAn()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuyBo.Enabled = giaTri;
            txtTenLoai.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        private void frmLoaiMonAn_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadDanhSachLoaiMonAn();
        }

        // TỐI ƯU 1: Tách hàm Load dữ liệu riêng cho code sạch đẹp
        private void LoadDanhSachLoaiMonAn()
        {
            try
            {
                context.ChangeTracker.Clear(); // Xóa cache để luôn lấy dữ liệu mới nhất
                var lma = context.LoaiMonAn.ToList();

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = lma;

                txtTenLoai.DataBindings.Clear();
                txtTenLoai.DataBindings.Add("Text", bindingSource, "TenLoai", false, DataSourceUpdateMode.Never);

                dataGridView.DataSource = bindingSource;
                DinhDangLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void DinhDangLuoi()
        {
            if (dataGridView.Columns.Count >= 2)
            {
                dataGridView.Columns[0].DataPropertyName = "ID";
                dataGridView.Columns[1].DataPropertyName = "TenLoai";

                dataGridView.Columns[0].HeaderText = "Mã Loại";
                dataGridView.Columns[1].HeaderText = "Tên Loại Món Ăn";
            }
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtTenLoai.Clear();
            txtTenLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
            txtTenLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            string tenLoai = txtTenLoai.Text;

            if (MessageBox.Show("Xác nhận xóa loại món ăn '" + tenLoai + "'?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // TỐI ƯU 2: Bọc Try-Catch để chống văng phần mềm khi loại món ăn đang được sử dụng
                try
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
                    LoaiMonAn lma = context.LoaiMonAn.Find(id);

                    if (lma != null)
                    {
                        context.LoaiMonAn.Remove(lma);
                        context.SaveChanges();
                        MessageBox.Show("Đã xóa loại món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LoadDanhSachLoaiMonAn();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa Loại món ăn này vì đang có Món ăn thuộc loại này trong thực đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadDanhSachLoaiMonAn();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenMoi = txtTenLoai.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenMoi))
            {
                MessageBox.Show("Vui lòng nhập tên loại món ăn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoai.Focus();
                return;
            }

            try
            {
                // TỐI ƯU 3: Ràng buộc không cho nhập trùng tên Loại Món Ăn
                bool trungTen = xuLyThem ? context.LoaiMonAn.Any(l => l.TenLoai.ToLower() == tenMoi.ToLower())
                                         : context.LoaiMonAn.Any(l => l.TenLoai.ToLower() == tenMoi.ToLower() && l.ID != id);
                if (trungTen)
                {
                    MessageBox.Show("Tên loại món ăn này đã tồn tại! Vui lòng nhập tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenLoai.Focus();
                    return;
                }

                if (xuLyThem)
                {
                    LoaiMonAn lma = new LoaiMonAn();
                    lma.TenLoai = tenMoi;
                    context.LoaiMonAn.Add(lma);
                }
                else
                {
                    LoaiMonAn lma = context.LoaiMonAn.Find(id);
                    if (lma != null)
                    {
                        lma.TenLoai = tenMoi;
                        context.LoaiMonAn.Update(lma);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Lưu loại món ăn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                LoadDanhSachLoaiMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                string tenExcel = table.Columns.Contains("TenLoai") ? r["TenLoai"].ToString().Trim() : "";

                                // TỐI ƯU 4: Chống nạp rỗng và chống nạp trùng tên loại từ file Excel
                                if (!string.IsNullOrWhiteSpace(tenExcel) && !context.LoaiMonAn.Any(l => l.TenLoai.ToLower() == tenExcel.ToLower()))
                                {
                                    LoaiMonAn lma = new LoaiMonAn();
                                    lma.TenLoai = tenExcel;
                                    context.LoaiMonAn.Add(lma);
                                    demThanhCong++;
                                }
                            }
                            context.SaveChanges();

                            MessageBox.Show($"Đã nạp thành công {demThanhCong} loại món ăn mới.\n(Bỏ qua các loại đã tồn tại hoặc bị rỗng)", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDanhSachLoaiMonAn();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nhập Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            saveFileDialog.Title = "Xuất danh sách loại món ăn ra Excel";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.FileName = "DanhSachLoaiMonAn_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
                        new DataColumn("ID", typeof(int)),
                        new DataColumn("TenLoai", typeof(string))
                    });

                    var danhSach = context.LoaiMonAn.ToList();
                    foreach (var lma in danhSach)
                    {
                        table.Rows.Add(lma.ID, lma.TenLoai);
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "LoaiMonAn");
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
    }
}