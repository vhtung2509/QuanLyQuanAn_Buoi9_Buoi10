namespace QuanLyQuanAn.Forms
{
    partial class frmChiTiet_PhieuNhap
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            cboDonViTinh = new ComboBox();
            label6 = new Label();
            numSoLuong = new NumericUpDown();
            label5 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NguyenLieu = new DataGridViewTextBoxColumn();
            DonViTinh = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            dtpNgayNhapHang = new DateTimePicker();
            label4 = new Label();
            cboNhaCungCap = new ComboBox();
            label3 = new Label();
            cboNguyenLieu = new ComboBox();
            label2 = new Label();
            cboNhanVienLap = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            numDonGia = new NumericUpDown();
            label7 = new Label();
            txtTongTien = new TextBox();
            btnLuuPhieuNhap = new Button();
            btnInPhieuNhap = new Button();
            btnXacNhanMua = new Button();
            btnHuyBo = new Button();
            btnThoat = new Button();
            panel1 = new Panel();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cboDonViTinh
            // 
            cboDonViTinh.FormattingEnabled = true;
            cboDonViTinh.Location = new Point(686, 167);
            cboDonViTinh.Margin = new Padding(4);
            cboDonViTinh.Name = "cboDonViTinh";
            cboDonViTinh.Size = new Size(248, 31);
            cboDonViTinh.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(494, 176);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(130, 23);
            label6.TabIndex = 10;
            label6.Text = "Đơn vị tính (*):";
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(686, 107);
            numSoLuong.Margin = new Padding(4);
            numSoLuong.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(249, 30);
            numSoLuong.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(494, 115);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(113, 23);
            label5.TabIndex = 8;
            label5.Text = "Số lượng (*):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(17, 325);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(1379, 248);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nguyên liệu nhập";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.DarkSlateGray;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, NguyenLieu, DonViTinh, SoLuong, DonGia, ThanhTien });
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new Point(4, 27);
            dataGridView.Margin = new Padding(4);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.DarkSlateGray;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1371, 217);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 32.08556F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // NguyenLieu
            // 
            NguyenLieu.DataPropertyName = "NguyenLieu";
            NguyenLieu.FillWeight = 113.582886F;
            NguyenLieu.HeaderText = "Nguyên liệu";
            NguyenLieu.MinimumWidth = 6;
            NguyenLieu.Name = "NguyenLieu";
            // 
            // DonViTinh
            // 
            DonViTinh.DataPropertyName = "DonViTinh";
            DonViTinh.FillWeight = 113.582886F;
            DonViTinh.HeaderText = "Đơn vị tính";
            DonViTinh.MinimumWidth = 6;
            DonViTinh.Name = "DonViTinh";
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.FillWeight = 113.582886F;
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.FillWeight = 113.582886F;
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            ThanhTien.FillWeight = 113.582886F;
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            // 
            // dtpNgayNhapHang
            // 
            dtpNgayNhapHang.CustomFormat = "dd/MM/yy";
            dtpNgayNhapHang.Format = DateTimePickerFormat.Short;
            dtpNgayNhapHang.Location = new Point(200, 109);
            dtpNgayNhapHang.Margin = new Padding(4);
            dtpNgayNhapHang.MaxDate = new DateTime(2026, 4, 5, 0, 0, 0, 0);
            dtpNgayNhapHang.MinDate = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            dtpNgayNhapHang.Name = "dtpNgayNhapHang";
            dtpNgayNhapHang.Size = new Size(150, 30);
            dtpNgayNhapHang.TabIndex = 7;
            dtpNgayNhapHang.Value = new DateTime(2026, 4, 5, 0, 0, 0, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 115);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(172, 23);
            label4.TabIndex = 6;
            label4.Text = "Ngày nhập hàng (*):";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(200, 167);
            cboNhaCungCap.Margin = new Padding(4);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(248, 31);
            cboNhaCungCap.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 176);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(149, 23);
            label3.TabIndex = 4;
            label3.Text = "Nhà cung cấp (*):";
            // 
            // cboNguyenLieu
            // 
            cboNguyenLieu.FormattingEnabled = true;
            cboNguyenLieu.Location = new Point(686, 50);
            cboNguyenLieu.Margin = new Padding(4);
            cboNguyenLieu.Name = "cboNguyenLieu";
            cboNguyenLieu.Size = new Size(248, 31);
            cboNguyenLieu.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(494, 58);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(181, 23);
            label2.TabIndex = 2;
            label2.Text = "Nguyên liệu nhập (*):";
            // 
            // cboNhanVienLap
            // 
            cboNhanVienLap.FormattingEnabled = true;
            cboNhanVienLap.Location = new Point(200, 50);
            cboNhanVienLap.Margin = new Padding(4);
            cboNhanVienLap.Name = "cboNhanVienLap";
            cboNhanVienLap.Size = new Size(248, 31);
            cboNhanVienLap.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 58);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(150, 23);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên lập (*):";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(numDonGia);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboDonViTinh);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numSoLuong);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dtpNgayNhapHang);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cboNhaCungCap);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboNguyenLieu);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cboNhanVienLap);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(17, 83);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(1379, 218);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(1125, 51);
            numDonGia.Margin = new Padding(4);
            numDonGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(159, 30);
            numDonGia.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(965, 58);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(149, 23);
            label7.TabIndex = 12;
            label7.Text = "Đơn giá nhập (*):";
            // 
            // txtTongTien
            // 
            txtTongTien.ForeColor = Color.Black;
            txtTongTien.Location = new Point(1126, 594);
            txtTongTien.Margin = new Padding(4);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(265, 30);
            txtTongTien.TabIndex = 4;
            // 
            // btnLuuPhieuNhap
            // 
            btnLuuPhieuNhap.BackColor = Color.MediumSeaGreen;
            btnLuuPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnLuuPhieuNhap.ForeColor = Color.White;
            btnLuuPhieuNhap.Location = new Point(21, 592);
            btnLuuPhieuNhap.Margin = new Padding(4);
            btnLuuPhieuNhap.Name = "btnLuuPhieuNhap";
            btnLuuPhieuNhap.Size = new Size(171, 34);
            btnLuuPhieuNhap.TabIndex = 5;
            btnLuuPhieuNhap.Text = "Lưu Phiếu Nhập";
            btnLuuPhieuNhap.UseVisualStyleBackColor = false;
            btnLuuPhieuNhap.Click += btnLuuPhieuNhap_Click;
            // 
            // btnInPhieuNhap
            // 
            btnInPhieuNhap.BackColor = Color.MediumSeaGreen;
            btnInPhieuNhap.FlatStyle = FlatStyle.Flat;
            btnInPhieuNhap.ForeColor = Color.White;
            btnInPhieuNhap.Location = new Point(217, 592);
            btnInPhieuNhap.Margin = new Padding(4);
            btnInPhieuNhap.Name = "btnInPhieuNhap";
            btnInPhieuNhap.Size = new Size(171, 34);
            btnInPhieuNhap.TabIndex = 6;
            btnInPhieuNhap.Text = "In Phiếu Nhập";
            btnInPhieuNhap.UseVisualStyleBackColor = false;
            btnInPhieuNhap.Click += btnInPhieuNhap_Click;
            // 
            // btnXacNhanMua
            // 
            btnXacNhanMua.BackColor = Color.SlateBlue;
            btnXacNhanMua.FlatStyle = FlatStyle.Flat;
            btnXacNhanMua.ForeColor = Color.White;
            btnXacNhanMua.Location = new Point(418, 592);
            btnXacNhanMua.Margin = new Padding(4);
            btnXacNhanMua.Name = "btnXacNhanMua";
            btnXacNhanMua.Size = new Size(171, 34);
            btnXacNhanMua.TabIndex = 7;
            btnXacNhanMua.Text = "Xác nhận mua";
            btnXacNhanMua.UseVisualStyleBackColor = false;
            btnXacNhanMua.Click += btnXacNhanMua_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.Crimson;
            btnHuyBo.FlatStyle = FlatStyle.Flat;
            btnHuyBo.ForeColor = Color.White;
            btnHuyBo.Location = new Point(617, 592);
            btnHuyBo.Margin = new Padding(4);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(171, 34);
            btnHuyBo.TabIndex = 8;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Crimson;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(824, 592);
            btnThoat.Margin = new Padding(4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(171, 34);
            btnThoat.TabIndex = 9;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label8);
            panel1.Location = new Point(17, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1379, 53);
            panel1.TabIndex = 10;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.WhiteSmoke;
            label8.Location = new Point(0, 0);
            label8.Name = "label8";
            label8.Size = new Size(1379, 53);
            label8.TabIndex = 0;
            label8.Text = "Chi Tiết Phiếu Nhập Hàng";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmChiTiet_PhieuNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1409, 659);
            Controls.Add(panel1);
            Controls.Add(btnThoat);
            Controls.Add(btnHuyBo);
            Controls.Add(btnXacNhanMua);
            Controls.Add(btnInPhieuNhap);
            Controls.Add(btnLuuPhieuNhap);
            Controls.Add(txtTongTien);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Margin = new Padding(4);
            Name = "frmChiTiet_PhieuNhap";
            Load += frmChiTiet_PhieuNhap_Load;
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cboDonViTinh;
        private Label label6;
        private NumericUpDown numSoLuong;
        private Label label5;
        private GroupBox groupBox2;
        private DateTimePicker dtpNgayNhapHang;
        private Label label4;
        private ComboBox cboNhaCungCap;
        private Label label3;
        private ComboBox cboNguyenLieu;
        private Label label2;
        private ComboBox cboNhanVienLap;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtTongTien;
        private Button btnLuuPhieuNhap;
        private Button btnInPhieuNhap;
        private NumericUpDown numDonGia;
        private Label label7;
        private Button btnXacNhanMua;
        private Button btnHuyBo;
        private Button btnThoat;
        private Panel panel1;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NguyenLieu;
        private DataGridViewTextBoxColumn DonViTinh;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn ThanhTien;
        private Label label8;
    }
}