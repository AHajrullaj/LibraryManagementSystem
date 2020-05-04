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
    public partial class DorezoLiber : Form
    {
        public static string idK;
        public static string idP;
        public static string emr;
        public static string mbr;
        private readonly shfaqLexuesitControl1 frm1;
        public DorezoLiber()
        {
            InitializeComponent();
        }
        public DorezoLiber(shfaqLexuesitControl1 frm)
        {
            InitializeComponent();

            frm1 = frm;
        }
        private void DorezoLiber_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = idK;
            textBox2.Text = emr;
            textBox3.Text = mbr;
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select liberLexues.id_Liber,emer,autor,dtRezervimi,dtLeshimi,barkodi,salle,dorezuar from liberLexues join Liber on liberLexues.id_Liber=Liber.Id join KopjeLibri on liberLexues.id_KLib=KopjeLibri.barkodi where id_KB='" + idK+ "' and dorezuar=0", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns["id_Liber"].ReadOnly = true;
            dataGridView1.Columns["emer"].ReadOnly = true;
            dataGridView1.Columns["autor"].ReadOnly = true;
            dataGridView1.Columns["dtRezervimi"].ReadOnly = true;
            dataGridView1.Columns["dtLeshimi"].ReadOnly = true;
            dataGridView1.Columns["salle"].ReadOnly = true;
            dataGridView1.Columns[dataGridView1.Columns["dorezuar"].Index].ReadOnly = false;
            scn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] indekseKutie = new int[5];
            int[] indekskutiSalle = new int[5];
             bool iCekuarKutiFund, kutiFillim;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                iCekuarKutiFund = (bool)dataGridView1.Rows[i].Cells[7].Value;
                kutiFillim= (bool)dataGridView1.Rows[i].Cells[6].Value;
                if (iCekuarKutiFund)
                {
                    indekseKutie[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                   // Console.WriteLine("demtuar nr=" + Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                  
                }
                if (kutiFillim)
                {
                    indekskutiSalle[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    //Console.WriteLine("salle nr=" + Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                    
                }
            }
            for(int i = 0; i < indekskutiSalle.Length; i++)
            {
                if (indekskutiSalle[i] == indekseKutie[i]&&indekseKutie[i]!=0)
                {
                   MessageBox.Show("SALLE  id=" + indekskutiSalle[i]);
                    //update tab liber demtuar++
                    //update tab liberLExues dorezuar=1
                    //kart bibloteke nr max liber--;
                    int demtuar = 1;
                    SqlConnection scn = new SqlConnection();
                    scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                    scn.Open();
                    SqlCommand scmd = scmd = new SqlCommand("select demtuar from Liber where Id=@idja", scn);
                    scmd.Parameters.AddWithValue("@idja", indekskutiSalle[i]);
                    SqlDataReader a4 = scmd.ExecuteReader();
                    while (a4.Read())
                    {
                        demtuar = Convert.ToInt32(a4["demtuar"].ToString());

                        break;
                    }
                    demtuar++;
                    scmd = new SqlCommand("UPDATE Liber SET demtuar=@d Where Id=@id", scn);
                    scmd.Parameters.AddWithValue("@id", indekskutiSalle[i]);
                    scmd.Parameters.AddWithValue("@d", demtuar);
                    scmd.ExecuteNonQuery();
                    scmd = new SqlCommand("UPDATE liberLexues SET dorezuar=1 Where id_KB=@id and id_Liber=@IDL", scn);
                    scmd.Parameters.AddWithValue("@IDL", indekskutiSalle[i]);
                    scmd.Parameters.AddWithValue("@id", Convert.ToInt32(idK));
                    scmd.ExecuteNonQuery();
                    scmd = new SqlCommand("UPDATE KopjeLibri SET rezervuar=0 Where barkodi=@id ", scn);
                    scmd.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[5].Value);
                    scmd.ExecuteNonQuery();

                    scmd = scmd = new SqlCommand("select nrMaxLiber from KartBibloteke where id_lexues=@idja", scn);
                    scmd.Parameters.AddWithValue("@idja",idP);
                   a4 = scmd.ExecuteReader();
                    while (a4.Read())
                    {
                        demtuar = Convert.ToInt32(a4["nrMaxLiber"].ToString());

                        break;
                    }
                    demtuar--;
                    scmd = new SqlCommand("UPDATE KartBibloteke SET nrMaxLiber=@d Where Id=@id", scn);
                    scmd.Parameters.AddWithValue("@id", Convert.ToInt32(idK));
                    scmd.Parameters.AddWithValue("@d", demtuar);
                    scmd.ExecuteNonQuery();
                    scn.Close();

                }
                else
                {
                    if( indekseKutie[i]!=0) {
                        MessageBox.Show("TJ id=" + indekseKutie[i]);
                        int gjendje = 1;
                        SqlConnection scn = new SqlConnection();
                        scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                        scn.Open();
                        SqlCommand scmd = scmd = new SqlCommand("select gjendje from Liber where Id=@idja", scn);
                        scmd.Parameters.AddWithValue("@idja", indekseKutie[i]);
                        SqlDataReader a4 = scmd.ExecuteReader();
                        while (a4.Read())
                        {
                            gjendje = Convert.ToInt32(a4["gjendje"].ToString());

                            break;
                        }
                        gjendje++;
                        scmd = new SqlCommand("UPDATE Liber SET gjendje=@d Where Id=@id", scn);
                        scmd.Parameters.AddWithValue("@id", indekseKutie[i]);
                        scmd.Parameters.AddWithValue("@d", gjendje);
                        scmd.ExecuteNonQuery();
                        scmd = new SqlCommand("UPDATE liberLexues SET dorezuar=1 Where id_KB=@id and id_Liber=@IDL", scn);
                        scmd.Parameters.AddWithValue("@IDL", indekseKutie[i]);
                        scmd.Parameters.AddWithValue("@id", Convert.ToInt32(idK));
                        scmd.ExecuteNonQuery();
                        scmd = new SqlCommand("UPDATE KopjeLibri SET rezervuar=0 Where barkodi=@id ", scn);
                        scmd.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[5].Value);
                        scmd.ExecuteNonQuery();
                        scmd = scmd = new SqlCommand("select nrMaxLiber from KartBibloteke where id=@idja", scn);
                        scmd.Parameters.AddWithValue("@idja", Convert.ToInt32(idK));
                        a4 = scmd.ExecuteReader();
                        while (a4.Read())
                        {
                            gjendje = Convert.ToInt32(a4["nrMaxLiber"].ToString());

                            break;
                        }
                        //MessageBox.Show("PA u zbrit?" + gjendje.ToString());
                        scmd = scmd = new SqlCommand("select id_liber,id_kb,id_lexues from ListPritje", scn);
                        
                        a4 = scmd.ExecuteReader();
                        bool hyn = true;
                        while (a4.Read())
                        {
                            MessageBox.Show(a4["id_kb"].ToString()+"  hiiii");
                            for (int indc = 0; indc < indekseKutie.Length; indc++)
                            {
                                if (indekseKutie[indc] == Convert.ToInt32(a4["id_liber"].ToString()))
                                {
                                    MessageBox.Show("hiii do marresh librin qe nuk ishte ne gjendje");
                                    string query = "INSERT INTO liberLexues (id_Lexues,id_Liber,id_KB,dtRezervimi,dtLeshimi,salle,dorezuar,id_KLib)";//
                                    query += " VALUES (@IdL, @IdLib,@IdKB,@dtR,@dtD,@salle,@dorezuar,@idKL)";//
                                    scmd = new SqlCommand(query, scn);

                                    scmd.Parameters.AddWithValue("@IdL", a4["id_lexues"].ToString());
                                    scmd.Parameters.AddWithValue("@IdLib", indekseKutie[indc]);
                                    scmd.Parameters.AddWithValue("@IdKB", Convert.ToInt32(a4["id_kb"].ToString()));
                                    scmd.Parameters.AddWithValue("@dtR", DateTime.Today);
                                    scmd.Parameters.AddWithValue("@dtD", DateTime.Today.AddDays(7));
                                    scmd.Parameters.AddWithValue("@idKL", dataGridView1.Rows[indc].Cells[5].Value.ToString());
                                    scmd.Parameters.AddWithValue("@salle", 0);
                                    scmd.Parameters.AddWithValue("@dorezuar", 0);
                                    scmd.ExecuteNonQuery();
                                    int gjen=0;
                                    scmd = new SqlCommand("select gjendje from Liber where Id=@idja", scn);
                                    scmd.Parameters.AddWithValue("@idja", indekseKutie[indc]);
                                    SqlDataReader a2 = scmd.ExecuteReader();
                                    while (a2.Read())
                                    {
                                        gjen = Convert.ToInt32(a2["gjendje"].ToString());

                                        break;
                                    }

                                    gjen -= 1;
                                    scmd = new SqlCommand("UPDATE Liber SET gjendje=@gj Where Id=@id", scn);
                                    scmd.Parameters.AddWithValue("@id", indekseKutie[indc]);
                                    scmd.Parameters.AddWithValue("@gj", gjen);
                                    scmd.ExecuteNonQuery();
                                    scmd = new SqlCommand("UPDATE KopjeLibri SET rezervuar=@gj Where barkodi=@id", scn);
                                    scmd.Parameters.AddWithValue("@id", dataGridView1.Rows[indc].Cells[5].Value.ToString());
                                    scmd.Parameters.AddWithValue("@gj", 1);
                                    scmd.ExecuteNonQuery();
                                    SqlCommand cmd = new SqlCommand("DELETE FROM ListPritje WHERE id_liber=@id ", scn);
                                    cmd.Parameters.AddWithValue("@id", indekseKutie[indc]);
                                    cmd.ExecuteNonQuery();
                                    hyn = false;
                                    indekseKutie[indc] = -1;
                                    break;
                                }
                            }
                        }



                        if (hyn)
                        {
                            gjendje--;
                            scmd = new SqlCommand("UPDATE KartBibloteke SET nrMaxLiber=@d Where Id=@id", scn);
                            scmd.Parameters.AddWithValue("@id", Convert.ToInt32(idK));
                            MessageBox.Show("PROB?" + gjendje.ToString());
                            scmd.Parameters.AddWithValue("@d", gjendje);
                            scmd.ExecuteNonQuery();
                        }
                        scn.Close();
                    }
                    //update tab liber gjendje++
                    //update tab liberLExues dorezuar=1
                    //kart bibloteke nr max liber--;
                }
            }
            updateIDataGrid();
        }
        void updateIDataGrid()
        {
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("Select id_Liber,emer,autor,dtRezervimi,dtLeshimi,salle,dorezuar from liberLexues join Liber on liberLexues.id_Liber=Liber.Id where id_KB='" + idK + "' and dorezuar=0", scn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns["id_Liber"].ReadOnly = true;
            dataGridView1.Columns["emer"].ReadOnly = true;
            dataGridView1.Columns["autor"].ReadOnly = true;
            dataGridView1.Columns["dtRezervimi"].ReadOnly = true;
            dataGridView1.Columns["dtLeshimi"].ReadOnly = true;
            dataGridView1.Columns["salle"].ReadOnly = true;
            dataGridView1.Columns[dataGridView1.Columns["dorezuar"].Index].ReadOnly = false;
            scn.Close();
        }
    }
}
