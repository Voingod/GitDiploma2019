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
            "ФМБІ, 6 курс, БС-71мп\nВойник Богдан Олексійович\n"+
            "ФМБІ, 6 курс, БС-71мн\nБорисова Галина Вікторівна";
            labelCopy.Text = "Copyright ©  2018";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
