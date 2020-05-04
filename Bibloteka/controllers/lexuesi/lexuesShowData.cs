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

namespace Bibloteka.controllers.lexuesi
{
    public partial class lexuesShowData : UserControl
    {
        public lexuesShowData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0 || textBox4.Text.Length != 0 || textBox5.Text.Length != 0)
            {
                string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Lexues SET firstName = @name, lastName = @lname,passwordi=@pass,addresa=@add Where email=@em", con);
                cmd.Parameters.AddWithValue("@em", textBox3.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@lname", textBox2.Text);
                cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                cmd.Parameters.AddWithValue("@add", textBox5.Text);
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

        private void lexuesShowData_Load(object sender, EventArgs e)
        {
            textBox1.Text = Lexues.firstName;
            textBox2.Text = Lexues.lastName;
            textBox3.Text = Lexues.email;
            textBox4.Text = Lexues.pass;
            textBox5.Text = merrADD();

            
        }
        string merrADD()
        {
            string adresa="prova";
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select addresa from Lexues where email=@idja", scn);
            if (Lexues.email != null) { scmd.Parameters.AddWithValue("@idja", Lexues.email); } else
            {
                scmd.Parameters.AddWithValue("@idja", "email");
            }
            
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                adresa = (a["addresa"].ToString());
                break;
            }
            scn.Close();
            return adresa;
        }
    }
}
