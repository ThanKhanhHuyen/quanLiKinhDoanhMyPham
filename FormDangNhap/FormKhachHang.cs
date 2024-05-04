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
using System.Text.RegularExpressions;

namespace FormDangNhap
{
    public partial class FormKhachHang : Form
    {
        string connectionString = Connection.connectionString;

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
            this.BringToFront();
            displayDataKH();

            // Đặt giới tính mặc định là Nam
            rbNam.Checked = true;
        }

        private void displayDataKH()
        {
            string query = "hienKhachHang";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvKhachHang.DataSource = datatable;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn ngày sinh
                dtpNgaySinhKH.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtDiaChi.Text)
                    || string.IsNullOrEmpty(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!");
                    return;
                }

                //check xem khóa chính đã tồn tại hay chưa
                if (MaKHTonTai(txtMaKH.Text))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!");
                    return;
                }

                DateTime ngaysinh = dtpNgaySinhKH.Value;
                // Kiểm tra ngày sinh phải nhỏ hơn ngày hiện tại
                if (ngaysinh > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!");
                    return;
                }

                if (!IsValidPhoneNumber(txtSDT.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!");
                    return;
                }

                string gioiTinh;
                if (rbNam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else if (rbNu.Checked)
                {
                    gioiTinh = "Nữ";
                }
                else
                {
                    gioiTinh = ""; // hoặc giá trị mặc định khác nếu cần
                }

                string query = "themKhachHang";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@ngaySinh", dtpNgaySinhKH.Value);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm khách hàng thành công");
                        displayDataKH();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        //check mã khách hàng
        private bool MaKHTonTai(string MaKHValue)
        {
            string query = "SELECT COUNT(*) FROM tblKhachHang WHERE sMaKH = @maKH";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@maKH", MaKHValue);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        //Kiểm tra định dạng sdt
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy để kiểm tra định dạng số điện thoại
            string pattern = @"^0\d{9,10}$"; // Số điện thoại bắt đầu bằng số 0 và có 10 hoặc 11 chữ số

            // Kiểm tra xem số điện thoại phù hợp với biểu thức chính quy hay không
            if (Regex.IsMatch(phoneNumber, pattern))
            {
                return true; // Số điện thoại hợp lệ
            }
            else
            {
                return false; // Số điện thoại không hợp lệ
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoaKhachHang";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!");
                        displayDataKH();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        //Làm rỗng
        private void makeEmpty()
        {
            txtMaKH.Enabled = true;
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinhKH.Value= DateTime.Today;
            txtSDT.Text = "";
            rbNam.Checked = true;
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            makeEmpty();
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Enabled = false;
            int i;
            i = dgvKhachHang.CurrentRow.Index;
            txtMaKH.Text = dgvKhachHang.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[i].Cells[2].Value.ToString();
            dtpNgaySinhKH.Text = dgvKhachHang.Rows[i].Cells[3].Value.ToString();
            txtSDT.Text = dgvKhachHang.Rows[i].Cells[4].Value.ToString();

            string gioiTinh = dgvKhachHang.Rows[i].Cells[5].Value.ToString();
            if (gioiTinh == "Nam")
            {
                rbNam.Checked = true;
            }
            else if (gioiTinh == "Nữ")
            {
                rbNu.Checked = true;
            }
            else
            {
                // Xử lý trường hợp không có giới tính hoặc giá trị không hợp lệ
                // Ví dụ: Hiển thị thông báo hoặc xử lý mặc định
                MessageBox.Show("Giới tính không hợp lệ!");
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Enabled = false;
            int i;
            i = dgvKhachHang.CurrentRow.Index;
            txtMaKH.Text = dgvKhachHang.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKhachHang.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvKhachHang.Rows[i].Cells[2].Value.ToString();
            dtpNgaySinhKH.Text = dgvKhachHang.Rows[i].Cells[3].Value.ToString();
            txtSDT.Text = dgvKhachHang.Rows[i].Cells[4].Value.ToString();

            string gioiTinh = dgvKhachHang.Rows[i].Cells[5].Value.ToString();
            if (gioiTinh == "Nam")
            {
                rbNam.Checked = true;
            }
            else if (gioiTinh == "Nữ")
            {
                rbNu.Checked = true;
            }
            else
            {
                // Xử lý trường hợp không có giới tính hoặc giá trị không hợp lệ
                // Ví dụ: Hiển thị thông báo hoặc xử lý mặc định
                MessageBox.Show("Giới tính không hợp lệ!");
            }
        }

        private void btnSửa_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn ngày sinh
                dtpNgaySinhKH.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtDiaChi.Text)
                    || string.IsNullOrEmpty(txtSDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!");
                    return;
                }

                DateTime ngaysinh = dtpNgaySinhKH.Value;
                // Kiểm tra ngày sinh phải nhỏ hơn ngày hiện tại
                if (ngaysinh > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!");
                    return;
                }

                if (!IsValidPhoneNumber(txtSDT.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!");
                    return;
                }

                string gioiTinh;
                if (rbNam.Checked)
                {
                    gioiTinh = "Nam";
                }
                else if (rbNu.Checked)
                {
                    gioiTinh = "Nữ";
                }
                else
                {
                    gioiTinh = ""; // hoặc giá trị mặc định khác nếu cần
                }

                string query = "suaKhachHang";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@ngaySinh", dtpNgaySinhKH.Value);
                    cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa thông tin thành công");
                        displayDataKH();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin  không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormTimKiemKhachHang formTimKiemKH = new FormTimKiemKhachHang();
            formTimKiemKH.Show();
        }
    }
}
