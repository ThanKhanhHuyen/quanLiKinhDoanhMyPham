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
    public partial class FormTimKiemSanPham : Form
    {

        string connectionString = Connection.connectionString;
        // Biến cờ để theo dõi xem liệu người dùng đã nhấn nút đăng xuất hay không
        private bool isLoggingOut = false;

        public FormTimKiemSanPham()
        {
            InitializeComponent();
        }

        private void FormTimKiemSanPham_Load(object sender, EventArgs e)
        {
            displayDataTKSP();
            loadDataCBBMaLoai();
            cbbTimKiemML.Enabled = false;
            dtpTimKiemHSD.Enabled = false;
        }

        private void loadDataCBBMaLoai()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaLoai FROM tblLoaiHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbTimKiemML.Items.Add(reader["sMaLoai"].ToString());
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
        private void displayDataTKSP()
        {
            string query = "hienSanPham";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                dgvTimKiemSP.DataSource = datatable;
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

        private void FormTimKiemSanPham_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cbbTimKiemML_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbMaLoai.Checked && !cbHanSuDung.Checked)
            {
                string maLoai = cbbTimKiemML.Text;
                string query = "SELECT * FROM tblSanPham WHERE sMaLoai LIKE @maLoai";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maLoai", "%" + maLoai + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }
            else if (cbMaLoai.Checked && cbHanSuDung.Checked)
            {
                string maLoai = cbbTimKiemML.Text;
                string hanSuDung = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                string query = "select sMaSanPham AS 'Mã SP', sTenSanPham AS 'Tên SP', fDonGia AS 'Đơn giá', sNuocSX AS 'Nước SX', sMaNSX AS 'Mã NSX',  sMaLoai AS 'Mã loại', sMaNCC AS 'Mã NCC', fSoLuongKho AS 'Số lượng kho' , FORMAT(dHanSD, 'dd/MM/yyyy') AS 'Hạn sử dụng' FROM tblSanPham WHERE FORMAT(dHanSD, 'dd/MM/yyyy') LIKE @hanSuDung AND sMaLoai LIKE @maLoai";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maLoai", "%" + maLoai + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@hanSuDung", "%" + hanSuDung + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }
        }

        private void dtpTimKiemHSD_ValueChanged(object sender, EventArgs e)
        {
            if (cbHanSuDung.Checked && !cbMaLoai.Checked)
            {
                string hanSD = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                string query = "select sMaSanPham AS 'Mã SP', sTenSanPham AS 'Tên SP', fDonGia AS 'Đơn giá', sNuocSX AS 'Nước SX', sMaNSX AS 'Mã NSX',  sMaLoai AS 'Mã loại', sMaNCC AS 'Mã NCC', fSoLuongKho AS 'Số lượng kho' , FORMAT(dHanSD, 'dd/MM/yyyy') AS 'Hạn sử dụng' FROM tblSanPham WHERE FORMAT(dHanSD, 'dd/MM/yyyy') LIKE @hanSuDung";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@hanSuDung", "%" + hanSD + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }
            else if (cbMaLoai.Checked && cbHanSuDung.Checked)
            {
                string maLoai = cbbTimKiemML.Text;
                string hanSuDung = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                string query = "select sMaSanPham AS 'Mã SP', sTenSanPham AS 'Tên SP', fDonGia AS 'Đơn giá', sNuocSX AS 'Nước SX', sMaNSX AS 'Mã NSX',  sMaLoai AS 'Mã loại', sMaNCC AS 'Mã NCC', fSoLuongKho AS 'Số lượng kho' , FORMAT(dHanSD, 'dd/MM/yyyy') AS 'Hạn sử dụng' FROM tblSanPham WHERE FORMAT(dHanSD, 'dd/MM/yyyy') LIKE @hanSuDung AND sMaLoai LIKE @maLoai";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maLoai", "%" + maLoai + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@hanSuDung", "%" + hanSuDung + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }
        }

        private void cbbTimKiemML_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (cbMaLoai.Checked && !cbHanSuDung.Checked)
            {
                string maLoai = cbbTimKiemML.Text;
                string query = "SELECT * FROM tblSanPham WHERE sMaLoai LIKE @maLoai";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maLoai", "%" + maLoai + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }
            else if (cbMaLoai.Checked && cbHanSuDung.Checked)
            {
                string maLoai = cbbTimKiemML.Text;
                string hanSuDung = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                string query = "select sMaSanPham AS 'Mã SP', sTenSanPham AS 'Tên SP', fDonGia AS 'Đơn giá', sNuocSX AS 'Nước SX', sMaNSX AS 'Mã NSX',  sMaLoai AS 'Mã loại', sMaNCC AS 'Mã NCC', fSoLuongKho AS 'Số lượng kho' , FORMAT(dHanSD, 'dd/MM/yyyy') AS 'Hạn sử dụng' FROM tblSanPham WHERE FORMAT(dHanSD, 'dd/MM/yyyy') LIKE @hanSuDung AND sMaLoai LIKE @maLoai";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maLoai", "%" + maLoai + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@hanSuDung", "%" + hanSuDung + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }*/
        }

        private void cbMaLoai_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMaLoai.Checked && !cbHanSuDung.Checked)
            {
                cbbTimKiemML.Enabled = true;
                dtpTimKiemHSD.Enabled = false;
                string maLoai = cbbTimKiemML.Text;
                cbbTimKiemML_SelectedValueChanged(maLoai, e);
            }
            else if (cbHanSuDung.Checked && !cbMaLoai.Checked)
            {
                dtpTimKiemHSD.Enabled = true;
                cbbTimKiemML.Enabled = false;
                string hanSD = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                dtpTimKiemHSD_ValueChanged(hanSD, e);
            }
            else if (cbMaLoai.Checked && cbHanSuDung.Checked)
            {
                cbbTimKiemML.Enabled = true;
                dtpTimKiemHSD.Enabled = true;
                string maLoai = cbbTimKiemML.Text;
                string hanSD = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                cbbTimKiemML_SelectedValueChanged(maLoai, e);
                dtpTimKiemHSD_ValueChanged(hanSD, e);
            }
            else if (!cbMaLoai.Checked && !cbHanSuDung.Checked)
            {
                cbbTimKiemML.Enabled = false;
                dtpTimKiemHSD.Enabled = false;
                displayDataTKSP();
            }
        }

        private void cbHanSuDung_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMaLoai.Checked && !cbHanSuDung.Checked)
            {
                cbbTimKiemML.Enabled = true;
                dtpTimKiemHSD.Enabled = false;
                string maLoai = cbbTimKiemML.Text;
                cbbTimKiemML_SelectedValueChanged(maLoai, e);
            }
            else if (cbHanSuDung.Checked && !cbMaLoai.Checked)
            {
                dtpTimKiemHSD.Enabled = true;
                cbbTimKiemML.Enabled = false;
                string hanSD = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                dtpTimKiemHSD_ValueChanged(hanSD, e);
            }
            else if (cbMaLoai.Checked && cbHanSuDung.Checked)
            {
                cbbTimKiemML.Enabled = true;
                dtpTimKiemHSD.Enabled = true;
                string maLoai = cbbTimKiemML.Text;
                string hanSD = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
                cbbTimKiemML_SelectedValueChanged(maLoai, e);
                dtpTimKiemHSD_ValueChanged(hanSD, e);
            }
            else if (!cbMaLoai.Checked && !cbHanSuDung.Checked)
            {
                cbbTimKiemML.Enabled = false;
                dtpTimKiemHSD.Enabled = false;
                displayDataTKSP();
            }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string hanSuDung = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");
            string query = "select sMaSanPham , sTenSanPham , fDonGia , sNuocSX , sMaNSX ,  sMaLoai, sMaNCC , fSoLuongKho  , dHanSD  FROM tblSanPham WHERE FORMAT(dHanSD, 'dd/MM/yyyy') LIKE @hanSuDung AND sMaLoai LIKE @maLoai";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@maloai", cbbTimKiemML.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@hanSuDung", hanSuDung);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                rptTKSP report = new rptTKSP();
                report.SetDataSource(datatable);
                FormInBaoCao formInBaoCao = new FormInBaoCao();
                formInBaoCao.crystalReportViewer1.ReportSource = report;
                formInBaoCao.ShowDialog();
            }
        }

        /*private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            if (cbMaLoai.Checked == true)
            {
                string maLoai = cbbTimKiemML.Text;
                string query = "SELECT * FROM tblSanPham WHERE sMaLoai LIKE @maLoai";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maLoai", "%" + maLoai + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }

            if (cbHanSuDung.Checked == true)
            {

                string hanSD = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");

                string query = "select sMaSanPham AS 'Mã SP', sTenSanPham AS 'Tên SP', fDonGia AS 'Đơn giá', sNuocSX AS 'Nước SX', sMaNSX AS 'Mã NSX',  sMaLoai AS 'Mã loại', sMaNCC AS 'Mã NCC', fSoLuongKho AS 'Số lượng kho' , FORMAT(dHanSD, 'dd/MM/yyyy') AS 'Hạn sử dụng' FROM tblSanPham WHERE FORMAT(dHanSD, 'dd/MM/yyyy') LIKE @hanSuDung";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@hanSuDung", "%" + hanSD + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }


            }
            if (cbMaLoai.Checked == true && cbHanSuDung.Checked == true)
            {
                string maLoai = cbbTimKiemML.Text;
                string hanSD = dtpTimKiemHSD.Value.ToString("dd/MM/yyyy");

                string query = "select sMaSanPham AS 'Mã SP', sTenSanPham AS 'Tên SP', fDonGia AS 'Đơn giá', sNuocSX AS 'Nước SX', sMaNSX AS 'Mã NSX',  sMaLoai AS 'Mã loại', sMaNCC AS 'Mã NCC', fSoLuongKho AS 'Số lượng kho' , FORMAT(dHanSD, 'dd/MM/yyyy') AS 'Hạn sử dụng' FROM tblSanPham WHERE FORMAT(dHanSD, 'dd/MM/yyyy') LIKE @hanSuDung AND sMaLoai LIKE @maLoai";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@maLoai", "%" + maLoai + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@hanSuDung", "%" + hanSD + "%");
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dgvTimKiemSP.DataSource = datatable;
                }
            }
        }*/


    }
}
