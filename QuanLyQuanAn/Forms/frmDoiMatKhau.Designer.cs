namespace QuanLyQuanAn.Forms
{
    partial class frmDoiMatKhau
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMatKhauMoi = new TextBox();
            txtMatKhauCu = new TextBox();
            txtXacNhan = new TextBox();
            groupBox1 = new GroupBox();
            btnHienThi = new Button();
            btnHuyBo = new Button();
            btnLuu = new Button();
            btnThoat = new Button();
            label4 = new Label();
            panel1 = new Panel();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 71);
            label1.Name = "label1";
            label1.Size = new Size(139, 23);
            label1.TabIndex = 0;
            label1.Text = "Mật khẩu cũ (*):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 144);
            label2.Name = "label2";
            label2.Size = new Size(153, 23);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu mới (*):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 213);
            label3.Name = "label3";
            label3.Size = new Size(193, 23);
            label3.TabIndex = 2;
            label3.Text = "Xác nhận mật khẩu (*):";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(254, 137);
            txtMatKhauMoi.Margin = new Padding(3, 4, 3, 4);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(194, 30);
            txtMatKhauMoi.TabIndex = 3;
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(254, 64);
            txtMatKhauCu.Margin = new Padding(3, 4, 3, 4);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(195, 30);
            txtMatKhauCu.TabIndex = 4;
            // 
            // txtXacNhan
            // 
            txtXacNhan.Location = new Point(254, 206);
            txtXacNhan.Margin = new Padding(3, 4, 3, 4);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.Size = new Size(195, 30);
            txtXacNhan.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnHienThi);
            groupBox1.Controls.Add(btnHuyBo);
            groupBox1.Controls.Add(btnLuu);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtXacNhan);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMatKhauMoi);
            groupBox1.Controls.Add(txtMatKhauCu);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 128);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(812, 344);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin mật khẩu";
            // 
            // btnHienThi
            // 
            btnHienThi.BackColor = Color.MediumBlue;
            btnHienThi.FlatStyle = FlatStyle.Flat;
            btnHienThi.ForeColor = Color.White;
            btnHienThi.Location = new Point(122, 275);
            btnHienThi.Margin = new Padding(3, 4, 3, 4);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(94, 35);
            btnHienThi.TabIndex = 9;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = false;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.Crimson;
            btnHuyBo.FlatStyle = FlatStyle.Flat;
            btnHuyBo.ForeColor = Color.White;
            btnHuyBo.Location = new Point(240, 275);
            btnHuyBo.Margin = new Padding(3, 4, 3, 4);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(94, 35);
            btnHuyBo.TabIndex = 8;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.MediumSeaGreen;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(6, 275);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 35);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Crimson;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(355, 275);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 35);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(812, 68);
            label4.TabIndex = 7;
            label4.Text = "Đổi Mật Khẩu";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 15);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(812, 68);
            panel1.TabIndex = 7;
            // 
            // frmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 487);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmDoiMatKhau_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMatKhauMoi;
        private TextBox txtMatKhauCu;
        private TextBox txtXacNhan;
        private GroupBox groupBox1;
        private Button btnHienThi;
        private Button btnHuyBo;
        private Button btnLuu;
        private Button btnThoat;
        private Label label4;
        private Panel panel1;
    }
}