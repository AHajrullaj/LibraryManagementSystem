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
using Bibloteka.forms;

namespace Bibloteka
{
    public partial class MainUserControl1 : UserControl
    {
        public MainUserControl1()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string fileName = @"C:\Users\HP\Desktop\foto\foto1.jpg";
            string connectionString = "Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                FileInfo finfo = new FileInfo(fileName);

                byte[] btImage = new byte[finfo.Length];
                FileStream fStream = finfo.OpenRead();

                fStream.Read(btImage, 0, btImage.Length);
                fStream.Close();

                using (SqlCommand sqlCommand = new SqlCommand(
                       "INSERT INTO Liber (emer,[autor],ISBN,sasia,gjendje,statusi,imageUrl) VALUES('Harry Potter', 'JKRowling','JKRowliddsdng',5,5,'N',@image)",
                       sqlConnection))
                { 
                    SqlParameter imageParameter =
                                   new SqlParameter("@image", SqlDbType.Image);
                    imageParameter.Value = btImage;

                    sqlCommand.Parameters.Add(imageParameter);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        

        private void MainUserControl1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 6 imageUrl FROM Liber ORDER BY Id DESC ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = 0;
            int m=ds.Tables[0].Rows.Count;
            PictureBox[] boxes = {pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6};
            while (m>0) {
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[i]["imageUrl"]);
                    
                        boxes[i].Image = new Bitmap(ms);
                    
                    i++;


                }
                else { break; }
                m--;
            
            }
            SqlCommand scmd = new SqlCommand("select TOP 6 emer,autor from Liber ORDER BY Id DESC ", con);

            SqlDataReader a = scmd.ExecuteReader();
            Label[] labels = { label1,label2,label5,label6,label7,label8,label9,label10,label11,label12,label13,label14};
            int index = 0;
            while (a.Read())
            {
                labels[index].Text = a["emer"].ToString();
                labels[index+1].Text = a["autor"].ToString();
                index+=2;

            }
            con.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            string t = label1.Text;
            string a = label2.Text;
            kodiILibraveIndividual(t,a);

        }
        private void kodiILibraveIndividual(string titulli,string autori)
        {
            
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select Id,emer,autor,ISBN,sasia,gjendje from Liber where emer=@emer and autor=@autor", scn);
            scmd.Parameters.AddWithValue("@emer", titulli);
            scmd.Parameters.AddWithValue("@autor", autori);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                singleBook.id = a["Id"].ToString();
                singleBook.titul = a["emer"].ToString();
                singleBook.autor = a["autor"].ToString();
                singleBook.isbn = a["ISBN"].ToString();
                singleBook.sasi = a["sasia"].ToString();
                singleBook.gjendje = a["gjendje"].ToString();
                break;
            }
            scn.Close();
            singleBook frm = new singleBook(this);
            frm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string t = label7.Text;
            string a = label8.Text;
            kodiILibraveIndividual(t, a);
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            string t = label11.Text;
            string a = label12.Text;
            kodiILibraveIndividual(t, a);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            string t = label5.Text;
            string a = label6.Text;
            kodiILibraveIndividual(t, a);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string t = label9.Text;
            string a = label10.Text;
            kodiILibraveIndividual(t, a);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            string t = label13.Text;
            string a = label14.Text;
            kodiILibraveIndividual(t, a);
        }
    }
}
