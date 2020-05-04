using Bibloteka.controllers.punonjesi;
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
    public partial class EditoLexues : Form
    {
        public static string id;
        public static string emr;
        public static string mbr;
        public static string eml;
        public static string pass;
        public static string adresa;
        private readonly shfaqLexuesitControl1 frm1;
        public EditoLexues()
        {
            InitializeComponent();
        }
        public EditoLexues(shfaqLexuesitControl1 frm)
        {
            InitializeComponent();

            frm1 = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Lexues SET firstName = @name, lastName = @lname,passwordi=@pass, addresa=@add Where id=@id", con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@lname", textBox3.Text);
            cmd.Parameters.AddWithValue("@pass", textBox5.Text);
            cmd.Parameters.AddWithValue("@add", textBox6.Text);
            cmd.ExecuteNonQuery();
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
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Lexues", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            frm1.dataGridView1.DataSource = dtbl;
            scn.Close();
            this.Close();

        }

        private void EditoLexues_Load(object sender, EventArgs e)
        {
            textBox1.Text = id;
            textBox2.Text = emr;
            textBox3.Text = mbr;
            textBox4.Text = eml;
            textBox5.Text = pass;
            textBox6.Text = adresa;
        }
    }
}
