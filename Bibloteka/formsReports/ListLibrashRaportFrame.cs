using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibloteka.formsReports
{
    public partial class ListLibrashRaportFrame : Form
    {
        public ListLibrashRaportFrame()
        {
            InitializeComponent();
        }

        private void ListLibrashRaportFrame_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.dataTable1TableAdapter.Fill(this.listLibrash.DataTable1, dateTimePicker1.Value.Date.ToString());
            this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Fill(this.listLibrash.DataTable1, DateTime.Today.ToString());
            this.reportViewer1.RefreshReport();

        }
    }
}
