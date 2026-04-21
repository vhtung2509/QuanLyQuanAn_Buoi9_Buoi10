namespace QuanLyQuanAn.Reports
{
    partial class frmThongKeMonAn
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
            label1 = new Label();
            label2 = new Label();
            cboLoaiMonAn = new ComboBox();
            txtTrangThai = new TextBox();
            btnLocKetQua = new Button();
            label3 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // reportViewer
            // 
            reportViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer.Location = new Point(15, 177);
            reportViewer.Margin = new Padding(4, 3, 4, 3);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(1207, 432);
            reportViewer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 132);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(113, 23);
            label1.TabIndex = 1;
            label1.Text = "Loại món ăn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(358, 132);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 23);
            label2.TabIndex = 2;
            label2.Text = "Tìm món:";
            // 
            // cboLoaiMonAn
            // 
            cboLoaiMonAn.FormattingEnabled = true;
            cboLoaiMonAn.Location = new Point(136, 124);
            cboLoaiMonAn.Margin = new Padding(4, 3, 4, 3);
            cboLoaiMonAn.Name = "cboLoaiMonAn";
            cboLoaiMonAn.Size = new Size(188, 31);
            cboLoaiMonAn.TabIndex = 3;
            // 
            // txtTrangThai
            // 
            txtTrangThai.Location = new Point(453, 124);
            txtTrangThai.Margin = new Padding(4, 3, 4, 3);
            txtTrangThai.Name = "txtTrangThai";
            txtTrangThai.Size = new Size(155, 30);
            txtTrangThai.TabIndex = 4;
            // 
            // btnLocKetQua
            // 
            btnLocKetQua.BackColor = Color.SeaGreen;
            btnLocKetQua.FlatStyle = FlatStyle.Flat;
            btnLocKetQua.ForeColor = Color.WhiteSmoke;
            btnLocKetQua.Location = new Point(679, 121);
            btnLocKetQua.Margin = new Padding(4, 3, 4, 3);
            btnLocKetQua.Name = "btnLocKetQua";
            btnLocKetQua.Size = new Size(118, 33);
            btnLocKetQua.TabIndex = 5;
            btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.UseVisualStyleBackColor = false;
            btnLocKetQua.Click += btnLocKetQua_Click;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(1207, 51);
            label3.TabIndex = 6;
            label3.Text = "Thống Kê Món Ăn";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label3);
            panel1.Location = new Point(15, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1207, 51);
            panel1.TabIndex = 7;
            // 
            // frmThongKeMonAn
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1238, 622);
            Controls.Add(panel1);
            Controls.Add(btnLocKetQua);
            Controls.Add(txtTrangThai);
            Controls.Add(cboLoaiMonAn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(reportViewer);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmThongKeMonAn";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += frmThongKeMonAn_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private Label label1;
        private Label label2;
        private ComboBox cboLoaiMonAn;
        private TextBox txtTrangThai;
        private Button btnLocKetQua;
        private Label label3;
        private Panel panel1;
    }
}