
namespace FormDangNhap
{
    partial class FormTimKiemNhanVien
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
            this.dgvTimKiemNV = new System.Windows.Forms.DataGridView();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.cbMaNV = new System.Windows.Forms.CheckBox();
            this.cbNgayVaoLam = new System.Windows.Forms.CheckBox();
            this.txtTimKiemMNV = new System.Windows.Forms.TextBox();
            this.dtpTimKiemNVL = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemNV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTimKiemNV
            // 
            this.dgvTimKiemNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiemNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimKiemNV.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvTimKiemNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemNV.Location = new System.Drawing.Point(778, 72);
            this.dgvTimKiemNV.Name = "dgvTimKiemNV";
            this.dgvTimKiemNV.RowHeadersWidth = 82;
            this.dgvTimKiemNV.RowTemplate.Height = 33;
            this.dgvTimKiemNV.Size = new System.Drawing.Size(817, 877);
            this.dgvTimKiemNV.TabIndex = 0;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.AutoSize = true;
            this.btnQuayLai.BackColor = System.Drawing.Color.LightGray;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnQuayLai.Location = new System.Drawing.Point(545, 389);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(138, 67);
            this.btnQuayLai.TabIndex = 1;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // cbMaNV
            // 
            this.cbMaNV.AutoSize = true;
            this.cbMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbMaNV.Location = new System.Drawing.Point(26, 67);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(186, 33);
            this.cbMaNV.TabIndex = 2;
            this.cbMaNV.Text = "Mã nhân viên";
            this.cbMaNV.UseVisualStyleBackColor = true;
            this.cbMaNV.CheckedChanged += new System.EventHandler(this.cbMaNV_CheckedChanged);
            // 
            // cbNgayVaoLam
            // 
            this.cbNgayVaoLam.AutoSize = true;
            this.cbNgayVaoLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbNgayVaoLam.Location = new System.Drawing.Point(26, 162);
            this.cbNgayVaoLam.Name = "cbNgayVaoLam";
            this.cbNgayVaoLam.Size = new System.Drawing.Size(190, 33);
            this.cbNgayVaoLam.TabIndex = 3;
            this.cbNgayVaoLam.Text = "Ngày vào làm";
            this.cbNgayVaoLam.UseVisualStyleBackColor = true;
            this.cbNgayVaoLam.CheckedChanged += new System.EventHandler(this.cbNgayVaoLam_CheckedChanged);
            // 
            // txtTimKiemMNV
            // 
            this.txtTimKiemMNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtTimKiemMNV.Location = new System.Drawing.Point(245, 77);
            this.txtTimKiemMNV.Name = "txtTimKiemMNV";
            this.txtTimKiemMNV.Size = new System.Drawing.Size(423, 35);
            this.txtTimKiemMNV.TabIndex = 4;
            this.txtTimKiemMNV.TextChanged += new System.EventHandler(this.txtTimKiemMNV_TextChanged);
            // 
            // dtpTimKiemNVL
            // 
            this.dtpTimKiemNVL.CustomFormat = "dd/MM/yyyy";
            this.dtpTimKiemNVL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpTimKiemNVL.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimKiemNVL.Location = new System.Drawing.Point(245, 162);
            this.dtpTimKiemNVL.Name = "dtpTimKiemNVL";
            this.dtpTimKiemNVL.Size = new System.Drawing.Size(423, 35);
            this.dtpTimKiemNVL.TabIndex = 5;
            this.dtpTimKiemNVL.Value = new System.DateTime(2024, 4, 7, 0, 0, 0, 0);
            this.dtpTimKiemNVL.ValueChanged += new System.EventHandler(this.dtpTimKiemNVL_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpTimKiemNVL);
            this.groupBox1.Controls.Add(this.txtTimKiemMNV);
            this.groupBox1.Controls.Add(this.cbNgayVaoLam);
            this.groupBox1.Controls.Add(this.cbMaNV);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 284);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm theo";
            // 
            // FormTimKiemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1643, 989);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.dgvTimKiemNV);
            this.Name = "FormTimKiemNhanVien";
            this.Text = "FormTimKiemNhanVien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimKiemNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.FormTimKiemNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemNV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimKiemNV;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.CheckBox cbMaNV;
        private System.Windows.Forms.CheckBox cbNgayVaoLam;
        private System.Windows.Forms.TextBox txtTimKiemMNV;
        private System.Windows.Forms.DateTimePicker dtpTimKiemNVL;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}