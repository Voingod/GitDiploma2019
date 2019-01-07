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

namespace UniversalWindow
{
    public partial class UniversalWindowCl : Form
    {

        List<string> ExcelSheetsGlobal;
        DataTable schemaTableGlobal;
        OleDbConnection connGlobal;
        DataTable dtFindStudent = new DataTable();
        

        public UniversalWindowCl()
        {
            InitializeComponent();
            btnOpenFile.Enabled = false;
            btnOutputFileData.Enabled = false;
            btnCunclusion.Enabled = false;
            comboBoxList.Enabled = false;
        }

        private void btnCunclusion_Click(object sender, EventArgs e)
        {
            try
            {
                CuclStart();
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnCunclusion " + ex.Message);
            }


        }
        void CuclStart()
        {
            textBoxConclusion.Text = "Йде кластеризація із записом результатів до файлу";
           string tablewithcluster = "Cluster" + comboBoxList.Items[comboBoxList.SelectedIndex].ToString();
           int flag =(comboBoxList.FindStringExact(tablewithcluster));
            OleDbConnection conn;
            OleDbCommand cmd;
            Connection(out conn, out cmd, textBoxFile.Text);
            conn.Open();
            if (flag != -1)
            {
                cmd.CommandText = "DROP TABLE [" + tablewithcluster + "];";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE [" + tablewithcluster + "] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {

                cmd.CommandText = "CREATE TABLE [" + tablewithcluster + "] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            


            List<string> NameColumninFile = new List<string>();
            for (int i=0;i<dataGridViewFile.Columns.Count;i++)
            {
                NameColumninFile.Add(dataGridViewFile.Columns[i].HeaderText);
            }
            string elementinresulttable = (dataGridViewResultTable[0,dataGridViewResultTable.CurrentRow.Index]).Value.ToString();
            if (NameColumninFile.Contains(elementinresulttable))
            {
                Console.WriteLine("ergerg " + NameColumninFile.IndexOf(elementinresulttable));
            }

            double datainresulttable = 0;
            double datainfile = 0;
            double summ = 0;
            double min = 0;
            double nextMin = 0;
            int Cl = 0;
            int nextCl = 0;

            for (int k = 0; k < dataGridViewFile.Rows.Count; k++)
            {
                List<double> SummClasters = new List<double>();
                for (int j = 1; j < dataGridViewResultTable.Columns.Count; j++)
                {
                    summ = 0;
                    for (int i = 1; i < dataGridViewResultTable.Rows.Count; i++)
                    {
                        datainresulttable = Convert.ToDouble(dataGridViewResultTable[j, i].Value.ToString());
                        if (dataGridViewFile[NameColumninFile.IndexOf(elementinresulttable) + i - 1, k].Value.ToString().Length != 0)
                        {
                            datainfile = Convert.ToDouble(dataGridViewFile[NameColumninFile.IndexOf(elementinresulttable) + i - 1, k].Value.ToString());
                            //Console.WriteLine(Math.Pow((datainfile - datainresulttable), 2));
                        }
                        else
                        {
                            datainfile = 0;
                        }
                        summ += Math.Pow((datainfile - datainresulttable), 2);
                    }
                    SummClasters.Add(summ);
                }

                List<double> SummClastersSort = new List<double>();

                for (int i = 0; i < SummClasters.Count; i++)
                {
                    SummClastersSort.Add(SummClasters[i]);
                }

                SummClastersSort.Sort();
                min = SummClastersSort[0];
                nextMin = SummClastersSort[1];

                Cl = SummClasters.IndexOf(min) + 1;
                nextCl = SummClasters.IndexOf(nextMin) + 1;

                min = Math.Round(min, 2);
                nextMin = Math.Round(nextMin, 2);

                //Console.WriteLine(Cl);
                //-------------------------------------------------------------------------
                //Console.WriteLine(k);
                //Console.WriteLine(Cl+" "+nextCl+" "+" "+min+" "+nextMin);

                conn.Open();
                string str = "INSERT INTO [" + tablewithcluster + "](Cl,Dist,NextCl,NextDist) VALUES(@Cl, @Dist, @NextCl ,@NextDist);"; ;

                OleDbCommand com = new OleDbCommand(str, conn);

                com.Parameters.AddWithValue("@Cl", Cl);
                com.Parameters.AddWithValue("@Dist", min);
                com.Parameters.AddWithValue("@NextCl", nextCl);
                com.Parameters.AddWithValue("@NextDist", nextMin);
                // cmd.CommandText = "INSERT INTO [" + tablewithcluster + "](Cl,Dist,NextCl,NextDist) VALUES(er,reh,er,eth);";
                // cmd.CommandText = "INSERT INTO [" + tablewithcluster + "](Cl,Dist,NextCl,NextDist) VALUES(1," + min + ",1,1);";
                //cmd.Parameters.AddWithValue("", Cl);
                //cmd.Parameters.AddWithValue("", min);
                //cmd.Parameters.AddWithValue("", nextCl);
                //cmd.Parameters.AddWithValue("", nextMin);
                com.ExecuteNonQuery();
                conn.Close();
                // Instert(textBoxFile.Text, (Cl), (min), (nextCl), (nextMin), "Cl,Dist,NextCl,NextDist", tablewithcluster);
                textBoxConclusion.Text = "Кластеризацію успішно проведено. Результат збережено";
            }

        }
        public void Connection(out OleDbConnection conn, out OleDbCommand cmd, string path)
        {
            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            conn = new OleDbConnection(stringcoon);
            cmd = new OleDbCommand();
            cmd.Connection = conn;
            //conn.Open();
        }
        //public void Instert(string pathGlobal, int Cl, double Dist, int NextCl, double NextDist, string columnName, string tablename)
        //{
        //    OleDbConnection conn;
        //    OleDbCommand cmd;
        //    string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathGlobal + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
        //    conn = new OleDbConnection(stringcoon);
        //    cmd = new OleDbCommand();
        //    cmd.Connection = conn;
        //   // conn.Open();
        //    cmd.CommandText = "INSERT INTO ["+tablename+"](" + columnName + ") VALUES(?,?,?,?);";
        //    cmd.Parameters.AddWithValue("", Cl);
        //    cmd.Parameters.AddWithValue("", Dist);
        //    cmd.Parameters.AddWithValue("", NextCl);
        //    cmd.Parameters.AddWithValue("", NextDist);
        //    cmd.ExecuteNonQuery();
        //    // conn.Close();
        //}
        private void btnResultTable_Click(object sender, EventArgs e)
        {
            try
            {
                OpenResultTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnResultTable " + ex.Message);
            }
            
        }
        void OpenResultTable()
        {
            string path = "";
            
            DataTable dt = new DataTable();

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = textBoxResultTable.Text = ofd.FileName;
            }

            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            OleDbConnection conn = new OleDbConnection(stringcoon);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


            // Показать список листов в файле
            List<string> ExcelSheets = new List<string>();
            List<string> ColumnInSheets = new List<string>();
            string columnintable = "";

            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {
                string str = Convert.ToString(schemaTable.Rows[i].ItemArray[2]);
                string[] charsToRemove = new string[] { "$" };
                foreach (string c in charsToRemove)
                {
                    str = str.Replace(c, string.Empty);
                }
                ExcelSheets.Add(str);
                Console.WriteLine(ExcelSheets[i]);
            }
            if (rbtnWoman.Checked)
            {
                int indexsheet = ExcelSheets.IndexOf(rbtnWoman.Text);
                string sheet1 = (string)schemaTable.Rows[indexsheet].ItemArray[2];
                // Выбираем все данные с листа
                string select = String.Format("SELECT * FROM [{0}]", sheet1);

                OleDbCommand oleDB = new OleDbCommand(select, conn);
                OleDbDataReader reader = oleDB.ExecuteReader();
                for (int i = 0; i < reader.FieldCount; i++)
                { 
                    ColumnInSheets.Add(reader.GetName(i)); // Имя столбца
                    if(!ColumnInSheets[i].Contains("F"))
                    {
                        columnintable += ColumnInSheets[i] + ",";
                    }
                    Console.WriteLine(ColumnInSheets[i]);
                }
                columnintable=(columnintable.Remove(columnintable.Length-1));
               
                OleDbDataAdapter da = new OleDbDataAdapter("Select "+ columnintable + " from[" + rbtnWoman.Text + "$]", conn);
                da.Fill(dt);
                dataGridViewResultTable.AllowUserToAddRows = false;
                dataGridViewResultTable.DataSource = dt;

            }
            else if (rbtnMan.Checked)
            {
                int indexsheet = ExcelSheets.IndexOf(rbtnMan.Text);
                string sheet1 = (string)schemaTable.Rows[indexsheet].ItemArray[2];
                // Выбираем все данные с листа
                string select = String.Format("SELECT * FROM [{0}]", sheet1);

                OleDbCommand oleDB = new OleDbCommand(select, conn);
                OleDbDataReader reader = oleDB.ExecuteReader();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ColumnInSheets.Add(reader.GetName(i)); // Имя столбца
                    if (!ColumnInSheets[i].Contains("F"))
                    {
                        columnintable += ColumnInSheets[i] + ",";
                    }
                    Console.WriteLine(ColumnInSheets[i]);
                }
                columnintable = (columnintable.Remove(columnintable.Length - 1));


                OleDbDataAdapter da = new OleDbDataAdapter("Select " + columnintable + " from[" + rbtnMan.Text + "$]", conn);
                da.Fill(dt);
                dataGridViewResultTable.AllowUserToAddRows = false;
                dataGridViewResultTable.DataSource = dt;
            }
            btnOpenFile.Enabled = true;

        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileForCulc(out ExcelSheetsGlobal, out schemaTableGlobal, out connGlobal);
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnOpenFile " + ex.Message);
            }
            
        }
        void OpenFileForCulc(out List<string> ExcelSheets, out DataTable schemaTable, out OleDbConnection conn)
        {
            string path = "";
            DataTable dt = new DataTable();

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = textBoxFile.Text = ofd.FileName;
            }

            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            conn = new OleDbConnection(stringcoon);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            conn.Open();
            schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


