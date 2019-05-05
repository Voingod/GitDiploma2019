#define ConsoleWriteline

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;


namespace ClusterBox
{
    public partial class CuclClusterChange : Form
    {
        public CuclClusterChange()
        {
            InitializeComponent();
            numUpCl.Enabled = false;
            numUpVec.Enabled = false;
            btnCountInCl.Enabled = false;
            btnCL.Enabled = false;
            textBoxFindStudent.Enabled = false;
        }

        DataTable dt;//Создание таблицы для dataGridView, чтобы записать в нее значения
        OleDbDataAdapter da;
        int max_cluster = 0;

        void DataGridViewTable(OleDbDataAdapter da)
        {
            dt = new DataTable("Read");
            da.Fill(dt);
            dataGridViewRead.AllowUserToAddRows = false;
            dataGridViewRead.DataSource = dt;

            List<int> clusterCount = new List<int>(dt.Rows.Count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Cl"].ToString() != "")
                {
                    clusterCount.Add(Convert.ToInt32(dt.Rows[i]["Cl"].ToString()));
                }
            }
            clusterCount.Sort();
            clusterCount.Reverse();
            max_cluster = clusterCount[0];

#if ConsoleWriteline

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i]["Cl"]);
                Console.WriteLine(max_cluster);
            }
            for (int i = 0; i < clusterCount.Count; i++)
            {
                Console.WriteLine("--" + clusterCount[i]);
            }



