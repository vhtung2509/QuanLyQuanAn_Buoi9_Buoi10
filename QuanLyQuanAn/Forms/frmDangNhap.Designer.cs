namespace QuanLyQuanAn.Forms
{
    partial class frmDangNhap
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
            panel1 = new Panel();
            cyberGroupBox1 = new ReaLTaiizor.Controls.CyberGroupBox();
            pictureBox1 = new PictureBox();
            btnDangNhap = new ReaLTaiizor.Controls.HopeButton();
            txtMatKhau = new ReaLTaiizor.Controls.HopeTextBox();
            txtTenDangNhap = new ReaLTaiizor.Controls.HopeTextBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            btnHuyBo = new ReaLTaiizor.Controls.HopeButton();
            cbHienMatKhau = new CheckBox();
            panel1.SuspendLayout();
            cyberGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(cyberGroupBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(492, 539);
            panel1.TabIndex = 0;
            // 
            // cyberGroupBox1
            // 
            cyberGroupBox1.Alpha = 20;
            cyberGroupBox1.BackColor = Color.Transparent;
            cyberGroupBox1.Background = true;
            cyberGroupBox1.Background_WidthPen = 3F;
            cyberGroupBox1.BackgroundPen = true;
            cyberGroupBox1.ColorBackground = Color.DimGray;
            cyberGroupBox1.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            cyberGroupBox1.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            cyberGroupBox1.ColorBackground_Pen = Color.DimGray;
            cyberGroupBox1.ColorLighting = Color.FromArgb(29, 200, 238);
            cyberGroupBox1.ColorPen_1 = Color.FromArgb(37, 52, 68);
            cyberGroupBox1.ColorPen_2 = Color.FromArgb(41, 63, 86);
            cyberGroupBox1.Controls.Add(pictureBox1);
            cyberGroupBox1.CyberGroupBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            cyberGroupBox1.ForeColor = Color.FromArgb(245, 245, 245);
            cyberGroupBox1.Lighting = false;
            cyberGroupBox1.LinearGradient_Background = false;
            cyberGroupBox1.LinearGradientPen = false;
            cyberGroupBox1.Location = new Point(12, 69);
            cyberGroupBox1.Name = "cyberGroupBox1";
            cyberGroupBox1.PenWidth = 15;
            cyberGroupBox1.RGB = false;
            cyberGroupBox1.Rounding = true;
            cyberGroupBox1.RoundingInt = 60;
            cyberGroupBox1.Size = new Size(456, 433);
            cyberGroupBox1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            cyberGroupBox1.TabIndex = 2;
            cyberGroupBox1.Tag = "Cyber";
            cyberGroupBox1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            cyberGroupBox1.Timer_RGB = 300;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.DimGray;
            pictureBox1.Image = Properties.Resources.logologin;
            pictureBox1.Location = new Point(40, 74);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(377, 279);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BorderColor = Color.FromArgb(220, 223, 230);
            btnDangNhap.ButtonType = ReaLTaiizor.Util.HopeButtonType.Success;
            btnDangNhap.DangerColor = Color.FromArgb(245, 108, 108);
            btnDangNhap.DefaultColor = Color.FromArgb(255, 255, 255);
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnDangNhap.InfoColor = Color.FromArgb(144, 147, 153);
            btnDangNhap.Location = new Point(579, 468);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnDangNhap.Size = new Size(148, 50);
            btnDangNhap.SuccessColor = Color.MediumSeaGreen;
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.TextColor = Color.White;
            btnDangNhap.WarningColor = Color.FromArgb(230, 162, 60);
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = Color.White;
            txtMatKhau.BaseColor = Color.FromArgb(44, 55, 66);
            txtMatKhau.BorderColorA = Color.FromArgb(64, 158, 255);
            txtMatKhau.BorderColorB = Color.FromArgb(220, 223, 230);
            txtMatKhau.Font = new Font("Segoe UI", 12F);
            txtMatKhau.ForeColor = Color.FromArgb(48, 49, 51);
            txtMatKhau.Hint = "Mật khẩu";
            txtMatKhau.Location = new Point(579, 355);
            txtMatKhau.MaxLength = 32767;
            txtMatKhau.Multiline = false;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '\0';
            txtMatKhau.ScrollBars = ScrollBars.None;
            txtMatKhau.SelectedText = "";
            txtMatKhau.SelectionLength = 0;
            txtMatKhau.SelectionStart = 0;
            txtMatKhau.Size = new Size(328, 43);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.TabStop = false;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BackColor = Color.White;
            txtTenDangNhap.BaseColor = Color.FromArgb(44, 55, 66);
            txtTenDangNhap.BorderColorA = Color.FromArgb(64, 158, 255);
            txtTenDangNhap.BorderColorB = Color.FromArgb(220, 223, 230);
            txtTenDangNhap.Font = new Font("Segoe UI", 12F);
            txtTenDangNhap.ForeColor = Color.FromArgb(48, 49, 51);
            txtTenDangNhap.Hint = "Tên đăng nhập";
            txtTenDangNhap.Location = new Point(579, 289);
            txtTenDangNhap.MaxLength = 32767;
            txtTenDangNhap.Multiline = false;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PasswordChar = '\0';
            txtTenDangNhap.ScrollBars = ScrollBars.None;
            txtTenDangNhap.SelectedText = "";
            txtTenDangNhap.SelectionLength = 0;
            txtTenDangNhap.SelectionStart = 0;
            txtTenDangNhap.Size = new Size(328, 43);
            txtTenDangNhap.TabIndex = 2;
            txtTenDangNhap.TabStop = false;
            txtTenDangNhap.UseSystemPasswordChar = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.WhiteSmoke;
            pictureBox2.Image = Properties.Resources.logodangnhapchuan;
            pictureBox2.Location = new Point(585, 69);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(322, 187);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(579, 9);
            label2.Name = "label2";
            label2.Size = new Size(322, 57);
            label2.TabIndex = 0;
            label2.Text = "Hệ Thống Đăng Nhập";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.WhiteSmoke;
            btnHuyBo.BorderColor = Color.FromArgb(220, 223, 230);
            btnHuyBo.ButtonType = ReaLTaiizor.Util.HopeButtonType.Danger;
            btnHuyBo.DangerColor = Color.Crimson;
            btnHuyBo.DefaultColor = Color.FromArgb(255, 255, 255);
            btnHuyBo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyBo.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnHuyBo.InfoColor = Color.FromArgb(144, 147, 153);
            btnHuyBo.Location = new Point(759, 468);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnHuyBo.Size = new Size(148, 50);
            btnHuyBo.SuccessColor = Color.FromArgb(103, 194, 58);
            btnHuyBo.TabIndex = 5;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.TextColor = Color.White;
            btnHuyBo.WarningColor = Color.FromArgb(230, 162, 60);
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // cbHienMatKhau
            // 
            cbHienMatKhau.AutoSize = true;
            cbHienMatKhau.Location = new Point(579, 420);
            cbHienMatKhau.Name = "cbHienMatKhau";
            cbHienMatKhau.Size = new Size(127, 24);
            cbHienMatKhau.TabIndex = 6;
            cbHienMatKhau.Text = "Hiện mật khẩu";
            cbHienMatKhau.UseVisualStyleBackColor = true;
            cbHienMatKhau.CheckedChanged += cbHienMatKhau_CheckedChanged;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(994, 539);
            Controls.Add(cbHienMatKhau);
            Controls.Add(btnHuyBo);
            Controls.Add(btnDangNhap);
            Controls.Add(panel1);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1920, 1020);
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.Fuchsia;
            panel1.ResumeLayout(false);
            cyberGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private ReaLTaiizor.Controls.CyberGroupBox cyberGroupBox1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.HopeButton btnDangNhap;
        public ReaLTaiizor.Controls.HopeTextBox txtMatKhau;
        public ReaLTaiizor.Controls.HopeTextBox txtTenDangNhap;
        private PictureBox pictureBox2;
        private Label label2;
        private ReaLTaiizor.Controls.HopeButton btnHuyBo;
        private CheckBox cbHienMatKhau;
    }
}