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
    public partial class FormNhapHang : Form
    {
        string connectionString = Connection.connectionString;

        private bool isLoggingOut = false;

        public FormNhapHang()
        {
            InitializeComponent();
        }

        private void FormNhapHang_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
            this.BringToFront();
            loadDataCBBMaNV();
            loadDataCBBMaNCC();
            displayDataNH();
        }

        private void displayDataNH()
        {
            string query = "hienDonNhap";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvDonNhap.DataSource = datatable;
            }
        }

        private void loadDataCBBMaNV()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaNV FROM tblNhanVien ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbMaNVNhap.Items.Add(reader["sMaNV"].ToString());
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

        private void loadDataCBBMaNCC()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaNCC FROM tblNhaCungCap ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbMaNCC.Items.Add(reader["sMaNCC"].ToString());
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

        private void FormNhapHang_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn sd
                dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtSoHDNhap.Text) || string.IsNullOrEmpty(cbbMaNVNhap.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                    return;
                }

                //check xem khóa chính đã tồn tại hay chưa
                if (MaHDNhapTonTai(txtSoHDNhap.Text))
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại!");
                    return;
                }

                DateTime ngayNhap = dtpNgayNhap.Value;
                // Kiểm tra ngày nhập không được lớn hơn ngày hiện tại
                if (ngayNhap > DateTime.Now)
                {
                    MessageBox.Show("Ngày nhập không hợp lệ!");
                    return;
                }

                string query = "themDonNhap";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohdnhap", txtSoHDNhap.Text);
                    cmd.Parameters.AddWithValue("@ngaynhap", dtpNgayNhap.Value);
                    cmd.Parameters.AddWithValue("@manv", cbbMaNVNhap.Text);
                    cmd.Parameters.AddWithValue("@mancc", cbbMaNCC.Text);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm đơn nhập thành công");
                        displayDataNH();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm đơn nhập không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        private bool MaHDNhapTonTai(string MaHDNValue)
        {
            string query = "SELECT COUNT(*) FROM tblDonNhap WHERE sSoHDNhap = @sohdnhap";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@sohdnhap", MaHDNValue);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn sd
                dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtSoHDNhap.Text) || string.IsNullOrEmpty(cbbMaNVNhap.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                    return;
                }

                DateTime ngayNhap = dtpNgayNhap.Value;
                // Kiểm tra ngày nhập không được lớn hơn ngày hiện tại
                if (ngayNhap > DateTime.Now)
                {
                    MessageBox.Show("Ngày nhập không hợp lệ!");
                    return;
                }

                string query = "suaDonNhap";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohdnhap", txtSoHDNhap.Text);
                    cmd.Parameters.AddWithValue("@ngaynhap", dtpNgayNhap.Value);
                    cmd.Parameters.AddWithValue("@manv", cbbMaNVNhap.Text);
                    cmd.Parameters.AddWithValue("@mancc", cbbMaNCC.Text);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa đơn nhập thành công");
                        displayDataNH();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa đơn nhập không thành công");
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
                string query = "xoaDonNhap";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohdnhap", txtSoHDNhap.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa đơn nhập thành công!");
                        displayDataNH();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa đơn nhập không thành công!");
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
            txtSoHDNhap.Enabled = true;
            txtSoHDNhap.Text = "";
            dtpNgayNhap.Value = DateTime.Today;
            cbbMaNVNhap.Text = "";
            cbbMaNCC.Text = "";
            txtTongTien.Text = "";
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            makeEmpty();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormTimKiemDonNhap formTimDonNhap = new FormTimKiemDonNhap();
            formTimDonNhap.Show();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            displayDataNH();
        }

        private void dgvDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHDNhap.Enabled = false;
            int i;
            i = dgvDonNhap.CurrentRow.Index;
            txtSoHDNhap.Text = dgvDonNhap.Rows[i].Cells[0].Value.ToString();
            dtpNgayNhap.Text = dgvDonNhap.Rows[i].Cells[1].Value.ToString();
            cbbMaNVNhap.Text = dgvDonNhap.Rows[i].Cells[2].Value.ToString();
            txtTongTien.Text = dgvDonNhap.Rows[i].Cells[3].Value.ToString();
            cbbMaNCC.Text = dgvDonNhap.Rows[i].Cells[4].Value.ToString();
        }

        private void dgvDonNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHDNhap.Enabled = false;
            int i;
            i = dgvDonNhap.CurrentRow.Index;
            txtSoHDNhap.Text = dgvDonNhap.Rows[i].Cells[0].Value.ToString();
            dtpNgayNhap.Text = dgvDonNhap.Rows[i].Cells[1].Value.ToString();
            cbbMaNVNhap.Text = dgvDonNhap.Rows[i].Cells[2].Value.ToString();
            txtTongTien.Text = dgvDonNhap.Rows[i].Cells[3].Value.ToString();
            cbbMaNCC.Text = dgvDonNhap.Rows[i].Cells[4].Value.ToString();
        }

        private void dgvDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị của ô "MaHoaDon" của hàng được chọn
                string maHoaDonNhap = dgvDonNhap.Rows[e.RowIndex].Cells["Số HD"].Value.ToString();

                // Tạo một instance của formChiTietHoaDon
                FormChiTietNhapHang formChiTietNhapHang = new FormChiTietNhapHang();
                // Thiết lập mã hóa đơn trước khi hiển thị form
                formChiTietNhapHang.SetMaHoaDonNhap(maHoaDonNhap);
                formChiTietNhapHang.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTest formTest = new FormTest();
            formTest.Show();
        }
    }
}
