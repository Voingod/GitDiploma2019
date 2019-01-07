using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using CalculateRadius;

namespace ClusterVector
{
    public partial class VectorFormStart : Form
    {
        public VectorFormStart()
        {
            InitializeComponent();
            numUpCl.Enabled = false;
            numUpVec.Enabled = false;
            btnCountInCl.Enabled = false;
            btnCL.Enabled = false;
            btnGraf.Enabled = false;
            textBox1.Enabled = false;
            btnCount.Enabled = false;
        }

        
        DataTable dt;//Создание таблицы для dataGridView, чтобы записать в нее значения
        OleDbDataAdapter da;
        int count = 0;
        int k = 0;
        int k2 = 0;
        int kInFind = 0;
        int countForRegress = 0;
        int countForParam = 0;
        string title = "";
        string namechart="";

        double[] radiusCl = new double[8];

        

        string [] ArrayFilterdataGridViewDist(int j, int count)//метод для выбора из списка, отсортированного по кластер-метка, значений АТС, ЧСС, АТР для расчета ур-я регрессии
        {
            string[] filter = new string[] {dataGridViewDist[13, j].Value.ToString(), dataGridViewDist[1 + count, j].Value.ToString(), dataGridViewDist[2 + count, j].Value.ToString(), dataGridViewDist[3 + count, j].Value.ToString(),
            dataGridViewDist[7, j].Value.ToString(),dataGridViewDist[8, j].Value.ToString(),dataGridViewDist[9, j].Value.ToString()};
            return filter;
        }

        string[] ArrayFilterdataGridViewDistCl(int j, int count)//метод для выбора из списка, отсортированного по кластер-метка, значений АТС, ЧСС, АТР для расчета ур-я регрессии
        {
            string[] filter = new string[] {dataGridViewCl_Cl[13, j].Value.ToString(), dataGridViewCl_Cl[1 + count, j].Value.ToString(), dataGridViewCl_Cl[2 + count, j].Value.ToString(), dataGridViewCl_Cl[3 + count, j].Value.ToString(),
            dataGridViewCl_Cl[7, j].Value.ToString(),dataGridViewCl_Cl[8, j].Value.ToString(),dataGridViewCl_Cl[9, j].Value.ToString()};
            return filter;
        }

        //  string[] test = new string[] { dataGridViewDist[1 + 0, 0].Value.ToString() };
       // string[] filterCl = new string[] { };

        void DataGridViewTable(OleDbDataAdapter da)
        {
            dt = new DataTable("Read");
            da.Fill(dt);
            dataGridViewRead.AllowUserToAddRows = false;
            dataGridViewRead.DataSource = dt;
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


            //if (!Directory.Exists(Environment.CurrentDirectory + "/Table"))
            //{
            //    DirectoryInfo di = Directory.CreateDirectory(Environment.CurrentDirectory + "/Table");
            //}

            //if (!File.Exists(Environment.CurrentDirectory + "/Table/ForDisertation.xlsx"))
            //{
            //    string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            //    Assembly currentAssembly = Assembly.GetExecutingAssembly();
            //    Stream stream = currentAssembly.GetManifestResourceStream("ClusterVector.ForDisertation.xlsx");
            //    byte[] bytes = new byte[stream.Length];
            //    stream.Read(bytes, 0, bytes.Length);
            //    stream.Close();
            //    using (FileStream fs = new FileStream(Environment.CurrentDirectory + "/Table/ForDisertation.xlsx", FileMode.Create, FileAccess.Write))
            //    {
            //        fs.Write(bytes, 0, bytes.Length);
            //        fs.Close();
            //    }
            //}

            try
            {
                string path = txtBoxPath.Text;
                string pathResultTable = "";
                if(rbtCl4.Checked)
                {
                    pathResultTable = Environment.CurrentDirectory + "/Table/ResultTableCl5.xls";
                }
                else if(rbtCl8.Checked)
                {
                    pathResultTable = Environment.CurrentDirectory + "/Table/ResultTable.xls";
                }
                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                OleDbConnection conn = new OleDbConnection(stringcoon);
                if (rbtWoman.Checked)
                {
                    
                   // = new double[] { 18.22, 21.79, 17.30, 23.25, 17.57, 20.42, 16.43, 18.82 };
                    radiusCl= RadiusCL.Radius(pathResultTable, "CL1, CL2, CL3, CL4, CL5, CL6, CL7, CL8", rbtWoman.Text);

                    da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТС1, АТС2, АТС3, АТС4, АТС5," +
                        "АТД0, АТД1, АТД2, АТД3, АТД4, АТД5," +
                        "ЧСС0, ЧСС1, ЧСС2, ЧСС3, ЧСС4, ЧСС5, " +
                        "АТР1, АТР2, АТР3, " +
                        "Кластер,Метка,Расстояние,РасстояниеМ from[" + rbtWoman.Text + "$]", conn);

                    DataGridViewTable(da);

                }
                else if (rbtMan.Checked)
                {
                    radiusCl = RadiusCL.Radius(pathResultTable, "CL1, CL2, CL3, CL4, CL5, CL6, CL7", rbtMan.Text);

                    // radiusCl = new double[] {25.21, 19.56, 19.32, 27.09, 28.24, 22.81, 22.72};

                    //da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТД0, ЧСС0, АТС1, АТД1, ЧСС1, АТС2, АТД2, ЧСС2, АТС3, АТД3, ЧСС3, АТС4, АТД4, ЧСС4, АТС5, АТД5, ЧСС5, Кластер, Метка, Расстояние, РасстояниеМ from[" + rbtMan.Text + "$]", conn);
                    da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТС1, АТС2, АТС3, АТС4, АТС5," +
                        "АТД0, АТД1, АТД2, АТД3, АТД4, АТД5," +
                        "ЧСС0, ЧСС1, ЧСС2, ЧСС3, ЧСС4, ЧСС5," +
                        "АТР1, АТР2, АТР3, " +
                        "Кластер,Метка,Расстояние,РасстояниеМ from[" + rbtMan.Text + "$]", conn);
                    DataGridViewTable(da);
                }
                numUpCl.Enabled = true;
                numUpVec.Enabled = true;
                textBox1.Enabled = true;
                btnCount.Enabled = true;
            }

            catch (OleDbException ex)
            {
                string exeption = ex.Message;
                Console.WriteLine(exeption);
                if (exeption.Contains("0x80004005")|| exeption.Contains("Ошибочный аргумент."))
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
        }