            // Показать список листов в файле
            ExcelSheets = new List<string>();
          

            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {
                string str = Convert.ToString(schemaTable.Rows[i].ItemArray[2]);
                string[] charsToRemove = new string[] { "$" };
                foreach (string c in charsToRemove)
                {
                    str = str.Replace(c, string.Empty);
                }
                ExcelSheets.Add(str);
                comboBoxList.Items.Add(ExcelSheets[i]);
                Console.WriteLine(ExcelSheets[i]);
            }
            comboBoxList.Enabled = true;


        }

        private void btnOutputFileData_Click(object sender, EventArgs e)
        {
            try
            {
                OutoutFileData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnOutoutFileData " + ex.Message);
            }
        }
        void OutoutFileData()
        {

            dataGridViewFile.DataSource = new object();
            DataTable dtFileOutput = new DataTable();
            string columninfile = "";
            string columnintableForfile = "";
            String[] s = textBoxVarInList.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s.Length; i++)
            {
                columninfile += (s[i].ToString() + ",");
            }
            for (int i = dataGridViewResultTable.CurrentRow.Index; i < dataGridViewResultTable.RowCount; i++)
            {
                columnintableForfile += (dataGridViewResultTable[0, i].Value.ToString() + ",");

            }
            columnintableForfile = (columnintableForfile.Remove(columnintableForfile.Length - 1));
            if(textBoxVarInList.Text=="")
            {
                columninfile = columnintableForfile;
                
            }
            else
            {
                columninfile = (columninfile.Remove(columninfile.Length - 1)) + "," + columnintableForfile;
            }
            

           
            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBoxFile.Text + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            OleDbConnection conn = new OleDbConnection(stringcoon);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            OleDbDataAdapter da = new OleDbDataAdapter("Select " + columninfile + " from[" + comboBoxList.Items[comboBoxList.SelectedIndex].ToString() + "$]", conn);
            da.Fill(dtFileOutput);
            da.Fill(dtFindStudent);
            dataGridViewFile.AllowUserToAddRows = false;
            dataGridViewFile.DataSource = dtFileOutput;




            btnCunclusion.Enabled = true;
            

        }

        private void comboBoxList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ListChange();
            }
            catch (Exception ex)
            {
                Console.WriteLine("comboBoxListChange " + ex.Message);
            }
        }
        void ListChange()
        {
            btnOutputFileData.Enabled = true;
            List<string> ColumnInSheetsGlobal = new List<string>();
            textBoxVarInList.Clear();
            int indexsheet = ExcelSheetsGlobal.IndexOf(comboBoxList.Items[comboBoxList.SelectedIndex].ToString());
            Console.WriteLine("qwefewf "+indexsheet);
            string sheet1 = (string)schemaTableGlobal.Rows[indexsheet].ItemArray[2];
            // Выбираем все данные с листа
            string select = String.Format("SELECT * FROM [{0}]", sheet1);

            OleDbCommand oleDB = new OleDbCommand(select, connGlobal);
            OleDbDataReader reader = oleDB.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                ColumnInSheetsGlobal.Add(reader.GetName(i)); // Имя столбца
                textBoxVarInList.Text += ColumnInSheetsGlobal[i] + Environment.NewLine;

            }
        }

        private void textBoxFindStudent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FindStudent();
            }
            catch (Exception ex)
            {
                Console.WriteLine("textBoxFindStudentTextChanged: " + ex.Message);
            }
        }
        void FindStudent()
        {
            List<string> findstudent = new List<string>();
            for(int i=0;i< dataGridViewFile.Columns.Count; i++)
            {
                findstudent.Add(dataGridViewFile.Columns[i].HeaderText);
            }
            if(findstudent.Contains("ПІБ"))
            {
                DataView dv = new DataView(dtFindStudent);//Создание новой таблицы
                dv.RowFilter = string.Format("ПІБ like '%{0}%'", textBoxFindStudent.Text);//Поиск в столбце ПІБ по значению, введенному в textBox1
                dataGridViewFile.DataSource = dv.ToTable();//Заполнение таблицы
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
        }
    
    }
}
