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

namespace ClusterBox
{
    public partial class UniversalWindow : Form
    {
        List<string> ExcelSheetsGlobal;
        DataTable schemaTableGlobal;
        OleDbConnection connGlobal;
        DataTable dtFindStudent = new DataTable();
        DataTable dtInputFile = new DataTable();
        DataTable dtRadiusCl = new DataTable();
        DataTable dtAll = new DataTable();
        List<string> columninfile_global;
        string select_list = "";
        String[] s;
        string path_character_table = "";
        List<double> Rad;

        bool textboxfindstudent_change = true;

        public UniversalWindow()
        {
            InitializeComponent();
            btnOpenFile.Enabled = false;
            btnOutputFileData.Enabled = false;
            btnCunclusion.Enabled = false;
            comboBoxList.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnCunclusion_Click(object sender, EventArgs e)
        {
            try
            {
                CuclStart();
                btnUpdate.Enabled = true;
            }
            //try
            //{
            //    CuclStart();
            //}
            catch (Exception ex)
            {
                Console.WriteLine("btnCunclusion " + ex.Message);
                Console.WriteLine("btnCunclusion " + ex.StackTrace);
            }


        }

        void CuclStart()
        {

            // string tablewithcluster = "Cluster" + comboBoxList.Items[comboBoxList.SelectedIndex].ToString();
            string tablewithcluster = "Cluster" + select_list;
            int flag = (comboBoxList.FindStringExact(tablewithcluster));
            OleDbConnection conn;
            OleDbCommand cmd;
            Connection(out conn, out cmd, textBoxFile.Text);
            conn.Open();
            if (flag != -1)
            {
                try
                {
                    cmd.CommandText = "DROP TABLE [" + tablewithcluster + "];";
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("обработка исключения");
                }
                finally
                {
                    cmd.CommandText = "CREATE TABLE [" + tablewithcluster + "] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
            else
            {
                try
                {
                    cmd.CommandText = "CREATE TABLE [" + tablewithcluster + "] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("Перед початком роботи закрийте базу даних");
                }

            }



            //List<string> NameColumninFile = new List<string>();
            //for (int i=0;i<dataGridViewFile.Columns.Count;i++)
            //{
            //    NameColumninFile.Add(dataGridViewFile.Columns[i].HeaderText);
            //}
            //foreach(string abc in NameColumninFile)
            //{
            //    Console.WriteLine(abc);
            //}
            string elementinresulttable = (dataGridViewResultTable[0, dataGridViewResultTable.CurrentRow.Index]).Value.ToString();
            Console.WriteLine(elementinresulttable);
            if (columninfile_global.Contains(elementinresulttable))
            {
                Console.WriteLine("ergerg " + columninfile_global.IndexOf(elementinresulttable));
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
                // Console.WriteLine("k:"+ k);

                List<double> SummClasters = new List<double>();
                for (int j = 1; j < dataGridViewResultTable.Columns.Count; j++)
                {
                    // Console.WriteLine("j:" + j);
                    summ = 0;
                    for (int i = dataGridViewResultTable.CurrentRow.Index; i < dataGridViewResultTable.Rows.Count; i++)
                    {
                        // Console.WriteLine("i:" + i);
                        datainresulttable = Convert.ToDouble(dataGridViewResultTable[j, i].Value.ToString());
                        if ((dtInputFile.Rows[k][columninfile_global.IndexOf(elementinresulttable) + i - dataGridViewResultTable.CurrentRow.Index].ToString().Length != 0))
                        {
                            //Console.WriteLine(columninfile_global.IndexOf(elementinresulttable) + i - dataGridViewResultTable.CurrentRow.Index+"--");
                            datainfile = Convert.ToDouble(dtInputFile.Rows[k][columninfile_global.IndexOf(elementinresulttable) + i - dataGridViewResultTable.CurrentRow.Index].ToString());
                            //datainfile = Convert.ToDouble(dataGridViewFile[columninfile_global.IndexOf(elementinresulttable) + i - 1, k].Value.ToString());
                            //Console.WriteLine(Math.Pow((datainfile - datainresulttable), 2));
                            // Console.WriteLine(columninfile_global.IndexOf(elementinresulttable) + i - dataGridViewResultTable.CurrentRow.Index + " index_index");
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

            }
            textBoxConclusion.Text = "Кластеризацію успішно проведено. Результат збережено";

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
                    if (!ColumnInSheets[i].Contains("F"))
                    {
                        columnintable += ColumnInSheets[i] + ",";
                    }
                    Console.WriteLine(ColumnInSheets[i]);
                }
                columnintable = (columnintable.Remove(columnintable.Length - 1));

                OleDbDataAdapter da = new OleDbDataAdapter("Select " + columnintable + " from[" + rbtnWoman.Text + "$]", conn);
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
                string path = "";
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path = textBoxFile.Text = ofd.FileName;
                }
                OpenFileForCulc(out ExcelSheetsGlobal, out schemaTableGlobal, out connGlobal, path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("btnOpenFile_Click " + ex.Message);
            }

        }
        void OpenFileForCulc(out List<string> ExcelSheets, out DataTable schemaTable, out OleDbConnection conn, string path)
        {
            //  string path = "";
            // DataTable dt = new DataTable();


            comboBoxList.Items.Clear();

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
                OutoutFileData(out dtInputFile, out dtRadiusCl, out s);

            }
            catch (Exception ex)
            {
                Console.WriteLine("btnOutoutFileData " + ex.Message);
                Console.WriteLine("btnOutoutFileData " + ex.StackTrace);
            }
        }


        List<double> OutoutFileData(out DataTable dtInputFile, out DataTable dtRadiusCl, out String[] s)
        {


            dataGridViewFile.DataSource = new object();
            DataTable dtFileOutput = new DataTable();
            dtInputFile = new DataTable();
            dtRadiusCl = new DataTable();

            string columninfile = "";
            string columnintableForfile = "";
            s = textBoxVarInList.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < s.Length; i++)
            {
                columninfile += (s[i].ToString() + ",");
            }
            Console.WriteLine("columninfile1 " + columninfile);
            for (int i = dataGridViewResultTable.CurrentRow.Index; i < dataGridViewResultTable.RowCount; i++)
            {
                columnintableForfile += (dataGridViewResultTable[0, i].Value.ToString() + ",");

            }
            Console.WriteLine("columnintableForfile1 " + columnintableForfile);
            columnintableForfile = (columnintableForfile.Remove(columnintableForfile.Length - 1));
            Console.WriteLine("columnintableForfile2 " + columnintableForfile);
            if (textBoxVarInList.Text == "")
            {
                columninfile = columnintableForfile;
                Console.WriteLine("columninfile2_true " + columninfile);

            }
            else
            {
                columninfile = (columninfile.Remove(columninfile.Length - 1));
                //+ "," + columnintableForfile;
                Console.WriteLine("columninfile2_false " + columninfile);
            }
            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBoxFile.Text + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            OleDbConnection conn = new OleDbConnection(stringcoon);

            try
            {

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                conn.Open();

                OleDbDataAdapter da = new OleDbDataAdapter("Select " + columninfile + " from[" + select_list + "$]", conn);
                OleDbDataAdapter da_intut_table = new OleDbDataAdapter("Select * from[" + select_list + "$]", conn);
                //OleDbDataAdapter da = new OleDbDataAdapter("Select " + columninfile + " from[" + comboBoxList.Items[comboBoxList.SelectedIndex].ToString() + "$]", conn);
                //OleDbDataAdapter da_intut_table = new OleDbDataAdapter("Select * from[" + comboBoxList.Items[comboBoxList.SelectedIndex].ToString() + "$]", conn);
                da.Fill(dtFileOutput);
                da.Fill(dtFindStudent);
                da_intut_table.Fill(dtInputFile);
                dataGridViewFile.AllowUserToAddRows = false;
                dataGridViewFile.DataSource = dtFileOutput;
                conn.Close();





                btnCunclusion.Enabled = true;
                OpenFileForCulc(out ExcelSheetsGlobal, out schemaTableGlobal, out connGlobal, textBoxFile.Text);
                Console.WriteLine("Cluster" + select_list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }

            try
            {
                if (comboBoxList.Items.Contains("Cluster" + select_list))
                {

                    OleDbConnection connRadiusCl = new OleDbConnection(stringcoon);
                    OleDbCommand cmdRadiusCl = new OleDbCommand();
                    cmdRadiusCl.Connection = conn;
                    conn.Open();
                    string select = "Cl,Dist,NextCl,NextDist";
                    OleDbDataAdapter daRadiusCl = new OleDbDataAdapter("Select " + select + " from[" + "Cluster" + select_list + "$]", conn);

                    daRadiusCl.Fill(dtRadiusCl);

                    Rad = new List<double>();
                    List<int> Cl = new List<int>();

                    for (int i = 0; i < dtRadiusCl.Rows.Count; i++)
                    {

                        Cl.Add(Convert.ToInt32(dtRadiusCl.Rows[i]["Cl"].ToString()));

                    }

                    int min_cl = Cl.Min();
                    int max_cl = Cl.Max();
                    for (int j = min_cl; j <= max_cl; j++)
                    {
                        List<double> RadAverage = new List<double>();
                        for (int i = 0; i < dtRadiusCl.Rows.Count; i++)
                        {

                            if (dtRadiusCl.Rows[i]["Cl"].ToString().Contains(j.ToString()))
                            {
                                RadAverage.Add(Convert.ToDouble(dtRadiusCl.Rows[i]["Dist"].ToString()));
                            }
                        }
                        Rad.Add(Math.Round(RadAverage.Average(), 2));
                    }
                    //radius = radius / dtRadiusCl.Rows.Count;
                    foreach (double r in Rad)
                    {
                        Console.WriteLine("radius!!!!!!!!!!!!! " + r);
                    }

                    conn.Close();
                    UpdateDate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
            return Rad;
        }

        private void comboBoxList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            select_list = "";
            try
            {
                select_list = (comboBoxList.Items[comboBoxList.SelectedIndex].ToString());
                ListChange(out columninfile_global);
            }
            catch (Exception ex)
            {
                Console.WriteLine("comboBoxListChange " + ex.Message);
            }
        }
        void ListChange(out List<string> columninfile_global_listchange)
        {
            btnOutputFileData.Enabled = true;
            List<string> ColumnInSheetsGlobal = new List<string>();
            textBoxVarInList.Clear();
            int indexsheet = ExcelSheetsGlobal.IndexOf(comboBoxList.Items[comboBoxList.SelectedIndex].ToString());
            Console.WriteLine("qwefewf " + indexsheet);
            string sheet1 = (string)schemaTableGlobal.Rows[indexsheet].ItemArray[2];
            // Выбираем все данные с листа
            string select = String.Format("SELECT * FROM [{0}]", sheet1);

            OleDbCommand oleDB = new OleDbCommand(select, connGlobal);
            OleDbDataReader reader = oleDB.ExecuteReader();
            columninfile_global_listchange = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                ColumnInSheetsGlobal.Add(reader.GetName(i)); // Имя столбца
                textBoxVarInList.Text += ColumnInSheetsGlobal[i] + Environment.NewLine;
                columninfile_global_listchange.Add(reader.GetName(i));
            }
        }
        /// <summary>
        /// Обработка поиска студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Поиск студента
        /// </summary>
        void FindStudent()
        {
            textboxfindstudent_change = false;
            List<string> findstudent = new List<string>();
            for (int i = 0; i < dataGridViewFile.Columns.Count; i++)
            {
                findstudent.Add(dataGridViewFile.Columns[i].HeaderText);
            }
            if (findstudent.Contains("ПІБ"))
            {
                DataView dv = new DataView(dtAll);//Создание новой таблицы
                dv.RowFilter = string.Format("ПІБ like '%{0}%'", textBoxFindStudent.Text);//Поиск в столбце ПІБ по значению, введенному в textBox1
                dataGridViewFile.DataSource = dv.ToTable();//Заполнение таблицы
            }

            textboxfindstudent_change = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                OutoutFileData(out dtInputFile, out dtRadiusCl, out s);

            }
            catch (Exception ex)
            {
                Console.WriteLine("btnOutoutFileData " + ex.Message);
                Console.WriteLine("btnOutoutFileData " + ex.StackTrace);
            }


        }
        void UpdateDate()
        {
            try
            {

                dtAll = dtInputFile.Copy();
                dtAll.Merge(dtRadiusCl);

                Console.WriteLine(dtAll.Columns.Count);

                for (int i = 0; i < dtAll.Rows.Count / 2; i++)
                {
                    dtAll.Rows[i][dtAll.Columns.Count - 1] = dtAll.Rows[dtAll.Rows.Count / 2 + i][dtAll.Columns.Count - 1];
                    dtAll.Rows[i][dtAll.Columns.Count - 2] = dtAll.Rows[dtAll.Rows.Count / 2 + i][dtAll.Columns.Count - 2];
                    dtAll.Rows[i][dtAll.Columns.Count - 3] = dtAll.Rows[dtAll.Rows.Count / 2 + i][dtAll.Columns.Count - 3];
                    dtAll.Rows[i][dtAll.Columns.Count - 4] = dtAll.Rows[dtAll.Rows.Count / 2 + i][dtAll.Columns.Count - 4];


                    DataRow dr = dtAll.Rows[dtAll.Rows.Count / 2 + i];
                    dr.Delete();

                }

                dataGridViewFile.DataSource = dtAll;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }
        private string Character(OleDbConnection conn, string sex, string read, int i)
        {
            conn.Open();
            OleDbCommand command1 = new OleDbCommand("Select * from " + sex + "", conn);
            OleDbDataReader dr = command1.ExecuteReader();
            // conn.Close();
            while (dr.Read())
            {
                read = Convert.ToString(dr[i - 1]);
            }
            dr.Close();
            return read;
        }

        private string ReadFile(string read, int i, string path)
        {


            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            OleDbConnection conn = new OleDbConnection(stringcoon);

            try
            {
                if (rbtnMan.Checked)
                {
                    read = Character(conn, "[" + rbtnMan.Text + "$]", read, i);
                    conn.Close();
                }
                else
                {
                    read = Character(conn, "[" + rbtnWoman.Text + "$]", read, i);
                    conn.Close();
                }

            }
            catch
            {
                MessageBox.Show("Файл з рекомендаціями не знайдено");
                read = "\nДані відснутні";
            }

            return read;
        }

        private void btnCharacter_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    path_character_table = ofd.FileName;
                }
                if (rbtnMan.Checked)
                {
                    textBoxConclusion.Text = "Таблицю з характеристиками " + "\"" + rbtnMan.Text + "\"" + " успішно завантажено";
                }
                else
                {
                    textBoxConclusion.Text = "Таблицю з характеристиками " + "\"" + rbtnWoman.Text + "\"" + " успішно завантажено";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void dataGridViewFile_SelectionChanged(object sender, EventArgs e)
        {

            try
            {

                if (path_character_table != "" && dataGridViewFile.Columns.Contains("Dist") && dataGridViewFile.Columns.Contains("Cl") &&
                    dataGridViewFile.Columns.Contains("NextCl") && dataGridViewFile.Columns.Contains("NextDist") && textboxfindstudent_change)
                {
                    string read = "";

                    int columnCl = (dataGridViewFile.Columns["Cl"].Index);
                    int columnDist = (dataGridViewFile.Columns["Dist"].Index);
                    int columnNextDist = (dataGridViewFile.Columns["NextDist"].Index);
                    int columnNextCl = (dataGridViewFile.Columns["NextCl"].Index);
                    int row = (dataGridViewFile.CurrentCell.RowIndex);
                    double radius = Rad[Convert.ToInt32(dataGridViewFile[columnCl, row].Value.ToString()) - 1];

                    int columnSurname = (dataGridViewFile.Columns["ПІБ"].Index);

                    Console.WriteLine(radius + " " + dataGridViewFile[columnDist, row].Value.ToString());

                    // Console.WriteLine(Convert.ToInt32(dataGridViewFile[columnCl, row].Value.ToString()));
                    if (radius > Convert.ToDouble(dataGridViewFile[columnDist, row].Value.ToString()))
                    {
                        MessageBox.Show("Студент " + dataGridViewFile[columnSurname, row].Value.ToString() +
                            " знаходиться у кластері " + dataGridViewFile[columnCl, row].Value.ToString() + "\n" +
                            "Мінімальна відстань становить " + dataGridViewFile[columnDist, row].Value.ToString() + "\n\n" +

                            ReadFile(read, Convert.ToInt32(dataGridViewFile[columnCl, row].Value.ToString()), path_character_table));
                    }
                    else
                    {
                        MessageBox.Show("Студент " + dataGridViewFile[columnSurname, row].Value.ToString() +
                           " знаходиться у кластері " + dataGridViewFile[columnCl, row].Value.ToString() + "\n" +
                           "Мінімальна відстань становить " + dataGridViewFile[columnDist, row].Value.ToString() + "\n\n" +

                           ReadFile(read, Convert.ToInt32(dataGridViewFile[columnCl, row].Value.ToString()), path_character_table) + "\n\n" +
                           "Радіус кластера не перевищує вектор направлення студента: " + radius + "<" + dataGridViewFile[columnDist, row].Value.ToString() + "\n\n" +
                           "Необхідно вивести додаткові характеристики \n\n" +
                           "Наступний кластер після оптимального :" + dataGridViewFile[columnNextCl, row].Value.ToString() + "\n" +
                            "Субмінімальна відстань становить " + dataGridViewFile[columnNextDist, row].Value.ToString() + "\n\n" +

                            ReadFile(read, Convert.ToInt32(dataGridViewFile[columnNextCl, row].Value.ToString()), path_character_table));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Instruction instruct = new Instruction();
            //instruct.Show();
        }

        private void GlobalClToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
            //form1.Show();
            //Hide();
        }

        private void UniversalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniversalWindow universalWindow = new UniversalWindow();
            universalWindow.Show();
            Hide();
        }

        private void ModeClCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //StartWindow startWindow = new StartWindow();
            //startWindow.Show();
            //Hide();
        }

        private void menuStrip1_MouseDown_1(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }


        private void btnCunclusion_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxConclusion.Text = "Йде кластеризація із записом результатів до файлу";
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            Hide();
            WindowController.ShowGlobalWindow();
        }

        private void btnMono_Click(object sender, EventArgs e)
        {
            Hide();
            WindowController.ShowMonoWindow();
        }

        private void btnUniversal_Click(object sender, EventArgs e)
        {
            Hide();
            WindowController.ShowUniversalWindow();
        }

        private void btnRegress_Click(object sender, EventArgs e)
        {
            Hide();
            WindowController.ShowVectorRegressionWindow();
        }

        private void InstructionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowController.ShowInstruction();
        }

        private void PurposeProgramTSMenu_Click(object sender, EventArgs e)
        {
            WindowController.ShowAboutProgram();
        }

        private void LegendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowController.ShowLegend();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowController.ShowAboutUs();
        }

        private void UniversalWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            WindowController.ExitIfNoWindow();
        }

        private void ClusterChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            WindowController.ShowChangeWindow();
        }
    }
}

