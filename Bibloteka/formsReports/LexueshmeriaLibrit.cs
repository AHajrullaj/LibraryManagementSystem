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
    public partial class LexueshmeriaLibrit : Form
    {
        public LexueshmeriaLibrit()
        {
            InitializeComponent();
        }

        private void LexueshmeriaLibrit_Load(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,emer,autor from Liber", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            scn.Close();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                int idj =Convert.ToInt32( (dataGridView1.CurrentRow.Cells[0].Value).ToString());
                this.dataTable1TableAdapter.Fill(this.lexueshmeriaELibrit.DataTable1,idj);
                this.reportViewer1.RefreshReport();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
