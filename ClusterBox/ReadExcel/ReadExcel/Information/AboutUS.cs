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
    public partial class AboutUS : Form
    {
        public AboutUS()
        {
            InitializeComponent();
        }

        private void AboutUS_Load(object sender, EventArgs e)
        {
            rtbAboutUs.Text = "Програмний продукт розроблено студентами \nНТУУ \"КПІ ім. Ігоря Сікорського\"\n"+
            "Факультету біомедичної інженерії\n\n"+
            "Aвтори: \n" +
            "ФМБІ, 6 курс, БС-71мп\nВойник Богдан Олексійович\n"+
            "ФМБІ, 6 курс, БС-71мн\nБорисова Галина Вікторівна";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            WindowController.aboutUs = null;
        }

    }
}
