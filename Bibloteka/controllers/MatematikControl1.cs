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
using Bibloteka.forms;

namespace Bibloteka.controllers
{
    public partial class MatematikControl1 : UserControl
    {
        singleBook frm;
        public MatematikControl1()
        {
            InitializeComponent();
        }

        private void MatematikControl1_Load(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Liber.Id,emer,autor,ISBN,sasia,gjendje from Liber join liber_kategoriLiber on liber_kategoriLiber.Liber_Id=Liber.Id join KategoriLibri on liber_kategoriLiber.KategoriLibri_Id=KategoriLibri.id where KategoriLibri_Id=5 ", scn);
            //SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            scn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection scn = new SqlConnection(@"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI");
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select emer,autor,ISBN,sasia,gjendje from Liber join liber_kategoriLiber on liber_kategoriLiber.Liber_Id=Liber.Id join KategoriLibri on liber_kategoriLiber.KategoriLibri_Id=KategoriLibri.id where KategoriLibri_Id=5 and (emer like '%" + textBox1.Text + "%' or autor like '%" + textBox1.Text + "%')", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {


                int indeksi = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                //MessageBox.Show(indeksi.ToString());
                SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                SqlCommand scmd = new SqlCommand("select Id,emer,autor,ISBN,sasia,gjendje from Liber where Id=@idja", scn);

                scmd.Parameters.AddWithValue("@idja", indeksi);

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
                frm = new singleBook(this);

                frm.ShowDialog();
            }
        }
    }
}
