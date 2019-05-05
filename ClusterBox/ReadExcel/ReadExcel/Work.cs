using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Reflection;

namespace ClusterBox
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
                        radiusCl = new double[] { 878.08, 1425.58, 1043.88, 1085.48, 1477.13, 757.28, 1048.59, 800.77 };


                    }
                    else if (rbtCl4.Checked)
                    {
                        n = 5;
                        radiusCl = new double[] { 923.51, 1009.39, 1402.19, 1451.66, 1660.35 };
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
                        radiusCl = new double[] { 1520.09, 1285.33, 1628.77, 1204.14, 1948.87, 2290.51, 1381.65 };
                    }
                    else if (rbtCl4.Checked)
                    {
                        n = 5;
                        radiusCl = new double[] { 1362.65, 1966.39, 1290.68, 1659.76, 2756.1 };

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
