using Bibloteka.controllers;
using Bibloteka.forms;
using Bibloteka.formsReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibloteka
{
    public partial class Form1 : Form
    {
        public static bool i=false;
        public static int id;
        public static string role;
        public static bool loguar= false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            klasiketControl11.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            mainUserControl11.BringToFront();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "logout")
            {
                Form1.role = "";
                Form1.loguar = false;
                Form1.i = false;
                button1.Text = "login";
                this.Hide();
                Login frm2 = new Login();
                frm2.ShowDialog();

            }
            else { 
            this.Hide();
            Login frm2 = new Login();
            frm2.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (role.Equals("Menaxheri"))
            {
                this.Hide();
                Menaxheri mg = new Menaxheri();
                mg.ShowDialog();
            }
            else if (role.Equals("PunonjesiSportelit"))
            {
                this.Hide();
                Punonjes mg = new Punonjes();
                mg.ShowDialog();

            }
            else
            {
                if (role.Equals("Lexuesi"))
                {
                    this.Hide();
                    Lexues mg = new Lexues();
                    mg.ShowDialog();

                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (i&&role.Equals("Menaxheri"))
            {
                button2.Visible = true;
                button2.Text = "Menaxher UI";
            }else if (i && role.Equals("PunonjesiSportelit"))
            {
                button2.Visible = true;
                button2.Text = "Punonjes Sporteli UI";

            }
            else
            {
                if(i && role.Equals("Lexuesi"))
                {
                    button2.Visible = true;
                    button2.Text = "Lexues UI";
                }
            }
            if (role != "" && loguar)
            {
                button1.Text = "logout";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*this.Hide();*//*
            Punonjes mg = new Punonjes();
            mg.ShowDialog();*/


            /* ListLibrashRaportFrame f = new ListLibrashRaportFrame();
             f.ShowDialog();*/

            /*LexuesQeKaneKaluarAfatin f = new LexuesQeKaneKaluarAfatin();
            f.ShowDialog();*/
            /*LexueshmeriaLibrit l = new LexueshmeriaLibrit();
            l.ShowDialog();*/
            /*prova l = new prova();???????
            l.ShowDialog();*/
            /*provaTotal p = new provaTotal();
            p.ShowDialog();*/
            ecuriaEKategorise ec = new ecuriaEKategorise();
            ec.ShowDialog();


        }

        private void mainUserControl11_Load(object sender, EventArgs e)
        {

        }

        private void teknologjiControl11_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            teknologjiControl11.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            matematikControl11.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           kimiControl11.BringToFront();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            fizikControl11.BringToFront();
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            elektronikControl11.BringToFront();
        }

        private void mainUserControl11_Load_1(object sender, EventArgs e)
        {

        }

        private void mainUserControl11_Load_2(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
