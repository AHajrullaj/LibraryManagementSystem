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

namespace Bibloteka
{
    public partial class afterLogin : Form
    {
        public afterLogin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
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
            catch(Exception)
            {
                MessageBox.Show("opsi", "error", MessageBoxButtons.OK);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm2 = new Form1();
            frm2.ShowDialog();
        }
    }
}
