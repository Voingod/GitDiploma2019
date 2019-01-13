using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace ReadExcel
{
    public class Work
    {
        static int n = 0;
        public double[] radiusCl = new double[n];
        public void CreateFile()
        {
            
            if (File.Exists(Environment.CurrentDirectory + "/Table/ResultTable.xls") && File.Exists(Environment.CurrentDirectory + "/Table/Character.xlsx")
                 && File.Exists(Environment.CurrentDirectory + "/Table/ResultTableCl4.xls") && File.Exists(Environment.CurrentDirectory + "/Table/CharacterCl4.xlsx"))
            {
                return;
            }
            else
            {
                string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                //Console.WriteLine(resourceNames);
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                Stream stream = currentAssembly.GetManifestResourceStream("ReadExcel.Resources.ResultTrue.xls");
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "/Table/ResultTable.xls", FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }                
                stream = currentAssembly.GetManifestResourceStream("ReadExcel.Resources.Character.xlsx");
                bytes= new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "/Table/Character.xlsx", FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }

                stream = currentAssembly.GetManifestResourceStream("ReadExcel.Resources.CharacterCl4.xlsx");
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "/Table/CharacterCl4.xlsx", FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                stream = currentAssembly.GetManifestResourceStream("ReadExcel.Resources.ResultTrueCl4.xls");
                bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "/Table/ResultTableCl4.xls", FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }

        }
        

        public string ReadFile(DataGridView dataGridViewExcel, RadioButton rbtnWoman, RadioButton rbtnMan, RadioButton rbtCl4, RadioButton rbtCl8)
        {
            //tbPathToFile.Text = "D:\\1 (10 семестр)\\ДИПЛОМ Магистра (2018)\\Прога\\ReadExcel\\ReadExcel\\bin\\Debug\\ResultTrue.xls";
            string path = "";
            OleDbConnection conn=new OleDbConnection();
            string ClMan = "";
            string ClWoman = "";
            if (rbtCl8.Checked)
            {
                path = Environment.CurrentDirectory + "/Table/ResultTable.xls";
                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                Console.WriteLine(stringcoon);
                conn = new OleDbConnection(stringcoon);
                ClMan = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7";
                ClWoman = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7,Cl8";
            }
            else if (rbtCl4.Checked)
            {
                path = Environment.CurrentDirectory + "/Table/ResultTableCl4.xls";
                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                Console.WriteLine(stringcoon);
                conn = new OleDbConnection(stringcoon);
                ClMan = "Parametr,Cl1,Cl2,Cl3,Cl4";
                ClWoman = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5";
            }
            
            if (rbtnWoman.Checked)
            {
                if (rbtCl8.Checked)
                {
                    n = 8;
                    radiusCl = new double[] { 18.63, 22.13, 18.41, 20.53, 19.22, 20.60, 17.49, 18.95 };
                }
                else if (rbtCl4.Checked)
                {
                    n = 5;
                    radiusCl = new double[] { 18.63, 22.13, 18.41, 20.53, 19.22 };
                }
              

                OleDbDataAdapter da = new OleDbDataAdapter("Select "+ ClWoman + " from [" + rbtnWoman.Text + "$]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewExcel.AllowUserToAddRows = false;
                dataGridViewExcel.DataSource = dt;
            }
            else if (rbtnMan.Checked)
            {
                if (rbtCl8.Checked)
                {
                    n = 7;
                    radiusCl = new double[] { 25.48, 20.49, 21.24, 27.49, 28.52, 23.79, 23.04 };
                }
                else if (rbtCl4.Checked)
                {
                    n = 4;
                    radiusCl = new double[] { 25.48, 20.49, 21.24, 27.49 };
                }
               

                OleDbDataAdapter da = new OleDbDataAdapter("Select "+ ClMan + " from [" + rbtnMan.Text + "$]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewExcel.AllowUserToAddRows = false;
                dataGridViewExcel.DataSource = dt;
            }
            return path;

            //row- строка
            //column - столбец
        }
    }
}
