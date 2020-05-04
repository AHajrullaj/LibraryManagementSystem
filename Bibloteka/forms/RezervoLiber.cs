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
    public partial class RezervoLiber : Form
    {
        int indeksEtikete = 0;
        public static string id;
        public static string idKB;
        public static string nrLibr;
        public static string emr;
        public static string mbr;
        private readonly shfaqLexuesitControl1 frm1;
        public RezervoLiber()
        {
            InitializeComponent();
        }
        public RezervoLiber(shfaqLexuesitControl1 frm)
        {
            InitializeComponent();

            frm1 = frm;
        }

        private void RezervoLiber_Load(object sender, EventArgs e)
        {
            textBox7.Text = id;
            textBox9.Text = emr;
            textBox10.Text = mbr;
            textBox8.Text = idKB;
            textBox11.Text = nrLibr;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker3.MinDate = DateTime.Today;
            dateTimePicker5.MinDate = DateTime.Today;
            dateTimePicker7.MinDate = DateTime.Today;
            dateTimePicker9.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(7);
            dateTimePicker3.MaxDate = DateTime.Today.AddDays(7);
            dateTimePicker5.MaxDate = DateTime.Today.AddDays(7);
            dateTimePicker7.MaxDate = DateTime.Today.AddDays(7);
            dateTimePicker9.MaxDate = DateTime.Today.AddDays(7);
            dateTimePicker2.MinDate = DateTime.Today;
            dateTimePicker4.MinDate = DateTime.Today;
            dateTimePicker6.MinDate = DateTime.Today;
            dateTimePicker8.MinDate = DateTime.Today;
            dateTimePicker10.MinDate = DateTime.Today;
            dateTimePicker2.MaxDate = DateTime.Today.AddDays(7);
            dateTimePicker4.MaxDate= DateTime.Today.AddDays(7);
            dateTimePicker6.MaxDate= DateTime.Today.AddDays(7);
            dateTimePicker8.MaxDate= DateTime.Today.AddDays(7);
            dateTimePicker10.MaxDate= DateTime.Today.AddDays(7);
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,emer,autor,sasia,gjendje from Liber where fshire <> 1", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            scn.Close();

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                SqlConnection scn = new SqlConnection(@"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI");
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select Id,emer,autor,sasia,gjendje from Liber where fshire <> 1 and emer like '%" + textBox1.Text+"%'", scn);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dataGridView1.DataSource = dtbl;

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox[] idELibrave = {textBox2,textBox3,textBox4,textBox5,textBox6};
            DateTimePicker[] dtRezervimi = { dateTimePicker1,dateTimePicker3,dateTimePicker5,dateTimePicker7,dateTimePicker9};
            DateTimePicker[] dtDorezimi = { dateTimePicker2, dateTimePicker4, dateTimePicker6, dateTimePicker8, dateTimePicker10 };
            PictureBox[] X = { pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5};
            ComboBox[] idKopje = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5 };
            DataGridView dgv = sender as DataGridView;
                if (dgv == null)
                    return;
                if (dgv.CurrentRow.Selected)
                {
                string idj =(dataGridView1.CurrentRow.Cells[0].Value).ToString();
                int  gjendje=1, demtuar=1;
                SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                SqlCommand scmd = new SqlCommand("select gjendje,demtuar from Liber where Id=@idja", scn);
                scmd.Parameters.AddWithValue("@idja", Convert.ToInt32(idj));
                SqlDataReader a = scmd.ExecuteReader();
                while (a.Read())
                { 
                    gjendje = Convert.ToInt32(a["gjendje"].ToString());
                    demtuar = Convert.ToInt32(a["demtuar"].ToString());
                    break;
                }
                if (gjendje == 0 && demtuar != 0)//(nrLiber <=5) ======>Per te caktuar nje kufi qe nuk mund te rezervoj me shume se 5 libraDONE
                {
                    DialogResult dialogResult = MessageBox.Show("Ju nuk mund te rezervoni kete liber\nDeshironi t'a rezervoni per ne salle?", "Libri nuk ka kopje te lira", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        
                        for (int i = 0; i < idELibrave.Length; i++)
                        {
                            if (idELibrave[i].Text.Length > 2)
                            {
                                idELibrave[i].Text = idELibrave[i].Text.Substring(0,2);
                            }
                            if (!idj.Equals(idELibrave[i].Text))
                            {
                               
                                if (idELibrave[i].Text.Length == 0)
                                {
                                    dtRezervimi[i].Visible = false;
                                    //dtDorezimi[i].Visible = false;
                                    dtDorezimi[i].MinDate = DateTime.Today;
                                    dtDorezimi[i].MaxDate = DateTime.Today;
                                    idELibrave[i].Text = idj + "-Salle";

                                    SqlCommand scmd2 = new SqlCommand("select barkodi from KopjeLibri join Liber on KopjeLibri.id_Liber=Id where Id=@idja and rezervuar=0 and KopjeLibri.demtuar=1", scn);
                                    //MessageBox.Show(idELibrave[i].Text);

                                    scmd2.Parameters.AddWithValue("@idja", Convert.ToInt32(idELibrave[i].Text.Substring(0, 2)));
                                    SqlDataReader a3 = scmd2.ExecuteReader();
                                    while (a3.Read())
                                    {
                                        idKopje[i].Items.Add(a3["barkodi"].ToString());
                                    }
                                    indeksEtikete++;
                                    a3.Close();
                                    Console.WriteLine("VERIFIKIM --"+idj+"/./././"+ !idj.Equals(idELibrave[i].Text)+""+ idELibrave[i].Text);
                                    break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Libri i vendosur njeher ne liste");
                                break;
                            }

                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        for (int i = 0; i < idELibrave.Length; i++)
                        {
                            if (idELibrave[i].Text.Length == 0)
                            {
                                idELibrave[i].Text = "";
                                break;
                            }

                        }
                    }

                }else if (gjendje==0)
                {
                    DialogResult dialogResult = MessageBox.Show("Ju nuk mund te rezervoni kete liber\nDeshironi ta rezervoni ne nje moment te dyte ?", "Libri nuk ka kopje te lira", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "INSERT INTO ListPritje (id_liber, id_lexues,id_kb)";
                        query += " VALUES (@idL, @idLex,@idKB)";
                        scmd = new SqlCommand(query, scn);
                        scmd.Parameters.AddWithValue("@idL", idj);
                        scmd.Parameters.AddWithValue("@idLex", id);
                        scmd.Parameters.AddWithValue("@idKB", idKB);
                        scmd.ExecuteNonQuery();

                    }
                       

                }
                else
                {  //(nrLiber <=5) ======>Per te caktuar nje kufi qe nuk mund te rezervoj me shume se 5 libra
                    for (int i = 0; i < idELibrave.Length; i++)
                    {
                        Console.WriteLine(!idj.Equals(idELibrave[i]) + "--" + idj + "---" + idELibrave[i]);
                        if (Convert.ToInt32(nrLibr)+ i < 5)
                        {
                            if (!idj.Equals(idELibrave[i].Text))
                            {
                                if (idELibrave[i].Text.Length == 0)
                                {
                                    idELibrave[i].Text = idj;
                                    
                                    SqlCommand scmd1 = new SqlCommand("select barkodi from KopjeLibri join Liber on KopjeLibri.id_Liber=Id where Id=@idja and rezervuar=0", scn);
                                    scmd1.Parameters.AddWithValue("@idja", Convert.ToInt32(idELibrave[i].Text));
                                    SqlDataReader a2 = scmd1.ExecuteReader();
                                    while (a2.Read())
                                    {
                                        idKopje[i].Items.Add(a2["barkodi"].ToString());
                                    }
                                    
                                    dtRezervimi[i].Visible = true;
                                    dtDorezimi[i].Visible = true;
                                    scmd1 = new SqlCommand("select Max(DitRezervimi) as ditet from KategoriLibri join liber_kategoriLiber on KategoriLibri.id=liber_kategoriLiber.KategoriLibri_Id where Liber_Id=@idj;",scn);
                                    scmd1.Parameters.AddWithValue("@idj", Convert.ToInt32(idELibrave[i].Text));
                                    a2 = scmd1.ExecuteReader();
                                    while (a2.Read())
                                    {
                                        //idKopje[i].Items.Add(a2["barkodi"].ToString());
                                        dtDorezimi[i].MaxDate = DateTime.Today.AddDays(Convert.ToInt32(a2["ditet"].ToString()));
                                        MessageBox.Show("HYRA" + a2["ditet"].ToString());
                                        break;
                                    }
                                    scn.Close();
                                    indeksEtikete++;
                                    break;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Libri i vendosur njeher ne liste");
                                break;
                            }
                            if (i+1 == idELibrave.Length )
                            {
                                MessageBox.Show("Nuk mund te perzgjidhini me libra");
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("arritet limitin e librave=5");
                            break;
                        }
                       

                    }
                    
                }
            }
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            /*if (textBox2.Text.Length != 0)
            {
                int sasia, gjendje, demtuar;
                int idLib1 = Convert.ToInt32(textBox2.Text);
                SqlConnection scn = new SqlConnection();
                scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                scn.Open();
                SqlCommand scmd = new SqlCommand("select sasia,gjendje,demtuar from Liber where Id=@idja", scn);
                scmd.Parameters.AddWithValue("@idja", idLib1);
                SqlDataReader a = scmd.ExecuteReader();
                while (a.Read())
                {
                    sasia = Convert.ToInt32(a["sasia"].ToString());
                    gjendje = Convert.ToInt32(a["gjendje"].ToString());
                    demtuar = Convert.ToInt32(a["demtuar"].ToString());
                    break;
                }

            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            comboBox1.Items.Clear();
            //comboBox2.Items.Clear();
            comboBox1.Visible = true;
            hiqEtiket();
            /*dateTimePicker1.ResetText();
            DateTime d = dateTimePicker1.Value.Date;
            Console.WriteLine(d.ToString("d"));*/
        }
        private void hiqEtiket()
        {

            TextBox[] etiket = {  textBox2, textBox3, textBox4, textBox5, textBox6};
            string[] et = {  textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text , textBox6.Text};
            DateTime[] datatERezervimit = { dateTimePicker1.Value.Date, dateTimePicker3.Value.Date, dateTimePicker5.Value.Date, dateTimePicker7.Value.Date, dateTimePicker9.Value.Date };
            DateTimePicker[] DtRez = { dateTimePicker1, dateTimePicker3, dateTimePicker5, dateTimePicker7, dateTimePicker9 };

            DateTime[] datatEDorezimit = { dateTimePicker2.Value.Date, dateTimePicker4.Value.Date, dateTimePicker6.Value.Date, dateTimePicker8.Value.Date, dateTimePicker10.Value.Date };
            DateTimePicker[] DtDor = { dateTimePicker2, dateTimePicker4, dateTimePicker6, dateTimePicker8, dateTimePicker10 };
            
            
            
            ComboBox[] idKopje = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5 };
            string[] listCombi1 = null, listCombi2 = null, listCombi3 = null, listCombi4 = null, listCombi5 = null;
            Object[] listaVektor = { listCombi1, listCombi2, listCombi3, listCombi4, listCombi5 };
            string[] result;
            
            for (int i = 0; i < idKopje.Length; i++)
            {
                listaVektor[i] = new string[idKopje[i].Items.Count];
                 result = (string[])listaVektor[i];
                for (int j = 0; j < idKopje[i].Items.Count; j++)
                {
                    result[j]= idKopje[i].Items[j].ToString();
                }
                listaVektor[i] = (Object[])result;
            }
            // Object listItems[] = { };

           // MessageBox.Show("fshira" + listaVektor[0].ToString() + "  " + listaVektor[1].ToString() + "  " + listaVektor[2].ToString());

            var temp = new List<string>();
            int ind = 0;
            var temp2 = new List<DateTime>();
            var temp3 = new List<DateTime>();
            var temp4 = new List<Object>();
            foreach (var s in et)
            {
                if (!string.IsNullOrEmpty(s)) { 
                    temp.Add(s);
                    temp2.Add(datatERezervimit[ind]);
                    temp3.Add(datatEDorezimit[ind]);
                    temp4.Add(listaVektor[ind]);
                }
                ind++;
            }
            et = temp.ToArray();
            datatERezervimit = temp2.ToArray();
            datatEDorezimit = temp3.ToArray();
            listaVektor = temp4.ToArray();
            for (int i = 0; i < et.Length; i++)
            {
                
                if (et[i] != "")
                {
                    etiket[i].Text = et[i];
                    if (et[i].Contains("-"))
                    {
                        //dateTimePicker9.MinDate = DateTime.Today;
                        //dateTimePicker1.MaxDate = DateTime.Today.AddDays(7);
                        //DtDor[i].Visible = false;
                        DtDor[i].MinDate=DateTime.Today;
                        DtDor[i].MaxDate = DateTime.Today;
                        DtRez[i].Visible = false;
                        //idKopje[i].Visible = false;
                    }
                    else
                    {
                        DtDor[i].Visible = true;
                        DtRez[i].Visible = true;
                        idKopje[i].Visible = true;
                    }
                    DtRez[i].Value = datatERezervimit[i];
                    DtDor[i].Value = datatEDorezimit[i];
                    idKopje[i].Items.Clear();
                    idKopje[i].Items.AddRange((string [])listaVektor[i]);
                   
                }


            }
            
            for (int i = et.Length; i < 5; i++)
            {   
                etiket[i].Text = "";
                DtRez[i].Visible = true;
                DtRez[i].ResetText();
                idKopje[i].Items.Clear();
                idKopje[i].Visible = true;
                
                DtDor[i].ResetText();
                DtDor[i].Visible = true;
               // MessageBox.Show("Po pastrohet" + i);
            }
            indeksEtikete--;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            dateTimePicker3.Visible = true;
            dateTimePicker4.Visible = true;
            comboBox2.Items.Clear();
            comboBox2.Visible = true;
            
            hiqEtiket();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            
            dateTimePicker5.Visible = true;
            dateTimePicker6.Visible = true;
            comboBox3.Items.Clear();
            comboBox3.Visible = true;
            
            hiqEtiket();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            
            dateTimePicker7.Visible = true;
            dateTimePicker8.Visible = true;
            comboBox4.Visible = true;
            comboBox4.Items.Clear();
            hiqEtiket();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            dateTimePicker9.Visible = true;
            dateTimePicker10.Visible = true;
            comboBox5.Visible = true;
            comboBox5.Items.Clear();
            hiqEtiket();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int max = 0, total = 0, j = 0;
            int hyrsi = 0;
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select nrMaxLiber,totaliPergjatKohes from KartBibloteke where Id=@idja", scn);
            scmd.Parameters.AddWithValue("@idja", Convert.ToInt32(idKB));
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                max = Convert.ToInt32(a["nrMaxLiber"].ToString());
                total = Convert.ToInt32(a["totaliPergjatKohes"].ToString());
                break;
            }
            TextBox[] idELibrave = { textBox2, textBox3, textBox4, textBox5, textBox6 };
            DateTimePicker[] dtRezervimi = { dateTimePicker1, dateTimePicker3, dateTimePicker5, dateTimePicker7, dateTimePicker9 };
            DateTimePicker[] dtDorezimi = { dateTimePicker2, dateTimePicker4, dateTimePicker6, dateTimePicker8, dateTimePicker10 };
            ComboBox[] Kopjet = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5 };
            int gjendje = 1, demtuar = 1;

            for (int i = 0; i < idELibrave.Length; i++)
            {
                 
                    if (idELibrave[i].Text.Length != 0)
                    {
                        if (idELibrave[i].Text.Contains("-"))
                        {
                            string query = "INSERT INTO liberLexues (id_Lexues,id_Liber,id_KB,dtLeshimi,salle,dorezuar,id_KLib)";//
                            query += " VALUES (@IdL, @IdLib,@IdKB,@dtD,@salle,@dorezuar,@idKL)";//
                            scmd = new SqlCommand(query, scn);
                            scmd.Parameters.AddWithValue("@IdL", Convert.ToInt32(id));
                            scmd.Parameters.AddWithValue("@IdLib", Convert.ToInt32(idELibrave[i].Text.Substring(0, 2)));
                            scmd.Parameters.AddWithValue("@IdKB", Convert.ToInt32(idKB));
                        scmd.Parameters.AddWithValue("@dtD", dtDorezimi[i].Value.Date);
                        scmd.Parameters.AddWithValue("@idKL",Kopjet[i].SelectedItem.ToString());
                            scmd.Parameters.AddWithValue("@salle", 1);
                            scmd.Parameters.AddWithValue("@dorezuar", 0);
                            scmd.ExecuteNonQuery();
                            scmd = new SqlCommand("select demtuar from Liber where Id=@idja", scn);
                            scmd.Parameters.AddWithValue("@idja", Convert.ToInt32(idELibrave[i].Text.Substring(0, 2)));
                            SqlDataReader a4 = scmd.ExecuteReader();
                            while (a4.Read())
                            {
                                demtuar = Convert.ToInt32(a4["demtuar"].ToString());

                                break;
                            }

                            demtuar -= 1;
                            scmd = new SqlCommand("UPDATE Liber SET demtuar=@gj Where Id=@id", scn);
                            scmd.Parameters.AddWithValue("@id", Convert.ToInt32(idELibrave[i].Text.Substring(0, 2)));
                            scmd.Parameters.AddWithValue("@gj", demtuar);
                            scmd.ExecuteNonQuery();
                            scmd = new SqlCommand("UPDATE KopjeLibri SET rezervuar=@gj Where barkodi=@id", scn);
                            scmd.Parameters.AddWithValue("@id", Kopjet[i].SelectedItem.ToString());
                            scmd.Parameters.AddWithValue("@gj", 1);
                            scmd.ExecuteNonQuery();
                        }
                        else
                        {
                            string query = "INSERT INTO liberLexues (id_Lexues,id_Liber,id_KB,dtRezervimi,dtLeshimi,salle,dorezuar,id_KLib)";//
                            query += " VALUES (@IdL, @IdLib,@IdKB,@dtR,@dtD,@salle,@dorezuar,@idKL)";//
                            scmd = new SqlCommand(query, scn);

                            scmd.Parameters.AddWithValue("@IdL", Convert.ToInt32(id));
                            scmd.Parameters.AddWithValue("@IdLib", Convert.ToInt32(idELibrave[i].Text));
                            scmd.Parameters.AddWithValue("@IdKB", Convert.ToInt32(idKB));
                            scmd.Parameters.AddWithValue("@dtR", dtRezervimi[i].Value.Date);
                            scmd.Parameters.AddWithValue("@dtD", dtDorezimi[i].Value.Date);
                        scmd.Parameters.AddWithValue("@idKL", Kopjet[i].SelectedItem.ToString());
                        scmd.Parameters.AddWithValue("@salle", 0);
                            scmd.Parameters.AddWithValue("@dorezuar", 0);
                            scmd.ExecuteNonQuery();

                            scmd = new SqlCommand("select gjendje from Liber where Id=@idja", scn);
                            scmd.Parameters.AddWithValue("@idja", Convert.ToInt32(Convert.ToInt32(idELibrave[i].Text)));
                            SqlDataReader a2 = scmd.ExecuteReader();
                            while (a2.Read())
                            {
                                gjendje = Convert.ToInt32(a2["gjendje"].ToString());

                                break;
                            }

                            gjendje -= 1;
                            scmd = new SqlCommand("UPDATE Liber SET gjendje=@gj Where Id=@id", scn);
                            scmd.Parameters.AddWithValue("@id", Convert.ToInt32(idELibrave[i].Text));
                            scmd.Parameters.AddWithValue("@gj", gjendje);
                            scmd.ExecuteNonQuery();
                        scmd = new SqlCommand("UPDATE KopjeLibri SET rezervuar=@gj Where barkodi=@id", scn);
                        scmd.Parameters.AddWithValue("@id", Kopjet[i].SelectedItem.ToString());
                        scmd.Parameters.AddWithValue("@gj", 1);
                        scmd.ExecuteNonQuery();
                    }
                        j++;
                    }
                    else
                    {
                        break;
                    }
                
            }
            /*if (hyrsi == 1) { */
            Console.WriteLine(max + "dhe   " + j+" me id"+ idKB);
            max += j;
            total += j;
           
            scmd= new SqlCommand("UPDATE KartBibloteke SET nrMaxLiber=@max,totaliPergjatKohes=@total Where id=@id", scn);
            scmd.Parameters.AddWithValue("@id", Convert.ToInt32(idKB));
            scmd.Parameters.AddWithValue("@max", max);
            scmd.Parameters.AddWithValue("@total", total);
            scmd.ExecuteNonQuery();

            scn.Close();
            MessageBox.Show("Rezervimi u krye me sukses");
            this.Close();
           /* }*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Perzgjidhni kopjen");
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
