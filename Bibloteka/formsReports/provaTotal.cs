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
    public partial class provaTotal : Form
    {
        public provaTotal()
        {
            InitializeComponent();
        }

        private void provaTotal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'provaTotal1.Liber' table. You can move, or remove it, as needed.
            this.liberTableAdapter.Fill(this.provaTotal1.Liber);

            this.reportViewer1.RefreshReport();
        }
    }
}
