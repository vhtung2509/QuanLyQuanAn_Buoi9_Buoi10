namespace QuanLyQuanAn.Forms
{
    partial class frmTichHopAI
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
            txtCauHoi = new TextBox();
            rtbTraLoi = new RichTextBox();
            btnGui = new Button();
            btnThoat = new Button();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(976, 71);
            label1.TabIndex = 0;
            label1.Text = "Tư Vấn Với AI ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(976, 71);
            panel1.TabIndex = 1;
            // 
            // txtCauHoi
            // 
            txtCauHoi.Location = new Point(169, 43);
            txtCauHoi.Name = "txtCauHoi";
            txtCauHoi.Size = new Size(451, 30);
            txtCauHoi.TabIndex = 2;
            // 
            // rtbTraLoi
            // 
            rtbTraLoi.Location = new Point(169, 139);
            rtbTraLoi.Name = "rtbTraLoi";
            rtbTraLoi.Size = new Size(451, 226);
            rtbTraLoi.TabIndex = 3;
            rtbTraLoi.Text = "";
            // 
            // btnGui
            // 
            btnGui.BackColor = Color.MediumSeaGreen;
            btnGui.FlatStyle = FlatStyle.Flat;
            btnGui.ForeColor = Color.WhiteSmoke;
            btnGui.Location = new Point(721, 43);
            btnGui.Name = "btnGui";
            btnGui.Size = new Size(94, 29);
            btnGui.TabIndex = 4;
            btnGui.Text = "Gửi";
            btnGui.UseVisualStyleBackColor = false;
            btnGui.Click += btnGui_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = Color.Crimson;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.ForeColor = Color.WhiteSmoke;
            btnThoat.Location = new Point(721, 222);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = false;
            btnThoat.Click += btnThoat_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 51);
            label2.Name = "label2";
            label2.Size = new Size(157, 23);
            label2.TabIndex = 6;
            label2.Text = "Vấn để cần hỏi (*):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 139);
            label3.Name = "label3";
            label3.Size = new Size(124, 23);
            label3.TabIndex = 7;
            label3.Text = "Câu trả lời (*):";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnGui);
            groupBox1.Controls.Add(btnThoat);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCauHoi);
            groupBox1.Controls.Add(rtbTraLoi);
            groupBox1.Location = new Point(12, 114);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(976, 392);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin bạn thắc mắc";
            // 
            // frmTichHopAI
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1000, 518);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmTichHopAI";
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox txtCauHoi;
        private RichTextBox rtbTraLoi;
        private Button btnGui;
        private Button btnThoat;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
    }
}