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
    public partial class FormChiTietHoaDon : Form
    {
        string connectionString = Connection.connectionString;
        // Thuộc tính để lưu trữ mã hóa đơn
        public string MaHoaDon { get; set; }

        private bool isLoggingOut = false;

        public FormChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            txtCT_SoHD.Enabled = false;
            txtCT_SoHD.Text = MaHoaDon;
            loadDataCBBMaSP();
            displayDataCTHD();
        }

        //Lấy ra mã hóa đơn
        public void SetMaHoaDon(string maHoaDon)
        {
            MaHoaDon = maHoaDon;
        }

        //Combobox Mã SP
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
                                cbbCT_MaSP.Items.Add(reader["sMaSanPham"].ToString());
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
        public void displayDataCTHD()
        {
            string query = "hienChiTietHoaDon";
            using(SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@sohd",txtCT_SoHD.Text);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvCTHD.DataSource = datatable;
            }
        }

        //Đơn giá thay đổi khi cbb mã sản phẩm thay đổi
        private void cbbCT_MaSP_TextChanged(object sender, EventArgs e)
        {
            if(cbbCT_MaSP.Text!= "")
            {
                txtCT_Gia.Text = loadDonGia(cbbCT_MaSP.Text).ToString();
            }
            else
            {
                txtCT_Gia.Text = "";
            }
            
        }

        //Lấy đơn giá từ bảng sản phẩm
        private double loadDonGia(string MaSPValue)
        {
            string query = "SELECT fDonGia FROM tblSanPham WHERE sMaSanPham = @masp";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@masp", MaSPValue);
                connection.Open();
                double result = (double)command.ExecuteScalar();
                return result;
            }
        }

        //Lấy số lượng tồn kho từ bảng sản phẩm
        private double soLuongTrongKho(string masp)
        {
            string query = "SELECT fSoLuongKho FROM tblSanPham WHERE sMaSanPham = @masp";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@masp", masp);
                connection.Open();
                double result = (double)command.ExecuteScalar();
                return result;
            }
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

        private void FormChiTietHoaDon_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCT_SoHD.Enabled = false;
            cbbCT_MaSP.Enabled = false;
            int i;
            i = dgvCTHD.CurrentRow.Index;
            txtCT_SoHD.Text = dgvCTHD.Rows[i].Cells[0].Value.ToString();
            cbbCT_MaSP.Text = dgvCTHD.Rows[i].Cells[1].Value.ToString();
            txtCT_SL.Text = dgvCTHD.Rows[i].Cells[2].Value.ToString();
            txtCT_Gia.Text = dgvCTHD.Rows[i].Cells[3].Value.ToString();
            txtCT_GiamGia.Text = dgvCTHD.Rows[i].Cells[4].Value.ToString();
            //txtCT_ThanhTien.Text = dgvCTHD.Rows[i].Cells[4].Value.ToString();
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCT_SoHD.Enabled = false;
            cbbCT_MaSP.Enabled = false;
            int i;
            i = dgvCTHD.CurrentRow.Index;
            txtCT_SoHD.Text = dgvCTHD.Rows[i].Cells[0].Value.ToString();
            cbbCT_MaSP.Text = dgvCTHD.Rows[i].Cells[1].Value.ToString();
            txtCT_SL.Text = dgvCTHD.Rows[i].Cells[2].Value.ToString();
            txtCT_Gia.Text = dgvCTHD.Rows[i].Cells[3].Value.ToString();
            txtCT_GiamGia.Text = dgvCTHD.Rows[i].Cells[4].Value.ToString();
            //txtCT_ThanhTien.Text = dgvCTHD.Rows[i].Cells[4].Value.ToString();
        }

        //Thêm CTHD
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "themChiTietHoaDon";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohd", txtCT_SoHD.Text);
                    cmd.Parameters.AddWithValue("@masp", cbbCT_MaSP.Text);
                    cmd.Parameters.AddWithValue("@soluongmua", Double.Parse(txtCT_SL.Text));
                    cmd.Parameters.AddWithValue("@dongia", Double.Parse(txtCT_Gia.Text));
                    cmd.Parameters.AddWithValue("@mucgiamgia", Double.Parse(txtCT_GiamGia.Text));

                    double soLuongMuaInput = Double.Parse(txtCT_SL.Text);
                    if (soLuongMuaInput > soLuongTrongKho(cbbCT_MaSP.Text))
                    {
                        MessageBox.Show("Số lượng sản phẩm không được nhiều hơn trong kho!");
                    }
                    else
                    {
                        connection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
                            displayDataCTHD();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Thêm chi tiết hóa đơn không thành công!");
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

        //Sửa CTHD

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoaChiTietHoaDon";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@masp", cbbCT_MaSP.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa chi tiết hóa đơn thành công!");
                        displayDataCTHD();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa chi tiết hóa đơn không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(cbbCT_MaSP.Text) || string.IsNullOrEmpty(txtCT_SL.Text) || string.IsNullOrEmpty(txtCT_GiamGia.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn!");
                    return;
                }

                string query = "suaChiTietHoaDon";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohd", txtCT_SoHD.Text);
                    cmd.Parameters.AddWithValue("@masp", cbbCT_MaSP.Text);
                    cmd.Parameters.AddWithValue("@soluongmua", Double.Parse(txtCT_SL.Text));
                    cmd.Parameters.AddWithValue("@dongia", Double.Parse(txtCT_Gia.Text));
                    cmd.Parameters.AddWithValue("@mucgiamgia", Double.Parse(txtCT_GiamGia.Text));

                    if (Double.Parse(txtCT_SL.Text) < 0)
                    {
                        MessageBox.Show("Số lượng mua không hợp lệ");
                        return;
                    }

                    if (Double.Parse(txtCT_GiamGia.Text) < 0)
                    {
                        MessageBox.Show("Mức giảm giá không hợp lệ");
                        return;
                    }

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa hóa đơn thành công");
                        displayDataCTHD();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa hóa đơn không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        private void makeEmpty()
        {
            txtCT_SoHD.Enabled = false;
            cbbCT_MaSP.Text = "";
            txtCT_SL.Text = "";
            txtCT_Gia.Text = "";
            txtCT_GiamGia.Text = "";
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            makeEmpty();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
