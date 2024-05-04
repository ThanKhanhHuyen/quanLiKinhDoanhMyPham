
namespace FormDangNhap
{
    partial class FormTimKiemDonNhap
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
            this.txtTK_SoHD = new System.Windows.Forms.TextBox();
            this.dtpTK_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTK_NgayNhap = new System.Windows.Forms.CheckBox();
            this.cbTK_SoHD = new System.Windows.Forms.CheckBox();
            this.dgvTKDonNhap = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKDonNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTK_SoHD
            // 
            this.txtTK_SoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK_SoHD.Location = new System.Drawing.Point(274, 81);
            this.txtTK_SoHD.Name = "txtTK_SoHD";
            this.txtTK_SoHD.Size = new System.Drawing.Size(337, 35);
            this.txtTK_SoHD.TabIndex = 2;
            this.txtTK_SoHD.TextChanged += new System.EventHandler(this.txtTK_SoHD_TextChanged);
            // 
            // dtpTK_NgayNhap
            // 
            this.dtpTK_NgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpTK_NgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTK_NgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTK_NgayNhap.Location = new System.Drawing.Point(274, 177);
            this.dtpTK_NgayNhap.Name = "dtpTK_NgayNhap";
            this.dtpTK_NgayNhap.Size = new System.Drawing.Size(337, 35);
            this.dtpTK_NgayNhap.TabIndex = 3;
            this.dtpTK_NgayNhap.Value = new System.DateTime(2024, 4, 13, 0, 0, 0, 0);
            this.dtpTK_NgayNhap.ValueChanged += new System.EventHandler(this.dtpTK_NgayNhap_ValueChanged);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Location = new System.Drawing.Point(542, 381);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(138, 67);
            this.btnQuayLai.TabIndex = 4;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTK_NgayNhap);
            this.groupBox1.Controls.Add(this.cbTK_SoHD);
            this.groupBox1.Controls.Add(this.dtpTK_NgayNhap);
            this.groupBox1.Controls.Add(this.txtTK_SoHD);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(69, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 277);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm theo";
            // 
            // cbTK_NgayNhap
            // 
            this.cbTK_NgayNhap.AutoSize = true;
            this.cbTK_NgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTK_NgayNhap.Location = new System.Drawing.Point(17, 177);
            this.cbTK_NgayNhap.Name = "cbTK_NgayNhap";
            this.cbTK_NgayNhap.Size = new System.Drawing.Size(160, 33);
            this.cbTK_NgayNhap.TabIndex = 5;
            this.cbTK_NgayNhap.Text = "Ngày nhập";
            this.cbTK_NgayNhap.UseVisualStyleBackColor = true;
            this.cbTK_NgayNhap.CheckedChanged += new System.EventHandler(this.cbTK_NgayNhap_CheckedChanged);
            // 
            // cbTK_SoHD
            // 
            this.cbTK_SoHD.AutoSize = true;
            this.cbTK_SoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTK_SoHD.Location = new System.Drawing.Point(17, 83);
            this.cbTK_SoHD.Name = "cbTK_SoHD";
            this.cbTK_SoHD.Size = new System.Drawing.Size(168, 33);
            this.cbTK_SoHD.TabIndex = 4;
            this.cbTK_SoHD.Text = "Số hóa đơn";
            this.cbTK_SoHD.UseVisualStyleBackColor = true;
            this.cbTK_SoHD.CheckedChanged += new System.EventHandler(this.cbTK_SoHD_CheckedChanged);
            // 
            // dgvTKDonNhap
            // 
            this.dgvTKDonNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTKDonNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTKDonNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKDonNhap.Location = new System.Drawing.Point(743, 57);
            this.dgvTKDonNhap.Name = "dgvTKDonNhap";
            this.dgvTKDonNhap.RowHeadersWidth = 82;
            this.dgvTKDonNhap.RowTemplate.Height = 33;
            this.dgvTKDonNhap.Size = new System.Drawing.Size(871, 787);
            this.dgvTKDonNhap.TabIndex = 6;
            // 
            // FormTimKiemDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1668, 897);
            this.Controls.Add(this.dgvTKDonNhap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuayLai);
            this.Name = "FormTimKiemDonNhap";
            this.Text = "FormTimKiemDonNhap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimKiemDonNhap_FormClosing);
            this.Load += new System.EventHandler(this.FormTimKiemDonNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKDonNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtTK_SoHD;
        private System.Windows.Forms.DateTimePicker dtpTK_NgayNhap;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvTKDonNhap;
        private System.Windows.Forms.CheckBox cbTK_NgayNhap;
        private System.Windows.Forms.CheckBox cbTK_SoHD;
    }
}