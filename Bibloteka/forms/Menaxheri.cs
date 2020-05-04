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
    public partial class Menaxheri : Form
    {
        public Menaxheri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.role = "";
            Form1.loguar = false;
            Form1.i = false;
            this.Hide();
            Login frm2 = new Login();
            frm2.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm2 = new Form1();
            frm2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            teTjeraMenaxherControl11.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shtoPunonjesNgaMenaxheri1.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Punonjes", scn);
            //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            shfaqPunMenaxheri1.dataGridView1.DataSource = dtbl;
            scn.Close();
            shfaqPunMenaxheri1.BringToFront();
        }

        private void Menaxheri_Load(object sender, EventArgs e)
        { 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shtoLiberMenaxher1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,emer,autor,ISBN,sasia,gjendje,demtuar,statusi from Liber", scn);
            //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            shfaqLibraMenaxheri1.dataGridView1.DataSource = dtbl;
            shfaqLibraMenaxheri1.BringToFront();
        }
    }
}
