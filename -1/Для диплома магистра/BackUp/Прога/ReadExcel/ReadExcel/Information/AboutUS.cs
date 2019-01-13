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
    public partial class AboutUS : Form
    {
        public AboutUS()
        {
            InitializeComponent();
        }

        private void AboutUS_Load(object sender, EventArgs e)
        {
            rtbAboutUs.Text = "Програмний продукт розроблено студентами НТУУ \"КПІ ім. Ігоря Сікорського\""+
            " факультету біомедичної інженерії.\n\n"+
            "ФМБІ, 4 курс, БС-31\nВойник Богдан Олексійович\n"+
            "ФМБІ, 4 курс, БС-31\nФедчишин Максим Олександрович";
            labelCopy.Text = "Copyright ©  2017";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
