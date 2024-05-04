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
    public partial class FormTimKiemHoaDon : Form
    {
        string connectionString = Connection.connectionString;

        private bool isLoggingOut = false;

        public FormTimKiemHoaDon()
        {
            InitializeComponent();
        }

        private void FormTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            displayDataTKHD(); 
            txtTKHD_SoHD.Enabled = false;
            cbbTKHD_MaKH.Enabled = false;
            loadDataCBBMaKH();
        }

        private void displayDataTKHD()
        {
            string query = "hienHoaDon";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvTKHD.DataSource = datatable;
            }
        }

        private void FormTimKiemHoaDon_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnQuaylai_Click(object sender, EventArgs e)
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

        private void loadDataCBBMaKH()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaKH FROM tblKhachHang ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbTKHD_MaKH.Items.Add(reader["sMaKH"].ToString());
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

        //Khi nhập liệu vào ô số hóa đơn thay đổi
        private void txtTKHD_SoHD_TextChanged(object sender, EventArgs e)
        {
            if (cbTKHD_SoHD.Checked && !cbTKHD_MaKH.Checked)
            {
                string soHD = txtTKHD_SoHD.Text;
                string query = "SELECT * FROM tblHoaDon WHERE sSoHD LIKE @sohd";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@sohd", "%" + soHD + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKHD.DataSource = datatable;
                }
            }
            else if (cbTKHD_SoHD.Checked && cbTKHD_MaKH.Checked)
            {
                string soHD = txtTKHD_SoHD.Text;
                string maKH = cbbTKHD_MaKH.Text;
                string query = "SELECT sSoHD AS 'Số HD', sMaNV AS 'Mã NV', sMaKH AS 'Mã KH', FORMAT(dNgayLap, 'dd/MM/yyyy') AS 'Ngày lập', fTongTien AS 'Tổng tiền' FROM tblHoaDon WHERE sSoHD LIKE @sohd AND sMaKH LIKE @makh";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@sohd", "%" + soHD + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@makh", "%" + maKH + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKHD.DataSource = datatable;
                }
            }
        }

        //Xử lí khi lựa chọn của cbb mã khách hàng thay đổi
        private void cbbTKHD_MaKH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTKHD_MaKH.Checked && !cbTKHD_SoHD.Checked)
            {
                string maKH = cbbTKHD_MaKH.Text;
                string query = "SELECT * FROM tblHoaDon WHERE sMaKH LIKE @makh";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@makh", "%" + maKH + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKHD.DataSource = datatable;
                }
            }
            else if (cbTKHD_SoHD.Checked && cbTKHD_MaKH.Checked)
            {
                string soHD = txtTKHD_SoHD.Text;
                string maKH = cbbTKHD_MaKH.Text;
                string query = "SELECT sSoHD AS 'Số HD', sMaNV AS 'Mã NV', sMaKH AS 'Mã KH', FORMAT(dNgayLap, 'dd/MM/yyyy') AS 'Ngày lập', fTongTien AS 'Tổng tiền' FROM tblHoaDon WHERE sSoHD LIKE @sohd AND sMaKH LIKE @makh";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@sohd", "%" + soHD + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@makh", "%" + maKH + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKHD.DataSource = datatable;
                }
            }
        }

        private void cbTKHD_SoHD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTKHD_SoHD.Checked && !cbTKHD_MaKH.Checked)
            {
                txtTKHD_SoHD.Enabled = true;
                cbbTKHD_MaKH.Enabled = false;
                string soHD = txtTKHD_SoHD.Text;
                txtTKHD_SoHD_TextChanged(soHD, e);
            }
            else if (!cbTKHD_SoHD.Checked && cbTKHD_MaKH.Checked)
            {
                cbbTKHD_MaKH.Enabled = true;
                txtTKHD_SoHD.Enabled = false;
                string makH = cbbTKHD_MaKH.Text;
                cbbTKHD_MaKH_SelectedValueChanged(makH, e);
            }
            else if (cbTKHD_SoHD.Checked && cbTKHD_MaKH.Checked)
            {
                txtTKHD_SoHD.Enabled = true;
                cbbTKHD_MaKH.Enabled = true;
                string soHD = txtTKHD_SoHD.Text;
                string makH = cbbTKHD_MaKH.Text;
                txtTKHD_SoHD_TextChanged(soHD, e);
                cbbTKHD_MaKH_SelectedValueChanged(makH, e);
            }
            else if (!cbTKHD_SoHD.Checked && !cbTKHD_MaKH.Checked)
            {
                txtTKHD_SoHD.Enabled = false;
                cbbTKHD_MaKH.Enabled = false;
                displayDataTKHD();
            }
        }

        private void cbTKHD_MaKH_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbTKHD_SoHD.Checked && cbTKHD_MaKH.Checked)
            {
                cbbTKHD_MaKH.Enabled = true;
                txtTKHD_SoHD.Enabled = false;
                string makH = cbbTKHD_MaKH.Text;
                cbbTKHD_MaKH_SelectedValueChanged(makH, e);
                
            }
            else if (cbTKHD_SoHD.Checked && !cbTKHD_MaKH.Checked)
            {
                txtTKHD_SoHD.Enabled = true;
                cbbTKHD_MaKH.Enabled = false;
                string soHD = txtTKHD_SoHD.Text;
                txtTKHD_SoHD_TextChanged(soHD, e);
            }
            else if (cbTKHD_SoHD.Checked && cbTKHD_MaKH.Checked)
            {
                txtTKHD_SoHD.Enabled = true;
                cbbTKHD_MaKH.Enabled = true;
                string soHD = txtTKHD_SoHD.Text;
                string makH = cbbTKHD_MaKH.Text;
                txtTKHD_SoHD_TextChanged(soHD, e);
                cbbTKHD_MaKH_SelectedValueChanged(makH, e);
            }
            else if (!cbTKHD_SoHD.Checked && !cbTKHD_MaKH.Checked)
            {
                txtTKHD_SoHD.Enabled = false;
                cbbTKHD_MaKH.Enabled = false;
                displayDataTKHD();
            }
        }
    }
}
