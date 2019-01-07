using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestResource
{
    public partial class YesNo : Form
    {
        public YesNo()
        {
            InitializeComponent();
            
        }
       
                 
        private void btnNo_Click(object sender, EventArgs e)
        {
            No();
        }
        public void No()
        {
            Console.WriteLine("Ничего не делать");
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Yes();
        }
        public void Yes()
        {
            Form1 form1 = new Form1();
            OleDbConnection conn;
            OleDbCommand cmd;
            form1.Connection(out conn, out cmd);
            Console.WriteLine("Сделать Insert");
            cmd.CommandText = "INSERT INTO [Cluster](Cl,Dist,NextCl,NextDist) VALUES(1,2133,7,6523);";
            cmd.ExecuteNonQuery();
        }
    }
}
