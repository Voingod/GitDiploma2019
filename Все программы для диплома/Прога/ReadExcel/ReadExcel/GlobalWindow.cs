using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Xls;
using ClusterVector;
using UniversalWindow;

namespace ReadExcel
{
    public partial class GlobalWindow : Form
    {
        string path = "";


        public GlobalWindow()
        {
            InitializeComponent();
            btnShow.Enabled = false;
            btnCulc.Enabled = false;
            btnShowUpdate.Enabled = false;
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TextPath.abc = tbPathToFileGM.Text = ofd.FileName;


            }
        }
        private void btnCulc_Click(object sender, EventArgs e)
        {
            try
            {

                ClusterTable(tbPathToFileGM.Text);
            }
            catch (OleDbException ex)
            {
                string exeption = ex.Message;

                if (exeption.Contains("0x80004005") || exeption.Contains("Ошибочный аргумент."))
                {
                    MessageBox.Show("За даним шляхом таблиці не знайдено");
                }
                else if (exeption.Contains("Недопустимое имя"))
                {
                    if (rbtnMan.Checked)
                    {
                        MessageBox.Show("Таблиця не містить листа " + rbtnMan.Text);
                    }
                    else if (rbtnWoman.Checked)
                    {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Таблиця не містить листа " + rbtnWoman.Text);
                    }
                    else
                    {
                        MessageBox.Show("Таблиця не містить вибраних листів.\nДивіться інструкцію користувача");
                    }


                }
                else if (exeption.Contains("Отсутствует значение для одного или нескольких требуемых параметров."))
                {
                    MessageBox.Show("У таблиці недостатньо стовпців для дослідження.\nПеревірте коректність таблиці або дивіться інструкцію користувача");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("База пошкоджена або містить некоректні дані.\nДивіться інструкцію користувача");
                }

            }
            catch (AccessViolationException)
            {
                MessageBox.Show("База даних має неправельний формат\n(Не є файлом Excel або має неправильне розрішеня)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.HelpLink);
               // MessageBox.Show("Заглушка, надо обработать");
            }

        }
        public void Connection(out OleDbConnection conn, out OleDbCommand cmd, string path)
        {
            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Mode = ReadWrite;" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            conn = new OleDbConnection(stringcoon);
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }
        public void Instert(string pathGlobal, int Cl, double Dist, int NextCl, double NextDist, string columnName)
        {
            OleDbConnection conn;
            OleDbCommand cmd;
            Connection(out conn, out cmd, pathGlobal);
            conn.Open();
            cmd.CommandText = "INSERT INTO [Cluster](" + columnName + ") VALUES(?,?,?,?);";
            cmd.Parameters.AddWithValue("", Cl);
            cmd.Parameters.AddWithValue("", Dist);
            cmd.Parameters.AddWithValue("", NextCl);
            cmd.Parameters.AddWithValue("", NextDist);
            cmd.ExecuteNonQuery();
            // conn.Close();
        }
        public void ClusterTable(string path)
        {
            bool flag = true;
            OleDbConnection conn;
            OleDbCommand cmd;
            Connection(out conn, out cmd, path);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


            // Показать список листов в файле
            List<string> ExcelSheets = new List<string>();
            List<string> ColumnInSheets = new List<string>();

            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {


                string str = Convert.ToString(schemaTable.Rows[i].ItemArray[2]);
                string[] charsToRemove = new string[] { "$" };
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

                if (ColumnInSheets.Contains("Cl") && ColumnInSheets.Contains("Dist") && ColumnInSheets.Contains("NextCl") && ColumnInSheets.Contains("NextDist"))
                {
                    conn.Close();
                    YesNo yesNo = new YesNo();
                    yesNo.Show();
                }
                else
                {

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (ColumnInSheets[i] == "F" + (i + 1))
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    conn.Close();
                    if (flag == true)
                    {
                        conn.Open();
                        cmd.CommandText = "DROP TABLE [Cluster];";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "CREATE TABLE [Cluster] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                        cmd.ExecuteNonQuery();
                        GlobalCucl(TextPath.abc, "Cl,Dist,NextCl,NextDist", path);
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Таблиця з ім'ям Cluster вже існує, але містить інші поля");

                    }
                }
            }
            else
            {

                cmd.CommandText = "CREATE TABLE [Cluster] (Cl INT, Dist INT, NextCl INT, NextDist INT);";
                cmd.ExecuteNonQuery();
                GlobalCucl(TextPath.abc, "Cl,Dist,NextCl,NextDist", path);
                conn.Close();

            }

        }
        public void GlobalCucl(string pathGlobal, string columnName, string path)
        {
            pathGlobal = TextPath.abc;


            DataTable dt = new DataTable();
            DataTable dtGlobal = new DataTable();


            string stringcoonGlobal = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathGlobal + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            OleDbConnection connGlobal = new OleDbConnection(stringcoonGlobal);



            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextPath.path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            OleDbConnection conn = new OleDbConnection(stringcoon);




            if (TextPath.SexCheck==false)
            {

                OleDbDataAdapter daGlobal = new OleDbDataAdapter("Select АТС0, АТД0, ЧСС0, АТС1, АТД1, ЧСС1, АТС2, АТД2, ЧСС2, АТС3, АТД3, ЧСС3, АТС4, АТД4, ЧСС4, АТС5, АТД5, ЧСС5 from [Жінки$] ", connGlobal);
                daGlobal.Fill(dtGlobal);

                OleDbDataAdapter da = new OleDbDataAdapter("Select " + TextPath.ClWoman + " from [" + rbtnWoman.Text + "$]", conn);
                da.Fill(dt);
            }
            else if (TextPath.SexCheck == true)
            {
                OleDbDataAdapter daGlobal = new OleDbDataAdapter("Select АТС0, АТД0, ЧСС0, АТС1, АТД1, ЧСС1, АТС2, АТД2, ЧСС2, АТС3, АТД3, ЧСС3, АТС4, АТД4, ЧСС4, АТС5, АТД5, ЧСС5 from [Чоловіки$]", connGlobal);
                daGlobal.Fill(dtGlobal);

                OleDbDataAdapter da = new OleDbDataAdapter("Select " + TextPath.ClMan + " from [" + rbtnMan.Text + "$]", conn);
                da.Fill(dt);
            }


            for (int k = 0; k < dtGlobal.Rows.Count; k++)
            {
                double min = 0;
                double nextMin = 0;
                List<double> SummClasters;

                Form1 form1 = new Form1();
                form1.EuclidSquare(k, dt, dtGlobal, out min, out nextMin, out SummClasters);

                int Cl = 0;
                double Dist = 0;
                int NextCl = 0;
                double NextDist = 0;

                for (int i = 0; i < SummClasters.Count; i++)
                {
                    if (min == SummClasters[i])
                    {
                        switch (i)
                        {
                            case 0: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;
                            case 1: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;
                            case 2: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;
                            case 3: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;
                            case 4: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;
                            case 5: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;
                            case 6: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;
                            case 7: Cl = (i + 1); Dist = Math.Round(SummClasters[i], 2); break;

                        }
                    }
                }
                for (int i = 0; i < SummClasters.Count; i++)
                {
                    if (nextMin == SummClasters[i])
                    {
                        switch (i)
                        {
                            case 0: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                            case 1: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                            case 2: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                            case 3: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                            case 4: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                            case 5: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                            case 6: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                            case 7: NextCl = (i + 1); NextDist = Math.Round(SummClasters[i], 2); break;
                        }
                    }
                }

                Instert(pathGlobal, (Cl), (Dist), (NextCl), (NextDist), columnName);
            }
            // conn.Close();
            //Workbook workbook = new Workbook();
            //Console.WriteLine(TextPath.abc);
            //workbook.LoadFromFile(TextPath.abc);
            //workbook.Save();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                ShowData();
            }
            catch (OleDbException ex)
            {
                string exeption = ex.Message;

                if (exeption.Contains("0x80004005") || exeption.Contains("Ошибочный аргумент."))
                {
                    MessageBox.Show("За даним шляхом таблиці не знайдено");
                }
                else if (exeption.Contains("Недопустимое имя"))
                {
                    if (rbtnMan.Checked)
                    {
                        MessageBox.Show("Таблиця не містить листа " + rbtnMan.Text);
                    }
                    else if (rbtnWoman.Checked)
                    {
                        MessageBox.Show("Таблиця не містить листа " + rbtnWoman.Text);
                    }
                    else
                    {
                        MessageBox.Show("Таблиця не містить вибраних листів.\nДивіться інструкцію користувача");
                    }


                }
                else if (exeption.Contains("Отсутствует значение для одного или нескольких требуемых параметров."))
                {
                    MessageBox.Show("У таблиці недостатньо стовпців для дослідження.\nПеревірте коректність таблиці або дивіться інструкцію користувача");
                }
                else
                {
                    MessageBox.Show("База пошкоджена або містить некоректні дані.\nДивіться інструкцію користувача");
                }

            }
            catch (AccessViolationException)
            {
                MessageBox.Show("База даних має неправельний формат\n(Не є файлом Excel або має неправильне розрішеня)");
            }
        }