        void Filter()
        {
            btnCL.Enabled = true;
            btnGraf.Enabled = true;

            DataView dv = new DataView(dt);//Создание новой таблицы

            string filter = string.Format("Кластер = '{0}'", numUpCl.Value);
            string filter2 = string.Format("AND Метка = '{0}'", numUpVec.Value);

            string filter3 = string.Format("OR Кластер = '{0}'", numUpVec.Value);
            string filter4 = string.Format("AND Метка = '{0}'", numUpCl.Value);

            dv.RowFilter = filter + filter2 + filter3 + filter4;//Поиск в столбце ПІБ по значению, введенному в textBox1
            dataGridViewDist.DataSource = dv.ToTable();//Заполнение таблицы


            dataGridViewDist.Columns.Remove("№");//Удаление столбца
            dataGridViewDist.Columns.Remove("АТС0");
            dataGridViewDist.Columns.Remove("АТС4");
            dataGridViewDist.Columns.Remove("АТС5");
            dataGridViewDist.Columns.Remove("АТД0");
            dataGridViewDist.Columns.Remove("АТД4");
            dataGridViewDist.Columns.Remove("АТД5");
            dataGridViewDist.Columns.Remove("ЧСС0");
            dataGridViewDist.Columns.Remove("ЧСС4");
            dataGridViewDist.Columns.Remove("ЧСС5");

            for (int i = 1; i < dataGridViewDist.Columns.Count-2; i++)
            {
                dataGridViewDist.Columns[i].Width = 39;
            }
            dataGridViewDist.Columns[15].Width = 55;
            dataGridViewDist.Columns[16].Width = 55;
            dataGridViewDist.Columns[13].HeaderText = "Кл.";
            dataGridViewDist.Columns[14].HeaderText = "М";
            dataGridViewDist.Columns[15].HeaderText = "Раст.";
            dataGridViewDist.Columns[16].HeaderText = "РастМ";
        }

        void FilterCl()
        {
            btnCountInCl.Enabled = true;
            btnGraf.Enabled = true;

            DataView dv = new DataView(dt);//Создание новой таблицы

            string filter = string.Format("Кластер = '{0}'", numUpCl.Value);
            string filter2 = string.Format("OR Кластер = '{0}'", numUpVec.Value);



            dv.RowFilter = filter + filter2;//Поиск в столбце ПІБ по значению, введенному в textBox1
            dataGridViewCl_Cl.DataSource = dv.ToTable();//Заполнение таблицы


            dataGridViewCl_Cl.Columns.Remove("№");//Удаление столбца
            dataGridViewCl_Cl.Columns.Remove("АТС0");
            dataGridViewCl_Cl.Columns.Remove("АТС4");
            dataGridViewCl_Cl.Columns.Remove("АТС5");
            dataGridViewCl_Cl.Columns.Remove("АТД0");
            dataGridViewCl_Cl.Columns.Remove("АТД4");
            dataGridViewCl_Cl.Columns.Remove("АТД5");
            dataGridViewCl_Cl.Columns.Remove("ЧСС0");
            dataGridViewCl_Cl.Columns.Remove("ЧСС4");
            dataGridViewCl_Cl.Columns.Remove("ЧСС5");

            for (int i = 1; i < dataGridViewCl_Cl.Columns.Count - 2; i++)
            {
                dataGridViewCl_Cl.Columns[i].Width = 39;
            }
            dataGridViewCl_Cl.Columns[15].Width = 55;
            dataGridViewCl_Cl.Columns[16].Width = 55;
            dataGridViewCl_Cl.Columns[13].HeaderText = "Кл.";
            dataGridViewCl_Cl.Columns[14].HeaderText = "М";
            dataGridViewCl_Cl.Columns[15].HeaderText = "Раст.";
            dataGridViewCl_Cl.Columns[16].HeaderText = "РастМ";
        }

        void FilterClCount(int k, int z)
        {
            //DataView dv = new DataView(dt);//Создание новой таблицы
   
            //string filter = string.Format("Кластер = '{0}'", z);
            //string filter2 = string.Format("AND Метка = '{0}'", k);


            //dv.RowFilter = filter+ filter2;
            //dataGridViewCl_Cl.DataSource = dv.ToTable();//Заполнение таблицы

            string filter = string.Format("Кластер = '{0}'", k+1);
            string filter2 = string.Format("AND Метка = '{0}'", z+1);

            string filter3 = string.Format("Кластер = '{0}'", z + 1);
            string filter4 = string.Format("AND Метка = '{0}'", k + 1);


            DataView MyDataView = new DataView(dt);
            MyDataView.RowFilter = filter + filter2;//Поиск в столбце ПІБ по значению, введенному в textBox1
            dataGridViewRead.DataSource = MyDataView.ToTable();//Заполнение таблицы
                                                               //Console.WriteLine(i + " " + j + " " + dataGridViewRead.RowCount);
            //MyDataView.RowFilter = filter3 + filter4;
            //dataGridViewRead.DataSource = MyDataView.ToTable();//Заполнение таблицы
            //                                                   // Console.WriteLine(j+" "+i+" "+dataGridViewRead.RowCount);

            List<string> Surname = new List<string>();

            int ClusterVecCount = 0;
            //int CountInCL; lblCountInCL

            for (int i = 0; i < dataGridViewRead.RowCount - 1; i++)
            {
                if (Surname.Contains(dataGridViewRead[1, i].Value.ToString()) == false)// если эл-т не содержится в списке, то добавить его (список фамилий студентов)
                {
                    Surname.Add(dataGridViewRead[1, i].Value.ToString());
                }
            }
            //Console.WriteLine(Surname.Count+"+++++++");
            DataView dvSurname = new DataView(dt);//Создание новой таблицы
            DataTable dtSurname = new DataTable();

            for (int i = 0; i < Surname.Count; i++)
            {
                string surname = string.Format("ПІБ = '{0}'", Surname[i]);
                dvSurname.RowFilter = surname;
                dtSurname = dvSurname.ToTable();
                int num = dvSurname.ToTable().Rows.Count;

                Console.WriteLine(Surname[i]);

                Console.WriteLine(num);


                for (int j = 0; j < num; j++)
                {
                    if ((j + 1) < num)
                    {
                        if ((dtSurname.Rows[j][24].ToString() == dtSurname.Rows[j + 1][23].ToString()))

                        {
                            ClusterVecCount++;
                           // CountInCL ++;
                            Console.WriteLine("-----" + ClusterVecCount + "----");
                        }
                    }
                }
            }
            dataGridViewCountInCl[k, z].Value = ClusterVecCount;
            //Console.WriteLine("-----"+ClusterVecCount+"----");
        }

