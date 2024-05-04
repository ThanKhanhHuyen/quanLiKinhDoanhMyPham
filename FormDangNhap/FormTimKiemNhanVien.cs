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
using Serilog;

namespace FormDangNhap
{
    public partial class FormTimKiemNhanVien : Form
    {
        string connectionString = Connection.connectionString;
        // Biến cờ để theo dõi xem liệu người dùng đã nhấn nút đăng xuất hay không
        private bool isLoggingOut = false;


        public FormTimKiemNhanVien()
        {
            InitializeComponent();        
        }

        private void FormTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            displayDataTKVN();
            dtpTimKiemNVL.Enabled = false;
            txtTimKiemMNV.Enabled = false;
        }

        private void displayDataTKVN()
        {
            string query = "hiennhanvien";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvTimKiemNV.DataSource = datatable;
            }
        }

        private void FormTimKiemNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnQuayLai_Click(object sender, EventArgs e)
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
        
        /*private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            if(cbMaNV.Checked == true)
            {
                string maNV = txtTimKiemMNV.Text;
                string query = "SELECT * FROM tblNhanVien WHERE sMaNV LIKE @manv";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@manv", "%"+maNV+"%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemNV.DataSource = datatable;
                }
            }
            
            if(cbNgayVaoLam.Checked == true)
            {
                
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");

                string query = "SELECT sMaNV AS 'Mã NV', sTenNV AS 'Tên NV', sDiaChi AS 'Địa chỉ', FORMAT(dNgaySinh, 'dd/MM/yyyy') AS 'Ngày sinh', FORMAT(dNgayVaoLam, 'dd/MM/yyyy') AS 'Ngày vào làm', sCCCD AS 'CCCD', fLuongCoBan AS 'Lương cơ bản', fPhuCap AS 'Phụ cấp' FROM tblNhanVien WHERE FORMAT(dNgayVaoLam, 'dd/MM/yyyy') LIKE @ngayvaolam";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {

                    adapter.SelectCommand.Parameters.AddWithValue("@ngayvaolam", "%" + ngayVaoLam + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemNV.DataSource = datatable;
                }
             
                
            }
            if (cbMaNV.Checked == true && cbNgayVaoLam.Checked == true)
            {
                string maNV = txtTimKiemMNV.Text;
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");

                string query = "SELECT sMaNV AS 'Mã NV', sTenNV AS 'Tên NV', sDiaChi AS 'Địa chỉ', FORMAT(dNgaySinh, 'dd/MM/yyyy') AS 'Ngày sinh', FORMAT(dNgayVaoLam, 'dd/MM/yyyy') AS 'Ngày vào làm', sCCCD AS 'CCCD', fLuongCoBan AS 'Lương cơ bản', fPhuCap AS 'Phụ cấp' FROM tblNhanVien WHERE FORMAT(dNgayVaoLam, 'dd/MM/yyyy') LIKE @ngayvaolam AND sMaNV LIKE @manv";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@manv", "%" + maNV + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@ngayvaolam", "%" + ngayVaoLam + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemNV.DataSource = datatable;
                }
            }
        }*/

        //Xử lí khi người dùng thay đổi giá trị của Textbox
        private void txtTimKiemMNV_TextChanged(object sender, EventArgs e)
        {
            if (cbMaNV.Checked && !cbNgayVaoLam.Checked)
            {
                string maNV = txtTimKiemMNV.Text;
                string query = "SELECT * FROM tblNhanVien WHERE sMaNV LIKE @manv";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@manv", "%" + maNV + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemNV.DataSource = datatable;
                }
            }
            else if (cbMaNV.Checked && cbNgayVaoLam.Checked) 
            {
                string maNV = txtTimKiemMNV.Text;
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");
                string query = "SELECT sMaNV AS 'Mã NV', sTenNV AS 'Tên NV', sDiaChi AS 'Địa chỉ', FORMAT(dNgaySinh, 'dd/MM/yyyy') AS 'Ngày sinh', FORMAT(dNgayVaoLam, 'dd/MM/yyyy') AS 'Ngày vào làm', sCCCD AS 'CCCD', fLuongCoBan AS 'Lương cơ bản', fPhuCap AS 'Phụ cấp' FROM tblNhanVien WHERE FORMAT(dNgayVaoLam, 'dd/MM/yyyy') LIKE @ngayvaolam AND sMaNV LIKE @manv";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@manv", "%" + maNV + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@ngayvaolam", "%" + ngayVaoLam + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemNV.DataSource = datatable;
                }
            }     
        }

        //Xử lí khi người dùng thay đổi giá trị của datetimepicker
        private void dtpTimKiemNVL_ValueChanged(object sender, EventArgs e)
        {
            if (cbNgayVaoLam.Checked && !cbMaNV.Checked)
            {
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");
                string query = "SELECT sMaNV AS 'Mã NV', sTenNV AS 'Tên NV', sDiaChi AS 'Địa chỉ', FORMAT(dNgaySinh, 'dd/MM/yyyy') AS 'Ngày sinh', FORMAT(dNgayVaoLam, 'dd/MM/yyyy') AS 'Ngày vào làm', sCCCD AS 'CCCD', fLuongCoBan AS 'Lương cơ bản', fPhuCap AS 'Phụ cấp' FROM tblNhanVien WHERE FORMAT(dNgayVaoLam, 'dd/MM/yyyy') LIKE @ngayvaolam";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {

                    adapter.SelectCommand.Parameters.AddWithValue("@ngayvaolam", "%" + ngayVaoLam + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemNV.DataSource = datatable;
                }
            }
            else if (cbNgayVaoLam.Checked && cbMaNV.Checked)
            {
                string maNV = txtTimKiemMNV.Text;
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");
                string query = "SELECT sMaNV AS 'Mã NV', sTenNV AS 'Tên NV', sDiaChi AS 'Địa chỉ', FORMAT(dNgaySinh, 'dd/MM/yyyy') AS 'Ngày sinh', FORMAT(dNgayVaoLam, 'dd/MM/yyyy') AS 'Ngày vào làm', sCCCD AS 'CCCD', fLuongCoBan AS 'Lương cơ bản', fPhuCap AS 'Phụ cấp' FROM tblNhanVien WHERE FORMAT(dNgayVaoLam, 'dd/MM/yyyy') LIKE @ngayvaolam AND sMaNV LIKE @manv";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@manv", "%" + maNV + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@ngayvaolam", "%" + ngayVaoLam + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemNV.DataSource = datatable;
                }
            }
            
        }

        //Xử lí sự kiện khi người dùng thay đổi sự lựa chọn với checkbox Mã nv
        private void cbMaNV_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMaNV.Checked && !cbNgayVaoLam.Checked)
            {
                txtTimKiemMNV.Enabled = true;
                dtpTimKiemNVL.Enabled = false;
                string maNV = txtTimKiemMNV.Text;
                txtTimKiemMNV_TextChanged(maNV, e);
            }
            else if (cbNgayVaoLam.Checked && !cbMaNV.Checked)
            {
                dtpTimKiemNVL.Enabled = true;
                txtTimKiemMNV.Enabled = false;
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");
                dtpTimKiemNVL_ValueChanged(ngayVaoLam, e);
            }
            else if (cbMaNV.Checked && cbNgayVaoLam.Checked)
            {
                txtTimKiemMNV.Enabled = true;
                dtpTimKiemNVL.Enabled = true;
                string maNV = txtTimKiemMNV.Text;
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");
                txtTimKiemMNV_TextChanged(maNV, e);
                dtpTimKiemNVL_ValueChanged(ngayVaoLam, e);
            }
            else if (!cbMaNV.Checked && !cbNgayVaoLam.Checked)
            {
                dtpTimKiemNVL.Enabled = false;
                txtTimKiemMNV.Enabled = false;
                displayDataTKVN();
            }
        }

        //Xử lí sự kiện khi người dùng thay đổi sự lựa chọn với checkbox Ngày vào l àm
        private void cbNgayVaoLam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNgayVaoLam.Checked && !cbMaNV.Checked)
            {
                dtpTimKiemNVL.Enabled = true;
                txtTimKiemMNV.Enabled = false;
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");
                dtpTimKiemNVL_ValueChanged(ngayVaoLam, e);
            }
            else if (cbMaNV.Checked && !cbNgayVaoLam.Checked)
            {

                txtTimKiemMNV.Enabled = true;
                dtpTimKiemNVL.Enabled = false;
                string maNV = txtTimKiemMNV.Text;
                txtTimKiemMNV_TextChanged(maNV, e);
            }
            else if (cbMaNV.Checked && cbNgayVaoLam.Checked)
            {
                txtTimKiemMNV.Enabled = true;
                dtpTimKiemNVL.Enabled = true;
                string maNV = txtTimKiemMNV.Text;
                string ngayVaoLam = dtpTimKiemNVL.Value.ToString("dd/MM/yyyy");
                txtTimKiemMNV_TextChanged(maNV, e);
                dtpTimKiemNVL_ValueChanged(ngayVaoLam, e);
            }
            else if (!cbMaNV.Checked && !cbNgayVaoLam.Checked)
            {
                dtpTimKiemNVL.Enabled = false;
                txtTimKiemMNV.Enabled = false;
                displayDataTKVN();
            }
        }
    }
}
