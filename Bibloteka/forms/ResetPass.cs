using Bibloteka.controllers.punonjesi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibloteka.forms
{

    public partial class ResetPass : Form
    {
        
        private readonly PunShowDataControl1 frm7;
        public ResetPass()
        {
            InitializeComponent();
        }
        public ResetPass(PunShowDataControl1 frm)
        {

            InitializeComponent();
            frm7 = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select user_id, password from [user] where email=@email", con);
            cmd.Parameters.AddWithValue("@email", Punonjes.email);
            SqlDataReader a = cmd.ExecuteReader();
            string old=""; int idj=0;
            while (true) { 
            if (a.Read())
            {
                    //MessageBox.Show(textBox1.Text + "--" + a["password"].ToString());
                if (textBox1.Text.Equals(a["password"].ToString()))
                {
                        old = a["password"].ToString();
                        idj = Convert.ToInt32(a["user_id"].ToString());
                        
                }
                else
                {
                        MessageBox.Show("Passwordi i vjeter nuk perputhet");
                        break;

                    }
               
            }


                string new1 = textBox2.Text, new2 = textBox2.Text;
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                if (!hasNumber.IsMatch(textBox2.Text))
                {
                    MessageBox.Show("Passwordi duhet te kete numer");
                    break;
                }
                else if (hasUpperChar.IsMatch(textBox2.Text))
                {
                    MessageBox.Show("Passwordi duhet te kete nje shkronje te madhe");
                    break;
                }
                else
                {
                    if (textBox2.Text.Length < 8)
                    {
                        MessageBox.Show("Passwordi duhet te kete te pakten 8 karaktere");
                        break;
                    }
                }

                if (textBox2.Text.Equals(textBox3.Text))
                {
                    cmd = new SqlCommand("SELECT TOP 3 oldPass FROM OldPass ORDER BY Id DESC ", con);
                    a = cmd.ExecuteReader();
                    int mn = 0;
                    byte[] input1;
                    HashAlgorithm Alg1;
                    string passKRIPT1;
                    while (a.Read())
                    {
                        input1 = Encoding.ASCII.GetBytes(a["oldPass"].ToString());

                        Alg1 = new SHA1CryptoServiceProvider();
                        Alg1.ComputeHash(input1);
                        passKRIPT1 = Convert.ToBase64String(Alg1.Hash);
                        string b = gjej();
                        

                        if (b.Equals(a["oldPass"].ToString()))
                        {
                            MessageBox.Show("Passwordi i ri nuk duhet te perputhet me nje pass te meparshem");
                            mn = 1;
                            break;
                        }

                    }
                    if (mn == 0) { 
                    cmd = new SqlCommand("UPDATE Punonjes SET passwordi=@pass Where email=@id", con);
                    cmd.Parameters.AddWithValue("@id", Punonjes.email);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE [user] SET password=@pass Where user_id=@id", con);
                    cmd.Parameters.AddWithValue("@id", idj);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    cmd.ExecuteNonQuery();

                       
                        string passKRIPT = gjej();



                        String query = "INSERT INTO [OldPass] (userID,oldPass)";
                    query += " VALUES (@uID, @rID)";

                    SqlCommand myCommand = new SqlCommand(query, con);
                    myCommand.Parameters.AddWithValue("@uID", idj);
                    myCommand.Parameters.AddWithValue("@rID", passKRIPT);
                    myCommand.ExecuteNonQuery();


                    MessageBox.Show("Update u krye me sukses");
                    break;
                    }
                    else
                    {
                        break;
                    }



                }
                else

                {
                    MessageBox.Show("Passwordet nuk perputhen"+textBox2.Text+"=="+textBox3.Text);
                    break;
                }


            }

        }
       string gjej()
        {
            byte[] input = Encoding.ASCII.GetBytes(textBox2.Text);

            HashAlgorithm Alg = new SHA1CryptoServiceProvider();
            Alg.ComputeHash(input);
            string passKRIPT = Convert.ToBase64String(Alg.Hash);
            return passKRIPT;
        }


        private void ResetPass_Load(object sender, EventArgs e)
        {

        }
    }
}
