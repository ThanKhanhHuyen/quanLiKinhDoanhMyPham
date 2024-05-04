
namespace FormDangNhap
{
    partial class FormTimKiemKhachHang
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
            this.cbTenKH = new System.Windows.Forms.CheckBox();
            this.cbGioiTinh = new System.Windows.Forms.CheckBox();
            this.txtTimKiemTKH = new System.Windows.Forms.TextBox();
            this.rbTKNam = new System.Windows.Forms.RadioButton();
            this.rbTKNu = new System.Windows.Forms.RadioButton();
            this.dgvTimKiemKH = new System.Windows.Forms.DataGridView();
            this.btnQuaylaiKH = new System.Windows.Forms.Button();
            this.btnTimKiem_KH = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemKH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTenKH
            // 
            this.cbTenKH.AutoSize = true;
            this.cbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbTenKH.Location = new System.Drawing.Point(33, 54);
            this.cbTenKH.Name = "cbTenKH";
            this.cbTenKH.Size = new System.Drawing.Size(216, 33);
            this.cbTenKH.TabIndex = 0;
            this.cbTenKH.Text = "Tên khách hàng";
            this.cbTenKH.UseVisualStyleBackColor = true;
            this.cbTenKH.CheckedChanged += new System.EventHandler(this.cbTenKH_CheckedChanged);
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.AutoSize = true;
            this.cbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbGioiTinh.Location = new System.Drawing.Point(33, 140);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(143, 33);
            this.cbGioiTinh.TabIndex = 1;
            this.cbGioiTinh.Text = "Giới Tính";
            this.cbGioiTinh.UseVisualStyleBackColor = true;
            this.cbGioiTinh.CheckedChanged += new System.EventHandler(this.cbGioiTinh_CheckedChanged);
            // 
            // txtTimKiemTKH
            // 
            this.txtTimKiemTKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTimKiemTKH.Location = new System.Drawing.Point(282, 54);
            this.txtTimKiemTKH.Name = "txtTimKiemTKH";
            this.txtTimKiemTKH.Size = new System.Drawing.Size(385, 35);
            this.txtTimKiemTKH.TabIndex = 2;
            // 
            // rbTKNam
            // 
            this.rbTKNam.AutoSize = true;
            this.rbTKNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rbTKNam.Location = new System.Drawing.Point(282, 140);
            this.rbTKNam.Name = "rbTKNam";
            this.rbTKNam.Size = new System.Drawing.Size(95, 33);
            this.rbTKNam.TabIndex = 3;
            this.rbTKNam.TabStop = true;
            this.rbTKNam.Text = "Nam";
            this.rbTKNam.UseVisualStyleBackColor = true;
            // 
            // rbTKNu
            // 
            this.rbTKNu.AutoSize = true;
            this.rbTKNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rbTKNu.Location = new System.Drawing.Point(453, 140);
            this.rbTKNu.Name = "rbTKNu";
            this.rbTKNu.Size = new System.Drawing.Size(75, 33);
            this.rbTKNu.TabIndex = 4;
            this.rbTKNu.TabStop = true;
            this.rbTKNu.Text = "Nữ";
            this.rbTKNu.UseVisualStyleBackColor = true;
            // 
            // dgvTimKiemKH
            // 
            this.dgvTimKiemKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiemKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimKiemKH.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTimKiemKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemKH.Location = new System.Drawing.Point(797, 73);
            this.dgvTimKiemKH.Name = "dgvTimKiemKH";
            this.dgvTimKiemKH.RowHeadersWidth = 82;
            this.dgvTimKiemKH.RowTemplate.Height = 33;
            this.dgvTimKiemKH.Size = new System.Drawing.Size(847, 889);
            this.dgvTimKiemKH.TabIndex = 5;
            // 
            // btnQuaylaiKH
            // 
            this.btnQuaylaiKH.AutoSize = true;
            this.btnQuaylaiKH.BackColor = System.Drawing.Color.LightGray;
            this.btnQuaylaiKH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuaylaiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnQuaylaiKH.Location = new System.Drawing.Point(540, 383);
            this.btnQuaylaiKH.Name = "btnQuaylaiKH";
            this.btnQuaylaiKH.Size = new System.Drawing.Size(138, 67);
            this.btnQuaylaiKH.TabIndex = 6;
            this.btnQuaylaiKH.Text = "Quay lại";
            this.btnQuaylaiKH.UseVisualStyleBackColor = false;
            this.btnQuaylaiKH.Click += new System.EventHandler(this.btnQuaylaiKH_Click);
            // 
            // btnTimKiem_KH
            // 
            this.btnTimKiem_KH.BackColor = System.Drawing.Color.LightGray;
            this.btnTimKiem_KH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem_KH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTimKiem_KH.Location = new System.Drawing.Point(342, 381);
            this.btnTimKiem_KH.Name = "btnTimKiem_KH";
            this.btnTimKiem_KH.Size = new System.Drawing.Size(138, 67);
            this.btnTimKiem_KH.TabIndex = 7;
            this.btnTimKiem_KH.Text = "Tìm kiếm";
            this.btnTimKiem_KH.UseVisualStyleBackColor = false;
            this.btnTimKiem_KH.Click += new System.EventHandler(this.btnTimKiem_KH_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTKNu);
            this.groupBox1.Controls.Add(this.rbTKNam);
            this.groupBox1.Controls.Add(this.txtTimKiemTKH);
            this.groupBox1.Controls.Add(this.cbGioiTinh);
            this.groupBox1.Controls.Add(this.cbTenKH);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(702, 270);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm theo";
            // 
            // FormTimKiemKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1690, 1001);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimKiem_KH);
            this.Controls.Add(this.btnQuaylaiKH);
            this.Controls.Add(this.dgvTimKiemKH);
            this.Name = "FormTimKiemKhachHang";
            this.Text = "FormTimKiemKhachHang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimKiemKhachHang_FormClosing);
            this.Load += new System.EventHandler(this.FormTimKiemKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemKH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbTenKH;
        private System.Windows.Forms.CheckBox cbGioiTinh;
        private System.Windows.Forms.TextBox txtTimKiemTKH;
        private System.Windows.Forms.RadioButton rbTKNam;
        private System.Windows.Forms.RadioButton rbTKNu;
        private System.Windows.Forms.DataGridView dgvTimKiemKH;
        private System.Windows.Forms.Button btnQuaylaiKH;
        private System.Windows.Forms.Button btnTimKiem_KH;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}