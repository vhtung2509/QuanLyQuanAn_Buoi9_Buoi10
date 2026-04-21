namespace QuanLyQuanAn.Forms
{
    partial class frmCongThuc
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
            groupBox1 = new GroupBox();
            btnThoat = new Button();
            txtChiTietCongThuc = new TextBox();
            cboMonAn = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(txtChiTietCongThuc);
            groupBox1.Controls.Add(cboMonAn);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(1, 127);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1185, 679);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Công thức chi tiết ";
            // 
            // btnThoat
            // 
            btnThoat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThoat.BackColor = Color.Crimson;
            btnThoat.ForeColor = Color.White;
            btnThoat.Location = new Point(1024, 45);
            btnThoat.Margin = new Padding(4, 3, 4, 3);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(118, 33);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtChiTietCongThuc
            // 
            txtChiTietCongThuc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtChiTietCongThuc.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtChiTietCongThuc.Location = new Point(8, 84);
            txtChiTietCongThuc.Margin = new Padding(4, 3, 4, 3);
            txtChiTietCongThuc.Multiline = true;
            txtChiTietCongThuc.Name = "txtChiTietCongThuc";
            txtChiTietCongThuc.ReadOnly = true;
            txtChiTietCongThuc.Size = new Size(1169, 584);
            txtChiTietCongThuc.TabIndex = 2;
            // 
            // cboMonAn
            // 
            cboMonAn.FlatStyle = FlatStyle.Flat;
            cboMonAn.FormattingEnabled = true;
            cboMonAn.Location = new Point(162, 41);
            cboMonAn.Margin = new Padding(4, 3, 4, 3);
            cboMonAn.Name = "cboMonAn";
            cboMonAn.Size = new Size(188, 31);
            cboMonAn.TabIndex = 1;
            cboMonAn.SelectedIndexChanged += cboMonAn_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(8, 49);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 23);
            label1.TabIndex = 0;
            label1.Text = "Chọn món ăn (*):";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label2);
            panel1.Location = new Point(1, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1185, 88);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1185, 88);
            label2.TabIndex = 0;
            label2.Text = "Công Thức Nấu Ăn";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmCongThuc
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186, 807);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmCongThuc";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += frmCongThuc_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cboMonAn;
        private Label label1;
        private TextBox txtChiTietCongThuc;
        private Button btnThoat;
        private Panel panel1;
        private Label label2;
    }
}