        private void numUpCl_ValueChanged(object sender, EventArgs e)
        {
            countForParam = 0;
            k = 0;
            btnGraf.Text = "График АТС";
            if(checkBox1.Checked)
            {
                FilterCl();
            }
            else
            {
                Filter();
            }
           // VisualFormatTable();
        }

        private void numUpVec_ValueChanged(object sender, EventArgs e)
        {
            countForParam = 0;
            k = 0;
            btnGraf.Text = "График АТС";
            if (checkBox1.Checked)
            {
                FilterCl();
            }
            else
            {
                Filter();
            }
            //VisualFormatTable();
        }

        private void dataGridViewMatrixCl_Click(object sender, EventArgs e)
        {
            lbli.Text = Convert.ToString(dataGridViewMatrixCl.CurrentCellAddress.X+1);
            lblj.Text = Convert.ToString(dataGridViewMatrixCl.CurrentCellAddress.Y+1);
            lbli1.Text = lblj.Text;
            lblj1.Text = lbli.Text;

            lblCount.Text= Convert.ToString(Convert.ToInt32((dataGridViewMatrixCl[dataGridViewMatrixCl.CurrentCellAddress.X, dataGridViewMatrixCl.CurrentCellAddress.Y].Value))
                + Convert.ToInt32((dataGridViewMatrixCl[dataGridViewMatrixCl.CurrentCellAddress.Y, dataGridViewMatrixCl.CurrentCellAddress.X].Value)));
        }

        void ClusertTest(List<int> ParametrsData, List<int> ArrayMinutes, out double[] ParametrsDataAfter, out string regress, out string CoefDetermin)
        {
            ParametrsDataAfter = new double[ParametrsData.Count];//Массив значений, расчитаного по уравнению регрессии
            CoefDetermin = "";
            regress = "";
            double SumMinute = 0;//Сумма минут
            double SumParametr = 0;//Сумма значений параметра (ЧСС/АТС/АТД)
            double SumMinutesQuare = 0;//Сумма квадратов по минутах
            double SumMinuteONSumParametr = 0;//Сумма произвидений параметра на минуту
            double determinate = 0;
            double Summ = 0;//Сумма квадрата разницы между парметром из таблицы и параметром, расчитанным по уравнению регресии
            double SumByTable = 0;//Сумма параметров из таблциы
            double SummForMiddle = 0;// Сумма квадрата разницы между парметром из таблицы и их средним значением

            //Уравнение линейной регрессии: y=ax+b
            double a = 0;
            double b = 0;
            char omega = '\u00B2';//Юникод степени двойки (надстрочная двойка)



            for (int i = 0; i < ParametrsData.Count; i++)
            {
               // chrtForAll.Series["Parametr"].Points.AddXY(ArrayMinutes[i], ParametrsData[i]);//Рисуем график зависимости параметра от минуты
                //Расчет параметров по методу наименьших квадратов, систему решаем методом Гаусса
                SumParametr += ParametrsData[i];
                SumMinute += ArrayMinutes[i];
                SumMinutesQuare += Math.Pow(ArrayMinutes[i], 2);
                SumMinuteONSumParametr += ParametrsData[i] * ArrayMinutes[i];
            }
            Console.WriteLine("SumMinutesQuare: " + SumMinutesQuare + " ParametrsData.Count: " + ParametrsData.Count + " SumMinute: "+ SumMinute);
            determinate = SumMinutesQuare * ParametrsData.Count - SumMinute * SumMinute;// ParametrsData.Count - колличество столбцов в массивах ParametrsData и ArrayMinutes.
            if (determinate != 0)
            {
                a = (SumMinuteONSumParametr * ParametrsData.Count - SumParametr * SumMinute) / determinate;
                b = (SumMinutesQuare * SumParametr - SumMinuteONSumParametr * SumMinute) / determinate;
                //----------------------//Построение линии тренда с расчетом коэффициента детерминации 
                for (int i = 0; i < ParametrsData.Count; i++)
                {
                    SumByTable += ParametrsData[i];
                }
                for (int i = 0; i < ParametrsData.Count; i++)
                {
                    ParametrsDataAfter[i] = a * ArrayMinutes[i] + b;
                    Summ += Math.Pow((ParametrsData[i] - ParametrsDataAfter[i]), 2);
                    SummForMiddle += Math.Pow((ParametrsData[i] - (SumByTable / ParametrsData.Count)), 2);
                }
                CoefDetermin = "R" + omega + " =" + Math.Round((1 - Summ / SummForMiddle), 4);//Вывод коэффициента детерминации 

                //for (int i = 0; i < ParametrsDataAfter.Length; i++)
                //{
                //    chrtForAll.Series["RegressLine"].Points.AddXY(ArrayMinutes[i], ParametrsDataAfter[i]);

                //}

                //---------------------//Построение линии тренда с расчетом коэффициента детерминации 

                if (b >= 0) { regress = "y=" + Math.Round(a, 4) + "x+" + Math.Round(b, 2); }
                else { regress = "y=" + Math.Round(a, 4) + "x" + Math.Round(b, 2); }

                if(countForRegress==0)
                {
                    CoefDatabase(Convert.ToInt32(numUpCl.Value), Convert.ToInt32(numUpVec.Value), a, b);
                    countForRegress++;
                }
                else
                {
                    CoefDatabase(Convert.ToInt32(numUpVec.Value), Convert.ToInt32(numUpCl.Value), a, b);
                    countForRegress = 0;

                }
               
                //count++;
                //if (count <= dataGridViewDist.Rows.Count)
                //{
                //    dataGridViewCoeff.Rows.Add(dataGridViewDist.CurrentRow.Index, lbCluster.Text, Math.Round(a, 4), Math.Round(b, 2));
                //}

            }
            else
            {
               // MessageBox.Show("Система имеет больше одного решения");
            }
        }

