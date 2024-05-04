using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormDangNhap
{
    public partial class FormChuongTrinh : Form
    {
        string connectionString = Connection.connectionString;

        // Biến cờ để theo dõi xem liệu người dùng đã nhấn nút đăng xuất hay không
        private bool isLoggingOut = false;

        public FormChuongTrinh()
        {
            InitializeComponent();

            // Đặt form cha là MdiContainer
            this.IsMdiContainer = true;
        }

        private void FormChuongTrinh_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen(this);
        }

        //Phương thức để hiển thị form ở giữa màn hình
        private void CenterFormOnScreen(Form form)
        {
            // Tính toán vị trí mới cho form
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = form.Width;
            int formHeight = form.Height;

            // Đặt vị trí mới cho form
            form.Left = (screenWidth - formWidth) / 2;
            form.Top = (screenHeight - formHeight) / 2;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Đặt biến cờ là true khi người dùng nhấn nút đăng xuất
            isLoggingOut = true;

            DialogResult result1 = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, đóng form hiện tại và mở lại form đăng nhập
            if (result1 == DialogResult.Yes)
            {
                this.Close();

                // Mở lại form đăng nhập
                FormDangNhap formdangnhap = new FormDangNhap();
                formdangnhap.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void FormChuongTrinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem liệu sự kiện FormClosing được kích hoạt từ việc nhấn nút đăng xuất hay không
            if (!isLoggingOut && e.CloseReason == CloseReason.UserClosing)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc muốn đóng ứng dụng không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng xác nhận muốn đóng ứng dụng, thì dừng chương trình
                if (result == DialogResult.Yes)
                {
                    Application.Exit(); // Dừng chương trình
                }
                else
                {
                    e.Cancel = true; // Ngăn chặn việc đóng form
                }
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            formNhanVien.MdiParent = this;
            formNhanVien.Dock = DockStyle.Fill;
            formNhanVien.Show();
            formNhanVien.WindowState = FormWindowState.Maximized;
            
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSanPham formSanPham = new FormSanPham();
            formSanPham.MdiParent = this;
            formSanPham.Dock = DockStyle.Fill;
            formSanPham.Show();
            formSanPham.WindowState = FormWindowState.Maximized;
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhachHang formKhachHang= new FormKhachHang();
            formKhachHang.MdiParent = this;
            formKhachHang.Dock = DockStyle.Fill;
            formKhachHang.Show();
            formKhachHang.WindowState = FormWindowState.Maximized;
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDon formHoaDon = new FormHoaDon();
            formHoaDon.MdiParent = this;
            formHoaDon.Dock = DockStyle.Fill;
            formHoaDon.Show();
            formHoaDon.WindowState = FormWindowState.Maximized;
        }

        private void quảnLýNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhapHang formNhapHang= new FormNhapHang();
            formNhapHang.MdiParent = this;
            formNhapHang.Dock = DockStyle.Fill;
            formNhapHang.Show();
            formNhapHang.WindowState = FormWindowState.Maximized;
        }
    }
}
