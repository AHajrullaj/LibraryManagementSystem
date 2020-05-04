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
    public partial class ecuriaEKategorise : Form
    {
        public ecuriaEKategorise()
        {
            InitializeComponent();
        }

        private void ecuriaEKategorise_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecuriaEKategorive.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.ecuriaEKategorive.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
