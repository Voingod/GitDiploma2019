using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterBox
{
    public partial class Legend : Form
    {
        public Legend()
        {
            InitializeComponent();
        }

        private void okBtnLegend_Click(object sender, EventArgs e)
        {
            WindowController.legend = null;
            this.Close();
        }
    }
}
