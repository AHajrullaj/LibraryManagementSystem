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
    public partial class Punonjes : Form
    {
        public static string id;
        public static string email;
        public static string firstName;
        public static string lastName;
        public static string pass;
        public static string role;
        public Punonjes()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            punShowDataControl11.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm2 = new Form1();
            frm2.ShowDialog();
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

        private void Punonjes_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            shtoLexuesControl11.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,firstName,lastName,email,passwordi,addresa from Lexues", scn);

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            shfaqLexuesitControl11.dataGridView1.DataSource = dtbl;
            scn.Close();
            shfaqLexuesitControl11.BringToFront();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
