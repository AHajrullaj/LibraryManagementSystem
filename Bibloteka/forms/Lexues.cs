using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bibloteka.forms
{
    public partial class Lexues : Form
    {
        public static string id;
        public static string email;
        public static string firstName;
        public static string lastName;
        public static string add;
        public static string pass;
        public static string role;
        public Lexues()
        {
            InitializeComponent();
        }

        private void Lexues_Load(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            string id = "0";
            SqlCommand scmd = new SqlCommand("select Id from Lexues where email=@idja", scn);
            if (Lexues.email != null) { scmd.Parameters.AddWithValue("@idja", Lexues.email); }
            else
            {
                scmd.Parameters.AddWithValue("@idja", "email");
            }

            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                id = (a["Id"].ToString());
                break;
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter("Select emer,autor,dtRezervimi,dtLeshimi from Liber join liberLexues on Liber.Id=liberLexues.id_Liber where dorezuar=0 and id_Lexues='" + Convert.ToInt32(id) + "'", scn);
            DataTable dtbl = new DataTable();//Select emer,autor,dtRezervimi,dtLeshimi,barkodi from Liber join liberLexues on Liber.Id=liberLexues.id_Liber join KopjeLibri on liberLexues.id_KLib=KopjeLibri.id_Kopje where dorezuar=0 and rezervuar=0 and id_Lexues='" + Convert.ToInt32(id) + "'"
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;

            int b=0;
               // int amk = dataGridView1.Rows.Count;
            scmd = new SqlCommand("select dtLeshimi from liberLexues where id_Lexues='" + Convert.ToInt32(id) + "' and dorezuar=0", scn);
            a = scmd.ExecuteReader();
            while (a.Read() && b < 5)
            {
                if (a["dtLeshimi"].ToString().Length==0)
                {
                    dataGridView1.Rows[b].DefaultCellStyle.BackColor = Color.Orange;
                }else { 
                /*MessageBox.Show(DateTime.Parse(a["dtLeshimi"].ToString()).Date.ToString());
                MessageBox.Show("Vs" + DateTime.Now.Date);
                */if (DateTime.Parse(a["dtLeshimi"].ToString()).Date== DateTime.Now.Date)
                {
                    dataGridView1.Rows[b].DefaultCellStyle.BackColor = Color.Orange;
                }
                else if (DateTime.Parse(a["dtLeshimi"].ToString()).Date < DateTime.Now.Date)
                {
                    dataGridView1.Rows[b].DefaultCellStyle.BackColor = Color.Red;
                }
                }
                b++;

            }
            dataGridView1.ClearSelection();


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

        private void button3_Click(object sender, EventArgs e)
        {
            //lexuesShowData1.BringToFront();
            lexuesShowData1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //showLibra1.BringToFront();
            lexuesShowData1.Hide();
        }
    }
}
