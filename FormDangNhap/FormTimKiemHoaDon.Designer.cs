
namespace FormDangNhap
{
    partial class FormTimKiemHoaDon
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
            this.cbTKHD_SoHD = new System.Windows.Forms.CheckBox();
            this.txtTKHD_SoHD = new System.Windows.Forms.TextBox();
            this.cbTKHD_MaKH = new System.Windows.Forms.CheckBox();
            this.cbbTKHD_MaKH = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvTKHD = new System.Windows.Forms.DataGridView();
            this.btnQuaylai = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKHD)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTKHD_SoHD
            // 
            this.cbTKHD_SoHD.AutoSize = true;
            this.cbTKHD_SoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTKHD_SoHD.Location = new System.Drawing.Point(40, 73);
            this.cbTKHD_SoHD.Name = "cbTKHD_SoHD";
            this.cbTKHD_SoHD.Size = new System.Drawing.Size(168, 33);
            this.cbTKHD_SoHD.TabIndex = 0;
            this.cbTKHD_SoHD.Text = "Số hóa đơn";
            this.cbTKHD_SoHD.UseVisualStyleBackColor = true;
            this.cbTKHD_SoHD.CheckedChanged += new System.EventHandler(this.cbTKHD_SoHD_CheckedChanged);
            // 
            // txtTKHD_SoHD
            // 
            this.txtTKHD_SoHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTKHD_SoHD.Location = new System.Drawing.Point(249, 73);
            this.txtTKHD_SoHD.Name = "txtTKHD_SoHD";
            this.txtTKHD_SoHD.Size = new System.Drawing.Size(339, 35);
            this.txtTKHD_SoHD.TabIndex = 2;
            this.txtTKHD_SoHD.TextChanged += new System.EventHandler(this.txtTKHD_SoHD_TextChanged);
            // 
            // cbTKHD_MaKH
            // 
            this.cbTKHD_MaKH.AutoSize = true;
            this.cbTKHD_MaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTKHD_MaKH.Location = new System.Drawing.Point(40, 164);
            this.cbTKHD_MaKH.Name = "cbTKHD_MaKH";
            this.cbTKHD_MaKH.Size = new System.Drawing.Size(206, 33);
            this.cbTKHD_MaKH.TabIndex = 3;
            this.cbTKHD_MaKH.Text = "Mã khách hàng";
            this.cbTKHD_MaKH.UseVisualStyleBackColor = true;
            this.cbTKHD_MaKH.CheckedChanged += new System.EventHandler(this.cbTKHD_MaKH_CheckedChanged);
            // 
            // cbbTKHD_MaKH
            // 
            this.cbbTKHD_MaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTKHD_MaKH.FormattingEnabled = true;
            this.cbbTKHD_MaKH.Location = new System.Drawing.Point(249, 164);
            this.cbbTKHD_MaKH.Name = "cbbTKHD_MaKH";
            this.cbbTKHD_MaKH.Size = new System.Drawing.Size(346, 37);
            this.cbbTKHD_MaKH.TabIndex = 4;
            this.cbbTKHD_MaKH.SelectedValueChanged += new System.EventHandler(this.cbbTKHD_MaKH_SelectedValueChanged);
            // 
            // dgvTKHD
            // 
            this.dgvTKHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTKHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTKHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKHD.Location = new System.Drawing.Point(751, 57);
            this.dgvTKHD.Name = "dgvTKHD";
            this.dgvTKHD.RowHeadersWidth = 82;
            this.dgvTKHD.RowTemplate.Height = 33;
            this.dgvTKHD.Size = new System.Drawing.Size(902, 847);
            this.dgvTKHD.TabIndex = 5;
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.BackColor = System.Drawing.Color.Silver;
            this.btnQuaylai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuaylai.Location = new System.Drawing.Point(503, 338);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(138, 67);
            this.btnQuaylai.TabIndex = 6;
            this.btnQuaylai.Text = "Quay lại";
            this.btnQuaylai.UseVisualStyleBackColor = false;
            this.btnQuaylai.Click += new System.EventHandler(this.btnQuaylai_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbTKHD_MaKH);
            this.groupBox1.Controls.Add(this.cbTKHD_MaKH);
            this.groupBox1.Controls.Add(this.txtTKHD_SoHD);
            this.groupBox1.Controls.Add(this.cbTKHD_SoHD);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(46, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 256);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm theo";
            // 
            // FormTimKiemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1785, 1001);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuaylai);
            this.Controls.Add(this.dgvTKHD);
            this.Name = "FormTimKiemHoaDon";
            this.Text = "FormTimKiemHoaDon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimKiemHoaDon_FormClosing);
            this.Load += new System.EventHandler(this.FormTimKiemHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKHD)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbTKHD_SoHD;
        private System.Windows.Forms.TextBox txtTKHD_SoHD;
        private System.Windows.Forms.CheckBox cbTKHD_MaKH;
        private System.Windows.Forms.ComboBox cbbTKHD_MaKH;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvTKHD;
        private System.Windows.Forms.Button btnQuaylai;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}