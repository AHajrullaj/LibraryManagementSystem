using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibloteka.forms;
using System.Data.SqlClient;

namespace Bibloteka.controllers.punonjesi
{
    
    public partial class PunShowDataControl1 : UserControl
    {
        ResetPass frm;
        int idPunonjes;
        public PunShowDataControl1()
        {
            InitializeComponent();
        }

        private void PunShowDataControl1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Punonjes.firstName;
            textBox2.Text = Punonjes.lastName;
            textBox3.Text = Punonjes.email;
            //textBox4.Text = Punonjes.pass;

            string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select id from Punonjes where email=@email", con);
            cmd.Parameters.AddWithValue("@email",textBox3.Text);
            SqlDataReader a = cmd.ExecuteReader();
            idPunonjes = 1;
            if (a.Read())
            {
                idPunonjes = Convert.ToInt32(a["id"].ToString());
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length!=0|| textBox2.Text.Length != 0|| textBox4.Text.Length != 0) { 
            string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Punonjes SET firstName = @name, lastName = @lname,passwordi=@pass Where id=@id", con);
            cmd.Parameters.AddWithValue("@id", idPunonjes);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@lname", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass", textBox4.Text);
            cmd.ExecuteNonQuery();
            
                cmd = new SqlCommand("UPDATE [user] SET firstname = @name, lastname = @lname,password=@pass Where email=@email", con);
                cmd.Parameters.AddWithValue("@email", textBox3.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Sigurohuni qe t'i keni plotesuar te gjitha fushat");
            }
            MessageBox.Show("Te dhenat u ndryshuan me sukses");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm = new ResetPass(this);

            frm.ShowDialog();
        }
    }
}
