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
        public double[] radiusCl = new double[8];
        public void CreateFile()
        {
            
            if (File.Exists(Environment.CurrentDirectory + "/Table/ResultTable.xls") && File.Exists(Environment.CurrentDirectory + "/Table/Character.xlsx"))
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
            }

        }

       
        public void ReadFile(TextBox tbPathToFile, DataGridView dataGridViewExcel, RadioButton rbtnWoman, RadioButton rbtnMan)
        {
            //tbPathToFile.Text = "D:\\1 (10 семестр)\\ДИПЛОМ Магистра (2018)\\Прога\\ReadExcel\\ReadExcel\\bin\\Debug\\ResultTrue.xls";
            string path = Environment.CurrentDirectory + "/Table/ResultTable.xls";
            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            Console.WriteLine(stringcoon);
            OleDbConnection conn = new OleDbConnection(stringcoon);
            if (rbtnWoman.Checked)
            {
                radiusCl = new double[] { 18.63, 22.13, 18.41, 20.53, 19.22, 20.60, 17.49, 18.95 };

                OleDbDataAdapter da = new OleDbDataAdapter("Select Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7,Cl8 from [" + rbtnWoman.Text + "$]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewExcel.AllowUserToAddRows = false;
                dataGridViewExcel.DataSource = dt;
            }
            else if (rbtnMan.Checked)
            {
                radiusCl = new double[] { 25.48, 20.49, 21.24, 27.49, 28.52, 23.79, 23.04 };

                OleDbDataAdapter da = new OleDbDataAdapter("Select Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7 from [" + rbtnMan.Text + "$]", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewExcel.AllowUserToAddRows = false;
                dataGridViewExcel.DataSource = dt;
            }

            //row- строка
            //column - столбец
        }
    }
}
