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
            string path = "";
            string ClMan = "";
            string ClWoman = "";
            DataTable dt = new DataTable();
            OleDbConnection conn;
            try
            {



                if (rbtCl8.Checked)
                {

                    path = Environment.CurrentDirectory + "/Table/ResultTable.xls";
                    string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";

                    conn = new OleDbConnection(stringcoon);

                    ClMan = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7";
                    ClWoman = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7,Cl8";
                }
                else if (rbtCl4.Checked)
                {

                    path = Environment.CurrentDirectory + "/Table/ResultTableCl5.xls";
                    string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";

                    conn = new OleDbConnection(stringcoon);

                    ClMan = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5";
                    ClWoman = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5";
                }


                if (rbtnWoman.Checked)
                {
                    if (rbtCl8.Checked)
                    {
                        n = 8;
                        radiusCl = new double[] { 18.22, 21.79, 17.30, 23.25, 17.57, 20.42, 16.43, 18.82 };

                    }
                    else if (rbtCl4.Checked)
                    {
                        n = 5;
                        radiusCl = new double[] { 19.16, 17.39, 21.39, 16.7, 17.72 };
                    }



                    string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                    conn = new OleDbConnection(stringcoon);

                    OleDbDataAdapter da = new OleDbDataAdapter("Select " + ClWoman + " from [" + rbtnWoman.Text + "$]", conn);

                    da.Fill(dt);
                    dataGridViewExcel.AllowUserToAddRows = false;
                    dataGridViewExcel.DataSource = dt;

                }
                else if (rbtnMan.Checked)
                {
                    if (rbtCl8.Checked)
                    {
                        n = 7;
                        radiusCl = new double[] { 25.21, 19.56, 19.32, 27.09, 28.24, 22.81, 22.72 };
                    }
                    else if (rbtCl4.Checked)
                    {
                        n = 5;
                        radiusCl = new double[] { 23.92, 29.4, 25.59, 24.40, 25.66 };
                    }



                    string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                    conn = new OleDbConnection(stringcoon);
                    OleDbDataAdapter da = new OleDbDataAdapter("Select " + ClMan + " from [" + rbtnMan.Text + "$]", conn);

                    da.Fill(dt);
                    dataGridViewExcel.AllowUserToAddRows = false;
                    dataGridViewExcel.DataSource = dt;
                }
            }
            catch(OleDbException ex)
            {
                if(ex.Message.Contains("Недопустимый путь"))
                {
                    MessageBox.Show("Не знайдено папку Table і наявні в ній результуючі таблиці");
                }
            }



            return path;

            //row- строка
            //column - столбец
        }
    }
}
