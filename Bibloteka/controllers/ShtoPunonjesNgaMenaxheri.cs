using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Bibloteka.controllers
{
    public partial class ShtoPunonjesNgaMenaxheri : UserControl
    {
        bool syri = false;
        public ShtoPunonjesNgaMenaxheri()
        {
            InitializeComponent();
        }

        

        private void ShtoPunonjesNgaMenaxheri_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String emr, mbr, email, pass;
            int paga;
            bool po = true;
            emr = textBox1.Text.ToLower();
            mbr = textBox2.Text.ToLower();
            email = textBox3.Text;
            pass = textBox4.Text;
            SqlConnection scn1 = new SqlConnection();
            scn1.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn1.Open();
            SqlCommand scmd1 = new SqlCommand("SELECT email from [user] ", scn1);

            SqlDataReader am = scmd1.ExecuteReader();
           
            while (am.Read())
            {
                if (email.Equals(am["email"].ToString()))
                {
                    MessageBox.Show("Email eshte i zene, shkruani nje email tjeter");
                    po = false;
                    break;
                }
            }

            if (po)
            {
                if (!(email.Contains("@") && email.EndsWith(".com")))
                {
                    MessageBox.Show("Vendosni nje email te sakt");//shiko dhe nese ka perplasje me perdorues te tjere.
                }
                paga = Convert.ToInt32(textBox5.Text);


                SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                string query = "INSERT INTO Punonjes (firstName, lastName, email, passwordi, paga)";
                query += " VALUES (@emr, @mbr, @email, @pass, @paga)";

                SqlCommand myCommand = new SqlCommand(query, scn);
                myCommand.Parameters.AddWithValue("@emr", emr);
                myCommand.Parameters.AddWithValue("@mbr", mbr);
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.Parameters.AddWithValue("@pass", pass);
                myCommand.Parameters.AddWithValue("@paga", paga);

                myCommand.ExecuteNonQuery();
                query = "INSERT INTO [user] (firstname, lastname, email, [password])";
                query += " VALUES (@emr, @mbr, @email, @pass)";

                myCommand = new SqlCommand(query, scn);
                myCommand.Parameters.AddWithValue("@emr", emr);
                myCommand.Parameters.AddWithValue("@mbr", mbr);
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.Parameters.AddWithValue("@pass", pass);
                myCommand.ExecuteNonQuery();
                SqlCommand scmd = new SqlCommand("SELECT TOP 1 user_id  FROM [user] ORDER BY user_id DESC ", scn);

                SqlDataReader a = scmd.ExecuteReader();
                int idja, m = 2;
                if (a.Read())
                {
                    idja = Convert.ToInt32(a["user_id"].ToString());
                    Console.WriteLine(idja + "" + m);
                    query = "INSERT INTO [user_role] ([user_role].user_id, [user_role].role_id)";
                    query += " VALUES (@uID, @rID)";

                    myCommand = new SqlCommand(query, scn);
                    myCommand.Parameters.AddWithValue("@uID", idja);
                    myCommand.Parameters.AddWithValue("@rID", m);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show("Punonjesi u shtua me sukses!");

                }


                scn.Close();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
