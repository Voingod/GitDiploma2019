using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Data.Common;

namespace TestResource
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            //dataGridView1.RowCount = 5;
            //dataGridView1.ColumnCount = 300;
            //for(int i=0;i<300;i++)
            //{
            //    dataGridView1[i, 1].Value = i;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            WorkWithFile workfile = new WorkWithFile();

            if (Directory.Exists(Environment.CurrentDirectory + "/testtest"))
            {
                workfile.CreateFile();
                workfile.ReadFile(dataGridView1);
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(Environment.CurrentDirectory + "/testtest");
                workfile.CreateFile();
                workfile.ReadFile(dataGridView1);
            }
            
        }
        public void Connection (out OleDbConnection conn, out OleDbCommand cmd)
        {
            string path = Environment.CurrentDirectory + "/testtest/1.xlsx";
            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            conn = new OleDbConnection(stringcoon);

            conn.Open();

            cmd = new OleDbCommand();
            cmd.Connection = conn;
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{

            bool flag = false;
            OleDbConnection conn;
            OleDbCommand cmd;
            Connection(out conn, out cmd);

            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


            // Показать список листов в файле
            List<string> ExcelSheets = new List<string>();
            List<string> ColumnInSheets = new List<string>();

            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {


                string str = Convert.ToString(schemaTable.Rows[i].ItemArray[2]);
                string [] charsToRemove = new string[] { "$" };
                foreach (string c in charsToRemove)
                {
                    str = str.Replace(c, string.Empty);
                }
                ExcelSheets.Add(str);
             
            }
            if (ExcelSheets.Contains("Cluster"))
            {
                int indexsheet = ExcelSheets.IndexOf("Cluster");
                string sheet1 = (string)schemaTable.Rows[indexsheet].ItemArray[2];
                // Выбираем все данные с листа
                string select = String.Format("SELECT * FROM [{0}]", sheet1);

                OleDbCommand oleDB = new OleDbCommand(select, conn);
                OleDbDataReader reader = oleDB.ExecuteReader();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ColumnInSheets.Add(reader.GetName(i)); // Имя столбца
                }
                if(ColumnInSheets.Contains("Cl")&& ColumnInSheets.Contains("Dist")&& ColumnInSheets.Contains("NextCl")&& ColumnInSheets.Contains("NextDist"))
                {
                    //YesNo yesNo = new YesNo();
                    //yesNo.Show();
                    cmd.CommandText = "CREATE TABLE [Cluster$] (Cl INT, Dist INT, NextCl INT, NextDist INT, hhkj int);";
                    cmd.ExecuteNonQuery();
                }
                else
                {


                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (ColumnInSheets[i] == "F" + (i + 1))
                        {
                            Console.WriteLine(i);
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        cmd.CommandText = "CREATE TABLE[Cluster$] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        Console.WriteLine("Таблица уже есть, но содержит другие поля");
                    }
                }
                //string timenow = DateTime.Now.ToString("ssmm");
                //cmd.CommandText = "CREATE TABLE [Cluster" + timenow + "] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                //cmd.ExecuteNonQuery();


            }
            else
            {
                    cmd.CommandText = "CREATE TABLE [Cluster] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                    cmd.ExecuteNonQuery();
            }
            conn.Close();


            //OleDbDataAdapter oCmd1 = new OleDbDataAdapter("CREATE TABLE[name2$] (One char(255), Two char(255), Three char(255))", conn);

            //DataSet oDS1 = new DataSet();
            //oCmd1.Fill(oDS1);
            // OleDbDataAdapter oCmd2 = new OleDbDataAdapter("INSERT INTO [test$] SELECT (Two) FROM [name2]", conn);
            // OleDbDataAdapter oCmd2 = new OleDbDataAdapter("SELECT (Two) FROM [name2]", conn);
            // OleDbDataAdapter oCmd2 = new OleDbDataAdapter("Select [test$].*, Null As NewColumn Into [name3] From [test$]", conn);
            // OleDbDataAdapter oCmd2 = new OleDbDataAdapter("SELECT Cl11, Cl22 FROM [test$],[Men$]", conn);

            //DataTable dt= new DataTable();
            //oCmd2.Fill(dt);


            // DataTable dt = oCmd2;
            // DataSet oDS2 = new DataSet();
            //oCmd2.Fill(oDS2);


            //conn.Open();


            //DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            ////string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            ////// Выбираем все данные с листа
            ////string select = String.Format("SELECT * FROM [{0}]", sheet1);

            ////OleDbCommand oleDB = new OleDbCommand(select, conn);
            ////OleDbDataReader reader = oleDB.ExecuteReader();
            ////for (int i = 0; i < reader.FieldCount; i++)
            ////{
            ////    Console.WriteLine(reader.GetName(i)); // Имя столбца
            ////}
            //// Показать список листов в файле
            //for (int i = 0; i < schemaTable.Rows.Count; i++)
            //{
            //    // Имена листов
            //   // Console.WriteLine(schemaTable.Rows[i].ItemArray[2]);

            //    // Дата модификации
            //    //Console.WriteLine(schemaTable.Rows[i].ItemArray[7]);
            //}

            //conn.Close();

           // Console.WriteLine(DateTime.Now.ToString("ssmm")); //Выводим дату, выводится название месяца а не его номер
            Console.WriteLine("Print: True");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OleDbConnection conn;
            OleDbCommand cmd;
            Connection(out conn, out cmd);
            OleDbDataAdapter daGlobal = new OleDbDataAdapter("Select CL11 from [test$]", conn);
            OleDbDataAdapter daGlobal1 = new OleDbDataAdapter("Select NextDist from [Cluster$]", conn);



           // DataSet ds1 = new DataSet();
            //DataSet ds2 = new DataSet();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            // ds1.Tables.Add(dt1);
            //ds2.Tables.Add(dt2);


            int count = 0;
            daGlobal.Fill(dt1);
            count = dt1.Rows.Count;
          //  Console.WriteLine(count);
            daGlobal1.Fill(dt1);

            dataGridView1.AllowUserToAddRows = false;

            //for(int i=0;i<dt1.Rows.Count;i++)
            //{
            //    Console.WriteLine(i + " " + dt1.Rows[i][1].ToString());
            //}

            Console.WriteLine(dt1.Rows.Count);
            for (int i=0;i<count;i++)
            {
                dt1.Rows[i][1] = dt1.Rows[count+i][1];
                dt1.Rows[count+i].Delete();
            }



            dataGridView1.DataSource = dt1;

        }
    }

}
