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
using Bibloteka.controllers;
using Bibloteka.forms;

namespace Bibloteka.controllers
{
    public partial class ShfaqPunMenaxheri : UserControl
    {
        //Edito_ShfaqPunMenaxheri edito_ShfaqPunMenaxheri = new Edito_ShfaqPunMenaxheri();
        public ShfaqPunMenaxheri()
        {
            InitializeComponent();

        }



        private void ShfaqPunMenaxheri_Load(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Punonjes", scn);
            //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
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
            SqlCommand scmd = new SqlCommand("select id,firstName,lastName,email,passwordi,paga from Punonjes where id=@idja", scn);
            scmd.Parameters.AddWithValue("@idja", indeksi);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                EDITO.id = a["id"].ToString();
                EDITO.emr = a["firstName"].ToString();
                EDITO.mbr = a["lastName"].ToString();
                EDITO.eml = a["email"].ToString();
                EDITO.pass = a["passwordi"].ToString();
                EDITO.paga = a["paga"].ToString();
                break;
            }

            scn.Close();
            EDITO frm = new EDITO(this);
            frm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("A jeni te sigurt qe deshironi te fshini kete perdorues?", "Fshi punonjes", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Punonjes WHERE id=@id ", con);
                cmd.Parameters.AddWithValue("@id", indeksi);
                cmd.ExecuteNonQuery();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Punonjes", con);
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
    }
}
