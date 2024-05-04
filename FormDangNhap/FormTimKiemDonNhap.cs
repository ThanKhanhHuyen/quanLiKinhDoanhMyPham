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
    public partial class FormTimKiemDonNhap : Form
    {
        string connectionString = Connection.connectionString;
        // Biến cờ để theo dõi xem liệu người dùng đã nhấn nút đăng xuất hay không
        private bool isLoggingOut = false;

        public FormTimKiemDonNhap()
        {
            InitializeComponent();
        }

        private void FormTimKiemDonNhap_Load(object sender, EventArgs e)
        {
            displayDataTKDN();
            txtTK_SoHD.Enabled = false;
            dtpTK_NgayNhap.Enabled = false;
        }

        private void displayDataTKDN()
        {
            string query = "hienDonNhap";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvTKDonNhap.DataSource = datatable;
            }
        }

        private void FormTimKiemDonNhap_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtTK_SoHD_TextChanged(object sender, EventArgs e)
        {
            if (cbTK_SoHD.Checked && !cbTK_NgayNhap.Checked)
            {
                string soHD = txtTK_SoHD.Text;
                string query = "SELECT * FROM tblDonNhap WHERE sSoHDNhap LIKE @sohdnhap";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@sohdnhap", "%" + soHD + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKDonNhap.DataSource = datatable;
                }
            }
            else if (cbTK_SoHD.Checked && cbTK_NgayNhap.Checked)
            {
                string soHD = txtTK_SoHD.Text;
                string ngayNhap = dtpTK_NgayNhap.Value.ToString("dd/MM/yyyy");
                string query = "SELECT sSoHDNhap AS 'Số HD', FORMAT(dNgayNhap, 'dd/MM/yyyy') AS 'Ngày nhập', sMaNV AS 'Mã NV', fTongTienNhap AS 'Tổng tiền ' FROM tblDonNhap WHERE sSoHDNhap LIKE @sohdnhap AND FORMAT(dNgayNhap, 'dd/MM/yyyy') LIKE @ngaynhap ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@sohdnhap", "%" + soHD + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@ngaynhap", "%" + ngayNhap + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKDonNhap.DataSource = datatable;
                }
            }
        }

        private void dtpTK_NgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (cbTK_NgayNhap.Checked && !cbTK_SoHD.Checked)
            {
                string ngayNhap = dtpTK_NgayNhap.Value.ToString("dd/MM/yyyy");
                string query = "SELECT sSoHDNhap AS 'Số HD', FORMAT(dNgayNhap, 'dd/MM/yyyy') AS 'Ngày nhập', sMaNV AS 'Mã NV', fTongTienNhap AS 'Tổng tiền ' FROM tblDonNhap WHERE FORMAT(dNgayNhap, 'dd/MM/yyyy') LIKE @ngaynhap";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {

                    adapter.SelectCommand.Parameters.AddWithValue("@ngaynhap", "%" + ngayNhap + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKDonNhap.DataSource = datatable;
                }
            }
            else if (cbTK_NgayNhap.Checked && cbTK_SoHD.Checked)
            {
                string soHD = txtTK_SoHD.Text;
                string ngayNhap = dtpTK_NgayNhap.Value.ToString("dd/MM/yyyy");
                string query = "SELECT sSoHDNhap AS 'Số HD', FORMAT(dNgayNhap, 'dd/MM/yyyy') AS 'Ngày nhập', sMaNV AS 'Mã NV', fTongTienNhap AS 'Tổng tiền ' FROM tblDonNhap WHERE sSoHDNhap LIKE @sohdnhap AND FORMAT(dNgayNhap, 'dd/MM/yyyy') LIKE @ngaynhap ";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@sohdnhap", "%" + soHD + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@ngaynhap", "%" + ngayNhap + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTKDonNhap.DataSource = datatable;
                }
            }
        }

        private void cbTK_SoHD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTK_SoHD.Checked && !cbTK_NgayNhap.Checked)
            {
                txtTK_SoHD.Enabled = true;
                dtpTK_NgayNhap.Enabled = false;
                string soHD = txtTK_SoHD.Text;
                txtTK_SoHD_TextChanged(soHD, e);
            }
            else if (cbTK_NgayNhap.Checked && !cbTK_SoHD.Checked)
            {
                dtpTK_NgayNhap.Enabled = true;
                txtTK_SoHD.Enabled = false;
                string ngayNhap = dtpTK_NgayNhap.Value.ToString("dd/MM/yyyy");
                dtpTK_NgayNhap_ValueChanged(ngayNhap, e);
            }
            else if (cbTK_SoHD.Checked && cbTK_NgayNhap.Checked)
            {
                txtTK_SoHD.Enabled = true;
                dtpTK_NgayNhap.Enabled = true;
                string soHD = txtTK_SoHD.Text;
                string ngayNhap = dtpTK_NgayNhap.Value.ToString("dd/MM/yyyy");
                txtTK_SoHD_TextChanged(soHD, e);
                dtpTK_NgayNhap_ValueChanged(ngayNhap, e);
            }
            else if (cbTK_SoHD.Checked && !cbTK_NgayNhap.Checked)
            {
                txtTK_SoHD.Enabled = false;
                dtpTK_NgayNhap.Enabled = false;
                displayDataTKDN();
            }
        }

        private void cbTK_NgayNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTK_NgayNhap.Checked && !cbTK_SoHD.Checked)
            {
                dtpTK_NgayNhap.Enabled = true;
                txtTK_SoHD.Enabled = false;
                string ngayNhap = dtpTK_NgayNhap.Value.ToString("dd/MM/yyyy");
                dtpTK_NgayNhap_ValueChanged(ngayNhap, e);
            }
            else if (cbTK_SoHD.Checked && !cbTK_NgayNhap.Checked)
            {
                txtTK_SoHD.Enabled = true;
                dtpTK_NgayNhap.Enabled = false;
                string soHD = txtTK_SoHD.Text;
                txtTK_SoHD_TextChanged(soHD, e);
            }
            else if (cbTK_SoHD.Checked && cbTK_NgayNhap.Checked)
            {
                txtTK_SoHD.Enabled = true;
                dtpTK_NgayNhap.Enabled = true;
                string soHD = txtTK_SoHD.Text;
                string ngayNhap = dtpTK_NgayNhap.Value.ToString("dd/MM/yyyy");
                txtTK_SoHD_TextChanged(soHD, e);
                dtpTK_NgayNhap_ValueChanged(ngayNhap, e);
            }
            else if (!cbTK_SoHD.Checked && !cbTK_NgayNhap.Checked)
            {
                txtTK_SoHD.Enabled = false;
                dtpTK_NgayNhap.Enabled = false;
                displayDataTKDN();
            }
        }
    }
}
