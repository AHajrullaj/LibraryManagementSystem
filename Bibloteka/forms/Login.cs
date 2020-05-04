using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bibloteka.forms;

namespace Bibloteka
{
    public partial class Login : Form
    {
        private bool syri = false;
        public Login()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String email = textBox1.Text;
            String pass = textBox2.Text;
            SqlConnection scn = new SqlConnection();
            scn.ConnectionString = @"Data Source=localhost;Initial Catalog=[user];database=bibloteka;MultipleActiveResultSets=True;integrated security=SSPI";
            scn.Open();
            SqlCommand scmd = new SqlCommand("select user_id,email,password from [user]", scn);
            SqlDataReader a = scmd.ExecuteReader();
            while (a.Read())
            {
                Console.WriteLine("id=" + Int32.Parse(a["user_id"].ToString()));
                if (email.Equals(a["email"].ToString()) && pass.Equals(a["password"].ToString()))
                {
                    int id = Int32.Parse(a["user_id"].ToString());
                    
                    scmd = new SqlCommand("select Name from [user] join user_role on user_role.user_id=@idja join Roles on user_role.role_id=Roles.Role_id ", scn);
                    scmd.Parameters.AddWithValue("@idja", id);
                    a = scmd.ExecuteReader();
                    Console.WriteLine("para cikli dy");
                    while (a.Read())
                    {
                        if (a["Name"].ToString().Equals("Menaxheri"))
                        {
                            Form1.role = a["Name"].ToString();
                            Form1.loguar = true;
                            Form1.i = true;
                            this.Hide();
                            Menaxheri frm2 = new Menaxheri();
                            frm2.ShowDialog();
                            break;
                        }
                        
                            if (a["Name"].ToString().Equals("PunonjesiSportelit"))
                        {
                            Form1.role = a["Name"].ToString();
                            Form1.loguar = true;
                            Form1.i = true;
                            scmd = new SqlCommand("select email,firstname,lastname,password from [user] join user_role on user_role.user_id=[user].user_id where user_role.user_id= @idja ", scn);
                            scmd.Parameters.AddWithValue("@idja", id);
                            a = scmd.ExecuteReader();
                            while (a.Read())
                            {
                                Punonjes.email= a["email"].ToString();
                                Punonjes.firstName = a["firstName"].ToString();
                                Punonjes.lastName= a["lastName"].ToString();
                                Punonjes.pass= a["password"].ToString();
                                break;

                            }
                                this.Hide();
                            Punonjes frm2 = new Punonjes();
                            frm2.ShowDialog();
                            break;
                        }

                        if (a["Name"].ToString().Equals("Lexuesi"))
                        {
                            Form1.role = a["Name"].ToString();
                            Form1.loguar = true;
                            Form1.i = true;
                            scmd = new SqlCommand("select email,firstname,lastname,password from [user] join user_role on user_role.user_id=[user].user_id where user_role.user_id= @idja ", scn);
                            scmd.Parameters.AddWithValue("@idja", id);
                            a = scmd.ExecuteReader();
                            while (a.Read())
                            {
                                Lexues.email = a["email"].ToString();
                                Lexues.firstName = a["firstName"].ToString();
                                Lexues.lastName = a["lastName"].ToString();
                                Lexues.pass = a["password"].ToString();
                                break;

                            }
                            this.Hide();
                            Lexues frm2 = new Lexues();
                            frm2.ShowDialog();
                            break;
                        }

                        /* button3.Text = a["Name"].ToString();
                         Console.WriteLine("brenda cikli dy");*/
                    }
                    break;
                    Console.WriteLine("jasht cikli2");
                }
                else
                {
                    label6.Text = "email ose passwordi eshte gabim";
                    //MessageBox.Show("email ose passwordi eshte gabim", "error", MessageBoxButtons.OK);
                    continue;
                }
                break;
                //listBox1.Items.Add(a["id"].ToString());
            }
            Console.WriteLine("jasht cikli1");
            scn.Close();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm2 = new Form1();
            frm2.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (syri)
            {
                textBox2.PasswordChar = '*';
                pictureBox2.Image = Image.FromFile("C:\\Users\\HP\\source\\repos\\Bibloteka\\Bibloteka\\images\\invisible_30px.png");
                syri = false;
            }
            else
            {
                textBox2.PasswordChar = '\0';
                pictureBox2.Image = Image.FromFile("C:\\Users\\HP\\source\\repos\\Bibloteka\\Bibloteka\\images\\eye_30px.png");
                syri = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /*private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            afterLogin frm2 = new afterLogin();
            frm2.ShowDialog();
        }*/
    }
}
