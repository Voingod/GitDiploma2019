using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RegressStudBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridViewFind.AllowUserToAddRows = false;
            dataGridViewFind.AllowUserToDeleteRows = false;
            dataGridViewStudent.AllowUserToAddRows = false;
            dataGridViewStudent.AllowUserToDeleteRows = false;
        }
        DataTable dt;//Создание таблицы для dataGridView, чтобы записать в нее значения
 //       int[] ArrayMinutes = new int [] { 1, 2, 3 };//Массив 
        int k = 0;//Счетчик данных (АТС/АТД/ЧСС)

        //Заполнение таблицы
        void DataGridViewTable(OleDbDataAdapter da)
        {
            dt = new DataTable("Students");
            da.Fill(dt);
            dataGridViewStudent.AllowUserToAddRows = false;
            dataGridViewStudent.DataSource = dt;
        }
        //Чтение данных из Excel
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "ForLineModel.xlsx";
                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                OleDbConnection conn = new OleDbConnection(stringcoon);
                if (rbtnWoman.Checked)
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("Select №1, ПІБ, №, АТС1, АТС2, АТС3, " +
                                                                "АТД1, АТД2, АТД3, " +
                                                                "ЧСС1, ЧСС2, ЧСС3, " +
                                                                "Cl8_APHR, MinCL, SubMinCL " +
                                                               "from[" + rbtnWoman.Text + "$]", conn);
             
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("1");
                    comboBox1.Items.Add("2");
                    comboBox1.Items.Add("3");
                    comboBox1.Items.Add("4");
                    comboBox1.Items.Add("5");
                    comboBox1.Items.Add("6");
                    comboBox1.Items.Add("7");
                    comboBox1.Items.Add("8");
                    DataGridViewTable(da);
                    Console.WriteLine(dataGridViewStudent[13,13].ValueType);
                }
                else if (rbtnMan.Checked)
                {
                   OleDbDataAdapter da = new OleDbDataAdapter("Select №1, ПІБ, №, АТС1, АТС2, АТС3, " +
                                                                "АТД1, АТД2, АТД3, " +
                                                                "ЧСС1, ЧСС2, ЧСС3, " +
                                                                "Cl8_APHR, MinCL, SubMinCL " +
                                                                "from[" + rbtnMan.Text + "$]", conn);
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("1");
                    comboBox1.Items.Add("2");
                    comboBox1.Items.Add("3");
                    comboBox1.Items.Add("4");
                    comboBox1.Items.Add("5");
                    comboBox1.Items.Add("6");
                    comboBox1.Items.Add("7");
                    DataGridViewTable(da);
                }
            }
            catch
            {
                MessageBox.Show("Путь не найден/некорректная таблица");
            }
        }
        
        //Метод поиска студента в БД
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewCoeff.Rows.Clear();
            count = 0;
            DataView dv = new DataView(dt);//Создание новой таблицы
            dv.RowFilter = string.Format("ПІБ like '%{0}%'", textBox1.Text);//Поиск в столбце ПІБ по значению, введенному в textBox1
            dataGridViewFind.DataSource = dv.ToTable();//Заполнение таблицы
            dataGridViewFind.Columns.Remove("№");//Удаление столбца
            dataGridViewFind.Columns.Remove("№1");

            dataGridViewFind.Columns["АТС1"].Visible = false;//Скрытие столбца
            dataGridViewFind.Columns["АТС2"].Visible = false;
            dataGridViewFind.Columns["АТС3"].Visible = false;
            dataGridViewFind.Columns["АТД1"].Visible = false;
            dataGridViewFind.Columns["АТД2"].Visible = false;
            dataGridViewFind.Columns["АТД3"].Visible = false;
            dataGridViewFind.Columns["ЧСС1"].Visible = false;
            dataGridViewFind.Columns["ЧСС2"].Visible = false;
            dataGridViewFind.Columns["ЧСС3"].Visible = false;
            dataGridViewFind.Columns["Cl8_APHR"].Visible = false;

            
                 
        }

        //Отображение графика/линии регресси/ расчет коэффициентов
        private void dataGridViewFind_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                MethodMinQuare();
            }
            catch
            {
                MessageBox.Show("Загрузите данные/еще что-то там из-за чего ошибка");
            }
        }

        //Подпись параметров на форме (АТС/АТД/ЧСС)
        //int[] Lable(int k)
        //{
        //    int One = 0;//Минута (подпись параметра в зависимости от минуты)
        //    int Two = 0;
        //    int Three = 0;
        //    int[] ArrayNumParametrs = new int[3];// Массив значений определенного параметра в зависимости от минуты и значения k.

        //    lbMinOneText.Text = dataGridViewFind.Columns[1+k].Name;//Вывод имени переменной на экран
        //    lbMinTwoText.Text = dataGridViewFind.Columns[2+k].Name;
        //    lbMinThreeText.Text = dataGridViewFind.Columns[3+k].Name;

        //    lbMinOneNumber.Text = dataGridViewFind[1+k, dataGridViewFind.CurrentRow.Index].Value.ToString();//Вывод значения на экран
        //    lbMinTwoNumber.Text = dataGridViewFind[2+k, dataGridViewFind.CurrentRow.Index].Value.ToString();
        //    lbMinThreeNumber.Text = dataGridViewFind[3+k, dataGridViewFind.CurrentRow.Index].Value.ToString();
        //    lbCluster.Text = dataGridViewFind[11, dataGridViewFind.CurrentRow.Index].Value.ToString();

        //    One = Convert.ToInt32(lbMinOneNumber.Text);//Запись значения параметра в зависимости от минуты
        //    Two = Convert.ToInt32(lbMinTwoNumber.Text);
        //    Three = Convert.ToInt32(lbMinThreeNumber.Text);

        //    //---------------------------------//Заполнение массива
        //    ArrayNumParametrs[0] = One;
        //    ArrayNumParametrs[1] = Two;
        //    ArrayNumParametrs[2] = Three;
        //    //---------------------------------//Заполнение массива

        //    return ArrayNumParametrs;
        //}
        //Метод наименьших квадратов + метод Гаусса
        int count = 0;
        void MethodMinQuare()
        {
            // int[] ParametrsData = { Convert.ToInt32(dataGridViewFind[1, 0]), Convert.ToInt32(dataGridViewFind[1, 1]), Convert.ToInt32(dataGridViewFind[1, 2]) };
            // int[] ArrayMinutes = new int[] { Convert.ToInt32(dataGridViewFind[1, 0]), Convert.ToInt32(dataGridViewFind[1, 1]), Convert.ToInt32(dataGridViewFind[1, 2]) };
            Console.WriteLine(Convert.ToInt32(dataGridViewFind[1, dataGridViewFind.CurrentRow.Index].Value.ToString()));
            Console.WriteLine(k);
            int[] ParametrsData = new int [] { Convert.ToInt32(dataGridViewFind[1, dataGridViewFind.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewFind[2, dataGridViewFind.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewFind[3, dataGridViewFind.CurrentRow.Index].Value.ToString()) };
            int[] ArrayMinutes = new int[] { Convert.ToInt32(dataGridViewFind[4, dataGridViewFind.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewFind[5, dataGridViewFind.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGridViewFind[6, dataGridViewFind.CurrentRow.Index].Value.ToString()) }; 
            //int[] ArrayMinutes = new int[] { 1, 2, 3 };



            double[] ParametrsDataAfter = new double[3];//Массив значений, расчитаного по уравнению регрессии
          
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

            chartRegress.Series["Parametr"].Points.Clear();
            chartRegress.Series["RegressLine"].Points.Clear();
            chartRegress.ChartAreas[0].AxisY.Minimum = ParametrsData.Min()-5;

            for (int i = 0; i < ParametrsData.Length; i++)
            {
                chartRegress.Series["Parametr"].Points.AddXY(ArrayMinutes[i], ParametrsData[i]);//Рисуем график зависимости параметра от минуты
                //Расчет параметров по методу наименьших квадратов, систему решаем методом Гаусса
                SumParametr += ParametrsData[i];
                SumMinute += ArrayMinutes[i];
                SumMinutesQuare += Math.Pow(ArrayMinutes[i], 2);
                SumMinuteONSumParametr += ParametrsData[i] * ArrayMinutes[i];
            }
            determinate = SumMinutesQuare * 3 - SumMinute * SumMinute;// 3 - колличество столбцов в массивах ParametrsData и ArrayMinutes.
            if (determinate != 0)
            {
                a = (SumMinuteONSumParametr * 3 - SumParametr * SumMinute) / determinate;
                b = (SumMinutesQuare * SumParametr - SumMinuteONSumParametr * SumMinute) / determinate;
                //----------------------//Построение линии тренда с расчетом коэффициента детерминации 
                for (int i=0;i<ParametrsData.Length;i++)
                {
                    SumByTable += ParametrsData[i];
                }
                for(int i=0;i< ParametrsData.Length;i++)
                {
                    ParametrsDataAfter[i] = a * ArrayMinutes[i] + b;
                    Summ += Math.Pow((ParametrsData[i] - ParametrsDataAfter[i]),2);
                    SummForMiddle += Math.Pow((ParametrsData[i] - (SumByTable / 3)),2);
                }
                lbCoef.Text= "R"+omega+" =" + Math.Round((1 - Summ / SummForMiddle),4);//Вывод коэффициента детерминации 

                //chartRegress.Series["RegressLine"].Points.AddXY(ArrayMinutes[0], ParametrsDataAfter[0]);
                //chartRegress.Series["RegressLine"].Points.AddXY(ArrayMinutes[2], ParametrsDataAfter[2]);

                // chartRegress.Series["RegressLine"].Points.AddXY(72, 129);
                for (int i=0;i< ParametrsDataAfter.Length;i++)
                {
                    chartRegress.Series["RegressLine"].Points.AddXY(ArrayMinutes[i], ParametrsDataAfter[i]);
                }
         
                //---------------------//Построение линии тренда с расчетом коэффициента детерминации 

                if (b>=0){lbRegress.Text = "y=" + Math.Round(a,4) + "x+" + Math.Round(b, 2);}
                else{lbRegress.Text = "y=" + Math.Round(a,4) + "x" + Math.Round(b, 2);}
                count ++;
                if(count<= dataGridViewFind.Rows.Count)
                {
                    dataGridViewCoeff.Rows.Add(dataGridViewFind.CurrentRow.Index, lbCluster.Text, Math.Round(a,4), Math.Round(b, 2));
                }
                
            }
            else
            {
                MessageBox.Show("Система имеет больше одного решения");
            }
        }

        //Метод перехода к разным параметрам + подпсись кнопки
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewCoeff.Rows.Clear();
                count = 0;
                if (k <= 3)// 3 - колличество параметров, то есть ЧСС, АТД, АТС
                {
                    k += 3;
                    if (k == 3)
                    {
                        btnNext.Text = "Перейти к ЧСС";
                    }
                    else
                    {
                        btnNext.Text = "Перейти к АТС";
                    }

                }
                else
                {
                    k = 0;
                    btnNext.Text = "Перейти к АТД";
                }
                MethodMinQuare();
            }
            catch
            {
                MessageBox.Show("Загрузите данные/еще что-то там из-за чего ошибка");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //double[] SummClasters = new double[dataGridViewStudent.Rows.Count];
            //double dataExcelFormat = 0;
            //    switch (comboBox1.SelectedIndex)
            //    {
            //        case 0:
            //        {
            //            //DataView dv1 = new DataView(dt);//Создание новой таблицы
            //            //dv1.RowFilter = string.Format("MinCL = '%{0}%'", comboBox1.SelectedItem.ToString());//Поиск в столбце ПІБ по значению, введенному в textBox1
            //            //dataGridViewStudent.DataSource = dv1.ToTable();//Заполнение таблицы
            //            chrtForCluster.ChartAreas[0].AxisY.Minimum = 90;
            //            (dataGridViewStudent.DataSource as DataTable).DefaultView.RowFilter = String.Format("MinCL = '" + comboBox1.SelectedItem.ToString() + "'");

            //            for (int j = 1; j < dataGridViewStudent.Rows.Count; ++j)
            //            {
            //                double.TryParse(dataGridViewStudent[5, j].Value.ToString(), out dataExcelFormat);
            //                SummClasters[j] = (dataExcelFormat);
            //            }
            //            for (int j = 0; j < dataGridViewStudent.Rows.Count; j++)
            //            {
            //                for (int i = 0; i < 3; i++)
            //                {
            //                    chrtForCluster.Series["Parametr"].Points.AddXY(ArrayMinutes[i], dataGridViewStudent[3, j].Value.ToString());//Рисуем график зависимости параметра от минуты
            //                }
            //            }
            //            break;
            //        }
            //        case 1:
            //        (dataGridViewStudent.DataSource as DataTable).DefaultView.RowFilter = String.Format("MinCL = '" + comboBox1.SelectedItem.ToString() + "'");
            //        break;
            //        case 2: break;
            //        case 3: break;
            //        case 4: break;
            //        case 5: break;
            //        case 6: break;
            //        case 7: break;
            //    }
        }
    }
}
