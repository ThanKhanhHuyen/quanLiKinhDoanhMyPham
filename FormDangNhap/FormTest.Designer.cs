
namespace FormDangNhap
{
    partial class FormTest
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
            this.cbbChonHD = new System.Windows.Forms.ComboBox();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbbChonHD
            // 
            this.cbbChonHD.FormattingEnabled = true;
            this.cbbChonHD.Location = new System.Drawing.Point(243, 97);
            this.cbbChonHD.Name = "cbbChonHD";
            this.cbbChonHD.Size = new System.Drawing.Size(383, 33);
            this.cbbChonHD.TabIndex = 1;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(705, 97);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(148, 61);
            this.btnInBaoCao.TabIndex = 2;
            this.btnInBaoCao.Text = "In Báo Cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1717, 853);
            this.Controls.Add(this.btnInBaoCao);
            this.Controls.Add(this.cbbChonHD);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Load += new System.EventHandler(this.FormTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbChonHD;
        private System.Windows.Forms.Button btnInBaoCao;
    }
}