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
    public partial class FormNhanVien : Form
    {
        string connectionString = Connection.connectionString;
        
        public FormNhanVien()
        {
            InitializeComponent();
            
        }

        //Xử lý sự kiện Form_Load
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
            this.BringToFront();
            displayData();         
        }

        //Hàm hiện nhân viên
        private void displayData()
        {
            string query = "hiennhanvien";
            using(SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvNhanVien.DataSource = datatable;
            }
        }

        //Sự kiện Click nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại ngày sinh và ngày vào làm
                dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
                dtpNgayVaoLam.CustomFormat = "dd/MM/yyyy";
                //check xem khóa chính đã tồn tại hay chưa
                if (KhoaChinhTonTai(txtMaNV.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    return;
                }
                if (CCCDTonTai(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD không được trùng nhau!");
                    return;
                }
                string query = "themnhanvien";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@ngayvaolam", dtpNgayVaoLam.Value);
                    cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmd.Parameters.AddWithValue("@luongcoban", Double.Parse(txtLuongCoBan.Text));
                    cmd.Parameters.AddWithValue("@phucap", Double.Parse(txtPhuCap.Text));

                    //check lương cơ bản và phụ cấp không được nhỏ hơn 0
                    if (Double.Parse(txtLuongCoBan.Text) < 0)
                    {
                        MessageBox.Show("Lương cơ bản phải lớn hơn 0!");
                        return;
                    }
                    if (Double.Parse(txtPhuCap.Text) < 0)
                    {
                        MessageBox.Show("Phụ cấp phải lớn hơn 0!");
                        return;
                    }

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm nhân viên thành công");
                        displayData();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên không thành công");
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        //check khóa chính
        private bool KhoaChinhTonTai(string KhoaChinhValue)
        {
            string query = "SELECT COUNT(*) FROM tblNhanVien WHERE sMaNV = @manv";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@manv", KhoaChinhValue);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        //check CCCD
        private bool CCCDTonTai(string CCCDValue)
        {
            string query = "SELECT COUNT(*) FROM tblNhanVien WHERE sCCCD = @cccd";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@cccd", CCCDValue);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        //Sự kiện Click nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoanhanvien";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        displayData();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên không thành công!");
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        //Làm rỗng
        private void makeEmpty()
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
            txtLuongCoBan.Text = "";
            txtPhuCap.Text = "";
            dtpNgaySinh.Value = DateTime.Today;
            dtpNgayVaoLam.Value = DateTime.Today;
        }

        //Sự kiện Click nút Bỏ chọn
        private void btnBoChon_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
            txtLuongCoBan.Text = "";
            txtPhuCap.Text = "";
            dtpNgaySinh.Value = DateTime.Today;
            dtpNgayVaoLam.Value = DateTime.Today;
        }

        //Tính lương
        private void btnTinhLuong_Click_1(object sender, EventArgs e)
        {
            if (txtTenNV.Text != "")
            {
                double luongCB = double.Parse(txtLuongCoBan.Text);
                double phuCap = double.Parse(txtPhuCap.Text);
                double result = luongCB + phuCap;
                MessageBox.Show("Lương của nhân viên " + txtTenNV.Text + " là: " + result);
            }
            else
            {
                MessageBox.Show("Vui lòng điền đẩy đủ thông tin nhân viên!");
            }
        }

        // Sửa nhân viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string oldCCCD = GetOldCCCD(txtMaNV.Text);

                // Kiểm tra xem CCCD mới có trùng với CCCD cũ không
                if (txtCCCD.Text != oldCCCD && CCCDTonTai(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD không được trùng nhau!");
                    return;
                }

                string query = "suaNhanVien";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@ngayvaolam", dtpNgayVaoLam.Value);
                    cmd.Parameters.AddWithValue("@cccd", txtCCCD.Text);
                    cmd.Parameters.AddWithValue("@luongcoban", Double.Parse(txtLuongCoBan.Text));
                    cmd.Parameters.AddWithValue("@phucap", Double.Parse(txtPhuCap.Text));
                    connection.Open();
                    if (Double.Parse(txtLuongCoBan.Text) < 0)
                    {
                        MessageBox.Show("Lương cơ bản không được nhỏ hơn 0!");
                        return;
                    }
                    if (Double.Parse(txtPhuCap.Text) < 0)
                    {
                        MessageBox.Show("Phụ cấp không được nhỏ hơn 0!");
                        return;
                    }
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa nhân viên thành công!");
                        displayData();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhân viên không thành công!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        // Hàm để lấy CCCD cũ của nhân viên
        private string GetOldCCCD(string maNV)
        {
            string query = "SELECT sCCCD FROM tblNhanVien WHERE sMaNV = @maNV";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@maNV", maNV);
                connection.Open();
                return (string)cmd.ExecuteScalar();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormTimKiemNhanVien formTimKiemNV = new FormTimKiemNhanVien();
            formTimKiemNV.Show();
        }

        private void dgvNhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Enabled = false;
            int i;
            i = dgvNhanVien.CurrentRow.Index;
            txtMaNV.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            dtpNgayVaoLam.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
            txtLuongCoBan.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            txtPhuCap.Text = dgvNhanVien.Rows[i].Cells[7].Value.ToString();
        }

        private void dgvNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Enabled = false;
            int i;
            i = dgvNhanVien.CurrentRow.Index;
            txtMaNV.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            dtpNgayVaoLam.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            txtCCCD.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
            txtLuongCoBan.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            txtPhuCap.Text = dgvNhanVien.Rows[i].Cells[7].Value.ToString();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string query = "select * from tblNhanVien";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                
                rptNV report = new rptNV();
                report.SetDataSource(datatable);
                FormInBaoCao formInBaoCao = new FormInBaoCao();
                formInBaoCao.crystalReportViewer1.ReportSource = report;
                formInBaoCao.ShowDialog();
            }

        }
    }
}
