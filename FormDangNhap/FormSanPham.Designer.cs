
namespace FormDangNhap
{
    partial class FormSanPham
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
            this.dtvSanPham = new System.Windows.Forms.DataGridView();
            this.lable1 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtNuocSX = new System.Windows.Forms.TextBox();
            this.cbbMaNSX = new System.Windows.Forms.ComboBox();
            this.cbbMaLoai = new System.Windows.Forms.ComboBox();
            this.cbbMaNCC = new System.Windows.Forms.ComboBox();
            this.txtSoLuongKho = new System.Windows.Forms.TextBox();
            this.dtpHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnBoChonSP = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnTimKiemSP = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtvSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtvSanPham
            // 
            this.dtvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtvSanPham.BackgroundColor = System.Drawing.Color.LightGray;
            this.dtvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvSanPham.Location = new System.Drawing.Point(782, 96);
            this.dtvSanPham.Name = "dtvSanPham";
            this.dtvSanPham.RowHeadersWidth = 82;
            this.dtvSanPham.RowTemplate.Height = 33;
            this.dtvSanPham.Size = new System.Drawing.Size(973, 1179);
            this.dtvSanPham.TabIndex = 0;
            this.dtvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvSanPham_CellClick);
            this.dtvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvSanPham_CellContentClick);
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lable1.Location = new System.Drawing.Point(23, 48);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(156, 29);
            this.lable1.TabIndex = 1;
            this.lable1.Text = "Mã sản phẩm";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMaSP.Location = new System.Drawing.Point(240, 48);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(398, 35);
            this.txtMaSP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(28, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(28, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đơn giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(28, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nước SX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(28, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã NSX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(28, 473);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mã loại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(28, 558);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mã NCC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.Location = new System.Drawing.Point(28, 643);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 29);
            this.label7.TabIndex = 9;
            this.label7.Text = "Số lượng kho";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(28, 728);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 29);
            this.label8.TabIndex = 10;
            this.label8.Text = "Hạn sử dụng";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTenSP.Location = new System.Drawing.Point(240, 133);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(398, 35);
            this.txtTenSP.TabIndex = 11;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDonGia.Location = new System.Drawing.Point(240, 218);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(398, 35);
            this.txtDonGia.TabIndex = 12;
            // 
            // txtNuocSX
            // 
            this.txtNuocSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNuocSX.Location = new System.Drawing.Point(240, 303);
            this.txtNuocSX.Name = "txtNuocSX";
            this.txtNuocSX.Size = new System.Drawing.Size(398, 35);
            this.txtNuocSX.TabIndex = 13;
            // 
            // cbbMaNSX
            // 
            this.cbbMaNSX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbbMaNSX.FormattingEnabled = true;
            this.cbbMaNSX.Location = new System.Drawing.Point(240, 388);
            this.cbbMaNSX.Name = "cbbMaNSX";
            this.cbbMaNSX.Size = new System.Drawing.Size(234, 37);
            this.cbbMaNSX.TabIndex = 14;
            // 
            // cbbMaLoai
            // 
            this.cbbMaLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbbMaLoai.FormattingEnabled = true;
            this.cbbMaLoai.Location = new System.Drawing.Point(242, 473);
            this.cbbMaLoai.Name = "cbbMaLoai";
            this.cbbMaLoai.Size = new System.Drawing.Size(232, 37);
            this.cbbMaLoai.TabIndex = 15;
            // 
            // cbbMaNCC
            // 
            this.cbbMaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbbMaNCC.FormattingEnabled = true;
            this.cbbMaNCC.Location = new System.Drawing.Point(240, 558);
            this.cbbMaNCC.Name = "cbbMaNCC";
            this.cbbMaNCC.Size = new System.Drawing.Size(230, 37);
            this.cbbMaNCC.TabIndex = 16;
            // 
            // txtSoLuongKho
            // 
            this.txtSoLuongKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtSoLuongKho.Location = new System.Drawing.Point(242, 643);
            this.txtSoLuongKho.Name = "txtSoLuongKho";
            this.txtSoLuongKho.Size = new System.Drawing.Size(398, 35);
            this.txtSoLuongKho.TabIndex = 17;
            // 
            // dtpHanSuDung
            // 
            this.dtpHanSuDung.CalendarFont = new System.Drawing.Font("Tahoma", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHanSuDung.CustomFormat = "dd/MM/yyyy";
            this.dtpHanSuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpHanSuDung.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanSuDung.Location = new System.Drawing.Point(242, 728);
            this.dtpHanSuDung.Name = "dtpHanSuDung";
            this.dtpHanSuDung.Size = new System.Drawing.Size(405, 35);
            this.dtpHanSuDung.TabIndex = 18;
            this.dtpHanSuDung.Value = new System.DateTime(2024, 4, 5, 0, 0, 0, 0);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.LightGray;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnThemSP.Location = new System.Drawing.Point(50, 42);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(138, 67);
            this.btnThemSP.TabIndex = 19;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.BackColor = System.Drawing.Color.LightGray;
            this.btnSuaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSuaSP.Location = new System.Drawing.Point(260, 42);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(138, 67);
            this.btnSuaSP.TabIndex = 20;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.UseVisualStyleBackColor = false;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // btnBoChonSP
            // 
            this.btnBoChonSP.BackColor = System.Drawing.Color.LightGray;
            this.btnBoChonSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoChonSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnBoChonSP.Location = new System.Drawing.Point(260, 153);
            this.btnBoChonSP.Name = "btnBoChonSP";
            this.btnBoChonSP.Size = new System.Drawing.Size(138, 67);
            this.btnBoChonSP.TabIndex = 21;
            this.btnBoChonSP.Text = "Bỏ chọn";
            this.btnBoChonSP.UseVisualStyleBackColor = false;
            this.btnBoChonSP.Click += new System.EventHandler(this.btnBoChonSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.Color.LightGray;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnXoaSP.Location = new System.Drawing.Point(463, 42);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(138, 67);
            this.btnXoaSP.TabIndex = 22;
            this.btnXoaSP.Text = "Xóa";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnTimKiemSP
            // 
            this.btnTimKiemSP.BackColor = System.Drawing.Color.LightGray;
            this.btnTimKiemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnTimKiemSP.Location = new System.Drawing.Point(46, 153);
            this.btnTimKiemSP.Name = "btnTimKiemSP";
            this.btnTimKiemSP.Size = new System.Drawing.Size(138, 67);
            this.btnTimKiemSP.TabIndex = 23;
            this.btnTimKiemSP.Text = "Tìm kiếm";
            this.btnTimKiemSP.UseVisualStyleBackColor = false;
            this.btnTimKiemSP.Click += new System.EventHandler(this.btnTimKiemSP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpHanSuDung);
            this.groupBox1.Controls.Add(this.txtSoLuongKho);
            this.groupBox1.Controls.Add(this.cbbMaNCC);
            this.groupBox1.Controls.Add(this.cbbMaLoai);
            this.groupBox1.Controls.Add(this.cbbMaNSX);
            this.groupBox1.Controls.Add(this.txtNuocSX);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.txtTenSP);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Controls.Add(this.lable1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 800);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sản phẩm";
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.LightGray;
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnInBaoCao.Location = new System.Drawing.Point(463, 153);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(138, 67);
            this.btnInBaoCao.TabIndex = 25;
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnInBaoCao);
            this.groupBox2.Controls.Add(this.btnTimKiemSP);
            this.groupBox2.Controls.Add(this.btnXoaSP);
            this.groupBox2.Controls.Add(this.btnBoChonSP);
            this.groupBox2.Controls.Add(this.btnSuaSP);
            this.groupBox2.Controls.Add(this.btnThemSP);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(32, 936);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 283);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1785, 1244);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtvSanPham);
            this.Name = "FormSanPham";
            this.Text = "FormSanPham";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtvSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtvSanPham;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtNuocSX;
        private System.Windows.Forms.ComboBox cbbMaNSX;
        private System.Windows.Forms.ComboBox cbbMaLoai;
        private System.Windows.Forms.ComboBox cbbMaNCC;
        private System.Windows.Forms.TextBox txtSoLuongKho;
        private System.Windows.Forms.DateTimePicker dtpHanSuDung;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnBoChonSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnTimKiemSP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}