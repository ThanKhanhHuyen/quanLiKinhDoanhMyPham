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
    public partial class FormHoaDon : Form
    {
        string connectionString = Connection.connectionString;

        private bool isLoggingOut = false;

        public FormHoaDon()
        {
            InitializeComponent();
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
            this.BringToFront();
            loadDataCBBMaNV();
            loadDataCBBMaKH();
            displayDataHD();
        }

        private void displayDataHD()
        {
            string query = "hienHoaDon";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvHoaDon.DataSource = datatable;
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
                                cbbMaNV.Items.Add(reader["sMaNV"].ToString());
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
                                cbbMaKH.Items.Add(reader["sMaKH"].ToString());
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

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn sd
                dtpNgayLapHD.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtSoHD.Text) || string.IsNullOrEmpty(cbbMaNV.Text) || string.IsNullOrEmpty(cbbMaKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn!");
                    return;
                }

                //check xem khóa chính đã tồn tại hay chưa
                if (MaHDTonTai(txtSoHD.Text))
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại!");
                    return;
                }

                int maSoThue;
                //Kiểm tra xem người dùng nhập vào có phải số nguyên không và độ dài < 10 không
                if (!int.TryParse(txtMaSoThue.Text, out maSoThue) || txtMaSoThue.Text.Length > 10)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên có tối đa 10 ký tự cho mã số thuế.");
                    return;
                }

                if (MaSoThueTonTai(maSoThue))
                {
                    MessageBox.Show("Mã số thuế đã tồn tại!");
                    return;
                }

                DateTime ngayLap = dtpNgayLapHD.Value;
                // Kiểm tra hạn sử dụng phải lớn hơn ngày hiện tại
                if (ngayLap > DateTime.Now)
                {
                    MessageBox.Show("Ngày lập không hợp lệ!");
                    return;
                }

                string query = "themHoaDon";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohd", txtSoHD.Text);
                    cmd.Parameters.AddWithValue("@manv", cbbMaNV.Text);
                    cmd.Parameters.AddWithValue("@makh", cbbMaKH.Text);
                    cmd.Parameters.AddWithValue("@ngaylap", dtpNgayLapHD.Value);
                    cmd.Parameters.AddWithValue("@masothue", txtMaSoThue.Text);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công");
                        displayDataHD();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        private bool MaHDTonTai(string MaHDValue)
        {
            string query = "SELECT COUNT(*) FROM tblHoaDon WHERE sSoHD = @sohd";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@sohd", MaHDValue);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private bool MaSoThueTonTai(int MaSoThueValue)
        {
            string query = "SELECT COUNT(*) FROM tblHoaDon WHERE MaSoThue = @masothue";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@masothue", SqlDbType.Int).Value = MaSoThueValue;
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn sd
                dtpNgayLapHD.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtSoHD.Text) || string.IsNullOrEmpty(cbbMaNV.Text) || string.IsNullOrEmpty(cbbMaKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn!");
                    return;
                }

                int maSoThue;
                //Kiểm tra xem người dùng nhập vào có phải số nguyên không và độ dài < 10 không
                if (!int.TryParse(txtMaSoThue.Text, out maSoThue) || txtMaSoThue.Text.Length > 10)
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên có tối đa 10 ký tự cho mã số thuế.");
                    return;
                }

                if (MaSoThueTonTai(maSoThue))
                {
                    MessageBox.Show("Mã số thuế đã tồn tại!");
                    return;
                }

                DateTime ngayLap = dtpNgayLapHD.Value;
                // Kiểm tra ngày lập không được lớn hơn ngày hiện tại
                if (ngayLap > DateTime.Now)
                {
                    MessageBox.Show("Ngày lập không hợp lệ!");
                    return;
                }

                string query = "suaHoaDon";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohd", txtSoHD.Text);
                    cmd.Parameters.AddWithValue("@manv", cbbMaNV.Text);
                    cmd.Parameters.AddWithValue("@makh", cbbMaKH.Text);
                    cmd.Parameters.AddWithValue("@ngaylap", dtpNgayLapHD.Value);
                    cmd.Parameters.AddWithValue("@masothue", txtMaSoThue.Text);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa hóa đơn thành công");
                        displayDataHD();
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

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoaHoaDon";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sohd", txtSoHD.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa hóa đơn thành công!");
                        displayDataHD();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa hóa đơn không thành công!");
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
            txtSoHD.Enabled = true;
            txtSoHD.Text = "";
            cbbMaNV.Text = "";
            cbbMaKH.Text = "";
            dtpNgayLapHD.Value = DateTime.Today;
            txtTongTien.Text = "";
            txtMaSoThue.Text = "";
        }

        private void btnReSetr_Click(object sender, EventArgs e)
        {
            makeEmpty();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHD.Enabled = false;
            int i;
            i = dgvHoaDon.CurrentRow.Index;
            txtSoHD.Text = dgvHoaDon.Rows[i].Cells[0].Value.ToString();
            cbbMaNV.Text = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
            cbbMaKH.Text = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
            dtpNgayLapHD.Text = dgvHoaDon.Rows[i].Cells[3].Value.ToString();
            txtTongTien.Text = dgvHoaDon.Rows[i].Cells[4].Value.ToString();
            txtTongTien.Text = dgvHoaDon.Rows[i].Cells[4].Value.ToString();
            txtMaSoThue.Text = dgvHoaDon.Rows[i].Cells[5].Value.ToString();
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoHD.Enabled = false;
            int i;
            i = dgvHoaDon.CurrentRow.Index;
            txtSoHD.Text = dgvHoaDon.Rows[i].Cells[0].Value.ToString();
            cbbMaNV.Text = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
            cbbMaKH.Text = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
            dtpNgayLapHD.Text = dgvHoaDon.Rows[i].Cells[3].Value.ToString();
            txtTongTien.Text = dgvHoaDon.Rows[i].Cells[4].Value.ToString();
            txtMaSoThue.Text = dgvHoaDon.Rows[i].Cells[5].Value.ToString();
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            FormTimKiemHoaDon formTimHD = new FormTimKiemHoaDon();
            formTimHD.Show();
        }

        private void dgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy giá trị của ô "MaHoaDon" của hàng được chọn
                string maHoaDon = dgvHoaDon.Rows[e.RowIndex].Cells["Số HD"].Value.ToString();

                // Tạo một instance của formChiTietHoaDon
                FormChiTietHoaDon formChiTietHoaDon = new FormChiTietHoaDon();
                // Thiết lập mã hóa đơn trước khi hiển thị form
                formChiTietHoaDon.SetMaHoaDon(maHoaDon);
                formChiTietHoaDon.Show();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            displayDataHD();
        }

        private void FormHoaDon_FormClosing(object sender, FormClosingEventArgs e)
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


        private void btnInBaoCaoHD_Click(object sender, EventArgs e)
        {
            int maSoThueA, maSoThueB;
            if (!int.TryParse(txta.Text, out maSoThueA) || !int.TryParse(txtb.Text, out maSoThueB))
            {
                MessageBox.Show("Vui lòng nhập số nguyên cho mã số thuế.");
                return;
            }

            string query = "SELECT tblKhachHang.sTenKh, tblHoaDon.MaSoThue " +
                           "FROM tblKhachHang " +
                           "JOIN tblHoaDon ON tblHoaDon.sMaKH = tblKhachHang.sMaKH " +
                           "WHERE tblHoaDon.MaSoThue BETWEEN @masothueA AND @masothueB " +
                           "GROUP BY tblHoaDon.MaSoThue, tblKhachHang.sTenKh";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@masothueA", maSoThueA);
                adapter.SelectCommand.Parameters.AddWithValue("@masothueB", maSoThueB);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                rptThi1 report = new rptThi1();
                report.SetDataSource(datatable);

                FormInBaoCao formInBaoCao = new FormInBaoCao();
                formInBaoCao.crystalReportViewer1.ReportSource = report;
                formInBaoCao.ShowDialog();
            }
        }
    }
}
