using Bibloteka.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Bibloteka.forms
{
    public partial class singleBook : Form
    {
        public static string id;
        public static string titul;
        public static string autor;
        public static string isbn;
        public static string sasi;
        public static string gjendje;
        private readonly MainUserControl1 frm1;
        private readonly KlasiketControl1 frm2;
        private readonly ElektronikControl1 frm3;
        private readonly FizikControl1 frm4;
        private readonly KimiControl1 frm5;
        private readonly MatematikControl1 frm6;
        private readonly TeknologjiControl1 frm7;
        public singleBook()
        {
            InitializeComponent();
        }
        public singleBook(MainUserControl1 frm)
        {

            InitializeComponent();
            frm1 = frm;
        }
        public singleBook(FizikControl1 frm)
        {

            InitializeComponent();
            frm4 = frm;
        }
        public singleBook(KlasiketControl1 frm)
        {

            InitializeComponent();
            frm2 = frm;
        }
        public singleBook(ElektronikControl1 frm)
        {

            InitializeComponent();
            frm3 = frm;
        }
        public singleBook(KimiControl1 frm)
        {

            InitializeComponent();
            frm5 = frm;
        }
        public singleBook(MatematikControl1 frm)
        {

            InitializeComponent();
            frm6 = frm;
        }
        public singleBook(TeknologjiControl1 frm)
        {

            InitializeComponent();
            frm7 = frm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.loguar==true && Form1.role == "Lexuesi")
            {
                MessageBox.Show("Do dali nderfaqja e perdoruesit..ajo e rezervimit");
            }else if(Form1.loguar == true && Form1.role == "PunonjesiSportelit" || Form1.role == "Menaxheri")
            {
                MessageBox.Show("Jeni loguar si perdorues me rrol menaxheri apo punonjes sporteli");
            }
            else
            {
                MessageBox.Show("Ju duhet te logoheni qe te rezervoni kete liber");
                this.Close();/*Hide();
                Login frm2 = new Login();
                frm2.ShowDialog();*/
            }
        }

        private void singleBook_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            textBox2.Text = titul;
            textBox3.Text = autor;
            textBox4.Text = isbn;
            textBox5.Text = sasi;
            textBox7.Text = gjendje;
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT imageUrl FROM Liber where id=@id ", con);
            da.SelectCommand.Parameters.AddWithValue("@id",Convert.ToInt32( id));
            DataSet ds = new DataSet();
            da.Fill(ds);

            int m = ds.Tables[0].Rows.Count;
            if (m > 0)
            {
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["imageUrl"]);
                pictureBox1.Image = new Bitmap(ms);
            }
            SqlCommand scmd2 = new SqlCommand("select barkodi from KopjeLibri join Liber on KopjeLibri.id_Liber=Id where Id=@idja and rezervuar=0 ", con);
            //MessageBox.Show(idELibrave[i].Text);
           // comboBox1.ValueMember = "barkodi";
            scmd2.Parameters.AddWithValue("@idja", Convert.ToInt32(singleBook.id));
            SqlDataReader a3 = scmd2.ExecuteReader();
            while (a3.Read())
            {
                comboBox1.Items.Add(a3["barkodi"].ToString());
            }
            
            /*comboBox1.DisplayMember = "barkodi";*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedValue+"//-----------"+ comboBox1.SelectedIndex);
            int a = comboBox1.SelectedIndex;
            pictureBox2.Visible = true;

            string brk = comboBox1.Items[a].ToString();
            if (brk.Length != 0)
            {
                /*Bitmap bitmap = new Bitmap(brk.Length * 22, 70);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font oFont = new System.Drawing.Font("IDAutomationHC39M", 12);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush black = new SolidBrush(Color.Black);
                    SolidBrush White = new SolidBrush(Color.White);
                    graphics.FillRectangle(White, 0, 0, bitmap.Width, bitmap.Height);
                    graphics.DrawString("*" + brk + "*", oFont, black, point);

                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    pictureBox2.Image = bitmap;
                    pictureBox2.Height = bitmap.Height;
                    pictureBox2.Width = bitmap.Width;
                }*/
                BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                
                pictureBox2.Image = writer.Write(brk);
                

            }
        }
    }
}
