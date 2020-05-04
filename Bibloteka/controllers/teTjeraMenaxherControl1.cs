using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;
using Bibloteka.formsReports;

namespace Bibloteka.controllers
{
    public partial class teTjeraMenaxherControl1 : UserControl
    {
        public teTjeraMenaxherControl1()
        {
            InitializeComponent();
        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
                // MessageBox.Show("opsi", "error", MessageBoxButtons.OK);
                SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                byte[] imag = File.ReadAllBytes(imageLocation);
                SqlCommand cmd = new SqlCommand("INSERT INTO Liber (emer,[autor],ISBN,sasia,gjendje,statusi,imageUrl) VALUES('liber2','whatever','provainsert1',5,5,'prov',@Image)", scn);
                cmd.Parameters.AddWithValue("@Image", imag);
                cmd.ExecuteNonQuery();
                MessageBox.Show("DONE GIRLL", "error", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("opsi", "error", MessageBoxButtons.OK);
            }


        }*/

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            LexuesQeKaneKaluarAfatin f = new LexuesQeKaneKaluarAfatin();
            f.ShowDialog();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ListLibrashRaportFrame f = new ListLibrashRaportFrame();
            f.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            /* LExTotale l = new LExTotale();
             l.ShowDialog();*/
            provaTotal l = new provaTotal();
            l.ShowDialog();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            Color color1 = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
            label3.BackColor = color1;
            label1.BackColor = color1;
            Color color = System.Drawing.ColorTranslator.FromHtml("#e9e0db");
            label2.BackColor = color;
            //
           
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            Color color1 = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
            label2.BackColor = color1;
            label4.BackColor = color1;
            Color color = System.Drawing.ColorTranslator.FromHtml("#e9e0db");
            label3.BackColor = color;
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            Color color1 = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
            label2.BackColor = color1;
            label3.BackColor = color1;
            Color color = System.Drawing.ColorTranslator.FromHtml("#e9e0db");
            label4.BackColor = color;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            EcuriaELex l = new EcuriaELex();
            l.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ecuriaELeximitNJElib l = new ecuriaELeximitNJElib();
            l.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ecuriaEKategorise ec = new ecuriaEKategorise();
            ec.ShowDialog();
        }
    }
}