        void MethodMinQuare(int count)
        {

           // int[] ParametrsData = new int[] { Convert.ToInt32(dataGridViewDist[1 + count, dataGridViewDist.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewDist[2 + count, dataGridViewDist.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewDist[3 + count, dataGridViewDist.CurrentRow.Index].Value.ToString()) };
            //int[] ArrayMinutes = new int[] { Convert.ToInt32(dataGridViewDist[7, dataGridViewDist.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewDist[8, dataGridViewDist.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewDist[9, dataGridViewDist.CurrentRow.Index].Value.ToString()) };

            List<int> ParametrsData = new List<int>();
            List<int> ArrayMinutes = new List<int>();

            List<int> ParametrsDataM = new List<int>();//Массив для значений метки
            List<int> ArrayMinutesM = new List<int>();

            //string[] filter = ArrayFilterdataGridViewDist(j);
            string[] filter=new string[0];
            int rowcount = 0;
            if (!checkBox1.Checked)
            {
                rowcount = dataGridViewDist.RowCount;
            }
            else
            {
                rowcount = dataGridViewCl_Cl.RowCount;
            }
            for (int j = 0; j < rowcount - 1; j++)
            {
               // Console.WriteLine(j + " " + count);
                if(!checkBox1.Checked)
                {
                    filter = ArrayFilterdataGridViewDist(j, count);
                }
                else
                {
                    filter = ArrayFilterdataGridViewDistCl(j, count);
                }
                
                //if (Convert.ToInt32(dataGridViewDist[13, j].Value.ToString()) == numUpCl.Value)
                //{

                //    ParametrsData.Add(Convert.ToInt32(dataGridViewDist[1 + count, j].Value.ToString()));
                //    ParametrsData.Add(Convert.ToInt32(dataGridViewDist[2 + count, j].Value.ToString()));
                //    ParametrsData.Add(Convert.ToInt32(dataGridViewDist[3 + count, j].Value.ToString()));

                //    ArrayMinutes.Add(Convert.ToInt32(dataGridViewDist[7, j].Value.ToString()));
                //    ArrayMinutes.Add(Convert.ToInt32(dataGridViewDist[8, j].Value.ToString()));
                //    ArrayMinutes.Add(Convert.ToInt32(dataGridViewDist[9, j].Value.ToString()));
                //}
                //else
                //{
                //    ParametrsDataM.Add(Convert.ToInt32(dataGridViewDist[1 + count, j].Value.ToString()));
                //    ParametrsDataM.Add(Convert.ToInt32(dataGridViewDist[2 + count, j].Value.ToString()));
                //    ParametrsDataM.Add(Convert.ToInt32(dataGridViewDist[3 + count, j].Value.ToString()));

                //    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewDist[7, j].Value.ToString()));
                //    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewDist[8, j].Value.ToString()));
                //    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewDist[9, j].Value.ToString()));
                //}

                if (Convert.ToInt32(filter[0]) == numUpCl.Value)
                {

                    ParametrsData.Add(Convert.ToInt32(filter[1]));
                    ParametrsData.Add(Convert.ToInt32(filter[2]));
                    ParametrsData.Add(Convert.ToInt32(filter[3]));

                    ArrayMinutes.Add(Convert.ToInt32(filter[4]));
                    ArrayMinutes.Add(Convert.ToInt32(filter[5]));
                    ArrayMinutes.Add(Convert.ToInt32(filter[6]));
                }
                else
                {

                    ParametrsDataM.Add(Convert.ToInt32(filter[1]));
                    ParametrsDataM.Add(Convert.ToInt32(filter[2]));
                    ParametrsDataM.Add(Convert.ToInt32(filter[3]));

                    ArrayMinutesM.Add(Convert.ToInt32(filter[4]));
                    ArrayMinutesM.Add(Convert.ToInt32(filter[5]));
                    ArrayMinutesM.Add(Convert.ToInt32(filter[6]));
                }

            } //разбиение студентов определенного кластера и метки на две группы

            //for(int i=0;i< ParametrsData.Count;i++)
            //{
            //    Console.WriteLine(ParametrsData[i]);
            //}
            Console.WriteLine("------");
            double[] ParametrsDataAfter;
            string regress;
            string CoefDetermin;
            ClusertTest(ParametrsData, ArrayMinutes, out ParametrsDataAfter, out regress, out CoefDetermin);
            lbRegress.Text = regress;
            lbCoef.Text = CoefDetermin;
            //chrtForAll.Series["Parametr"].Points.Clear();
            //chrtForAll.Series["RegressLine"].Points.Clear();
            //chrtForAll.ChartAreas[0].AxisY.Minimum = ParametrsData.Min() - 5;
            //for (int i = 0; i < ParametrsData.Count; i++)
            //{
            //    chrtForAll.Series["Parametr"].Points.AddXY(ArrayMinutes[i], ParametrsData[i]);//Рисуем график зависимости параметра от минуты
            //    chrtForAll.Series["RegressLine"].Points.AddXY(ArrayMinutes[i], ParametrsDataAfter[i]);
            //}

            chrtRegress.Series["RegressLineCL"].Points.Clear();
            chrtRegress.Series["RegressLineM"].Points.Clear();
            //chrtRegress.ChartAreas[0].AxisY.Minimum = ParametrsData.Min() - 5;
            for (int i = 0; i < ParametrsData.Count; i++)
            {
                chrtRegress.Series["RegressLineCL"].Points.AddXY(ArrayMinutes[i], ParametrsDataAfter[i]);
            }

            ClusertTest(ParametrsDataM, ArrayMinutesM, out ParametrsDataAfter, out regress, out CoefDetermin);
            lbRegressM.Text = regress;
            lbCoefM.Text = CoefDetermin;
            for (int i = 0; i < ParametrsDataM.Count; i++)
            {
                chrtRegress.Series["RegressLineM"].Points.AddXY(ArrayMinutesM[i], ParametrsDataAfter[i]);
            }



            //chrtForAllM.Series["Parametr"].Points.Clear();
            //chrtForAllM.Series["RegressLine"].Points.Clear();
            //chrtForAllM.ChartAreas[0].AxisY.Minimum = ParametrsDataM.Min() - 5;
            //for (int i = 0; i < ParametrsDataM.Count; i++)
            //{
            //    chrtForAllM.Series["Parametr"].Points.AddXY(ArrayMinutesM[i], ParametrsDataM[i]);//Рисуем график зависимости параметра от минуты
            //    chrtForAllM.Series["RegressLine"].Points.AddXY(ArrayMinutesM[i], ParametrsDataAfter[i]);
            //}

        }

