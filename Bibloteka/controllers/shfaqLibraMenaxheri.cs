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

namespace Bibloteka.controllers
{
    public partial class shfaqLibraMenaxheri : UserControl
    {
        public shfaqLibraMenaxheri()
        {
            InitializeComponent();
        }

        private void shfaqLibraMenaxheri_Load(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,emer,autor,ISBN,sasia,gjendje,demtuar,statusi from Liber where fshire <> 1", scn);
            //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select Id,emer,autor,ISBN,sasia,gjendje,statusi,demtuar from Liber where id=@idja and fshire <> 1", scn);
            scmd.Parameters.AddWithValue("@idja", indeksi);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                EditoLiber.id = a["Id"].ToString();
                EditoLiber.titul = a["emer"].ToString();
                EditoLiber.autor = a["autor"].ToString();
                EditoLiber.isbn = a["ISBN"].ToString();
                EditoLiber.sasi = a["sasia"].ToString();
                EditoLiber.gjendje =a["gjendje"].ToString();
                EditoLiber.statusi= a["statusi"].ToString();
                EditoLiber.demtuar = a["demtuar"].ToString();
                break;
            }
            scmd = new SqlCommand("select name from KategoriLibri join liber_kategoriLiber on liber_kategoriLiber.KategoriLibri_id=KategoriLibri.Id where liber_kategoriLiber.Liber_id=@id", scn);
            scmd.Parameters.AddWithValue("@id", indeksi);
            a = scmd.ExecuteReader();
            int i = 0;
            while (a.Read())
            {
                EditoLiber.etiketat[i]= a["name"].ToString();
                i++;
            }

                scn.Close();
            EditoLiber frm = new EditoLiber(this);
            frm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A jeni te sigurt qe deshironi te fshini kete liber?", "Fshi Librin", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Liber SET fshire = 1 Where Id=@id ", con);
                cmd.Parameters.AddWithValue("@id", indeksi);
                 
                cmd.ExecuteNonQuery();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,emer,autor,ISBN,sasia,gjendje,demtuar,statusi from Liber where fshire <> 1", con);
                //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                con.Close();
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select Id,emer,autor,ISBN from Liber where id=@idja and fshire <> 1", scn);
            scmd.Parameters.AddWithValue("@idja", indeksi);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                HistorikuILibrit.id = a["Id"].ToString();
                HistorikuILibrit.titul = a["emer"].ToString();
                HistorikuILibrit.autor = a["autor"].ToString();
                HistorikuILibrit.isbn = a["ISBN"].ToString();
                break;
            }
            scn.Close();
            HistorikuILibrit frm = new HistorikuILibrit(this);
            frm.ShowDialog();
        }
    }
}
