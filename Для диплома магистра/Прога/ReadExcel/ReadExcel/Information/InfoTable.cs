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
    public partial class InfoTable : Form
    {
        public InfoTable()
        {
            InitializeComponent();
        }

        private void btnInst_Click(object sender, EventArgs e)
        {
            Instruction instruction = new Instruction();
            instruction.Show();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InfoTable_Load(object sender, EventArgs e)
        {
            rtbTableInfo.Text = "Результуюча таблиця представляє собою набір даних, що показують "+
            "стандартне відхилення та середнє значення кожної змінної в певному кластері. "+
            "Середнє значення являє собою центр відповідної змінної у кластері, що використовується "+
            "у подальшому для визначення мінімальної відстані та радіусу кластеру. Якщо при вибору файлу "+
            "відбуваєтсья помилка, переконайтесь, що результуюча таблиця збережена у форматі \"*.xls\", що "+
            "представляє собою файл програми \"Excel\". Також переконайтесь, що таблция зведена до прийнятного "+
            "вигляду, що зображений на рис.2.";
        }
    }
}
