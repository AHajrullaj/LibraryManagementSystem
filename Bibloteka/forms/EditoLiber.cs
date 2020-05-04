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
    public partial class EditoLiber : Form
    {
        int indeksEtikete = 0;
        string imageLocation = "";
        public static string id;
        public static string titul;
        public static string autor;
        public static string isbn;
        public static string sasi;
        public static string demtuar;
        public static string gjendje;
        public static string statusi;
        public static string[] barK;
        //public static string[] JObarK;
        public static string[] etiketat = new string[6];
        
        
        private readonly shfaqLibraMenaxheri frm1;
        public EditoLiber(shfaqLibraMenaxheri frm)
        {

            InitializeComponent();
            frm1 = frm;
        }
        public EditoLiber()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int d= Convert.ToInt32(textBox8.Text), gj= Convert.ToInt32(textBox7.Text);
            while (true) { 
            if (Convert.ToInt32(textBox7.Text) > Convert.ToInt32(textBox5.Text))
            {
                MessageBox.Show("Gjendja e ka kaluara sasine! Vendosni nje sasi ose gjendje te sakte", "Error");
                    break;
            }else if(Convert.ToInt32(sasi) > Convert.ToInt32(textBox5.Text)){
                    MessageBox.Show("Sasi jo e rregullt\n Tip: Nese deshironi te fshini zgjidhni opsionin e demtuar per te kapur\n kopjen qe deshironi te fshini");
                    break;
            }else{
                    /*if (textBox6.Text.Length==0)
                    {*/
                        if (imageLocation != "")
                        {
                            //MessageBox.Show("if ");
                            SqlConnection scn = new SqlConnection();
                            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                            scn.Open();
                            Console.WriteLine("Image location" + imageLocation);
                            byte[] imag = File.ReadAllBytes(imageLocation);
                            SqlCommand cmd;
                            if (comboBox1.SelectedIndex == 1)
                            {
                                //s -= Convert.ToInt32(textBox6.Text);
                                //gj -= Convert.ToInt32(textBox6.Text);
                                if (Convert.ToInt32(textBox6.Text) > d)
                                {
                                    gj -= Convert.ToInt32(textBox6.Text) - d;
                                }
                                else
                                {
                                    gj += d - Convert.ToInt32(textBox6.Text);
                                }

                                if (gj < 0) { gj = 0; }
                                cmd = new SqlCommand("UPDATE Liber SET emer = @name, autor = @autor, ISBN=@isbn, sasia=@sasi,gjendje=@gjendje,imageUrl=@Image, demtuar=@demtuar Where id=@id", scn);
                                cmd.Parameters.AddWithValue("@demtuar", Convert.ToInt32(textBox6.Text));
                                cmd.Parameters.AddWithValue("@gjendje", gj);

                            }
                            else
                            {
                                if (gj < 0) { gj = 0; }
                                cmd = new SqlCommand("UPDATE Liber SET emer = @name, autor = @autor, ISBN=@isbn, sasia=@sasi,gjendje=@gjendje,imageUrl=@Image,demtuar=@demtuar Where id=@id", scn);
                                cmd.Parameters.AddWithValue("@demtuar", Convert.ToInt32(textBox8.Text));
                                gj += Convert.ToInt32(textBox5.Text) - Convert.ToInt32(sasi);
                                //MessageBox.Show("HEREEE" + gj);
                                cmd.Parameters.AddWithValue("@gjendje", gj);
                            }
                            cmd.Parameters.AddWithValue("@id", id);

                            cmd.Parameters.AddWithValue("@Image", imag);
                            cmd.Parameters.AddWithValue("@name", textBox2.Text);
                            cmd.Parameters.AddWithValue("@autor", textBox3.Text);
                            cmd.Parameters.AddWithValue("@isbn", textBox4.Text);
                            cmd.Parameters.AddWithValue("@sasi", Convert.ToInt32(textBox5.Text));
                            cmd.ExecuteNonQuery();
                            int indeksTj = 0;
                            // MessageBox.Show("vektori\n" + barK.Length);
                            string[] JObarK1 = new string[Convert.ToInt32(sasi)];
                            for (int i = 0; i < JObarK1.Length; i++)
                            {
                                if (checkedListBox1.GetItemCheckState(i) == CheckState.Unchecked)
                                {
                                    JObarK1[i] = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                                    //MessageBox.Show(JObarK1[i] + "eshte jo i selektuar");
                                }
                            }
                            for (int i = 0; i < barK.Length; i++)
                            {
                                if (barK[i] != null)
                                {
                                    //MessageBox.Show("barkodi\n" + barK[i]);
                                    cmd = new SqlCommand("UPDATE KopjeLibri SET demtuar = 1 Where id_Liber=@id and barkodi=@bk", scn);
                                    cmd.Parameters.AddWithValue("@id", id);
                                    cmd.Parameters.AddWithValue("@bk", barK[i]);
                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {

                                    //MessageBox.Show("SKA"+ JObarK1[indeksTj]);
                                    cmd = new SqlCommand("UPDATE KopjeLibri SET demtuar = 0 Where id_Liber=@id and barkodi=@bk", scn);
                                    cmd.Parameters.AddWithValue("@id", id);
                                    cmd.Parameters.AddWithValue("@bk", JObarK1[indeksTj]);
                                    cmd.ExecuteNonQuery();
                                    indeksTj++;
                                }
                            }
                            if (Convert.ToInt32(sasi) < Convert.ToInt32(textBox5.Text))
                            {
                                int sasiERe = Convert.ToInt32(textBox5.Text) - Convert.ToInt32(sasi);
                                int sasiTXB = Convert.ToInt32(textBox5.Text);
                                string bar = null, vend = null;
                                //"SELECT TOP 6 imageUrl FROM Liber ORDER BY Id DESC "
                                cmd = new SqlCommand("SELECT TOP barkodi,vendndodhja from KopjeLibri where id_Liber=@idja ORDER BY id_Kopje DESC", scn);
                                cmd.Parameters.AddWithValue("@idja", id);
                                SqlDataReader sh = cmd.ExecuteReader();
                                while (sh.Read())
                                {
                                    bar = sh["barkodi"].ToString();
                                    vend = sh["barkodi"].ToString();
                                    break;
                                }

                                MessageBox.Show(bar + "~~~~" + vend);
                                while (sasiERe > 0)
                                {
                                    bar = bar.Substring(0, bar.Length - 2);
                                    string query = "INSERT INTO KopjeLibri (barkodi,vendndodhja,demtuar,rezervuar,id_Liber)";
                                    query += " VALUES (@bar, @vend,0,0,@lID)";
                                    cmd = new SqlCommand(query, scn);
                                    cmd.Parameters.AddWithValue("@lID", id);
                                    cmd.Parameters.AddWithValue("@bar", bar + "-" + sasiTXB);
                                    cmd.Parameters.AddWithValue("@vend", vend);
                                    cmd.ExecuteNonQuery();
                                    sasiTXB--;
                                    sasiERe--;
                                }
                            }


                            scn.Close();

                            //MessageBox.Show("Update i sukseshem");
                            SqlConnection scnn = new SqlConnection();
                            scnn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                            scnn.Open();
                            SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Liber", scnn);
                            DataTable dtbl = new DataTable();
                            sqlDa.Fill(dtbl);
                            frm1.dataGridView1.DataSource = dtbl;
                            scnn.Close();
                            this.Close();
                            break;
                        }
                        else
                        {
                            //MessageBox.Show("else i fundit");
                            SqlConnection scn = new SqlConnection();
                            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                            scn.Open();

                            SqlCommand cmd;
                            if (comboBox1.SelectedIndex == 1)
                            {
                                if (Convert.ToInt32(textBox6.Text) > d)
                                {
                                    gj -= Convert.ToInt32(textBox6.Text) - d;
                                }
                                else
                                {
                                    gj += d - Convert.ToInt32(textBox6.Text);
                                }
                                if (gj < 0) { gj = 0; }
                                cmd = new SqlCommand("UPDATE Liber SET emer = @name, autor = @autor, ISBN=@isbn, sasia=@sasi,gjendje=@gjendje,demtuar=@demtuar Where id=@id", scn);
                                cmd.Parameters.AddWithValue("@demtuar", Convert.ToInt32(textBox6.Text));
                                cmd.Parameters.AddWithValue("@gjendje", gj);
                            }
                            else
                            {
                                //if (gj < 0) { gj = 0; }
                                cmd = new SqlCommand("UPDATE Liber SET emer = @name, autor = @autor, ISBN=@isbn, sasia=@sasi,gjendje=@gjendje,demtuar=@demtuar Where id=@id", scn);
                                
                                gj+= Convert.ToInt32(textBox5.Text) - Convert.ToInt32(sasi);
                                MessageBox.Show("HEREEE" + gj);
                                cmd.Parameters.AddWithValue("@gjendje", gj);
                                cmd.Parameters.AddWithValue("@demtuar", Convert.ToInt32(textBox8.Text));
                            }
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@name", textBox2.Text);
                            cmd.Parameters.AddWithValue("@autor", textBox3.Text);
                            cmd.Parameters.AddWithValue("@isbn", textBox4.Text);
                            cmd.Parameters.AddWithValue("@sasi", Convert.ToInt32(textBox5.Text));
                            cmd.ExecuteNonQuery();
                            insertimAfterDelete();
                            // MessageBox.Show("vektori 2\n" + barK.Length);
                            if (comboBox1.SelectedIndex == 1) { 
                            string[] JObarK1 = new string[Convert.ToInt32(sasi)];
                            for (int i = 0; i < JObarK1.Length; i++)
                            {
                                if (checkedListBox1.GetItemCheckState(i) == CheckState.Unchecked)
                                {
                                    JObarK1[i] = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                                    //MessageBox.Show(JObarK1[i] + "eshte jo i selektuar");
                                }
                            }
                            for (int i = 0; i < barK.Length; i++)
                            {

                                if (barK[i] != null)
                                {
                                    cmd = new SqlCommand("UPDATE KopjeLibri SET demtuar = 1 Where id_Liber=@id and barkodi=@bk", scn);
                                    cmd.Parameters.AddWithValue("@id", id);
                                    cmd.Parameters.AddWithValue("@bk", barK[i]);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            for (int indeksTj = 0; indeksTj < JObarK1.Length; indeksTj++)
                            {

                                // MessageBox.Show("SKA" + JObarK1[indeksTj] + " indtj=" + indeksTj);
                                if (JObarK1[indeksTj] != null)
                                {
                                    cmd = new SqlCommand("UPDATE KopjeLibri SET demtuar = 0 Where id_Liber=@id and barkodi=@bk", scn);
                                    cmd.Parameters.AddWithValue("@id", id);
                                    cmd.Parameters.AddWithValue("@bk", JObarK1[indeksTj]);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                                if (Convert.ToInt32(sasi) < Convert.ToInt32(textBox5.Text))
                                {
                                    int sasiERe = Convert.ToInt32(textBox5.Text) - Convert.ToInt32(sasi);
                                    int sasiTXB = Convert.ToInt32(textBox5.Text);
                                    string bar = null, vend = null;
                                    //"SELECT TOP 6 imageUrl FROM Liber ORDER BY Id DESC "
                                    cmd = new SqlCommand("SELECT TOP 1 barkodi,vendndodhja from KopjeLibri where id_Liber=@idja ORDER BY id_Kopje DESC", scn);
                                    cmd.Parameters.AddWithValue("@idja", id);
                                    SqlDataReader sh = cmd.ExecuteReader();
                                    while (sh.Read())
                                    {
                                        bar = sh["barkodi"].ToString();
                                        vend = sh["vendndodhja"].ToString();
                                        break;
                                    }
                                string bar1 = null;
                                    MessageBox.Show(bar + "~~2~~" + vend + "~~2~~" +sasiERe);
                                    while (sasiERe > 0)
                                    {
                                        bar1 = bar.Substring(0, bar.Length - 2);
                                        string query = "INSERT INTO KopjeLibri (barkodi,vendndodhja,demtuar,rezervuar,id_Liber)";
                                        query += " VALUES (@bar, @vend,0,0,@lID)";
                                        cmd = new SqlCommand(query, scn);
                                        cmd.Parameters.AddWithValue("@lID", id);
                                        cmd.Parameters.AddWithValue("@bar", bar1 + "-" + sasiTXB);
                                        cmd.Parameters.AddWithValue("@vend", vend);
                                        cmd.ExecuteNonQuery();
                                        sasiTXB--;
                                        sasiERe--;
                                    }
                                }
                                scn.Close();
                                MessageBox.Show("Update i sukseshem");
                                SqlConnection scnn = new SqlConnection();
                                scnn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                                scnn.Open();
                                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * from Liber", scnn);
                                DataTable dtbl = new DataTable();
                                sqlDa.Fill(dtbl);
                                frm1.dataGridView1.DataSource = dtbl;
                                scnn.Close();
                                this.Close();
                                break;
                            }
                            MessageBox.Show("su fut fr");
                        
                    /*}*/
            }
            }
        }
        /*public string [] merrJoTeEtikuar()
        {
            string [] JObarK1 = new string[Convert.ToInt32(sasi)];
            for (int i = 0; i < JObarK1.Length; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    JObarK1[i] = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    MessageBox.Show(JObarK1[i] + "eshte jo i selektuar");
                }
            }
            return JObarK1;
        }*/

        private void EditoLiber_Load(object sender, EventArgs e)
        {
            textBox1.Text = id;
            textBox2.Text = titul;
            textBox3.Text = autor;
            textBox4.Text = isbn;
            textBox5.Text = sasi;
            textBox7.Text = gjendje;
            textBox8.Text = demtuar;
            comboBox1.SelectedIndex = 0;
            Label[] labeli = {label11,label12,label13,label14,label15,label16 };
            for (int i=0;i<etiketat.Length;i++)
            {
                    labeli[i].Text = etiketat[i];
                
            }
            for (int i = 0; i < labeli.Length; i++)
            {
                if (labeli[i].Text.Length != 0)
                {
                    indeksEtikete++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(indeksEtikete);
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT imageUrl FROM Liber where id=@id ", con);
            da.SelectCommand.Parameters.AddWithValue("@id",textBox1.Text);
            DataSet ds = new DataSet();
            da.Fill(ds);
           
            int m = ds.Tables[0].Rows.Count;
            if (m > 0)
            {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["imageUrl"]);
                    pictureBox1.Image = new Bitmap(ms);
            }

            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                label8.Visible = true;
                textBox6.Visible = true;
                label18.Visible = true;
                checkedListBox1.Visible = true;
                SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                SqlCommand scmd = new SqlCommand("select barkodi,demtuar from KopjeLibri where id_Liber=@idja", scn);
                scmd.Parameters.AddWithValue("@idja", id);
                SqlDataReader a = scmd.ExecuteReader();
                int[] m = new int[Convert.ToInt32( sasi)];
                int i = 0;
                while (a.Read())
                {
                    checkedListBox1.Items.Add(a["barkodi"].ToString());
                    m[i] = Convert.ToInt32(a["demtuar"]);
                    i++;
                }
                for (i = 0; i < m.Length; i++)
                {
                    if (m[i] == 1)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
                scn.Close();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label[] etiket = { label11, label12, label13, label14, label15, label16 };
            if (comboBox2.SelectedItem == null)
            {

            }
            else
            {
                bool p = true;
                if (true)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (etiket[j].Text.Equals(this.comboBox2.GetItemText(this.comboBox2.SelectedItem)))
                        {
                            p = false;
                            break;
                        }
                    }

                }
                if (p)
                {
                    etiket[indeksEtikete].Text = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
                    indeksEtikete++;

                }


            }
        }
        private void hiqEtiket()
        {

            Label[] etiket = { label11, label12, label13, label14, label15, label16 };
            string[] et = { label11.Text, label12.Text, label13.Text, label14.Text, label15.Text, label16.Text };
            var temp = new List<string>();
            foreach (var s in et)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            et = temp.ToArray();
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

        private void label14_Click(object sender, EventArgs e)
        {
            label14.Text = "";
            hiqEtiket();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            label15.Text = "";
            hiqEtiket();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            label16.Text = "";
            hiqEtiket();
        }
        private void insertimAfterDelete()
        {
                SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM liber_kategoriLiber WHERE liber_kategoriLiber.Liber_id=@id ", scn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            int idKategorie = 1;
            Label[] etiket = { label11, label12, label13, label14, label15, label16 };
            for (int i = 0; i < etiket.Length; i++)
            {
                if (etiket[i].Text.Length != 0)
                {
                    SqlCommand scmd = new SqlCommand("SELECT id from KategoriLibri where name=@name ", scn);
                    scmd.Parameters.AddWithValue("@name", etiket[i].Text);

                    SqlDataReader a = scmd.ExecuteReader();
                    if (a.Read())
                    {
                        idKategorie = Convert.ToInt32(a["id"].ToString());
                    }
                    string query = "INSERT INTO liber_kategoriLiber (liber_kategoriLiber.Liber_id, liber_kategoriLiber.KategoriLibri_id)";
                    query += " VALUES (@lID, @kID)";
                    scmd = new SqlCommand(query, scn);
                    scmd.Parameters.AddWithValue("@lID", id);
                    scmd.Parameters.AddWithValue("@kID", idKategorie);
                    scmd.ExecuteNonQuery();
                }
                else
                {
                    break;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox6.Text = checkedListBox1.SelectedItems.Count.ToString();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int m = 0;
            barK=new string[checkedListBox1.Items.Count];

            
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                barK[m] = itemChecked.ToString();
                m++;
                textBox6.Text = m.ToString();
              
            }
            int l = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    l++;
                }
            }
            textBox6.Text = l.ToString();
        }
    }
}
