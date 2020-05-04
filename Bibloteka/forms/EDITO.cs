using Bibloteka.controllers;
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

namespace Bibloteka.forms
{
    public partial class EDITO : Form
    {
        public static string id;
        public static string emr;
        public static string mbr;
        public static string eml;
        public static string pass;
        public static string paga;
        private readonly ShfaqPunMenaxheri frm1;
        public EDITO()
        {
            InitializeComponent();
        }

        public EDITO(ShfaqPunMenaxheri frm)
        {
            InitializeComponent();

            frm1 = frm;
        }

         
        private void EDITO_Load(object sender, EventArgs e)
        {
            textBox1.Text = id;
            textBox2.Text = emr;
            textBox3.Text = mbr;
            textBox4.Text = eml;
            textBox5.Text = pass;
            textBox6.Text = paga;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Punonjes SET firstName = @name, lastName = @lname,passwordi=@pass, paga=@paga Where id=@id",con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@lname", textBox3.Text);
            cmd.Parameters.AddWithValue("@pass", textBox5.Text);
            cmd.Parameters.AddWithValue("@paga", Convert.ToInt32(textBox6.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            cmd = new SqlCommand("UPDATE [user] SET firstname = @name, lastname = @lname,password=@pass Where email=@email", con);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@lname", textBox3.Text);
            cmd.Parameters.AddWithValue("@pass", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Punonjes", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            frm1.dataGridView1.DataSource = dtbl;
            scn.Close();
            this.Close();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }
    }
}
