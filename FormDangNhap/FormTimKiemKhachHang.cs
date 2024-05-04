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
    public partial class FormTimKiemKhachHang : Form
    {
        string connectionString = Connection.connectionString;
        // Biến cờ để theo dõi xem liệu người dùng đã nhấn nút đăng xuất hay không
        private bool isLoggingOut = false;

        public FormTimKiemKhachHang()
        {
            InitializeComponent();
        }

        private void btnQuaylaiKH_Click(object sender, EventArgs e)
        {
            // Đặt biến cờ là true khi người dùng nhấn nút đăng xuất
            isLoggingOut = true;

            DialogResult result1 = MessageBox.Show("Bạn muốn dừng tìm kiếm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, đóng form hiện tại và mở lại form đăng nhập
            if (result1 == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormTimKiemKhachHang_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FormTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            displayDataTKKH();
        }

        private void displayDataTKKH()
        {
            string query = "hienKhachHang";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvTimKiemKH.DataSource = datatable;
            }
        }

        private void btnTimKiem_KH_Click(object sender, EventArgs e)
        {
            if (cbTenKH.Checked == true && cbGioiTinh.Checked == false)
            {
                string tenKH = txtTimKiemTKH.Text;
                string query = "SELECT * FROM tblKhachHang WHERE sTenKh LIKE @tenkh";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@tenkh", "%" + tenKH + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemKH.DataSource = datatable;
                }
            }

            if (cbTenKH.Checked == false && cbGioiTinh.Checked == true)
            {
                string gioiTinh = "";
                if (rbTKNam.Checked == true)
                {
                    gioiTinh = "Nam";
                    string query = "SELECT * FROM tblKhachHang WHERE sGioiTinh LIKE @gioitinh";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@gioitinh", "%" + gioiTinh + "%");
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        dgvTimKiemKH.DataSource = datatable;
                    }
                }

                if (rbTKNu.Checked == true)
                {
                    gioiTinh = "Nữ";
                    string query = "SELECT * FROM tblKhachHang WHERE sGioiTinh LIKE @gioitinh";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@gioitinh", "%" + gioiTinh + "%");
                        DataTable datatable = new DataTable();
                        adapter.Fill(datatable);
                        dgvTimKiemKH.DataSource = datatable;
                    }
                }
            }

            if (cbTenKH.Checked == true && cbGioiTinh.Checked == true)
            {
                string tenKH = txtTimKiemTKH.Text;
                string gioiTinh = "";
                if (rbTKNam.Checked == true)
                {
                    gioiTinh = "Nam";                   
                }

                if (rbTKNu.Checked == true)
                {
                    gioiTinh = "Nữ";                
                }
                string query = "SELECT * FROM tblKhachHang WHERE sTenKh LIKE @tenkh AND sGioiTinh LIKE @gioitinh";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@tenkh", "%" + tenKH + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@gioitinh", "%" + gioiTinh + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemKH.DataSource = datatable;
                }
            }
        }

        private void cbTenKH_CheckedChanged(object sender, EventArgs e)
        {
            if(!cbTenKH.Checked && !cbGioiTinh.Checked)
            {
                displayDataTKKH();
            }
        }

        private void cbGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbTenKH.Checked && !cbGioiTinh.Checked)
            {
                displayDataTKKH();
            }
        }
    }
}
