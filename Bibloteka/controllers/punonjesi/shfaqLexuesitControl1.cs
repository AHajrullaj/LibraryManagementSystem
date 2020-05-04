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

namespace Bibloteka.controllers.punonjesi
{
    public partial class shfaqLexuesitControl1 : UserControl
    {
        public shfaqLexuesitControl1()
        {
            InitializeComponent();
        }

        private void shfaqLexuesitControl1_Load(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,firstName,lastName,email,passwordi,addresa from Lexues", scn);
           
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            scn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select Id,firstName,lastName,email,passwordi,addresa from Lexues where Id=@idja", scn);
            scmd.Parameters.AddWithValue("@idja", indeksi);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                EditoLexues.id = a["Id"].ToString();
                EditoLexues.emr = a["firstName"].ToString();
                EditoLexues.mbr = a["lastName"].ToString();
                EditoLexues.eml = a["email"].ToString();
                EditoLexues.pass = a["passwordi"].ToString();
                EditoLexues.adresa = a["addresa"].ToString();
                break;
            }
            EditoLexues frm = new EditoLexues(this);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select Id,firstName,lastName from Lexues where Id=@idja", scn);
            scmd.Parameters.AddWithValue("@idja", indeksi);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                RezervoLiber.id = a["Id"].ToString();
                RezervoLiber.emr = a["firstName"].ToString();
                RezervoLiber.mbr = a["lastName"].ToString();
                break;
            }
            scmd = new SqlCommand("select id,nrMaxLiber from KartBibloteke where id_lexues=@idja", scn);
            scmd.Parameters.AddWithValue("@idja", indeksi);
            a = scmd.ExecuteReader();
            while (a.Read())
            {
                RezervoLiber.idKB = a["id"].ToString();
                RezervoLiber.nrLibr = a["nrMaxLiber"].ToString();
                break;
            }
            RezervoLiber frm = new RezervoLiber(this);
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ploteson kerkesen qe te dali lista me emrin e butonit..kjo duhet bere dhe te lexuesi per librat e vete
            //ketu mund te shlyhet dhe problemi i dorezimit te nje libri.
            //Bej nje search per mbiemerin e perdoruesit
            int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
           // MessageBox.Show(indeksi.ToString());
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select KartBibloteke.id,Lexues.Id as userID,firstName,lastName from Lexues join KartBibloteke on Lexues.Id=KartBibloteke.id_lexues where id_lexues=@I ", scn);
            scmd.Parameters.AddWithValue("@I", indeksi);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                DorezoLiber.idK = a["id"].ToString();
                DorezoLiber.emr = a["firstName"].ToString();
                DorezoLiber.mbr = a["lastName"].ToString();
                DorezoLiber.idP = a["userID"].ToString();
                break;
            }
            DorezoLiber frm = new DorezoLiber(this);
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int nrMax = 0;
            DialogResult dialogResult = MessageBox.Show("A jeni te sigurt qe deshironi te fshini kete Lexues?", "Fshi Lexuesin", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("select nrMaxLiber FROM  KartBibloteke WHERE id_lexues=@id ", con);
                cmd.Parameters.AddWithValue("@id", indeksi);
                SqlDataReader readeri = cmd.ExecuteReader();
                while (readeri.Read())
                {
                    nrMax = Convert.ToInt32( readeri["nrMaxLiber"].ToString());
                    break;
                }
                if (nrMax == 0) { 
                cmd = new SqlCommand("DELETE FROM Lexues WHERE Id=@id ", con);
                cmd.Parameters.AddWithValue("@id", indeksi);
                cmd.ExecuteNonQuery();
               
                cmd = new SqlCommand("DELETE FROM KartBibloteke WHERE id_lexues=@id ", con);
                cmd.Parameters.AddWithValue("@id", indeksi);
                cmd.ExecuteNonQuery();
                
                cmd = new SqlCommand("DELETE FROM liberLexues WHERE id_Lexues=@id ", con);
                cmd.Parameters.AddWithValue("@id", indeksi);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,firstName,lastName,email,passwordi,addresa from Lexues", con);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                con.Close();
                }
                else
                {
                    MessageBox.Show("Perdoruesi nuk mund te fshijet.\nEkzistojn libra per t'u dorezuar");
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
