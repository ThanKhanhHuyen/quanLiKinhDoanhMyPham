
namespace FormDangNhap
{
    partial class FormTimKiemSanPham
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
            this.dgvTimKiemSP = new System.Windows.Forms.DataGridView();
            this.cbMaLoai = new System.Windows.Forms.CheckBox();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.cbbTimKiemML = new System.Windows.Forms.ComboBox();
            this.dtpTimKiemHSD = new System.Windows.Forms.DateTimePicker();
            this.cbHanSuDung = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTimKiemSP
            // 
            this.dgvTimKiemSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiemSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimKiemSP.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvTimKiemSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiemSP.Location = new System.Drawing.Point(771, 94);
            this.dgvTimKiemSP.Name = "dgvTimKiemSP";
            this.dgvTimKiemSP.RowHeadersWidth = 82;
            this.dgvTimKiemSP.RowTemplate.Height = 33;
            this.dgvTimKiemSP.Size = new System.Drawing.Size(874, 857);
            this.dgvTimKiemSP.TabIndex = 0;
            // 
            // cbMaLoai
            // 
            this.cbMaLoai.AutoSize = true;
            this.cbMaLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbMaLoai.Location = new System.Drawing.Point(38, 72);
            this.cbMaLoai.Name = "cbMaLoai";
            this.cbMaLoai.Size = new System.Drawing.Size(123, 33);
            this.cbMaLoai.TabIndex = 2;
            this.cbMaLoai.Text = "Mã loại";
            this.cbMaLoai.UseVisualStyleBackColor = true;
            this.cbMaLoai.CheckedChanged += new System.EventHandler(this.cbMaLoai_CheckedChanged);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.BackColor = System.Drawing.Color.LightGray;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnQuayLai.Location = new System.Drawing.Point(545, 394);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(138, 67);
            this.btnQuayLai.TabIndex = 3;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // cbbTimKiemML
            // 
            this.cbbTimKiemML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbbTimKiemML.FormattingEnabled = true;
            this.cbbTimKiemML.Location = new System.Drawing.Point(244, 68);
            this.cbbTimKiemML.Name = "cbbTimKiemML";
            this.cbbTimKiemML.Size = new System.Drawing.Size(367, 37);
            this.cbbTimKiemML.TabIndex = 6;
            this.cbbTimKiemML.SelectedIndexChanged += new System.EventHandler(this.cbbTimKiemML_SelectedIndexChanged);
            this.cbbTimKiemML.SelectedValueChanged += new System.EventHandler(this.cbbTimKiemML_SelectedValueChanged);
            // 
            // dtpTimKiemHSD
            // 
            this.dtpTimKiemHSD.CustomFormat = "dd/MM/yyyy";
            this.dtpTimKiemHSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dtpTimKiemHSD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimKiemHSD.Location = new System.Drawing.Point(244, 160);
            this.dtpTimKiemHSD.Name = "dtpTimKiemHSD";
            this.dtpTimKiemHSD.Size = new System.Drawing.Size(367, 35);
            this.dtpTimKiemHSD.TabIndex = 7;
            this.dtpTimKiemHSD.Value = new System.DateTime(2024, 4, 8, 0, 0, 0, 0);
            this.dtpTimKiemHSD.ValueChanged += new System.EventHandler(this.dtpTimKiemHSD_ValueChanged);
            // 
            // cbHanSuDung
            // 
            this.cbHanSuDung.AutoSize = true;
            this.cbHanSuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbHanSuDung.Location = new System.Drawing.Point(38, 160);
            this.cbHanSuDung.Name = "cbHanSuDung";
            this.cbHanSuDung.Size = new System.Drawing.Size(179, 33);
            this.cbHanSuDung.TabIndex = 8;
            this.cbHanSuDung.Text = "Hạn sử dụng";
            this.cbHanSuDung.UseVisualStyleBackColor = true;
            this.cbHanSuDung.CheckedChanged += new System.EventHandler(this.cbHanSuDung_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHanSuDung);
            this.groupBox1.Controls.Add(this.dtpTimKiemHSD);
            this.groupBox1.Controls.Add(this.cbbTimKiemML);
            this.groupBox1.Controls.Add(this.cbMaLoai);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 260);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm theo";
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(365, 394);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(150, 67);
            this.btnInBaoCao.TabIndex = 10;
            this.btnInBaoCao.Text = "In báo cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // FormTimKiemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1727, 1002);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuayLai);
            this.Controls.Add(this.dgvTimKiemSP);
            this.Name = "FormTimKiemSanPham";
            this.Text = "FormTimKiemSanPham";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimKiemSanPham_FormClosing);
            this.Load += new System.EventHandler(this.FormTimKiemSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiemSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimKiemSP;
        private System.Windows.Forms.CheckBox cbMaLoai;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.ComboBox cbbTimKiemML;
        private System.Windows.Forms.DateTimePicker dtpTimKiemHSD;
        private System.Windows.Forms.CheckBox cbHanSuDung;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInBaoCao;
    }
}