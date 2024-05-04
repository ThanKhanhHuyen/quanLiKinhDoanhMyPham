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
    public partial class FormChiTietNhapHang : Form
    {
        string connectionString = Connection.connectionString;
        // Thuộc tính để lưu trữ mã hóa đơn
        public string MaHoaDonNhap { get; set; }

        private bool isLoggingOut = false;

        public FormChiTietNhapHang()
        {
            InitializeComponent();
        }

        private void FormChiTietNhapHang_Load(object sender, EventArgs e)
        {
            txtSoHDNhap.Enabled = false;
            txtSoHDNhap.Text = MaHoaDonNhap;
            loadDataCBBMaSP();
            displayDataCTNH();
        }

        public void SetMaHoaDonNhap(string maHoaDonNhap)
        {
            MaHoaDonNhap = maHoaDonNhap;
        }

        private void loadDataCBBMaSP()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaSanPham FROM tblSanPham";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbMaSPNhap.Items.Add(reader["sMaSanPham"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        //Hiển thị CTHD
        public void displayDataCTNH()
        {
            string query = "hienChiTietDonNhap";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@sohdnhap", txtSoHDNhap.Text);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvCTNH.DataSource = datatable;
            }
        }

        private void FormChiTietNhapHang_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvCTNH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHDNhap.Enabled = false;
            cbbMaSPNhap.Enabled = false;
            int i;
            i = dgvCTNH.CurrentRow.Index;
            txtSoHDNhap.Text = dgvCTNH.Rows[i].Cells[0].Value.ToString();
            cbbMaSPNhap.Text = dgvCTNH.Rows[i].Cells[1].Value.ToString();
            txtSLNhap.Text = dgvCTNH.Rows[i].Cells[2].Value.ToString();
            txtGiaNhap.Text = dgvCTNH.Rows[i].Cells[3].Value.ToString();
        }

        private void dgvCTNH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHDNhap.Enabled = false;
            cbbMaSPNhap.Enabled = false;
            int i;
            i = dgvCTNH.CurrentRow.Index;
            txtSoHDNhap.Text = dgvCTNH.Rows[i].Cells[0].Value.ToString();
            cbbMaSPNhap.Text = dgvCTNH.Rows[i].Cells[1].Value.ToString();
            txtSLNhap.Text = dgvCTNH.Rows[i].Cells[2].Value.ToString();
            txtGiaNhap.Text = dgvCTNH.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "themChiTietDonNhap";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohdnhap", txtSoHDNhap.Text);
                    cmd.Parameters.AddWithValue("@masp", cbbMaSPNhap.Text);
                    cmd.Parameters.AddWithValue("@soluongnhap", Double.Parse(txtSLNhap.Text));
                    cmd.Parameters.AddWithValue("@gianhap", Double.Parse(txtGiaNhap.Text));

                    if (Double.Parse(txtSLNhap.Text) <= 0)
                    {
                        MessageBox.Show("Số lượng nhập phải lớn hơn 0!");
                    }
                    else
                    {
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm chi tiết đơn nhập thành công!");
                            displayDataCTNH();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Thêm chi tiết đơn nhập không thành công!");
                            return;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "suaChiTietDonNhap";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohdnhap", txtSoHDNhap.Text);
                    cmd.Parameters.AddWithValue("@masp", cbbMaSPNhap.Text);
                    cmd.Parameters.AddWithValue("@soluongnhap", Double.Parse(txtSLNhap.Text));
                    cmd.Parameters.AddWithValue("@gianhap", Double.Parse(txtGiaNhap.Text));

                    if (Double.Parse(txtSLNhap.Text) <= 0)
                    {
                        MessageBox.Show("Số lượng nhập phải lớn hơn 0!");
                    }

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa chi tiết đơn nhập thành công");
                        displayDataCTNH();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa chi tiết đơn nhập không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoaChiTietDonNhap";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maspnhap", cbbMaSPNhap.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa chi tiết đơn nhập thành công!");
                        displayDataCTNH();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa chi tiết đơn nhập không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void makeEmpty()
        {
            txtSoHDNhap.Enabled = false;
            cbbMaSPNhap.Text = "";
            txtSLNhap.Text = "";
            txtGiaNhap.Text = "";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            makeEmpty();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            // Đặt biến cờ là true khi người dùng nhấn nút đăng xuất
            isLoggingOut = true;

            DialogResult result1 = MessageBox.Show("Bạn muốn quay lại trang trước?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, đóng form hiện tại và mở lại form đăng nhập
            if (result1 == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
