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
    public partial class InfoBD : Form
    {
        public InfoBD()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InfoBD_Load(object sender, EventArgs e)
        {
            rtbInfoBD.Text = "При збереженні даних перевіряється наявність бази даних у системі. "+
            "Якщо база даних існує і відповідає імені \"StudentsDB.mdb\", тоді відбуваєтсья "+
            "запис даних у відповідні поля. Якщо при збереженні виникає помилка, необхідно переконатися, "+
            "що таблиця бази даних, в яку записуються результати називається \"Результати\", а всі поля "+
            "підписані таким чионом, як зображено на рис. 1. Слід зазначити, що поле \"id\" є ключем та "+
            "заповнюється автоматично.\nЯкщо база даних не існує або не відповідає імені \"StudentsDB.mdb,\" "+
            "тоді вона буде створена автоматично з необхідними таблицею та полями для збереження даних.";
        }
    }
}
