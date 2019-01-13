using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ClusterVector
{
    public partial class Form1 : Form
    {
        public static string regressToGraf="";
        public static string CoefToGraf = "";
        public static string regressToGrafM = "";
        public static string CoefToGrafM = "";

        public static List<int> ParametrsDataToGraf = new List<int>();
        public static double[] ParametrsDataAfterToGraf;

        public static List<int> ArrayMinutesToGraf = new List<int>();

        public static List<int> ParametrsDataToGrafM = new List<int>();//Массив для значений метки
        public static List<int> ArrayMinutesToGrafM = new List<int>();


        public Form1()
        {
            
            InitializeComponent();
        }
        FormGraf formGraf = new FormGraf();
        DataTable dt;//Создание таблицы для dataGridView, чтобы записать в нее значения
        OleDbDataAdapter da;
        int count = 0;
        int k = 0;
        int countForRegress = 0;
        int countForParam = 0;
        void DataGridViewTable(OleDbDataAdapter da)
        {
            dt = new DataTable("Read");
            da.Fill(dt);
            dataGridViewRead.AllowUserToAddRows = false;
            dataGridViewRead.DataSource = dt;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "ForDisertation.xlsx";
                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                OleDbConnection conn = new OleDbConnection(stringcoon);
                if (rbtWoman.Checked)
                {
                     da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТС1, АТС2, АТС3, АТС4, АТС5," +
                        "АТД0, АТД1, АТД2, АТД3, АТД4, АТД5," +
                        "ЧСС0, ЧСС1, ЧСС2, ЧСС3, ЧСС4, ЧСС5, " +
                        "АТР1, АТР2, АТР3, " +
                        "Кластер,Метка,Расстояние,РасстояниеМ from[" + rbtWoman.Text + "$]", conn);

                    DataGridViewTable(da);

                }
                else if (rbtMan.Checked)
                {
                    //da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТД0, ЧСС0, АТС1, АТД1, ЧСС1, АТС2, АТД2, ЧСС2, АТС3, АТД3, ЧСС3, АТС4, АТД4, ЧСС4, АТС5, АТД5, ЧСС5, Кластер, Метка, Расстояние, РасстояниеМ from[" + rbtMan.Text + "$]", conn);
                    da = new OleDbDataAdapter("Select №, ПІБ, АТС0, АТС1, АТС2, АТС3, АТС4, АТС5," +
                        "АТД0, АТД1, АТД2, АТД3, АТД4, АТД5," +
                        "ЧСС0, ЧСС1, ЧСС2, ЧСС3, ЧСС4, ЧСС5," +
                        "Кластер,Метка,Расстояние,РасстояниеМ from[" + rbtMan.Text + "$]", conn);
                    DataGridViewTable(da);
                }
            }
            catch
            {
                MessageBox.Show("Путь не найден/некорректная таблица");
            }
        }

        void Filter()
        {
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

        private void numUpCl_ValueChanged(object sender, EventArgs e)
        {
            countForParam = 0;
            k = 0;
            btnGraf.Text = "График АТС";
            Filter();
        }

        private void numUpVec_ValueChanged(object sender, EventArgs e)
        {
            countForParam = 0;
            k = 0;
            btnGraf.Text = "График АТС";
            Filter();
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
            ParametrsDataAfterToGraf = new double[ParametrsData.Count];
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
                Console.WriteLine(ParametrsDataAfter.Length+" fjyjty");
                for (int i = 0; i < ParametrsData.Count; i++)
                {
                    ParametrsDataAfter[i] = a * ArrayMinutes[i] + b;
                   // ParametrsDataAfterToGraf[i] = a * ArrayMinutes[i] + b;
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
             
  Console.WriteLine(ParametrsDataToGraf.Count);
                //Console.WriteLine(ParametrsDataAfterToGraf.Length);
                for (int i = 0; i < ParametrsDataAfter.Length; i++)
                {
                    ParametrsDataAfterToGraf[i] = ParametrsDataAfter[i];
                }

            }

            else
            {
                MessageBox.Show("Система имеет больше одного решения");
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

           

            for (int j = 0; j < dataGridViewDist.RowCount-1; j++)
            {
                
                if (Convert.ToInt32(dataGridViewDist[13, j].Value.ToString()) == numUpCl.Value)
                {

                    ParametrsData.Add(Convert.ToInt32(dataGridViewDist[1 + count, j].Value.ToString()));
                    ParametrsData.Add(Convert.ToInt32(dataGridViewDist[2 + count, j].Value.ToString()));
                    ParametrsData.Add(Convert.ToInt32(dataGridViewDist[3 + count, j].Value.ToString()));

                    ArrayMinutes.Add(Convert.ToInt32(dataGridViewDist[7, j].Value.ToString()));
                    ArrayMinutes.Add(Convert.ToInt32(dataGridViewDist[8, j].Value.ToString()));
                    ArrayMinutes.Add(Convert.ToInt32(dataGridViewDist[9, j].Value.ToString()));
                }
                else
                {
                    ParametrsDataM.Add(Convert.ToInt32(dataGridViewDist[1 + count, j].Value.ToString()));
                    ParametrsDataM.Add(Convert.ToInt32(dataGridViewDist[2 + count, j].Value.ToString()));
                    ParametrsDataM.Add(Convert.ToInt32(dataGridViewDist[3 + count, j].Value.ToString()));

                    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewDist[7, j].Value.ToString()));
                    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewDist[8, j].Value.ToString()));
                    ArrayMinutesM.Add(Convert.ToInt32(dataGridViewDist[9, j].Value.ToString()));
                }
            } //разбиение студентов определенного кластера и метки на две группы

            for(int i=0;i< ParametrsData.Count;i++)
            {
                ParametrsDataToGraf.Add(ParametrsData[i]);
                // ParametrsDataAfterToGraf
                ArrayMinutesToGraf.Add(ArrayMinutes[i]);
                ParametrsDataToGrafM.Add(ParametrsDataM[i]);
                ArrayMinutesToGrafM.Add(ArrayMinutesM[i]);

        //Console.WriteLine(ParametrsDataToGraf[i]);
            }


            //for (int i = 0; i < ParametrsData.Count; i++)
            //{
            //    Console.WriteLine(ParametrsData[i]);
            //}
            //Console.WriteLine("gwef");

            double[] ParametrsDataAfter;
            string regress;
            string CoefDetermin;
            ClusertTest(ParametrsData, ArrayMinutes, out ParametrsDataAfter, out regress, out CoefDetermin);
            //lbRegress.Text = regress;
            regressToGraf = regress; //статические переменные уравнения регрессии для второй формы
            CoefToGraf = CoefDetermin; // статические переменные уравнения регрессии для второй формы
            formGraf.UpdateData();
            //lbCoef.Text = CoefDetermin;

            //chrtForAll.Series["Parametr"].Points.Clear();
            //chrtForAll.Series["RegressLine"].Points.Clear();
            //chrtForAll.ChartAreas[0].AxisY.Minimum = ParametrsData.Min() - 5;
            //for (int i = 0; i < ParametrsData.Count; i++)
            //{
            //    chrtForAll.Series["Parametr"].Points.AddXY(ArrayMinutes[i], ParametrsData[i]);//Рисуем график зависимости параметра от минуты
            //    chrtForAll.Series["RegressLine"].Points.AddXY(ArrayMinutes[i], ParametrsDataAfter[i]);
            //}



            ClusertTest(ParametrsDataM, ArrayMinutesM, out ParametrsDataAfter, out regress, out CoefDetermin);
            //lbRegressM.Text = regress;
            //lbCoefM.Text = CoefDetermin;

            regressToGrafM = regress; //статические переменные уравнения регрессии для второй формы
            CoefToGrafM = CoefDetermin; // статические переменные уравнения регрессии для второй формы
            formGraf.UpdateData();






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
            //  FormGraf formGraf = new FormGraf();
            // formGraf.Show();
            // formGraf.Update();
            
            try
            {
                
                if (k == 1)
                {
                    chrtForAll.ChartAreas[0].AxisY.Title = "АТД";
                    chrtForAllM.ChartAreas[0].AxisY.Title = "АТД";
                    count = 3;
                }
                else if (k == 2)
                {
                    chrtForAll.ChartAreas[0].AxisY.Title = "АТР";
                    chrtForAllM.ChartAreas[0].AxisY.Title = "АТР";
                    count = 9;
                }
                else
                {
                    chrtForAll.ChartAreas[0].AxisY.Title = "АТС";
                    chrtForAllM.ChartAreas[0].AxisY.Title = "АТC";
                    k = 0;
                    count = 0;
                }
                MethodMinQuare(count);
                k++;

                btnGraf.Text = (k == 1) ? "График АТД" : (k==2) ? "График АТР" : "График АТС";
                countForParam++;

            }
            catch
            {
                MessageBox.Show("Загрузите данные/еще что-то там из-за чего ошибка");
            }
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
                    if (dataGridViewMatrixCl[i, j].Value.ToString() != "0" || dataGridViewMatrixCl[j, i].Value.ToString() != "0")
                    {
                        dataGridViewMatrixCl[j, i].Style.BackColor= System.Drawing.Color.LightBlue;
                        dataGridViewMatrixCl[i, j].Style.BackColor = System.Drawing.Color.LightBlue;
                        Console.WriteLine(dataGridViewMatrixCl[j, i].Value.ToString());
                    }
                }
            }

            DataGridViewTable(da);
        }
        void CoefDatabase(int Cl, int M, double a, double b)
        {
            if(countForParam < 3)
            {
                dataGridViewCluster.Rows.Add(chrtForAll.ChartAreas[0].AxisY.Title, Cl, M, Math.Round(a, 4), Math.Round(b, 2));
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

                        if ((dtSurname.Rows[j][24].ToString() == "1") & (dtSurname.Rows[j+1][23].ToString()) == "6" ||
                           (dtSurname.Rows[j][24].ToString() == "1") & (dtSurname.Rows[j+1][23].ToString()) == "8" ||
                           (dtSurname.Rows[j][24].ToString() == "6") & (dtSurname.Rows[j+1][23].ToString()) == "1" ||
                           (dtSurname.Rows[j][24].ToString() == "8") & (dtSurname.Rows[j+1][23].ToString()) == "1" )
                           //(dtSurname.Rows[j][24].ToString() == "6") & (dtSurname.Rows[j+1][23].ToString()) == "8" ||
                           //(dtSurname.Rows[j][24].ToString() == "8") & (dtSurname.Rows[j+1][23].ToString()) == "6")
                        {
                            CounATS++;
                        }

                        if ((dtSurname.Rows[j][24].ToString() == "6") & (dtSurname.Rows[j+1][23].ToString()) == "8" ||
                           (dtSurname.Rows[j][24].ToString() == "8") & (dtSurname.Rows[j+1][23].ToString()) == "6")
                        {
                            CountATD++;
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
            lblCountSurnameChange.Text = CountSurnameChange.ToString();


            // Console.WriteLine(ClusterVecCount);
            //Console.WriteLine(SurnameCount);


            //for (int i = 0; i < Surname.Count; i++)
            //{
            //    Console.WriteLine(Surname[i]);
            //}
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);//Создание новой таблицы
            dv.RowFilter = string.Format("ПІБ like '%{0}%'", textBoxFind.Text);//Поиск в столбце ПІБ по значению, введенному в textBox1
            dataGridViewFind.DataSource = dv.ToTable();//Заполнение таблицы
            //dataGridViewFind.Columns.Remove("№");//Удаление столбца
            //dataGridViewFind.Columns.Remove("№1");
            dataGridViewFind.Columns[23].Width = 55;
            dataGridViewFind.Columns[24].Width = 55;
            dataGridViewFind.Columns["№"].Visible = false;
            dataGridViewFind.Columns["АТС1"].Visible = false;//Скрытие столбца
            dataGridViewFind.Columns["АТС2"].Visible = false;
            dataGridViewFind.Columns["АТС3"].Visible = false;
            dataGridViewFind.Columns["АТС0"].Visible = false;
            dataGridViewFind.Columns["АТС4"].Visible = false;
            dataGridViewFind.Columns["АТС5"].Visible = false;
            dataGridViewFind.Columns["АТД1"].Visible = false;
            dataGridViewFind.Columns["АТД2"].Visible = false;
            dataGridViewFind.Columns["АТД3"].Visible = false;
            dataGridViewFind.Columns["АТД0"].Visible = false;
            dataGridViewFind.Columns["АТД4"].Visible = false;
            dataGridViewFind.Columns["АТД5"].Visible = false;
            dataGridViewFind.Columns["ЧСС1"].Visible = false;
            dataGridViewFind.Columns["ЧСС2"].Visible = false;
            dataGridViewFind.Columns["ЧСС3"].Visible = false;
            dataGridViewFind.Columns["ЧСС0"].Visible = false;
            dataGridViewFind.Columns["ЧСС4"].Visible = false;
            dataGridViewFind.Columns["ЧСС5"].Visible = false;
            dataGridViewFind.Columns["АТР1"].Visible = false;
            dataGridViewFind.Columns["АТР2"].Visible = false;
            dataGridViewFind.Columns["АТР3"].Visible = false;
            //dataGridViewFind.Columns["Cl8_APHR"].Visible = false;
        }

        private void btnToGraf_Click(object sender, EventArgs e)
        {
           
            formGraf.Show();
         //   formGraf.Update();
          //  formGraf.Refresh();
        }
    }
}
