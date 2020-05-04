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

namespace Bibloteka.controllers
{
    public partial class ShtoLiberMenaxher : UserControl
    {
        int indeksEtikete = 0;
        string imageLocation = "";
        public ShtoLiberMenaxher()
        {
            InitializeComponent();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8 )
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
                 
                
            }
            catch (Exception)
            {
                MessageBox.Show("opsi", "error", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }


            }
            catch (Exception)
            {
                MessageBox.Show("opsi", "error", MessageBoxButtons.OK);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emr = textBox1.Text;
            string autor = textBox2.Text;
            string isbn = textBox5.Text;
            int sasia ;
            if (emr.Length == 0 || autor.Length == 0 || isbn.Length == 0 || textBox3.Text.Length == 0 || label8.Text.Length == 0)
            {
                MessageBox.Show("Sigurohuni qe te keni plotesuar te gjitha fushat", "error", MessageBoxButtons.OK);
            }
            else
            {
                sasia = Convert.ToInt32(textBox3.Text);
                if (Convert.ToInt32(sasia) < 50&&isbn.Length==13) {
                    isbn = isbn.Substring(0, 3) + "-" + isbn.Substring(3, 1) + "-" + isbn.Substring(4, 2) + "-" + isbn.Substring(6, 6) + "-" + isbn.Substring(12, 1);
                    SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                Console.WriteLine(imageLocation);
                if (imageLocation == "" || imageLocation == null)
                {
                    string fileName = @"C:\Users\HP\Desktop\foto\noAvailable.jpg";
                    FileInfo finfo = new FileInfo(fileName);

                    byte[] btImage = new byte[finfo.Length];
                    FileStream fStream = finfo.OpenRead();

                    fStream.Read(btImage, 0, btImage.Length);
                    fStream.Close();
                    SqlCommand cmdi = new SqlCommand("INSERT INTO Liber (emer,[autor],ISBN,sasia,gjendje,statusi,demtuar,imageUrl,fshire) VALUES(@emr,@aut,@isbn,@sasia,@sasia,'normal',0,@Image,0)", scn);
                    SqlParameter imageParameter =
                                       new SqlParameter("@Image", SqlDbType.Image);
                    imageParameter.Value = btImage;

                    cmdi.Parameters.Add(imageParameter);
                    cmdi.Parameters.AddWithValue("@emr", emr);
                    cmdi.Parameters.AddWithValue("@aut", autor);
                    cmdi.Parameters.AddWithValue("@isbn", isbn);
                    cmdi.Parameters.AddWithValue("@sasia", sasia);
                    cmdi.ExecuteNonQuery();
                    scn.Close();
                }
                else
                {


                    byte[] imag = File.ReadAllBytes(imageLocation);
                    SqlCommand cmd = new SqlCommand("INSERT INTO Liber (emer,[autor],ISBN,sasia,gjendje,statusi,demtuar,imageUrl,fshire) VALUES(@emr,@aut,@isbn,@sasia,@sasia,'normal',0,@Image,0)", scn);
                    cmd.Parameters.AddWithValue("@Image", imag);
                    cmd.Parameters.AddWithValue("@emr", emr);
                    cmd.Parameters.AddWithValue("@aut", autor);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@sasia", sasia);
                    cmd.ExecuteNonQuery();
                    scn.Close();
                }

                SqlCommand scmd = new SqlCommand("SELECT TOP 1 Id  FROM Liber ORDER BY Id DESC ", scn);
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                SqlDataReader a = scmd.ExecuteReader();
                int idLibri=1, idKategorie=1;
                string nrkatlibPerBarkod = "";
                if (a.Read())
                {
                    idLibri = Convert.ToInt32(a["Id"].ToString());
                }
                Label[] etiket = { label8, label9, label10, label11, label12, label13 };
                for(int i = 0; i < etiket.Length; i++)
                {
                    if (etiket[i].Text.Length != 0)
                    {
                        scmd= new SqlCommand("SELECT id from KategoriLibri where name=@name ", scn);
                        scmd.Parameters.AddWithValue("@name", etiket[i].Text);

                        a = scmd.ExecuteReader();
                        if (a.Read())
                        {
                            idKategorie = Convert.ToInt32(a["id"].ToString());
                                nrkatlibPerBarkod += idKategorie;
                        }
                        string query = "INSERT INTO liber_kategoriLiber (liber_kategoriLiber.Liber_id, liber_kategoriLiber.KategoriLibri_id)";
                        query += " VALUES (@lID, @kID)";
                        scmd= new SqlCommand(query, scn);
                        scmd.Parameters.AddWithValue("@lID", idLibri);
                        scmd.Parameters.AddWithValue("@kID", idKategorie);
                        scmd.ExecuteNonQuery();
                    }
                    else
                    {
                        break;
                    }

                }
                    string barkodi = nrkatlibPerBarkod + "-" + idLibri;
                    string vend="Rafti me numer-"+nrkatlibPerBarkod.Substring(0, 1) + "-Rradha: " + textBox1.Text.Substring(0, 1).ToUpper();
                    for(int i=0;i<sasia; i++)
                    {
                       // barkodi += "-" + i;
                        string query = "INSERT INTO KopjeLibri (barkodi,vendndodhja,demtuar,rezervuar,id_Liber)";
                        query += " VALUES (@bar, @vend,0,0,@lID)";
                        scmd = new SqlCommand(query, scn);
                        scmd.Parameters.AddWithValue("@lID", idLibri);
                        scmd.Parameters.AddWithValue("@bar", barkodi+"-"+i);
                        scmd.Parameters.AddWithValue("@vend", vend);
                        scmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Libri i shtua me sukses", "Success!", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Nuk mund te shtoni me shume se 50 libra ne te njejten kohe\n Ose vendosni nje isbn te sakte", "error", MessageBoxButtons.OK);
                }
                //MessageBox.Show("DONE GIRLL", "error", MessageBoxButtons.OK);
            }
        }

        private void ShtoLiberMenaxher_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label[] etiket = {label8,label9,label10,label11,label12,label13 };
            if (comboBox1.SelectedItem == null)
            {

            }
            else
            {
                bool p = true;
                if (true)
                {
                        for (int j = 0; j < 5; j++)
                        {
                            if (etiket[j].Text.Equals(this.comboBox1.GetItemText(this.comboBox1.SelectedItem)))
                            {
                            p = false;
                                break;
                            }
                        }

                }
                if (p)
                {
                    etiket[indeksEtikete].Text = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                    indeksEtikete++;
                     
                }
               

            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
                label8.Text = "";
                hiqEtiket();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            hiqEtiket();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            label10.Text = "";
            hiqEtiket();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            label11.Text = "";
            hiqEtiket();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            label12.Text = "";
            hiqEtiket();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            label13.Text = "";
            hiqEtiket();
        }
        private void hiqEtiket()
        {
           
            Label[] etiket = { label8, label9, label10, label11, label12, label13 };
            string[] et = { label8.Text, label9.Text, label10.Text, label11.Text, label12.Text, label13.Text };
            var temp = new List<string>();
            foreach (var s in et)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            et = temp.ToArray();
            Console.WriteLine(et.Length);
            for (int i = 0; i < et.Length; i++)
            {
                if (et[i] != "")
                {
                    etiket[i].Text = et[i];
                }


            }
            for (int i = et.Length; i < 6; i++)
            {
                etiket[i].Text = "";
            }
            indeksEtikete--;
        }
    }
}
