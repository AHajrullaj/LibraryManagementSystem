using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bibloteka.forms;

namespace Bibloteka.controllers.lexuesi
{
    public partial class showLibra : UserControl
    {
        public showLibra()
        {
            InitializeComponent();
        }

        private void showLibra_Load(object sender, EventArgs e)
        {
           
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            string id="0";
            SqlCommand scmd = new SqlCommand("select Id from Lexues where email=@idja", scn);
            if (Lexues.email != null) { scmd.Parameters.AddWithValue("@idja", Lexues.email); }
            else
            {
                scmd.Parameters.AddWithValue("@idja", "email");
            }

            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                id = (a["Id"].ToString());
                break;
            }


            SqlDataAdapter sqlDa = new SqlDataAdapter("Select emer,autor,dtRezervimi,dtLeshimi from Liber join liberLexues on Liber.Id=liberLexues.id_Liber where dorezuar=0 and id_Lexues='"+Convert.ToInt32(id)+"'", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            
            int b = 0;
            scmd = new SqlCommand("select dtLeshimi from liberLexues where id_Lexues='" + Convert.ToInt32(id) + "'", scn);
            a = scmd.ExecuteReader();
            while (a.Read()&&b<5)
            {
                if(DateTime.Parse(a["dtLeshimi"].ToString()).Date == DateTime.Now.Date)
                {
                    dataGridView1.Rows[b].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if(DateTime.Parse(a["dtLeshimi"].ToString()).Date < DateTime.Now.Date)
                {
                    dataGridView1.Rows[b].DefaultCellStyle.BackColor = Color.Red;
                }
                b++;

            }

            scn.Close();

        }
    }
}
