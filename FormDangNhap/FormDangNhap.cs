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
    public partial class FormDangNhap : Form
    {
        string connectionString = Connection.connectionString;
        private int wrongAttempts = 0;

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            CenterFormOnScreen(this);
        }

        // Phương thức để hiển thị form ở giữa màn hình
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

        //Sự kiện nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            Application.Exit();
        }

        //Sự kiện nút đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng phương thức nếu thông tin không đủ
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM tblTaiKhoan WHERE TenDangNhap = @Username AND MatKhau = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // Đặt lại số lần nhập sai nếu đăng nhập thành công
                            wrongAttempts = 0;

                            FormChuongTrinh f = new FormChuongTrinh();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Tăng số lần nhập sai và kiểm tra xem đã vượt quá số lần cho phép chưa
                            wrongAttempts++;
                            if (wrongAttempts >= 3)
                            {
                                MessageBox.Show("Bạn đã nhập sai quá 3 lần. Vui lòng liên hệ với quản trị viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                btnDangNhap.Enabled = false; // Vô hiệu hóa nút đăng nhập
                            }
                            else
                            {
                                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Bạn còn " + (3 - wrongAttempts) + " lần thử.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn nút đóng form
            if (e.CloseReason == CloseReason.UserClosing)
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
    }
}
