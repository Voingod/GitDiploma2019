using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace TestResource
{
    class WorkWithFile
    {


        public void CreateFile()
        {
            
            if (File.Exists(Environment.CurrentDirectory + "/testtest/1.xls"))
            {
                return;
            }
            else
            {
                string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                Stream stream = currentAssembly.GetManifestResourceStream("TestResource.Resources.ResultTrue.xls");
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "/testtest/1.xls", FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }

        }

        public void ReadFile(DataGridView dataGridView1)
        {
            dataGridView1.RowCount = 5;
            dataGridView1.ColumnCount = 3;
            string path = Environment.CurrentDirectory + "/testtest/1.xlsx";
            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            Console.WriteLine(stringcoon);
            OleDbConnection conn = new OleDbConnection(stringcoon);
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [test$]", conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
        }

    }
}
