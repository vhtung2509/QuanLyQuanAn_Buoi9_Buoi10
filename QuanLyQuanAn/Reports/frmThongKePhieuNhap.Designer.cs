namespace QuanLyQuanAn.Reports
{
    partial class frmThongKePhieuNhap
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
            reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            btnHienTatCa = new Button();
            btnLocKetQua = new Button();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer
            // 
            reportViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer.Location = new Point(15, 168);
            reportViewer.Margin = new Padding(4, 3, 4, 3);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(1321, 461);
            reportViewer.TabIndex = 0;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.BackColor = Color.LightSeaGreen;
            btnHienTatCa.FlatStyle = FlatStyle.Popup;
            btnHienTatCa.ForeColor = Color.WhiteSmoke;
            btnHienTatCa.Location = new Point(755, 108);
            btnHienTatCa.Margin = new Padding(4, 3, 4, 3);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(118, 33);
            btnHienTatCa.TabIndex = 12;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.UseVisualStyleBackColor = false;
            btnHienTatCa.Click += btnHienTatCa_Click;
            // 
            // btnLocKetQua
            // 
            btnLocKetQua.BackColor = Color.SeaGreen;
            btnLocKetQua.FlatStyle = FlatStyle.Popup;
            btnLocKetQua.ForeColor = Color.WhiteSmoke;
            btnLocKetQua.Location = new Point(602, 108);
            btnLocKetQua.Margin = new Padding(4, 3, 4, 3);
            btnLocKetQua.Name = "btnLocKetQua";
            btnLocKetQua.Size = new Size(118, 33);
            btnLocKetQua.TabIndex = 11;
            btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.UseVisualStyleBackColor = false;
            btnLocKetQua.Click += btnLocKetQua_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.CustomFormat = "dd/MM/yy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Location = new Point(390, 110);
            dtpDenNgay.Margin = new Padding(4, 3, 4, 3);
            dtpDenNgay.MaxDate = new DateTime(2026, 4, 5, 0, 0, 0, 0);
            dtpDenNgay.MinDate = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(143, 30);
            dtpDenNgay.TabIndex = 10;
            dtpDenNgay.Value = new DateTime(2026, 4, 5, 0, 0, 0, 0);
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.CustomFormat = "dd/MM/yy";
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Location = new Point(104, 110);
            dtpTuNgay.Margin = new Padding(4, 3, 4, 3);
            dtpTuNgay.MaxDate = new DateTime(2026, 4, 5, 0, 0, 0, 0);
            dtpTuNgay.MinDate = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(143, 30);
            dtpTuNgay.TabIndex = 9;
            dtpTuNgay.Value = new DateTime(2026, 4, 5, 0, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(289, 118);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 23);
            label2.TabIndex = 8;
            label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 118);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 23);
            label1.TabIndex = 7;
            label1.Text = "Từ ngày:";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1321, 65);
            label3.TabIndex = 13;
            label3.Text = "Thống Kê Phiếu Nhập Hàng";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(15, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1321, 65);
            panel1.TabIndex = 14;
            // 
            // frmThongKePhieuNhap
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1351, 643);
            Controls.Add(panel1);
            Controls.Add(btnHienTatCa);
            Controls.Add(btnLocKetQua);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(reportViewer);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmThongKePhieuNhap";
            WindowState = FormWindowState.Maximized;
            Load += frmThongKePhieuNhap_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private Button btnHienTatCa;
        private Button btnLocKetQua;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Label label2;
        private Label label1;
        private Label label3;
        private Panel panel1;
    }
}