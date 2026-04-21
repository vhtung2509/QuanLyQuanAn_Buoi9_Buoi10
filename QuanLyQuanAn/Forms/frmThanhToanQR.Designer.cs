namespace QuanLyQuanAn.Forms
{
    partial class frmThanhToanQR
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnXacNhan = new Button();
            btnHuyBo = new Button();
            lblTongTien = new Label();
            btnThoat = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(880, 80);
            label1.TabIndex = 0;
            label1.Text = "Thông Tin Chuyển Khoản";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(15, 14);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(880, 80);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.qrthanhtoan;
            pictureBox1.Location = new Point(71, 129);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(231, 278);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.MediumSeaGreen;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.ForeColor = Color.WhiteSmoke;
            btnXacNhan.Location = new Point(355, 366);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(138, 41);
            btnXacNhan.TabIndex = 3;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuyBo
            // 
            btnHuyBo.BackColor = Color.Crimson;
            btnHuyBo.FlatStyle = FlatStyle.Flat;
            btnHuyBo.ForeColor = Color.WhiteSmoke;
            btnHuyBo.Location = new Point(524, 366);
            btnHuyBo.Name = "btnHuyBo";
            btnHuyBo.Size = new Size(151, 41);
            btnHuyBo.TabIndex = 4;
            btnHuyBo.Text = "Hủy bỏ";
            btnHuyBo.UseVisualStyleBackColor = false;
            btnHuyBo.Click += btnHuyBo_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(355, 220);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(59, 23);
            lblTongTien.TabIndex = 5;
            lblTongTien.Text = "label2";
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Crimson;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.ForeColor = Color.WhiteSmoke;
            btnThoat.Location = new Point(704, 366);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(151, 41);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmThanhToanQR
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(908, 442);
            Controls.Add(btnThoat);
            Controls.Add(lblTongTien);
            Controls.Add(btnHuyBo);
            Controls.Add(btnXacNhan);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmThanhToanQR";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Button btnXacNhan;
        private Button btnHuyBo;
        private Label lblTongTien;
        private Button btnThoat;
    }
}