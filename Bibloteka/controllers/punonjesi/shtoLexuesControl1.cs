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

namespace Bibloteka.controllers.punonjesi
{
    public partial class shtoLexuesControl1 : UserControl
    {
        public shtoLexuesControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String emr, mbr, email, pass,add;
            emr = textBox1.Text.ToLower();
            mbr = textBox2.Text.ToLower();
            email = textBox3.Text;
            pass = textBox4.Text;
            add = textBox5.Text;
            
            bool po = true;
            SqlConnection scn1 = new SqlConnection();
            scn1.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn1.Open();
            SqlCommand scmd2 = new SqlCommand("SELECT email from [user] ", scn1);

            SqlDataReader am = scmd2.ExecuteReader();

            while (am.Read())
            {
                if (email.Equals(am["email"].ToString()))
                {
                    MessageBox.Show("Email eshte i zene, shkruani nje email tjeter");
                    po = false;
                    break;
                }
            }
            if (po)
            {
                if (!(email.Contains("@") && email.EndsWith(".com")))
                {
                    MessageBox.Show("Vendosni nje email te sakt");//shiko dhe nese ka perplasje me perdorues te tjere.
                }
                else if (emr.Length != 0 || mbr.Length != 0 || email.Length != 0 || pass.Length != 0 || add.Length != 0)
                {
                    MessageBox.Show("hi ");

                    SqlConnection scn = new SqlConnection();
                    scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
                    scn.Open();
                    string query = "INSERT INTO Lexues (firstName, lastName, email, passwordi, addresa)";
                    query += " VALUES (@emr, @mbr, @email, @pass, @add)";

                    SqlCommand myCommand = new SqlCommand(query, scn);
                    myCommand.Parameters.AddWithValue("@emr", emr);
                    myCommand.Parameters.AddWithValue("@mbr", mbr);
                    myCommand.Parameters.AddWithValue("@email", email);
                    myCommand.Parameters.AddWithValue("@pass", pass);
                    myCommand.Parameters.AddWithValue("@add", add);

                    myCommand.ExecuteNonQuery();

                    SqlCommand scmd1 = new SqlCommand("SELECT TOP 1 Id  FROM Lexues ORDER BY Id DESC ", scn);

                    SqlDataReader a1 = scmd1.ExecuteReader();
                    int idj;
                    if (a1.Read())
                    {
                        idj = Convert.ToInt32(a1["Id"].ToString());
                        query = "INSERT INTO KartBibloteke (id_lexues,nrMaxLiber,totaliPergjatKohes)";
                        query += " VALUES (@id,0,0)";

                        myCommand = new SqlCommand(query, scn);
                        myCommand.Parameters.AddWithValue("@id", idj);
                        myCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("heyyyy");
                    query = "INSERT INTO [user] (firstname, lastname, email, [password])";
                    query += " VALUES (@emr, @mbr, @email, @pass)";

                    myCommand = new SqlCommand(query, scn);
                    myCommand.Parameters.AddWithValue("@emr", emr);
                    myCommand.Parameters.AddWithValue("@mbr", mbr);
                    myCommand.Parameters.AddWithValue("@email", email);
                    myCommand.Parameters.AddWithValue("@pass", pass);
                    myCommand.ExecuteNonQuery();

                    SqlCommand scmd = new SqlCommand("SELECT TOP 1 user_id  FROM [user] ORDER BY user_id DESC ", scn);

                    SqlDataReader a = scmd.ExecuteReader();
                    int idja, m = 3;
                    if (a.Read())
                    {
                        idja = Convert.ToInt32(a["user_id"].ToString());
                        Console.WriteLine(idja + "" + m);
                        query = "INSERT INTO [user_role] ([user_role].user_id, [user_role].role_id)";
                        query += " VALUES (@uID, @rID)";

                        myCommand = new SqlCommand(query, scn);
                        myCommand.Parameters.AddWithValue("@uID", idja);
                        myCommand.Parameters.AddWithValue("@rID", m);
                        myCommand.ExecuteNonQuery();

                        MessageBox.Show("Lexuesi u shtua me sukses!");

                    }

                    scn.Close();
                }
                else
                {
                    MessageBox.Show(emr.Length +"      "+ mbr.Length +"email"+ email.Length+"  PAss-"+pass.Length+" Add"+add.Length );
                }
                
            }
            MessageBox.Show("dola fr");
        }
    }
}
