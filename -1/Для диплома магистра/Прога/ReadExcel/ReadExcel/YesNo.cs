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

namespace ReadExcel
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
            this.Close();
            GlobalWindow global = new GlobalWindow();

            OleDbConnection conn;
            OleDbCommand cmd;
            global.Connection(out conn, out cmd, TextPath.abc);
          
            conn.Open();
            cmd.CommandText = "DROP TABLE [Cluster];";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE [Cluster] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
            cmd.ExecuteNonQuery();
            conn.Close();

            global.GlobalCucl(TextPath.abc, "Cl,Dist,NextCl,NextDist");

        }
    }
}

