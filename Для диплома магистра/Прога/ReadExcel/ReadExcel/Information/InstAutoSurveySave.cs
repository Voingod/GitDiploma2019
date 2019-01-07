using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadExcel
{
    public partial class InstAutoSurveySave : Form
    {
        private Instruction instriction;
        public InstAutoSurveySave(Instruction i)
        {
            instriction = i;
            InitializeComponent();
        }
        private void InstAutoSurveySave_Load(object sender, EventArgs e)
        {
            rtbInfo.Text = instriction.MyMethod;
        }

        private void btnOKInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Instruction info = new Instruction();
            info.Show();
        }
    }
}
