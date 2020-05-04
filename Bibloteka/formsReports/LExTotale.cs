using Microsoft.Reporting.WebForms;
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
    public partial class LExTotale : Form
    {
        int i = 0;
        public object GridView1 { get; private set; }

        public LExTotale()
        {
            InitializeComponent();
        }

        private void LExTotale_Load(object sender, EventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (i == 0) { 
            this.chart1.Series.Add("Numri");
            }
            chart1.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            this.chart1.Series["Numri"].Points.Clear();
            SqlCommand scmd2 = new SqlCommand("select emer, count(Liber.Id) as NR from Liber join liberLexues on Liber.Id = liberLexues.id_Liber where CAST(dtRezervimi AS DATE) Between CAST(@dt AS DATE) and CAST(@dt1 AS DATE) group by Liber.emer; ", scn);
             

            scmd2.Parameters.AddWithValue("@dt", dateTimePicker1.Value.Date);
            scmd2.Parameters.AddWithValue("@dt1", dateTimePicker2.Value.Date);
            SqlDataReader a3 = scmd2.ExecuteReader();
            while (a3.Read())
            {
                this.chart1.Series["Numri"].Points.AddXY(a3["emer"].ToString(), Convert.ToInt32(a3["NR"].ToString()));
            }
            scn.Close();
            i++;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.Date;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                dateTimePicker2.Value = dateTimePicker1.Value.Date;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