#endif
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtBoxPath.Text == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtBoxPath.Text = ofd.FileName;
                }
            }

            #region
            try
            {
                string path = txtBoxPath.Text;


                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                OleDbConnection conn = new OleDbConnection(stringcoon);
                if (rbtWoman.Checked)
                {
                    da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТС1, АТС2, АТС3, АТС4, АТС5," +
                        "АТД0, АТД1, АТД2, АТД3, АТД4, АТД5," +
                        "ЧСС0, ЧСС1, ЧСС2, ЧСС3, ЧСС4, ЧСС5, " +
                        "Cl,Dist,NextCl,NextDist from[" + rbtWoman.Text + "$]", conn);

                    DataGridViewTable(da);

                }
                else if (rbtMan.Checked)
                {
                    da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТС1, АТС2, АТС3, АТС4, АТС5," +
                        "АТД0, АТД1, АТД2, АТД3, АТД4, АТД5," +
                        "ЧСС0, ЧСС1, ЧСС2, ЧСС3, ЧСС4, ЧСС5," +
                        "АТР1, АТР2, АТР3, " +
                        "Cl,Dist,NextCl,NextDist from[" + rbtMan.Text + "$]", conn);
                    DataGridViewTable(da);
                }
                numUpCl.Enabled = true;
                numUpVec.Enabled = true;
                textBoxFindStudent.Enabled = true;

            }
            #endregion

            #region
            catch (OleDbException ex)
            {
                string exeption = ex.Message;
                Console.WriteLine(exeption);
                if (exeption.Contains("0x80004005") || exeption.Contains("Ошибочный аргумент."))
                {
                    MessageBox.Show("За даним шляхом таблиці не знайдено");
                }
                else if (exeption.Contains("Недопустимое имя"))
                {
                    if (rbtMan.Checked)
                    {
                        MessageBox.Show("Таблиця не містить листа " + rbtMan.Text);
                    }
                    else if (rbtWoman.Checked)
                    {
                        MessageBox.Show("Таблиця не містить листа " + rbtWoman.Text);
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
            catch (InvalidOperationException)
            {
                MessageBox.Show("Встановіть додаток \"AccessDatabaseEngine\"\n з папки \"Додаток\"");
            }
            #endregion
        }
        void DeleteColumns()
        {
            string[] parametrs = new string[] { "№", "АТС0", "АТС4", "АТС5", "АТД0", "АТД4", "АТД5", "ЧСС0", "ЧСС4", "ЧСС5" };

            for (int i = 0; i < dataGridViewDist.Columns.Count; i++)
            {
                for (int j = 0; j < parametrs.Length; j++)
                {
                    if (dataGridViewDist.Columns[i].HeaderText == parametrs[j])
                    {

                        dataGridViewDist.Columns.RemoveAt(i);
                    }
                }
            }
        }

        void Filter()
        {
            btnCL.Enabled = true;
            btnCountInCl.Enabled = true;

            DataView dv = new DataView(dt);//Создание новой таблицы

            string filter = string.Format("Cl = '{0}'", numUpCl.Value);
            string filter2 = string.Format("AND NextCl = '{0}'", numUpVec.Value);

            string filter3 = string.Format("OR Cl = '{0}'", numUpVec.Value);
            string filter4 = string.Format("AND NextCl = '{0}'", numUpCl.Value);

            dv.RowFilter = filter + filter2 + filter3 + filter4;//Поиск в столбце ПІБ по значению, введенному в textBox1
            dataGridViewDist.DataSource = dv.ToTable();//Заполнение таблицы
            DeleteColumns();
            for (int i = 0; i < dataGridViewDist.Columns.Count; i++)
            {
                string columnName = dataGridViewDist.Columns[i].HeaderText;
                if (columnName == "Dist"|| columnName == "NextDist" || columnName == "ПІБ")
                {
                    if(columnName == "Dist")
                        dataGridViewDist.Columns[i].Width = 60;
                    else if (columnName == "NextDist")
                        dataGridViewDist.Columns[i].Width = 60;


#if ConsoleWriteline
                    Console.WriteLine(true);
                    Console.WriteLine(columnName + " Cl");
#endif
                  
                }
                else
                {
                    dataGridViewDist.Columns[i].Width = 39;
#if ConsoleWriteline
                    Console.WriteLine(false);
#endif
                }

            }
        }

        private void numUpCl_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Filter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void numUpVec_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Filter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnCL_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewMatrixCl.Rows.Clear();

                dataGridViewMatrixCl.ColumnCount = max_cluster;
                dataGridViewMatrixCl.RowCount = max_cluster;
                dataGridViewMatrixCl.TopLeftHeaderCell.Value = "Cl.Down";

                for (int i = 0; i < max_cluster; i++)
                {
                    dataGridViewMatrixCl.Columns[i].Width = 20;
                    dataGridViewMatrixCl.Rows[i].Height = 20;
                    dataGridViewMatrixCl.Columns[i].HeaderText = Convert.ToString(i + 1);
                    dataGridViewMatrixCl.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");
                    for (int j = i + 1; j < max_cluster; j++)
                    {
                        string filter = string.Format("Cl = '{0}'", i + 1);
                        string filter2 = string.Format("AND NextCl = '{0}'", j + 1);

                        string filter3 = string.Format("Cl = '{0}'", j + 1);
                        string filter4 = string.Format("AND NextCl = '{0}'", i + 1);


                        DataView MyDataView = new DataView(dt);
                        MyDataView.RowFilter = filter + filter2;//Поиск в столбце ПІБ по значению, введенному в textBox1
                        dataGridViewRead.DataSource = MyDataView.ToTable();//Заполнение таблицы
                                                                           //Console.WriteLine(i + " " + j + " " + dataGridViewRead.RowCount);

                        dataGridViewMatrixCl[i, j].Value = dataGridViewRead.RowCount;

                        MyDataView.RowFilter = filter3 + filter4;
                        dataGridViewRead.DataSource = MyDataView.ToTable();//Заполнение таблицы
                                                                           // Console.WriteLine(j+" "+i+" "+dataGridViewRead.RowCount);

                        dataGridViewMatrixCl[j, i].Value = dataGridViewRead.RowCount;
                    }
                }

                DataGridViewTable(da);
                ChangeCl(dataGridViewCountClChange, dataGridViewMatrixCl);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void ChangeCl(DataGridView gridView, DataGridView gridViewBase)
        {
            gridView.Rows.Clear();

            gridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            gridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            int k = 0;

            for (int i = 0; i < max_cluster; i++)
            {

                for (int j = 0; j < max_cluster; j++)
                {
                    if (Convert.ToString(gridViewBase[j, i].Value) != "0" && (gridViewBase[j, i].Value != null))
                    {
                        gridView.Rows.Add();
                        gridView[0, k].Value = i + 1;
                        gridView[1, k].Value = "->";
                        gridView[2, k].Value = j + 1 + "    = ";
                        gridView[3, k].Value = gridViewBase[j, i].Value;
                        k++;
                    }

#if ConsoleWriteline
                    //    Console.WriteLine(k + "->" + j + " " + dataGridViewMatrixCl[j, k].Value);
                    Console.WriteLine(i + "*" + j + "=" + i * j);
#endif

                }
            }
        }

        //Считает колличество переходов из класстера в Cl. Был студент в 1 кластере, по метке шел во второй, если перешел, тогда +1
        private void btnCountInCl_Click(object sender, EventArgs e)
        {
            // VisualFormatTable();
            try
            {
                dataGridViewCountInCl.Rows.Clear();
                dataGridViewCountInCl.ColumnCount = max_cluster;
                dataGridViewCountInCl.RowCount = max_cluster;
                dataGridViewCountInCl.TopLeftHeaderCell.Value = "Cl.Down";

                for (int i = 0; i < max_cluster; i++)
                {
                    dataGridViewCountInCl.Columns[i].Width = 20;
                    dataGridViewCountInCl.Rows[i].Height = 20;
                    dataGridViewCountInCl.Columns[i].HeaderText = Convert.ToString(i + 1);
                    dataGridViewCountInCl.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");

                }

                int[,] ClCount = new int[max_cluster, max_cluster];
                List<string> Surname = new List<string>();
                List<string> SurnameUpper = new List<string>(); //Для того, чтобы регистр не учитывался и не было одинаковых студентов
                for (int i = 0; i < dataGridViewRead.RowCount - 1; i++)
                {
                    if (SurnameUpper.Contains(dataGridViewRead[1, i].Value.ToString().ToUpper()) == false)// если эл-т не содержится в списке, то добавить его (список фамилий студентов)
                    {
                        SurnameUpper.Add(dataGridViewRead[1, i].Value.ToString().ToUpper());
                        Surname.Add(dataGridViewRead[1, i].Value.ToString());
                    }
                }

#if ConsoleWriteline

            for (int i=0; i<Surname.Count;i++)
            {
                Console.WriteLine(Surname[i]);
            }
#endif

                int ClusterVecCount = 0;
                DataView dvSurname = new DataView(dt);//Создание новой таблицы
                DataTable dtSurname = new DataTable();
                for (int i = 0; i < Surname.Count; i++)
                {
                    string surname = string.Format("ПІБ = '{0}'", Surname[i]);
                    dvSurname.RowFilter = surname;
                    dtSurname = dvSurname.ToTable();
                    int num = dvSurname.ToTable().Rows.Count;
#if ConsoleWriteline
                Console.WriteLine(dtSurname.Columns.Count);
                Console.WriteLine(num);
#endif
                    for (int j = 0; j < num; j++)
                    {
                        if ((j + 1) < num)
                        {
                            if ((dtSurname.Rows[j]["NextCl"].ToString() == dtSurname.Rows[j + 1]["Cl"].ToString()))

                            {
                                ClusterVecCount++;
                                ClCount[Convert.ToInt32(dtSurname.Rows[j]["Cl"].ToString()) - 1, Convert.ToInt32(dtSurname.Rows[j]["NextCl"].ToString()) - 1] += 1;
                            }
                        }
                    }
                }
                for (int i = 0; i < max_cluster; i++)
                {
                    for (int j = 0; j < max_cluster; j++)
                    {
                        Console.Write(ClCount[i, j] + " ");

                        dataGridViewCountInCl[i, j].Value = ClCount[i, j];
                        dataGridViewCountInCl[j, i].Value = ClCount[j, i];
                    }
                    Console.WriteLine();
                }
                ChangeCl(dataGridViewCountChangeTrue, dataGridViewCountInCl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
            }
        }


//Интерфейс
#region
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void btnCleanRead_Click(object sender, EventArgs e)
        {
            textBoxFindStudent.Text = "";
            textBoxFindStudent.Enabled = false;
            dataGridViewRead.DataSource = new object();
            dataGridViewMatrixCl.Rows.Clear();
        
            dataGridViewDist.DataSource = new object();
         
            dataGridViewCountInCl.Rows.Clear();
       
            

            numUpCl.Enabled = false;
            numUpVec.Enabled = false;
            btnCountInCl.Enabled = false;
            btnCL.Enabled = false;
            btnCountInCl.Enabled = false;

        }

        private void btnCleanCL_M_Click(object sender, EventArgs e)
        {
            textBoxFindStudent.Text = "";
            textBoxFindStudent.Enabled = false;
            dataGridViewDist.DataSource = new object();
            dataGridViewMatrixCl.Rows.Clear();
            dataGridViewCountInCl.Rows.Clear();
            btnCL.Enabled = false;
            btnCountInCl.Enabled = false;

        }

        private void btnCleanCL_CL_Click(object sender, EventArgs e)
        {
  
            dataGridViewCountInCl.Rows.Clear();
            btnCountInCl.Enabled = false;

           
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

        private void RegressionWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            WindowController.ExitIfNoWindow();
        }
        #endregion

        private void dataGridViewCountClChange_MouseEnter(object sender, EventArgs e)
        {
          //  dataGridViewCountClChange.BackgroundColor = System.Drawing.Color.YellowGreen;

#if ConsoleWriteline
            Console.WriteLine("Go");
#endif
        }

        private void dataGridViewCountClChange_MouseLeave(object sender, EventArgs e)
        {
         //   dataGridViewCountClChange.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
        }

        private void CuclClusterChange_Load(object sender, EventArgs e)
        {
#if ConsoleWriteline
            Console.WriteLine("Hm");
#endif

            //TipForDataGridViewCountChangeCl.SetToolTip(dataGridViewCountClChange, "Завантажте дані до таблиці кількості переходів клас-тер мітка і натисніть на цей блок");

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
            for (int i = 0; i < dataGridViewDist.Columns.Count; i++)
            {
                findstudent.Add(dataGridViewDist.Columns[i].HeaderText);
            }
            if (findstudent.Contains("ПІБ"))
            {
                DataView dv = new DataView(dt);//Создание новой таблицы
                dv.RowFilter = string.Format("ПІБ like '%{0}%'", textBoxFindStudent.Text);//Поиск в столбце ПІБ по значению, введенному в textBox1
                dataGridViewDist.DataSource = dv.ToTable();//Заполнение таблицы
            }
            DeleteColumns();


        }
    }

}
