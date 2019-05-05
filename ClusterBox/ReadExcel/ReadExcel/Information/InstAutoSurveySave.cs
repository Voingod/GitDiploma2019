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
    public partial class InstAutoSurveySave : Form
    {
        public string infoText;

        public InstAutoSurveySave()
        {
            InitializeComponent();
        }

        private void InstAutoSurveySave_Load(object sender, EventArgs e)
        {
            rtbInfo.Text = infoText;
        }

        private void btnOKInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InstAutoSurveySave_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instruction.infoUni = null;
        }
    }
}
