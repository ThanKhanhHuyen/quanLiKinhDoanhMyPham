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
    public partial class FormSanPham : Form
    {
        string connectionString = Connection.connectionString;

        public FormSanPham()
        {
            InitializeComponent();
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            this.MdiParent = this.ParentForm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = this.ParentForm.ClientSize;
            //this.Location = new System.Drawing.Point(0, 0);

            // Đảm bảo form con được hiển thị trên cùng
            this.BringToFront();
            loadDataCBBMaNSX();
            loadDataCBBMaNCC();
            loadDataCBBMaLoai();
            dispayDataSP();
        }

        private void dispayDataSP()
        {
            try
            {
                string query = "hienSanPham";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dtvSanPham.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi hiển thị dữ liệu sản phẩm: " + ex.Message);
            }
        }

        //Combobox Mã NSX
        private void loadDataCBBMaNSX()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaNSX FROM tblNhaSanXuat ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbMaNSX.Items.Add(reader["sMaNSX"].ToString());
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
        
        //Combobox mã loại
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
                                cbbMaLoai.Items.Add(reader["sMaLoai"].ToString());
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

        //Combobox mã NCC
        private void loadDataCBBMaNCC()
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sMaNCC FROM tblNhaCungCap";
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

        //Thêm sản phẩm
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn sd
                dtpHanSuDung.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrEmpty(txtDonGia.Text)
                    || string.IsNullOrEmpty(txtNuocSX.Text) || string.IsNullOrEmpty(cbbMaNSX.Text) || string.IsNullOrEmpty(cbbMaLoai.Text) || string.IsNullOrEmpty(cbbMaNCC.Text) || string.IsNullOrEmpty(txtSoLuongKho.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!");
                    return;
                }

                //check xem khóa chính đã tồn tại hay chưa
                if (MaSPTonTai(txtMaSP.Text))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!");
                    return;
                }

                DateTime hanSuDung = dtpHanSuDung.Value;
                // Kiểm tra hạn sử dụng phải lớn hơn ngày hiện tại
                if (hanSuDung <= DateTime.Now)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại!");
                    return;
                }

                string query = "themSanPham";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("@tenSP", txtTenSP.Text);
                    cmd.Parameters.AddWithValue("@donGia", Double.Parse(txtDonGia.Text));
                    cmd.Parameters.AddWithValue("@nuocSanXuat", txtNuocSX.Text);
                    cmd.Parameters.AddWithValue("@maNSX", cbbMaNSX.Text);
                    cmd.Parameters.AddWithValue("@maLoai", cbbMaLoai.Text);
                    cmd.Parameters.AddWithValue("@maNCC", cbbMaNCC.Text);
                    cmd.Parameters.AddWithValue("@soLuongKho", Double.Parse(txtSoLuongKho.Text));
                    cmd.Parameters.AddWithValue("@hanSuDung", dtpHanSuDung.Value);

                    //check đơn giá và số lượn kho phải lớn hơn 0
                    if (Double.Parse(txtSoLuongKho.Text) < 0)
                    {
                        MessageBox.Show("Số lượng kho phải lớn hơn 0!");
                        return;
                    }

                    if (Double.Parse(txtDonGia.Text) < 0)
                    {
                        MessageBox.Show("Gía sản phẩm phải lớn hơn 0!");
                        return;
                    }

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm sản phẩm thành công");
                        dispayDataSP();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        //check mã sản phẩm
        private bool MaSPTonTai(string MaSPValue)
        {
            string query = "SELECT COUNT(*) FROM tblSanPham WHERE sMaSanPham = @maSP";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@maSP", MaSPValue);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                //format lại hạn sd
                dtpHanSuDung.CustomFormat = "dd/MM/yyyy";
                // Kiểm tra thông tin đầu vào không được để trống
                if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSP.Text) || string.IsNullOrEmpty(txtDonGia.Text)
                    || string.IsNullOrEmpty(txtNuocSX.Text) || string.IsNullOrEmpty(cbbMaNSX.Text) || string.IsNullOrEmpty(cbbMaLoai.Text) || string.IsNullOrEmpty(cbbMaNCC.Text) || string.IsNullOrEmpty(txtSoLuongKho.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!");
                    return;
                }

                DateTime hanSuDung = dtpHanSuDung.Value;
                // Kiểm tra hạn sử dụng phải lớn hơn ngày hiện tại
                if (hanSuDung <= DateTime.Now)
                {
                    MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại!");
                    return;
                }

                string query = "suaSanPham";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("@tenSP", txtTenSP.Text);
                    cmd.Parameters.AddWithValue("@donGia", Double.Parse(txtDonGia.Text));
                    cmd.Parameters.AddWithValue("@nuocSanXuat", txtNuocSX.Text);
                    cmd.Parameters.AddWithValue("@maNSX", cbbMaNSX.Text);
                    cmd.Parameters.AddWithValue("@maLoai", cbbMaLoai.Text);
                    cmd.Parameters.AddWithValue("@maNCC", cbbMaNCC.Text);
                    cmd.Parameters.AddWithValue("@soLuongKho", Double.Parse(txtSoLuongKho.Text));
                    cmd.Parameters.AddWithValue("@hanSuDung", dtpHanSuDung.Value);

                    //check đơn giá và số lượn kho phải lớn hơn 0
                    if (Double.Parse(txtSoLuongKho.Text) < 0)
                    {
                        MessageBox.Show("Số lượng kho phải lớn hơn 0!");
                        return;
                    }

                    if (Double.Parse(txtDonGia.Text) < 0)
                    {
                        MessageBox.Show("Gía sản phẩm phải lớn hơn 0!");
                        return;
                    }

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    //nếu số dòng bị ảnh hưởng lớn hơn 0 và ngược lại
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công");
                        dispayDataSP();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Sửa sản phẩm không thành công");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "xoaSanPham";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        dispayDataSP();
                        makeEmpty();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm không thành công!");
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
            txtMaSP.Enabled = true;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtNuocSX.Text = "";
            cbbMaNSX.Text = "";
            cbbMaLoai.Text = "";
            cbbMaNCC.Text = "";
            txtSoLuongKho.Text = "";
            dtpHanSuDung.Value = DateTime.Today;
        }

        private void btnBoChonSP_Click(object sender, EventArgs e)
        {
            makeEmpty();
        }

        private void dtvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Enabled = false;
            int i;
            i = dtvSanPham.CurrentRow.Index;
            txtMaSP.Text = dtvSanPham.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text = dtvSanPham.Rows[i].Cells[1].Value.ToString();
            txtDonGia.Text = dtvSanPham.Rows[i].Cells[2].Value.ToString();
            txtNuocSX.Text = dtvSanPham.Rows[i].Cells[3].Value.ToString();
            cbbMaNSX.Text = dtvSanPham.Rows[i].Cells[4].Value.ToString();
            cbbMaLoai.Text = dtvSanPham.Rows[i].Cells[5].Value.ToString();
            cbbMaNCC.Text = dtvSanPham.Rows[i].Cells[6].Value.ToString();
            txtSoLuongKho.Text = dtvSanPham.Rows[i].Cells[7].Value.ToString();
            dtpHanSuDung.Text = dtvSanPham.Rows[i].Cells[8].Value.ToString();
        }

        private void dtvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Enabled = false;
            int i;
            i = dtvSanPham.CurrentRow.Index;
            txtMaSP.Text = dtvSanPham.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text = dtvSanPham.Rows[i].Cells[1].Value.ToString();
            txtDonGia.Text = dtvSanPham.Rows[i].Cells[2].Value.ToString();
            txtNuocSX.Text = dtvSanPham.Rows[i].Cells[3].Value.ToString();
            cbbMaNSX.Text = dtvSanPham.Rows[i].Cells[4].Value.ToString();
            cbbMaLoai.Text = dtvSanPham.Rows[i].Cells[5].Value.ToString();
            cbbMaNCC.Text = dtvSanPham.Rows[i].Cells[6].Value.ToString();
            txtSoLuongKho.Text = dtvSanPham.Rows[i].Cells[7].Value.ToString();
            dtpHanSuDung.Text = dtvSanPham.Rows[i].Cells[8].Value.ToString();
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            FormTimKiemSanPham formTimKiemSP = new FormTimKiemSanPham();
            formTimKiemSP.Show();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string query = "select * from tblSanPham";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);
                
                /*rptSP report = new rptSP();
                report.SetDataSource(datatable);
                FormInBaoCao formInBaoCao = new FormInBaoCao();
                formInBaoCao.crystalReportViewer1.ReportSource = report;
                formInBaoCao.ShowDialog();*/
            }
        }
    }
}