        private void btnGraf_Click(object sender, EventArgs e)
        {

            //try
            //{

                if (k == 1)
                {
                    // chrtForAll.ChartAreas[0].AxisY.Title = "АТД";
                    //chrtForAllM.ChartAreas[0].AxisY.Title = "АТД";
                    title = "Графік ліній регресій АТД-ЧСС";
                    namechart = "АТД";
                    count = 3;
                chrtRegress.Titles[0].Text = title;
                }
                else if (k == 2)
                {
                    title = "Графік ліній регресій АТР-ЧСС";
                namechart = "АТР";
                //chrtForAll.ChartAreas[0].AxisY.Title = "АТР";
                //  chrtForAllM.ChartAreas[0].AxisY.Title = "АТР";
                count = 9;
                chrtRegress.Titles[0].Text = title;
            }
                else
                {
                    title = "Графік ліній регресій АТС-ЧСС";
                namechart = "АТС";
                //  chrtForAll.ChartAreas[0].AxisY.Title = "АТС";
                //chrtForAllM.ChartAreas[0].AxisY.Title = "АТC";
                k = 0;
                    count = 0;
                chrtRegress.Titles[0].Text = title;
            }
                MethodMinQuare(count);
                k++;

                btnGraf.Text = (k == 1) ? "Графік АТД" : (k==2) ? "Графік АТР" : "Графік АТС";
            //    btnGrafInd.Text = (k == 1) ? "Графік АТД" : (k == 2) ? "Графік АТР" : "Графік АТС";

          
           
            
            countForParam++;

        //}
        //    catch(InvalidOperationException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        MessageBox.Show("Загрузите данные/еще что-то там из-за чего ошибка");
        //    }
}

