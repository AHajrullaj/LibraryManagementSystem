using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibloteka.formsReports
{
    public partial class EcuriaELex : Form
    {
        public EcuriaELex()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EcuriaELex_Load(object sender, EventArgs e)
        {

            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,firstName,lastName from Lexues", scn);
            //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Fill(this.ecuriaELex1.DataTable1, dateTimePicker1.Value.Date.ToString(), dateTimePicker2.Value.Date.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            this.reportViewer1.RefreshReport();
        }
    }
}
