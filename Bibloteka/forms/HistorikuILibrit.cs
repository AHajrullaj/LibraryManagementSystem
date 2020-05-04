using Bibloteka.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibloteka.forms
{
    public partial class HistorikuILibrit : Form
    {
        private readonly shfaqLibraMenaxheri frm1;
        public static string id;
        public static string titul;
        public static string autor;
        public static string isbn;
        public HistorikuILibrit()
        {
            InitializeComponent();
        }
        public HistorikuILibrit(shfaqLibraMenaxheri frm)
        {
            InitializeComponent();

            frm1 = frm;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HistorikuILibrit_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT imageUrl FROM Liber where id=@id ", con);
            da.SelectCommand.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            DataSet ds = new DataSet();
            da.Fill(ds);

            int m = ds.Tables[0].Rows.Count;
            if (m > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["imageUrl"]);
                pictureBox1.Image = new Bitmap(ms);
            }
            label5.Text = titul;
            label6.Text = autor;
            label7.Text = isbn;
            SqlDataAdapter sqlDa = new SqlDataAdapter("select firstName,lastName,id_KB,dtRezervimi,dtLeshimi,salle from liberLexues join Lexues on Lexues.Id=liberLexues.id_Lexues where id_Liber=@idj ", con);
            //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
            sqlDa.SelectCommand.Parameters.AddWithValue("@idj",HistorikuILibrit.id);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
        }
    }
}