        private void btnCL_Click(object sender, EventArgs e)
        {
            dataGridViewMatrixCl.ColumnCount = 8;
            dataGridViewMatrixCl.RowCount = 8;
            dataGridViewMatrixCl.TopLeftHeaderCell.Value = "Clusler";

            for (int i = 0; i < 8; i++)
            {
                dataGridViewMatrixCl.Columns[i].Width = 20;
                dataGridViewMatrixCl.Rows[i].Height = 20;
                dataGridViewMatrixCl.Columns[i].HeaderText = Convert.ToString(i + 1);
                dataGridViewMatrixCl.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");
                for (int j = i + 1; j < 8; j++)
                {
                    string filter = string.Format("Кластер = '{0}'", i + 1);
                    string filter2 = string.Format("AND Метка = '{0}'", j + 1);

                    string filter3 = string.Format("Кластер = '{0}'", j + 1);
                    string filter4 = string.Format("AND Метка = '{0}'", i + 1);


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
        }
        void CoefDatabase(int Cl, int M, double a, double b)
        {
            if(countForParam < 3)
            {
               // Console.WriteLine(title+" "+ Cl+" "+ M+" "+ Math.Round(a, 4)+" "+ Math.Round(b, 2));
                dataGridViewCluster.Rows.Add(namechart, Cl, M, Math.Round(a, 4), Math.Round(b, 2));
            }

        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            List<string> Surname = new List<string>();

            int ClusterVecCount = 0;
            int SurnameCount = 0;
            int CounATS = 0;
            int CountATD = 0;
            int CountSurnameChange = 0;

            for (int i=0;i<dataGridViewRead.RowCount-1;i++)
            {
                if (Surname.Contains(dataGridViewRead[1, i].Value.ToString()) == false)// если эл-т не содержится в списке, то добавить его (список фамилий студентов)
                {
                    Surname.Add(dataGridViewRead[1, i].Value.ToString());
                }
            }

            DataView dvSurname = new DataView(dt);//Создание новой таблицы
            DataTable dtSurname = new DataTable();

            for(int i = 0; i < Surname.Count; i++)
            {
                string surname = string.Format("ПІБ = '{0}'", Surname[i]);
                dvSurname.RowFilter = surname;
                dtSurname = dvSurname.ToTable();
                int num = dvSurname.ToTable().Rows.Count;
                Console.WriteLine(num);
                for(int j=0;j<num;j++)
                {
                    if ((j + 1) < num)
                    {
                        if ((dtSurname.Rows[j][24].ToString() == dtSurname.Rows[j + 1][23].ToString()))
             
                        {
                            ClusterVecCount++;
                        }
                        if(rbtWoman.Checked)
                        {

                            if ((dtSurname.Rows[j][24].ToString() == "1") & (dtSurname.Rows[j + 1][23].ToString()) == "6" ||
                               (dtSurname.Rows[j][24].ToString() == "6") & (dtSurname.Rows[j + 1][23].ToString()) == "1" ||
                                (dtSurname.Rows[j][24].ToString() == "6") & (dtSurname.Rows[j + 1][23].ToString()) == "8" ||
                                (dtSurname.Rows[j][24].ToString() == "8") & (dtSurname.Rows[j + 1][23].ToString()) == "6")
                            {
                                CounATS++;
                            }

                            if ((dtSurname.Rows[j][24].ToString() == "6") & (dtSurname.Rows[j + 1][23].ToString()) == "8" ||
                               (dtSurname.Rows[j][24].ToString() == "8") & (dtSurname.Rows[j + 1][23].ToString()) == "6")
                            {
                                CountATD++;
                            }
                        }
                        else if(rbtMan.Checked)
                        {
                            if ((dtSurname.Rows[j][24].ToString() == "2") & (dtSurname.Rows[j + 1][23].ToString()) == "3" ||
                                (dtSurname.Rows[j][24].ToString() == "3") & (dtSurname.Rows[j + 1][23].ToString()) == "2" ||
                                (dtSurname.Rows[j][24].ToString() == "2") & (dtSurname.Rows[j + 1][23].ToString()) == "7" ||
                                (dtSurname.Rows[j][24].ToString() == "7") & (dtSurname.Rows[j + 1][23].ToString()) == "2")
                            {
                                CounATS++;
                            }

                            if ((dtSurname.Rows[j][24].ToString() == "6") & (dtSurname.Rows[j + 1][23].ToString()) == "1" ||
                               (dtSurname.Rows[j][24].ToString() == "1") & (dtSurname.Rows[j + 1][23].ToString()) == "6")
                            {
                                CountATD++;
                            }
                        }


                        if (dtSurname.Rows[j + 1][23].ToString() != dtSurname.Rows[j][23].ToString())
                        {
                            SurnameCount++;
                        }
                    }
                }
            }

            
            CountSurnameChange = CounATS + CountATD + ClusterVecCount;

            lblCountSurname.Text = (dataGridViewRead.RowCount-1).ToString();
            lblCountChange.Text = SurnameCount.ToString();
            lblCountWithaoutChange.Text = ClusterVecCount.ToString();
               // Convert.ToString((dataGridViewRead.RowCount - 1) - SurnameCount);
            lblCounATS.Text = CounATS.ToString();
            lblCountATD.Text = CountATD.ToString();


            // Console.WriteLine(ClusterVecCount);
            //Console.WriteLine(SurnameCount);


            //for (int i = 0; i < Surname.Count; i++)
            //{
            //    Console.WriteLine(Surname[i]);
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            DataView dv = new DataView(dt);//Создание новой таблицы
            dv.RowFilter = string.Format("ПІБ like '%{0}%'", textBox1.Text);//Поиск в столбце ПІБ по значению, введенному в textBox1
            dataGridViewFind.DataSource = dv.ToTable();//Заполнение таблицы
            dataGridViewFind.Columns.Remove("№");//Удаление столбца
            dataGridViewFind.Columns["АТС1"].Visible = false;//Скрытие столбца
            dataGridViewFind.Columns["АТС2"].Visible = false;
            dataGridViewFind.Columns["АТС3"].Visible = false;
            dataGridViewFind.Columns["АТС4"].Visible = false;
            dataGridViewFind.Columns["АТС5"].Visible = false;
            dataGridViewFind.Columns["АТД1"].Visible = false;
            dataGridViewFind.Columns["АТД2"].Visible = false;
            dataGridViewFind.Columns["АТД3"].Visible = false;
            dataGridViewFind.Columns["АТД4"].Visible = false;
            dataGridViewFind.Columns["АТД5"].Visible = false;
            dataGridViewFind.Columns["ЧСС1"].Visible = false;
            dataGridViewFind.Columns["ЧСС2"].Visible = false;
            dataGridViewFind.Columns["ЧСС3"].Visible = false;
            dataGridViewFind.Columns["ЧСС4"].Visible = false;
            dataGridViewFind.Columns["ЧСС5"].Visible = false;
            dataGridViewFind.Columns["АТР1"].Visible = false;//Скрытие столбца
            dataGridViewFind.Columns["АТР2"].Visible = false;
            dataGridViewFind.Columns["АТР3"].Visible = false;
           
            dataGridViewFind.Columns["АТС0"].Visible = false;
            dataGridViewFind.Columns["АТД0"].Visible = false;
        
            dataGridViewFind.Columns["ЧСС0"].Visible = false;

            
            //dataGridViewFind.Columns["Cl8_APHR"].Visible = false;
        }

        private void btnCountInCl_Click(object sender, EventArgs e)
        {
            // VisualFormatTable();
            int CountInCl = 0;
            dataGridViewCountInCl.ColumnCount = 8;
            dataGridViewCountInCl.RowCount = 8;
            dataGridViewCountInCl.TopLeftHeaderCell.Value = "Clusler";

            for (int i = 0; i < 8; i++)
            {
                dataGridViewCountInCl.Columns[i].Width = 20;
                dataGridViewCountInCl.Rows[i].Height = 20;
                dataGridViewCountInCl.Columns[i].HeaderText = Convert.ToString(i + 1);
                dataGridViewCountInCl.Rows[i].HeaderCell.Value = string.Format((i + 1).ToString(), "0");
                for (int j = i + 1; j < 8; j++)
                {
                    FilterClCount(i, j);
                    CountInCl += Convert.ToInt32(dataGridViewCountInCl[i, j].Value.ToString());
                    FilterClCount(j, i);
                    CountInCl += Convert.ToInt32(dataGridViewCountInCl[j, i].Value.ToString());
                    //Console.WriteLine(i +" "+j);
                }
            }
            lblCountInCL.Text = Convert.ToString(CountInCl);
            DataGridViewTable(da);
        }

        //void VisualFormatTable()
        //{

        //    dataGridViewCl_Cl.Columns.Remove("№");//Удаление столбца
        //    dataGridViewCl_Cl.Columns.Remove("АТС0");
        //    dataGridViewCl_Cl.Columns.Remove("АТС4");
        //    dataGridViewCl_Cl.Columns.Remove("АТС5");
        //    dataGridViewCl_Cl.Columns.Remove("АТД0");
        //    dataGridViewCl_Cl.Columns.Remove("АТД4");
        //    dataGridViewCl_Cl.Columns.Remove("АТД5");
        //    dataGridViewCl_Cl.Columns.Remove("ЧСС0");
        //    dataGridViewCl_Cl.Columns.Remove("ЧСС4");
        //    dataGridViewCl_Cl.Columns.Remove("ЧСС5");

        //    for (int i = 1; i < dataGridViewCl_Cl.Columns.Count - 2; i++)
        //    {
        //        dataGridViewCl_Cl.Columns[i].Width = 39;
        //    }
        //    dataGridViewCl_Cl.Columns[15].Width = 55;
        //    dataGridViewCl_Cl.Columns[16].Width = 55;
        //    dataGridViewCl_Cl.Columns[13].HeaderText = "Кл.";
        //    dataGridViewCl_Cl.Columns[14].HeaderText = "М";
        //    dataGridViewCl_Cl.Columns[15].HeaderText = "Раст.";
        //    dataGridViewCl_Cl.Columns[16].HeaderText = "РастМ";
        //}

        private void dataGridViewFind_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double dist = 0;
            double[] Parametrs = new double[18];
            try
            {
                for (int i = 1; i < 19; i++)
                {
                    Parametrs[i - 1] = Convert.ToDouble(dataGridViewFind[i, dataGridViewFind.CurrentRow.Index].Value.ToString());
                    dist += Convert.ToDouble(dataGridViewFind[i, dataGridViewFind.CurrentRow.Index].Value.ToString());
                    //Console.WriteLine(Convert.ToInt32(dataGridViewFind[i, dataGridViewFind.CurrentRow.Index].Value.ToString()));
                }
            }
            catch
            {
                MessageBox.Show("Студент не має даних в базі даних");
            }
            
            double middle = (dist / 18);
          
            double middlePoint = 0.0;
            for (int i = 0; i < Parametrs.Length; i++)
            {
                middlePoint += Math.Abs(Parametrs[i] - middle);
            }

            lblRCl.Text = Convert.ToString(radiusCl[Convert.ToInt32(dataGridViewFind[22, dataGridViewFind.CurrentRow.Index].Value)-1]);
            lblRSt.Text = Convert.ToString(Math.Round((middlePoint / 18), 2));

            if(Convert.ToDouble(lblRCl.Text) < Convert.ToDouble(lblRSt.Text))
            {
                textBox2Zaglushka.Visible = false;
                lblConclusion.Text = "Студент виходить за границі кластера";
                GrafInd();                
            }
            else
            {
                textBox2Zaglushka.Visible = true;
                lblConclusion.Text = "Студент не виходить за границі кластера";
            }

            
           // Console.WriteLine(Convert.ToInt32(dataGridViewFind[22, dataGridViewFind.CurrentRow.Index].Value));

            // Console.WriteLine(Math.Round((middlePoint / 18), 2));
        }

        void GrafInd()
        {
            List<int> ParametrsData = new List<int>();
            List<int> ArrayMinutes = new List<int> { Convert.ToInt32(dataGridViewFind[14, dataGridViewFind.CurrentRow.Index].Value),
                        Convert.ToInt32(dataGridViewFind[15, dataGridViewFind.CurrentRow.Index].Value),
                        Convert.ToInt32(dataGridViewFind[16, dataGridViewFind.CurrentRow.Index].Value)};


            if (kInFind == 0)
            {
                ParametrsData = new List<int> { Convert.ToInt32(dataGridViewFind[2, dataGridViewFind.CurrentRow.Index].Value),
                    Convert.ToInt32(dataGridViewFind[3, dataGridViewFind.CurrentRow.Index].Value),
                    Convert.ToInt32(dataGridViewFind[4, dataGridViewFind.CurrentRow.Index].Value)};
            }
            else if (kInFind == 1)
            {
                ParametrsData = new List<int> { Convert.ToInt32(dataGridViewFind[8, dataGridViewFind.CurrentRow.Index].Value),
                    Convert.ToInt32(dataGridViewFind[9, dataGridViewFind.CurrentRow.Index].Value),
                    Convert.ToInt32(dataGridViewFind[10, dataGridViewFind.CurrentRow.Index].Value)};
            }
            else
            {
                kInFind = 0;
                ParametrsData = new List<int> { Convert.ToInt32(dataGridViewFind[2, dataGridViewFind.CurrentRow.Index].Value),
                    Convert.ToInt32(dataGridViewFind[3, dataGridViewFind.CurrentRow.Index].Value),
                    Convert.ToInt32(dataGridViewFind[4, dataGridViewFind.CurrentRow.Index].Value)};
            }

            double[] ParametrsDataAfter;
            string regress;
            string CoefDetermin;


           // Console.WriteLine("fdgfdg");

            for (int i = 0; i < ParametrsData.Count; i++)
            {
                Console.WriteLine(ParametrsData[i]);
            }
            Console.WriteLine();


            ClusertTest(ParametrsData, ArrayMinutes, out ParametrsDataAfter, out regress, out CoefDetermin);

            //Console.WriteLine(regress);
            //Console.WriteLine(CoefDetermin);

            chartInd.Series["RegressLineCL"].Points.Clear();
            chartInd.Series["RegressLineM"].Points.Clear();
            for (int i = 0; i < ParametrsData.Count; i++)
            {
                chartInd.Series["RegressLineCL"].Points.AddXY(ArrayMinutes[i], ParametrsDataAfter[i]);
            }
            lblIndReg.Text = regress;

            List<int> ParametrsDataM = new List<int>();//Массив для значений метки
            List<int> ArrayMinutesM = new List<int>();


            for (int i = 0; i < dataGridViewRead.RowCount; i++)
            {
                if ((dataGridViewRead[23, i].Value.ToString()) == (dataGridViewFind[22, dataGridViewFind.CurrentRow.Index].Value.ToString()))
                {
                    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewRead[15, i].Value.ToString()));
                    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewRead[16, i].Value.ToString()));
                    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewRead[17, i].Value.ToString()));
                    if (kInFind == 0)
                    {
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[3, i].Value.ToString()));
                        //Console.WriteLine(Convert.ToInt32(dataGridViewRead[2, i].Value.ToString()));
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[4, i].Value.ToString()));
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[5, i].Value.ToString()));
                    }
                    else if (kInFind == 1)
                    {
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[9, i].Value.ToString()));
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[10, i].Value.ToString()));
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[11, i].Value.ToString()));
                    }
                    else
                    {
                        kInFind = 0;
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[3, i].Value.ToString()));
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[4, i].Value.ToString()));
                        ParametrsDataM.Add(Convert.ToInt32(dataGridViewRead[5, i].Value.ToString()));
                    }
                }
                
            }
            //Console.WriteLine("Date:");
            //for(int i=0;i< ParametrsDataM.Count;i++)
            //{
            //    Console.WriteLine(ParametrsDataM[i]);
            //}
            ClusertTest(ParametrsDataM, ArrayMinutesM, out ParametrsDataAfter, out regress, out CoefDetermin);
            lblClinStudent.Text = regress;
            for (int i = 0; i < ParametrsDataM.Count; i++)
            {
                chartInd.Series["RegressLineM"].Points.AddXY(ArrayMinutesM[i], ParametrsDataAfter[i]);
            }
           // kInFind++;
        }

        private void btnGrafInd_Click(object sender, EventArgs e)
        {
            if (k2 == 1)
            {
                title = "Графік ліній регресій АТД-ЧСС";
                namechart = "АТД";
                chartInd.Titles[0].Text = title;
            }
            else if (k2 == 2)
            {
                title = "Графік ліній регресій АТР-ЧСС";
                namechart = "АТР";
                chartInd.Titles[0].Text = title;
            }
            else
            {
                title = "Графік ліній регресій АТС-ЧСС";
                namechart = "АТС";
                k2 = 0;
                chartInd.Titles[0].Text = title;
            }
            k2++;

            
            btnGrafInd.Text = (k2 == 1) ? "Графік АТД" : (k2 == 2) ? "Графік АТР" : "Графік АТС";


            kInFind++;
            GrafInd();
        }

        private void btnChartView_Click(object sender, EventArgs e)
        {
            this.Left = 25;
            this.Top = 10;

            btnChartDisable.Visible = true;
            btnChartView.Visible = false;


            this.ClientSize = new System.Drawing.Size(1310, 690);
            this.tabControl1.Size = new System.Drawing.Size(1330, 664);
            this.pictureBox1.Location = new System.Drawing.Point(1283, 2);

            this.panelCulc.Location = new System.Drawing.Point(542, 39);
            this.panelChart.Location = new System.Drawing.Point(769, 12);

            this.txtBoxPath.Size = new System.Drawing.Size(430, 20);

            this.label7.Location = new System.Drawing.Point(166, 60);
            this.label8.Location = new System.Drawing.Point(147, 263);
            this.label9.Location = new System.Drawing.Point(353, 263);
            this.label10.Location = new System.Drawing.Point(119, 237);
            this.label14.Location = new System.Drawing.Point(112, 427);

            this.numUpCl.Location = new System.Drawing.Point(202, 261);
            this.numUpVec.Location = new System.Drawing.Point(308, 261);
            this.checkBox1.Location = new System.Drawing.Point(220, 453);

            this.dataGridViewDist.Size = new System.Drawing.Size(527, 141);
            this.dataGridViewRead.Size = new System.Drawing.Size(527, 141);
            this.dataGridViewCl_Cl.Size = new System.Drawing.Size(527, 141);
        }

        private void btnChartDisable_Click(object sender, EventArgs e)
        {
            this.Left = 25;
            this.Top = 10;

            FormChanged();
        }

        void FormChanged()
        {
            btnChartDisable.Visible = false;
            btnChartView.Visible = true;

            this.ClientSize = new System.Drawing.Size(1021, 690);
            this.tabControl1.Size = new System.Drawing.Size(1551, 664);
            this.pictureBox1.Location = new System.Drawing.Point(994, 2);

            this.panelCulc.Location = new System.Drawing.Point(722, 39);
            this.panelChart.Location = new System.Drawing.Point(1009, 21);

            this.txtBoxPath.Size = new System.Drawing.Size(609, 20);

            this.label7.Location = new System.Drawing.Point(236, 60);
            this.label10.Location = new System.Drawing.Point(190, 237);
            this.label14.Location = new System.Drawing.Point(190, 427);
            this.label9.Location = new System.Drawing.Point(424, 263);
            this.label8.Location = new System.Drawing.Point(218, 263);

            this.numUpCl.Location = new System.Drawing.Point(273, 261);
            this.numUpVec.Location = new System.Drawing.Point(379, 261);
            this.checkBox1.Location = new System.Drawing.Point(298, 453);

            this.dataGridViewDist.Size = new System.Drawing.Size(706, 141);
            this.dataGridViewCl_Cl.Size = new System.Drawing.Size(706, 141);
            this.dataGridViewRead.Size = new System.Drawing.Size(706, 141);
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Close();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = 25;
            this.Top = 10;
        }

        private void tabPageChart_Enter(object sender, EventArgs e)
        {
            FormChanged();
        }

        private void btnCleanRead_Click(object sender, EventArgs e)
        {

            dataGridViewRead.DataSource = new object();
            dataGridViewMatrixCl.Rows.Clear();
            dataGridViewCluster.Rows.Clear();
            dataGridViewDist.DataSource = new object();
            dataGridViewCl_Cl.DataSource = new object();
            dataGridViewCountInCl.Rows.Clear();
            chrtRegress.Series["RegressLineCL"].Points.Clear();
            chrtRegress.Series["RegressLineM"].Points.Clear();
            chartInd.Series["RegressLineCL"].Points.Clear();
            chartInd.Series["RegressLineM"].Points.Clear();
            chartInd.Series["RegressLineCL"].Points.Clear();
            dataGridViewFind.DataSource = new object();
            lblConclusion.Text = " ______________";
            lblRSt.Text = "№";
            lblRCl.Text = "№";
            lblCountATD.Text = "№";
            lblCounATS.Text = "№";
            lblCountWithaoutChange.Text = "№";
            lblCountChange.Text = "№";
            lblCountSurname.Text = "№";

            textBox2Zaglushka.Visible = true;

            numUpCl.Enabled = false;
            numUpVec.Enabled = false;
            btnCountInCl.Enabled = false;
            btnCL.Enabled = false;
            btnGraf.Enabled = false;
            textBox1.Enabled = false;
            btnCount.Enabled = false;

            lblCount.Text = "№";
            lbli.Text = lblj1.Text = "К";
            lbli1.Text = lblj.Text = "М";

            lblCountInCL.Text = "№";

            lbRegress.Text = "Рівняння";
            lbCoef.Text = "№";
            lbRegressM.Text = "Рівняння";
            lbCoefM.Text = "№";
        }

        private void btnCleanCL_M_Click(object sender, EventArgs e)
        {
            dataGridViewDist.DataSource = new object();
            dataGridViewMatrixCl.Rows.Clear();
            btnCL.Enabled = false;
            btnGraf.Enabled = false;
            lblCount.Text = "№";
            lbli.Text = lblj1.Text = "К";
            lbli1.Text = lblj.Text = "М";
        }

        private void btnCleanCL_CL_Click(object sender, EventArgs e)
        {
            dataGridViewCl_Cl.DataSource = new object();
            dataGridViewCountInCl.Rows.Clear();
            btnCountInCl.Enabled = false;
            btnGraf.Enabled = false;
            lblCountInCL.Text = "№";
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chrtRegress.Series["RegressLineCL"].Points.Clear();
            chrtRegress.Series["RegressLineM"].Points.Clear();
            lbRegress.Text = "Рівняння:";
            lbCoef.Text = "№:";
            lbRegressM.Text = "Рівняння:";
            lbCoefM.Text = "№:";
            dataGridViewCluster.Rows.Clear();

            if(checkBox1.Checked)
            {
                label9.Text = "Кластер";
                label27.Text = "Рівняння Cl-" + numUpCl.Value;
                label28.Text = "Рівняння Cl-" + numUpVec.Value;
                dataGridViewCluster.Columns[1].HeaderText = "Cl1";
                dataGridViewCluster.Columns[2].HeaderText = "Cl2";
            }
            else
            {
                label9.Text = "Мітка";
                label27.Text = "Рівняння Cl";
                label28.Text = "Рівняння M";
                dataGridViewCluster.Columns[1].HeaderText = "Cl";
                dataGridViewCluster.Columns[2].HeaderText = "M";
            }
        }
    }
}