        //Интерфейс Начало
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TextPath.abc = tbPathToFileGM.Text = ofd.FileName;

            }
        }

        private void PurposeProgramTSMenu_Click(object sender, EventArgs e)
        {
            About aboutProgramm = new About();
            aboutProgramm.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUS us = new AboutUS();
            us.Show();
        }

        private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction instruct = new Instruction();
            instruct.Show();
        }

        private void LegendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legend legend = new Legend();
            legend.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            Close();
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));

        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
        }
        //Интерфейс Конец

        //Создание эксель-файла (сейчас не используется)
        private void button1_Click(object sender, EventArgs e)
        {
            //Initialize a new Workboook object
            Workbook workbook = new Workbook();
            //Get the first worksheet
            Worksheet sheet = workbook.Worksheets[0];
            //Write string values in a cell
            sheet.Range["A3"].Text = "This Excel Document is Created by Spire.XLS for .NET";
            //Save workbook to disk
            workbook.SaveToFile("Sample.xls", ExcelVersion.Version97to2003);
            try
            {
                workbook.LoadFromFile("path!!!!");
                workbook.Save();

                System.Diagnostics.Process.Start(workbook.FileName);
            }
            catch { }
        }

        private void btnShowUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ShowData();
            }
            catch (OleDbException ex)
            {
                string exeption = ex.Message;

                if (exeption.Contains("0x80004005") || exeption.Contains("Ошибочный аргумент."))
                {
                    MessageBox.Show("За даним шляхом таблиці не знайдено");
                }
                else if (exeption.Contains("Недопустимое имя"))
                {
                    if (rbtnMan.Checked)
                    {
                        MessageBox.Show("Таблиця не містить листа " + rbtnMan.Text);
                    }
                    else if (rbtnWoman.Checked)
                    {
                        MessageBox.Show("Таблиця не містить листа " + rbtnWoman.Text);
                    }
                    else
                    {
                        MessageBox.Show("Таблиця не містить вибраних листів.\nДивіться інструкцію користувача");
                    }


                }
                else if (exeption.Contains("Отсутствует значение для одного или нескольких требуемых параметров."))
                {
                    MessageBox.Show("У таблиці недостатньо стовпців для дослідження.\nПеревірте коректність таблиці або дивіться інструкцію користувача");
                }
                else
                {
                    MessageBox.Show("База пошкоджена або містить некоректні дані.\nДивіться інструкцію користувача");
                }

            }
            catch (AccessViolationException)
            {
                MessageBox.Show("База даних має неправельний формат\n(Не є файлом Excel або має неправильне розрішеня)");
            }
        }

        private void RegressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VectorFormStart vectorFormStart = new VectorFormStart();
            vectorFormStart.Show();
        }

        private void GlobalClToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void ModeClCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            Hide();
        }

        private void tbPathToFileGM_TextChanged(object sender, EventArgs e)
        {
            if (tbPathToFileGM.Text != "")
            {
                btnShow.Enabled = true;
                btnCulc.Enabled = true;
                btnShowUpdate.Enabled = true;
            }
            else
            {
                btnShow.Enabled = false;
                btnCulc.Enabled = false;
                btnShowUpdate.Enabled = false;
            }
        }

        private void ShowData()
        {
            string pathGlobal = TextPath.abc;
            //Console.WriteLine(pathGlobal);
            string stringcoonGlobal = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathGlobal + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            OleDbConnection connGlobal = new OleDbConnection(stringcoonGlobal);
            DataTable dtGlobalPart1 = new DataTable();
            DataTable dtGlobalPart2 = new DataTable();
            int countRows = 0;
            int countColumns = 0;

            OleDbConnection conn;
            OleDbCommand cmd;
            Connection(out conn, out cmd, pathGlobal);
            conn.Open();
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });


            // Показать список листов в файле
            List<string> ExcelSheets = new List<string>();

            for (int i = 0; i < schemaTable.Rows.Count; i++)
            {


                string str = Convert.ToString(schemaTable.Rows[i].ItemArray[2]);
                string[] charsToRemove = new string[] { "$" };
                foreach (string c in charsToRemove)
                {
                    str = str.Replace(c, string.Empty);
                }
                ExcelSheets.Add(str);

            }
            conn.Close();
            if (ExcelSheets.Contains("Cluster"))
            {
                if (rbtnWoman.Checked)
                {
                    OleDbDataAdapter daGlobalPart1 = new OleDbDataAdapter("Select ПІБ,АТС0, АТД0, ЧСС0, АТС1, АТД1, ЧСС1, АТС2, АТД2, ЧСС2, АТС3, АТД3, ЧСС3, АТС4, АТД4, ЧСС4, АТС5, АТД5, ЧСС5 from [Жінки$]", connGlobal);
                    OleDbDataAdapter daGlobalPart2 = new OleDbDataAdapter("Select Cl,Dist,NextCl,NextDist from [Cluster$]", connGlobal);

                    daGlobalPart1.Fill(dtGlobalPart1);
                    countRows = dtGlobalPart1.Rows.Count;
                    countColumns = dtGlobalPart1.Columns.Count;
                    daGlobalPart2.Fill(dtGlobalPart1);
                    for (int i = 0; i < countRows; i++)
                    {
                        dtGlobalPart1.Rows[i][countColumns] = dtGlobalPart1.Rows[countRows + i][countColumns];
                        dtGlobalPart1.Rows[i][countColumns + 1] = dtGlobalPart1.Rows[countRows + i][countColumns + 1];
                        dtGlobalPart1.Rows[i][countColumns + 2] = dtGlobalPart1.Rows[countRows + i][countColumns + 2];
                        dtGlobalPart1.Rows[i][countColumns + 3] = dtGlobalPart1.Rows[countRows + i][countColumns + 3];
                        dtGlobalPart1.Rows[countRows + i].Delete();
                    }
                    dataGridViewGlobal.AllowUserToAddRows = false;
                    dataGridViewGlobal.DataSource = dtGlobalPart1;
                }
                else if (rbtnMan.Checked)
                {
                    OleDbDataAdapter daGlobalPart1 = new OleDbDataAdapter("Select ПІБ,АТС0, АТД0, ЧСС0, АТС1, АТД1, ЧСС1, АТС2, АТД2, ЧСС2, АТС3, АТД3, ЧСС3, АТС4, АТД4, ЧСС4, АТС5, АТД5, ЧСС5 from [Чоловіки$]", connGlobal);
                    OleDbDataAdapter daGlobalPart2 = new OleDbDataAdapter("Select Cl,Dist,NextCl,NextDist from [Cluster$]", connGlobal);

                    daGlobalPart1.Fill(dtGlobalPart1);
                    countRows = dtGlobalPart1.Rows.Count;
                    countColumns = dtGlobalPart1.Columns.Count;
                    daGlobalPart2.Fill(dtGlobalPart1);
                    for (int i = 0; i < countRows; i++)
                    {
                        dtGlobalPart1.Rows[i][countColumns] = dtGlobalPart1.Rows[countRows + i][countColumns];
                        dtGlobalPart1.Rows[i][countColumns + 1] = dtGlobalPart1.Rows[countRows + i][countColumns + 1];
                        dtGlobalPart1.Rows[i][countColumns + 2] = dtGlobalPart1.Rows[countRows + i][countColumns + 2];
                        dtGlobalPart1.Rows[i][countColumns + 3] = dtGlobalPart1.Rows[countRows + i][countColumns + 3];
                        dtGlobalPart1.Rows[countRows + i].Delete();
                    }
                    dataGridViewGlobal.AllowUserToAddRows = false;
                    dataGridViewGlobal.DataSource = dtGlobalPart1;
                }
            }
            else
            {
                MessageBox.Show("Таблиця не містить листа Cluster.\nЗапустіть дослідження для створення таблиці");
            }


        }

        private void rbtCl4_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void rbtCl8_CheckedChanged(object sender, EventArgs e)
        {

            Check();
            //Console.WriteLine("ButtonCheck " + ClWoman);
        }

        private void GlobalWindow_Load(object sender, EventArgs e)
        {

            Check();
            //Console.WriteLine("LoadForm " + ClWoman);
        }

        private void Check()
        {

            if (rbtCl8.Checked)
            {
                TextPath.path = path = Environment.CurrentDirectory + "/Table/ResultTable.xls";
                TextPath.ClMan = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7";
                TextPath.ClWoman = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7,Cl8";
                Console.WriteLine("cl8");
            }
            else if (rbtCl4.Checked)
            {
                TextPath.path = path = Environment.CurrentDirectory + "/Table/ResultTableCl5.xls";
                TextPath.ClMan = "Parametr,Cl1,Cl2,Cl3,Cl4, Cl5";
                TextPath.ClWoman = "Parametr,Cl1,Cl2,Cl3,Cl4,Cl5";
                Console.WriteLine("cl4");
            }
        }

        private void rbtnWoman_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnWoman.Checked)
            {
                TextPath.SexCheck = false;
            }
            else
            {
                TextPath.SexCheck = true;
            }
        }



        private void UniversalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniversalWindowCl universalWindow = new UniversalWindowCl();
            universalWindow.Show();
            Hide();

        }
    }
}
