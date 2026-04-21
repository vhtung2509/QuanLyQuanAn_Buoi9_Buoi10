namespace QuanLyQuanAn.Forms
{
    partial class frmManHinhOrder
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
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            panel1 = new Panel();
            pnlOrder = new Panel();
            btnApDung = new ReaLTaiizor.Controls.HopeButton();
            txtVoucher = new TextBox();
            lblGiamGia = new Label();
            btnDatMon = new ReaLTaiizor.Controls.HopeButton();
            btnXoaMon = new ReaLTaiizor.Controls.HopeButton();
            btnThanhToan = new ReaLTaiizor.Controls.HopeButton();
            txtTongTien = new TextBox();
            label2 = new Label();
            dataGridView = new DataGridView();
            TenMon = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            cboBanAn = new ReaLTaiizor.Controls.HopeComboBox();
            label1 = new Label();
            pnlMenu = new Panel();
            flpDanhSachMon = new FlowLayoutPanel();
            panel4 = new Panel();
            btnNuocGiaiKhat = new ReaLTaiizor.Controls.CyberButton();
            btnMonKho = new ReaLTaiizor.Controls.CyberButton();
            btnMonNuoc = new ReaLTaiizor.Controls.CyberButton();
            panel1.SuspendLayout();
            pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            pnlMenu.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // bigLabel1
            // 
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Dock = DockStyle.Fill;
            bigLabel1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.WhiteSmoke;
            bigLabel1.Location = new Point(0, 0);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(848, 77);
            bigLabel1.TabIndex = 2;
            bigLabel1.Text = "Menu Thực Đơn";
            bigLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(bigLabel1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(848, 77);
            panel1.TabIndex = 2;
            // 
            // pnlOrder
            // 
            pnlOrder.BackColor = Color.DarkSlateGray;
            pnlOrder.Controls.Add(btnApDung);
            pnlOrder.Controls.Add(txtVoucher);
            pnlOrder.Controls.Add(lblGiamGia);
            pnlOrder.Controls.Add(btnDatMon);
            pnlOrder.Controls.Add(btnXoaMon);
            pnlOrder.Controls.Add(btnThanhToan);
            pnlOrder.Controls.Add(txtTongTien);
            pnlOrder.Controls.Add(label2);
            pnlOrder.Controls.Add(dataGridView);
            pnlOrder.Controls.Add(cboBanAn);
            pnlOrder.Controls.Add(label1);
            pnlOrder.Location = new Point(866, 12);
            pnlOrder.Name = "pnlOrder";
            pnlOrder.Size = new Size(564, 827);
            pnlOrder.TabIndex = 3;
            // 
            // btnApDung
            // 
            btnApDung.BorderColor = Color.FromArgb(220, 223, 230);
            btnApDung.ButtonType = ReaLTaiizor.Util.HopeButtonType.Info;
            btnApDung.DangerColor = Color.FromArgb(245, 108, 108);
            btnApDung.DefaultColor = Color.FromArgb(255, 255, 255);
            btnApDung.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApDung.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnApDung.InfoColor = Color.FromArgb(144, 147, 153);
            btnApDung.Location = new Point(448, 599);
            btnApDung.Name = "btnApDung";
            btnApDung.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnApDung.Size = new Size(94, 30);
            btnApDung.SuccessColor = Color.FromArgb(103, 194, 58);
            btnApDung.TabIndex = 10;
            btnApDung.Text = "Áp dụng";
            btnApDung.TextColor = Color.White;
            btnApDung.WarningColor = Color.FromArgb(230, 162, 60);
            btnApDung.Click += btnApDung_Click;
            // 
            // txtVoucher
            // 
            txtVoucher.Location = new Point(240, 563);
            txtVoucher.Name = "txtVoucher";
            txtVoucher.Size = new Size(302, 30);
            txtVoucher.TabIndex = 9;
            // 
            // lblGiamGia
            // 
            lblGiamGia.AutoSize = true;
            lblGiamGia.ForeColor = Color.WhiteSmoke;
            lblGiamGia.Location = new Point(38, 563);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(180, 23);
            lblGiamGia.TabIndex = 8;
            lblGiamGia.Text = "Voucher giảm giá (*):";
            // 
            // btnDatMon
            // 
            btnDatMon.BorderColor = Color.FromArgb(220, 223, 230);
            btnDatMon.ButtonType = ReaLTaiizor.Util.HopeButtonType.Success;
            btnDatMon.DangerColor = Color.FromArgb(245, 108, 108);
            btnDatMon.DefaultColor = Color.FromArgb(255, 255, 255);
            btnDatMon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatMon.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnDatMon.InfoColor = Color.FromArgb(144, 147, 153);
            btnDatMon.Location = new Point(38, 647);
            btnDatMon.Name = "btnDatMon";
            btnDatMon.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnDatMon.Size = new Size(260, 50);
            btnDatMon.SuccessColor = Color.FromArgb(103, 194, 58);
            btnDatMon.TabIndex = 7;
            btnDatMon.Text = "Đặt món";
            btnDatMon.TextColor = Color.White;
            btnDatMon.WarningColor = Color.FromArgb(230, 162, 60);
            btnDatMon.Click += btnDatMon_Click;
            // 
            // btnXoaMon
            // 
            btnXoaMon.BorderColor = Color.FromArgb(220, 223, 230);
            btnXoaMon.ButtonType = ReaLTaiizor.Util.HopeButtonType.Danger;
            btnXoaMon.DangerColor = Color.FromArgb(245, 108, 108);
            btnXoaMon.DefaultColor = Color.FromArgb(255, 255, 255);
            btnXoaMon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnXoaMon.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnXoaMon.InfoColor = Color.FromArgb(144, 147, 153);
            btnXoaMon.Location = new Point(38, 703);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnXoaMon.Size = new Size(260, 50);
            btnXoaMon.SuccessColor = Color.FromArgb(103, 194, 58);
            btnXoaMon.TabIndex = 6;
            btnXoaMon.Text = "Xóa món";
            btnXoaMon.TextColor = Color.White;
            btnXoaMon.WarningColor = Color.FromArgb(230, 162, 60);
            btnXoaMon.Click += btnXoaMon_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BorderColor = Color.FromArgb(220, 223, 230);
            btnThanhToan.ButtonType = ReaLTaiizor.Util.HopeButtonType.Success;
            btnThanhToan.DangerColor = Color.FromArgb(245, 108, 108);
            btnThanhToan.DefaultColor = Color.FromArgb(255, 255, 255);
            btnThanhToan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThanhToan.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnThanhToan.InfoColor = Color.FromArgb(144, 147, 153);
            btnThanhToan.Location = new Point(38, 759);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnThanhToan.Size = new Size(504, 50);
            btnThanhToan.SuccessColor = Color.FromArgb(255, 128, 0);
            btnThanhToan.TabIndex = 5;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.TextColor = Color.White;
            btnThanhToan.WarningColor = Color.FromArgb(230, 162, 60);
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(371, 495);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(171, 30);
            txtTongTien.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(240, 502);
            label2.Name = "label2";
            label2.Size = new Size(125, 23);
            label2.TabIndex = 3;
            label2.Text = "Tổng cộng (*):";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.BackgroundColor = Color.WhiteSmoke;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { TenMon, SoLuong, DonGia, ThanhTien });
            dataGridView.Location = new Point(38, 83);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(504, 406);
            dataGridView.TabIndex = 2;
            // 
            // TenMon
            // 
            TenMon.DataPropertyName = "TenMon";
            TenMon.HeaderText = "Tên món ";
            TenMon.MinimumWidth = 6;
            TenMon.Name = "TenMon";
            TenMon.Width = 125;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            SoLuong.Width = 125;
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            DonGia.Width = 125;
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            ThanhTien.HeaderText = "Thành tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            ThanhTien.Width = 125;
            // 
            // cboBanAn
            // 
            cboBanAn.DrawMode = DrawMode.OwnerDrawFixed;
            cboBanAn.FlatStyle = FlatStyle.Flat;
            cboBanAn.Font = new Font("Segoe UI", 12F);
            cboBanAn.FormattingEnabled = true;
            cboBanAn.ItemHeight = 30;
            cboBanAn.Location = new Point(240, 22);
            cboBanAn.Name = "cboBanAn";
            cboBanAn.Size = new Size(183, 36);
            cboBanAn.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(3, 22);
            label1.Name = "label1";
            label1.Size = new Size(231, 38);
            label1.TabIndex = 0;
            label1.Text = "Chọn bàn ăn (*):";
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.DarkSlateGray;
            pnlMenu.Controls.Add(flpDanhSachMon);
            pnlMenu.Controls.Add(panel4);
            pnlMenu.Location = new Point(12, 95);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(848, 744);
            pnlMenu.TabIndex = 4;
            // 
            // flpDanhSachMon
            // 
            flpDanhSachMon.AutoScroll = true;
            flpDanhSachMon.Dock = DockStyle.Fill;
            flpDanhSachMon.Location = new Point(0, 60);
            flpDanhSachMon.Name = "flpDanhSachMon";
            flpDanhSachMon.Size = new Size(848, 684);
            flpDanhSachMon.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkSlateGray;
            panel4.Controls.Add(btnNuocGiaiKhat);
            panel4.Controls.Add(btnMonKho);
            panel4.Controls.Add(btnMonNuoc);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(848, 60);
            panel4.TabIndex = 0;
            // 
            // btnNuocGiaiKhat
            // 
            btnNuocGiaiKhat.Alpha = 20;
            btnNuocGiaiKhat.BackColor = Color.Transparent;
            btnNuocGiaiKhat.Background = true;
            btnNuocGiaiKhat.Background_WidthPen = 4F;
            btnNuocGiaiKhat.BackgroundPen = true;
            btnNuocGiaiKhat.ColorBackground = Color.FromArgb(37, 52, 68);
            btnNuocGiaiKhat.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnNuocGiaiKhat.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnNuocGiaiKhat.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            btnNuocGiaiKhat.ColorLighting = Color.FromArgb(29, 200, 238);
            btnNuocGiaiKhat.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnNuocGiaiKhat.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnNuocGiaiKhat.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnNuocGiaiKhat.Dock = DockStyle.Left;
            btnNuocGiaiKhat.Effect_1 = true;
            btnNuocGiaiKhat.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnNuocGiaiKhat.Effect_1_Transparency = 25;
            btnNuocGiaiKhat.Effect_2 = true;
            btnNuocGiaiKhat.Effect_2_ColorBackground = Color.White;
            btnNuocGiaiKhat.Effect_2_Transparency = 20;
            btnNuocGiaiKhat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNuocGiaiKhat.ForeColor = Color.FromArgb(245, 245, 245);
            btnNuocGiaiKhat.Lighting = false;
            btnNuocGiaiKhat.LinearGradient_Background = false;
            btnNuocGiaiKhat.LinearGradientPen = false;
            btnNuocGiaiKhat.Location = new Point(404, 0);
            btnNuocGiaiKhat.Margin = new Padding(4, 3, 4, 3);
            btnNuocGiaiKhat.Name = "btnNuocGiaiKhat";
            btnNuocGiaiKhat.PenWidth = 15;
            btnNuocGiaiKhat.Rounding = true;
            btnNuocGiaiKhat.RoundingInt = 70;
            btnNuocGiaiKhat.Size = new Size(202, 60);
            btnNuocGiaiKhat.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnNuocGiaiKhat.TabIndex = 2;
            btnNuocGiaiKhat.Tag = "Cyber";
            btnNuocGiaiKhat.TextButton = "Nước Giải Khát";
            btnNuocGiaiKhat.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnNuocGiaiKhat.Timer_Effect_1 = 5;
            btnNuocGiaiKhat.Timer_RGB = 300;
            btnNuocGiaiKhat.Click += btnNuocGiaiKhat_Click;
            // 
            // btnMonKho
            // 
            btnMonKho.Alpha = 20;
            btnMonKho.BackColor = Color.Transparent;
            btnMonKho.Background = true;
            btnMonKho.Background_WidthPen = 4F;
            btnMonKho.BackgroundPen = true;
            btnMonKho.ColorBackground = Color.FromArgb(37, 52, 68);
            btnMonKho.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnMonKho.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnMonKho.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            btnMonKho.ColorLighting = Color.FromArgb(29, 200, 238);
            btnMonKho.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnMonKho.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnMonKho.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnMonKho.Dock = DockStyle.Left;
            btnMonKho.Effect_1 = true;
            btnMonKho.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnMonKho.Effect_1_Transparency = 25;
            btnMonKho.Effect_2 = true;
            btnMonKho.Effect_2_ColorBackground = Color.White;
            btnMonKho.Effect_2_Transparency = 20;
            btnMonKho.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMonKho.ForeColor = Color.FromArgb(245, 245, 245);
            btnMonKho.Lighting = false;
            btnMonKho.LinearGradient_Background = false;
            btnMonKho.LinearGradientPen = false;
            btnMonKho.Location = new Point(202, 0);
            btnMonKho.Margin = new Padding(4, 3, 4, 3);
            btnMonKho.Name = "btnMonKho";
            btnMonKho.PenWidth = 15;
            btnMonKho.Rounding = true;
            btnMonKho.RoundingInt = 70;
            btnMonKho.Size = new Size(202, 60);
            btnMonKho.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnMonKho.TabIndex = 1;
            btnMonKho.Tag = "Cyber";
            btnMonKho.TextButton = "Món Khô";
            btnMonKho.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnMonKho.Timer_Effect_1 = 5;
            btnMonKho.Timer_RGB = 300;
            btnMonKho.Click += btnMonKho_Click;
            // 
            // btnMonNuoc
            // 
            btnMonNuoc.Alpha = 20;
            btnMonNuoc.BackColor = Color.Transparent;
            btnMonNuoc.Background = true;
            btnMonNuoc.Background_WidthPen = 4F;
            btnMonNuoc.BackgroundPen = true;
            btnMonNuoc.ColorBackground = Color.FromArgb(37, 52, 68);
            btnMonNuoc.ColorBackground_1 = Color.FromArgb(37, 52, 68);
            btnMonNuoc.ColorBackground_2 = Color.FromArgb(41, 63, 86);
            btnMonNuoc.ColorBackground_Pen = Color.FromArgb(29, 200, 238);
            btnMonNuoc.ColorLighting = Color.FromArgb(29, 200, 238);
            btnMonNuoc.ColorPen_1 = Color.FromArgb(37, 52, 68);
            btnMonNuoc.ColorPen_2 = Color.FromArgb(41, 63, 86);
            btnMonNuoc.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            btnMonNuoc.Dock = DockStyle.Left;
            btnMonNuoc.Effect_1 = true;
            btnMonNuoc.Effect_1_ColorBackground = Color.FromArgb(29, 200, 238);
            btnMonNuoc.Effect_1_Transparency = 25;
            btnMonNuoc.Effect_2 = true;
            btnMonNuoc.Effect_2_ColorBackground = Color.White;
            btnMonNuoc.Effect_2_Transparency = 20;
            btnMonNuoc.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMonNuoc.ForeColor = Color.FromArgb(245, 245, 245);
            btnMonNuoc.Lighting = false;
            btnMonNuoc.LinearGradient_Background = false;
            btnMonNuoc.LinearGradientPen = false;
            btnMonNuoc.Location = new Point(0, 0);
            btnMonNuoc.Margin = new Padding(4, 3, 4, 3);
            btnMonNuoc.Name = "btnMonNuoc";
            btnMonNuoc.PenWidth = 15;
            btnMonNuoc.Rounding = true;
            btnMonNuoc.RoundingInt = 70;
            btnMonNuoc.Size = new Size(202, 60);
            btnMonNuoc.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            btnMonNuoc.TabIndex = 0;
            btnMonNuoc.Tag = "Cyber";
            btnMonNuoc.TextButton = "Món Nước";
            btnMonNuoc.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            btnMonNuoc.Timer_Effect_1 = 5;
            btnMonNuoc.Timer_RGB = 300;
            btnMonNuoc.Click += btnMonNuoc_Click;
            // 
            // frmManHinhOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1442, 846);
            Controls.Add(pnlMenu);
            Controls.Add(pnlOrder);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmManHinhOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmManHinhOrder_Load;
            panel1.ResumeLayout(false);
            pnlOrder.ResumeLayout(false);
            pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            pnlMenu.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private Panel panel1;
        private Panel pnlOrder;
        private Label label1;
        private ReaLTaiizor.Controls.HopeComboBox cboBanAn;
        private DataGridView dataGridView;
        private Label label2;
        private ReaLTaiizor.Controls.HopeButton btnDatMon;
        private ReaLTaiizor.Controls.HopeButton btnXoaMon;
        private ReaLTaiizor.Controls.HopeButton btnThanhToan;
        private TextBox txtTongTien;
        private Panel pnlMenu;
        private Panel panel4;
        private ReaLTaiizor.Controls.CyberButton btnNuocGiaiKhat;
        private ReaLTaiizor.Controls.CyberButton btnMonKho;
        private ReaLTaiizor.Controls.CyberButton btnMonNuoc;
        private FlowLayoutPanel flpDanhSachMon;
        private DataGridViewTextBoxColumn TenMon;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn ThanhTien;
        private TextBox txtVoucher;
        private Label lblGiamGia;
        private ReaLTaiizor.Controls.HopeButton btnApDung;
    }
}