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
    public partial class FormTest : Form
    {
        string connectionString = Connection.connectionString;

        public FormTest()
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            loadDataCBBSoHDN();
            
        }

        private void loadDataCBBSoHDN()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT sSoHDNhap FROM tblDonNhap ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbbChonHD.Items.Add(reader["sSoHDNhap"].ToString());
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

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string query = "select * from tblCHITIET_HD_NHAPHANG where sSoHDNhap = @sohdnhap";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@sohdnhap", cbbChonHD.Text);
                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                rptCTDN report = new rptCTDN();
                report.SetDataSource(datatable);
                FormInBaoCao formInBaoCao = new FormInBaoCao();
                formInBaoCao.crystalReportViewer1.ReportSource = report;
                formInBaoCao.ShowDialog();
            }
        }

        
    }
}
