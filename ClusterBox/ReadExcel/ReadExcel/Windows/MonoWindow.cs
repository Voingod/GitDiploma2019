using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using ADOX;

namespace ClusterBox
{
    public partial class MonoWindow : Form
    {
        bool flag = false;
        bool language = true;
        int cluster = 0;
        double distantiont = 0;
        Work work = new Work();

        public MonoWindow()
        {
            InitializeComponent();
            //tbPathToFile.Visible = false;
            tbPathToFile.Visible = true;
            rbtnWoman.Checked = true;
            rbtCl8.Checked = true;
            tabPageDB.Parent = null;
            tabPageScience.Parent = null;
            OpenToolStripMenuItem.Visible = false;
        }

        // Считывание с результирующей таблицы
        private double[] Data()
        {
            double ATD0 = Convert.ToDouble(numericUpDownATD0.Text);
            double ATD1 = Convert.ToDouble(numericUpDownATD1.Text);
            double ATD2 = Convert.ToDouble(numericUpDownATD2.Text);
            double ATD3 = Convert.ToDouble(numericUpDownATD3.Text);
            double ATD4 = Convert.ToDouble(numericUpDownATD4.Text);
            double ATD5 = Convert.ToDouble(numericUpDownATD5.Text);
            double ATS0 = Convert.ToDouble(numericUpDownATS0.Text);
            double ATS1 = Convert.ToDouble(numericUpDownATS1.Text);
            double ATS2 = Convert.ToDouble(numericUpDownATS2.Text);
            double ATS3 = Convert.ToDouble(numericUpDownATS3.Text);
            double ATS4 = Convert.ToDouble(numericUpDownATS4.Text);
            double ATS5 = Convert.ToDouble(numericUpDownATS5.Text);
            double CHSS0 = Convert.ToDouble(numericUpDownCHSS0.Text);
            double CHSS1 = Convert.ToDouble(numericUpDownCHSS1.Text);
            double CHSS2 = Convert.ToDouble(numericUpDownCHSS2.Text);
            double CHSS3 = Convert.ToDouble(numericUpDownCHSS3.Text);
            double CHSS4 = Convert.ToDouble(numericUpDownCHSS4.Text);
            double CHSS5 = Convert.ToDouble(numericUpDownCHSS5.Text);

            double[] DataEnter = new double[] { ATS0,ATD0,CHSS0,
                                                ATS1, ATD1,CHSS1,
                                                ATS2, ATD2, CHSS2,
                                                ATS3,ATD3,CHSS3,
                                                ATS4,ATD4,CHSS4,
                                                ATS5,ATD5,CHSS5 };
            return DataEnter;
        }
        private void SaveDate()
        {
            try
            {
                string sex = "";
                if (cbMan.Checked)
                {
                    sex = cbMan.Text;
                }
                else if (cbWoman.Checked)
                {
                    sex = cbWoman.Text;
                }

                using (var connection = new OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Engine Type=5", Environment.CurrentDirectory + "\\Table\\StudentsDB.mdb")))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        if (flag == true)
                        {
                            command.CommandText = "INSERT INTO Результати ([Учбовий квиток],Курс,Імя,Прізвище,[По батькові],[Дата народження],Стать,Вік,Зріст,Вага," +
                            "АТС0,АТС1,АТС2,АТС3,АТС4,АТС5,АТД0,АТД1,АТД2,АТД3,АТД4,АТД5,ЧСС0,ЧСС1,ЧСС2,ЧСС3,ЧСС4,ЧСС5,Cl,Dist)" +
                            "values ('" + tbStudentTicket.Text + "','" + tbCourse.Text + "','" + tbStudentName.Text +
                            "','" + tbSudentSurname.Text + "','" + tbStudentFatherName.Text + "','" + dateTimePicker1.Text +
                            "','" + sex + "','" + tbStudentAge.Text + "','" + tbStudentHeight.Text + "','" + tbStudentWeight.Text +
                            "','" + numericUpDownATS0.Text + "','" + numericUpDownATS1.Text + "','" + numericUpDownATS2.Text + "','" + numericUpDownATS3.Text + "','" + numericUpDownATS4.Text +
                            "','" + numericUpDownATS5.Text + "','" + numericUpDownATD0.Text + "','" + numericUpDownATD1.Text + "','" + numericUpDownATD2.Text + "','" + numericUpDownATD3.Text +
                            "','" + numericUpDownATD4.Text + "','" + numericUpDownATD5.Text + "','" + numericUpDownCHSS0.Text + "','" + numericUpDownCHSS1.Text + "','" + numericUpDownCHSS2.Text +
                            "','" + numericUpDownCHSS3.Text + "','" + numericUpDownCHSS4.Text + "','" + numericUpDownCHSS5.Text + "','" + cluster + "','" + distantiont + "');";
                        }
                        else
                        {
                            command.CommandText = "INSERT INTO Результати ([Учбовий квиток],Курс,Імя,Прізвище,[По батькові],[Дата народження],Стать,Вік,Зріст,Вага," +
                            "АТС0,АТС1,АТС2,АТС3,АТС4,АТС5,АТД0,АТД1,АТД2,АТД3,АТД4,АТД5,ЧСС0,ЧСС1,ЧСС2,ЧСС3,ЧСС4,ЧСС5,Cl,Dist)" +
                            "values ('" + null + "','" + null + "','" + null + "','" + null + "','" + null + "','" + null +
                            "','" + null + "','" + null + "','" + null + "','" + null +
                            "','" + numericUpDownATS0.Text + "','" + numericUpDownATS1.Text + "','" + numericUpDownATS2.Text + "','" + numericUpDownATS3.Text + "','" + numericUpDownATS4.Text +
                            "','" + numericUpDownATS5.Text + "','" + numericUpDownATD0.Text + "','" + numericUpDownATD1.Text + "','" + numericUpDownATD2.Text + "','" + numericUpDownATD3.Text +
                            "','" + numericUpDownATD4.Text + "','" + numericUpDownATD5.Text + "','" + numericUpDownCHSS0.Text + "','" + numericUpDownCHSS1.Text + "','" + numericUpDownCHSS2.Text +
                            "','" + numericUpDownCHSS3.Text + "','" + numericUpDownCHSS4.Text + "','" + numericUpDownCHSS5.Text + "','" + cluster + "','" + distantiont + "');";
                        }
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Не вдається зберегти дані");
            }
        }
        private void BodyMassIndex()
        {
            try
            {
                double Height = Convert.ToDouble(numericUpDownHeight.Text);
                double Weight = Convert.ToDouble(numericUpDownWeight.Text);
                if (Height != 100 || Weight != 51)
                {
                    double BMindex;
                    BMindex = Math.Round((Weight / (Height * Height)) * 10000, 2);
                    if (BMindex <= 16)
                    {
                        tbIndexMass.Text += "Індекс маси тіла складає: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Виражений дефіцит ваги тіла";
                    }
                    else if (BMindex > 16 && BMindex < 18.5)
                    {
                        tbIndexMass.Text += "Індекс маси тіла складає: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Недостатня ваги тіла";
                    }
                    else if (BMindex >= 18.5 && BMindex < 25)
                    {
                        tbIndexMass.Text += "Індекс маси тіла складає: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Нормальний стан";
                    }
                    else if (BMindex >= 25 && BMindex < 30)
                    {
                        tbIndexMass.Text += "Індекс маси тіла складає: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Надлишкога вага тіла (передожиріння)";
                    }
                    else if (BMindex >= 30 && BMindex < 35)
                    {
                        tbIndexMass.Text += "Індекс маси тіла складає: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Ожиріння першого ступеня";
                    }
                    else if (BMindex >= 35 && BMindex < 40)
                    {
                        tbIndexMass.Text += "Індекс маси тіла складає: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Ожиріння другого ступеня";
                    }
                    else if (BMindex >= 40)
                    {
                        tbIndexMass.Text += "Індекс маси тіла складає: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Ожиріння третього ступеня";
                    }

                }
                else
                {
                    MessageBox.Show("Введіть значення, відмінні від значень,\nщо стоять за змовчуванням (дані ваги та зросту)");
                }
            }
            catch
            {
                MessageBox.Show("Перевірте коректність введених даних зросту і ваги!\nДив. інструкцію користувача (Програма->Інструкція користувача)");
            }
        }
        private void CreateDBtablesColumn()
        {
            try
            {
                string ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Engine Type=5", Environment.CurrentDirectory + "\\Table\\StudentsDB.mdb");
                ADOX.Catalog cat = new ADOX.Catalog();
                ADOX.Table locTable = new ADOX.Table();
                ADOX.Key locKey = new ADOX.Key();
                ADOX.Column locCol = new Column();

                //Create the Locations table and it's fields
                locTable.Name = "Результати";
                locCol.Name = "id";
                //locCol.Attributes = ColumnAttributesEnum.adColNullable;
                locCol.Type = ADOX.DataTypeEnum.adInteger;
                locTable.Columns.Append(locCol);

                locTable.Columns.Append("Учбовий квиток", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Курс", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Імя", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Прізвище", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("По батькові", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Дата народження", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Стать", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Вік", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Зріст", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Вага", DataTypeEnum.adVarWChar, 255);

                locTable.Columns.Append("АТС0", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТС1", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТС2", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТС3", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТС4", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТС5", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТД0", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТД1", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТД2", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТД3", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТД4", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("АТД5", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("ЧСС0", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("ЧСС1", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("ЧСС2", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("ЧСС3", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("ЧСС4", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("ЧСС5", DataTypeEnum.adVarWChar, 255);

                locTable.Columns.Append("Cl", DataTypeEnum.adVarWChar, 255);
                locTable.Columns.Append("Dist", DataTypeEnum.adVarWChar, 255);

                locKey.Name = "Primary Key";
                locKey.Columns.Append("id");
                locKey.Type = KeyTypeEnum.adKeyPrimary;

                cat.Create(ConnectionString);

                // Must create database file before applying autonumber to column
                locCol.ParentCatalog = cat;
                if (locCol.Name != "id")
                {
                    locCol.Attributes = ColumnAttributesEnum.adColFixed;
                    //locCol.Attributes = ColumnAttributesEnum.adColNullable;
                }
                locCol.Properties["AutoIncrement"].Value = true;

                //Exception triggered here
                cat.Tables.Append(locTable);
            }
            catch
            {
                MessageBox.Show("Не вдається свторити Базу даних.\nДані не збережено!");
            }
        }
        private void EngBodyMassIndex()
        {
            try
            {
                double Height = Convert.ToDouble(numericUpDownHeight.Text);
                double Weight = Convert.ToDouble(numericUpDownWeight.Text);
                if (Height != 100 || Weight != 50)
                {
                    double BMindex;
                    BMindex = Math.Round((Weight / (Height * Height)) * 10000, 2);
                    if (BMindex <= 16)
                    {
                        tbIndexMass.Text += "The body mass index is: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Characteristic:" + Environment.NewLine + "Expressed body weight deficiency";
                    }
                    else if (BMindex > 16 && BMindex < 18.5)
                    {
                        tbIndexMass.Text += "The body mass index is: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Characteristic:" + Environment.NewLine + "Lack of body weight";
                    }
                    else if (BMindex >= 18.5 && BMindex < 25)
                    {
                        tbIndexMass.Text += "The body mass index is: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Characteristic:" + Environment.NewLine + "Normal";
                    }
                    else if (BMindex >= 25 && BMindex < 30)
                    {
                        tbIndexMass.Text += "The body mass index is: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Characteristic:" + Environment.NewLine + "Excess body weight";
                    }
                    else if (BMindex >= 30 && BMindex < 35)
                    {
                        tbIndexMass.Text += "The body mass index is: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Characteristic:" + Environment.NewLine + "Obesity of the first degree";
                    }
                    else if (BMindex >= 35 && BMindex < 40)
                    {
                        tbIndexMass.Text += "The body mass index is: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Characteristic:" + Environment.NewLine + "Obesity of the second degree";
                    }
                    else if (BMindex >= 40)
                    {
                        tbIndexMass.Text += "The body mass index is: " + Convert.ToString(BMindex) + Environment.NewLine;
                        tbIndexMass.Text += "*Characteristic:" + Environment.NewLine + "Obesity of the third degree";
                    }

                }
                else
                {
                    MessageBox.Show("Введіть значення, відмінні від значень,\nщо стоять за змовчуванням (дані ваги та зросту)");
                }
            }
            catch
            {
                MessageBox.Show("Перевірте коректність введених даних зросту і ваги!\nДив. інструкцію користувача (Програма->Інструкція користувача)");
            }
        }

        private void EuclidSquare(double[] DataEnter, out double min, out double nextMin, out List<double> SummClasters)
        {
            min = 0;
            nextMin = 0;
            SummClasters = new List<double>();

            try
            {
                SummClasters = new List<double>();
                for (int i = 1; i < dataGridViewExcel.Columns.Count; ++i)
                {
                    double summ = 0;
                    for (int j = 1; j < dataGridViewExcel.Rows.Count; ++j)
                    {
                        double dataExcelFormat = Convert.ToDouble(dataGridViewExcel[i, j].Value.ToString());
                        summ += Math.Pow((DataEnter[j - 1] - dataExcelFormat), 2);
                    }
                    SummClasters.Add(summ);
                }

                List<double> SummClastersCopy = new List<double>();

                for (int i = 0; i < SummClasters.Count; i++)
                {
                    SummClastersCopy.Add(SummClasters[i]);
                }
                SummClastersCopy.Sort();
                min = SummClastersCopy[0];
                nextMin = SummClastersCopy[1];
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Неможливо визначити групу ризику, осільки не знайдено результуючої таблиці");
            }
        }

        public void EuclidSquare(int k, DataTable dt, DataTable dtGlobal, out double min, out double nextMin, out List<double> SummClasters)
        {
            //dt - результрующая таблица
            //dtGlobal - таблица с данными АТС, АТД, ЧСС, для которых надо определить кластер
            min = 0;
            nextMin = 0;
            SummClasters = new List<double>();
            try
            {
                SummClasters = new List<double>();

                for (int i = 0; i < dt.Columns.Count - 1; ++i)
                {

                    double summ = 0;
                    double dataExcelGlobalFormat;

                    for (int j = 0; j < dt.Rows.Count - 1; ++j)
                    {
                        if (dtGlobal.Rows[k][j].ToString().Length != 0)
                        {
                            dataExcelGlobalFormat = Convert.ToDouble(dtGlobal.Rows[k][j].ToString());
                            ;
                        }
                        else
                        {
                            dataExcelGlobalFormat = Convert.ToDouble(dtGlobal.Rows[k][j] = 0);
                        }
                        double dataExcelFormat = Convert.ToDouble(dt.Rows[j + 1][i + 1].ToString());
                        summ += Math.Pow((dataExcelFormat - dataExcelGlobalFormat), 2);
                    }

                    SummClasters.Add(summ);
                }

                List<double> SummClastersCopy = new List<double>();

                for (int i = 0; i < SummClasters.Count; i++)
                {
                    SummClastersCopy.Add(SummClasters[i]);
                }
                SummClastersCopy.Sort();
                min = SummClastersCopy[0];
                nextMin = SummClastersCopy[1];
            }

            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Неможливо визначити групу ризику, осільки не знайдено результуючої таблиці");
            }
        }

        private void Culculate()
        {
            if (tbPathToFile.Visible == true)
            {
                try
                {
                    double[] DataEnter = new double[18];
                    double dist = 0.0;
                    Data();
                    DataEnter = Data();


                    for (int i = 0; i < DataEnter.Length; i++)
                    {
                        dist += DataEnter[i];
                    }
                    double middle = (dist / 18);

                    string read = "";
                    double middlePoint = 0.0;

                    for (int i = 0; i < DataEnter.Length; i++)
                    {
                        middlePoint += Math.Abs(DataEnter[i] - middle);
                    }
                    tbResult.Clear();
                    tbRecomend.Clear();
                    tbIndexMass.Clear();

                    double min = 0;
                    double nextMin = 0;
                    List<double> SummClasters;
                    EuclidSquare(DataEnter, out min, out nextMin, out SummClasters);

                    for (int i = 0; i < SummClasters.Count; i++)
                    {
                        if (min == SummClasters[i])
                        {
                            switch (i)
                            {
                                case 0:
                                    tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 1:
                                    tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 2:
                                    tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 3:
                                    tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 4:
                                    tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 5:
                                    tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 6:
                                    tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 7:
                                    tbResult.Text += "Студент відноситься до кластеру  *" + (i + 1) + "*" + Environment.NewLine +
                                "Мінімальна відстань до кластеру становить: " + (distantiont = Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                            }

                        }
                    }

                    if ((min > work.radiusCl[cluster - 1]))
                    {
                        Console.WriteLine("StudentRadius: " + (Math.Round((middlePoint / 18), 2)) + " ClusterRadius: " + work.radiusCl[cluster - 1]);
                        for (int i = 0; i < SummClasters.Count; i++)
                        {
                            if (nextMin == SummClasters[i])
                            {
                                switch (i)
                                {
                                    case 0:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 1:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 2:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 3:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 4:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 5:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 6:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 7:
                                        tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                    + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                }
                            }
                        }
                    }
                    if (language == true)
                    {
                        BodyMassIndex();
                    }
                    else if (language == false)
                    {
                        EngBodyMassIndex();
                    }

                }

                catch (FormatException)
                {
                    MessageBox.Show("Перевірте корректність введених даних\nДив.інструкцію користувача\"Програма->Інструкція користувача\"");
                }

                catch (InvalidOperationException)
                {
                    MessageBox.Show("Встановіть додаток \"AccessDatabaseEngine\"\n з папки \"Додаток\"");
                }
                catch (OleDbException)
                {
                    if (File.Exists(tbPathToFile.Text))
                    {
                        MessageBox.Show("Невірні поля у завантаженому файлі\nДив.інструкцію користувача\"Програма->Інструкція користувача\"");
                    }
                    else if (!File.Exists(tbPathToFile.Text))
                    {
                        MessageBox.Show("Файл не знайдено\nВиберіть інший файл!");
                    }
                }
                catch (AccessViolationException)
                {
                    MessageBox.Show("База даних має неправельний формат\n(Не є файлом Excel або має неправильне розрішеня)");
                }
                catch
                {
                    MessageBox.Show("Неможливо визначити групу ризику, осільки не знайдено результуючої таблиці");
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл\nНатисніть Файл->Відкрити");
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

        private string ReadFile(string read, int i)
        {
            string path = "";
            if (rbtCl8.Checked)
            {
                path = Environment.CurrentDirectory + "/Table/Character.xlsx";
            }
            else if (rbtCl4.Checked)
            {
                path = Environment.CurrentDirectory + "/Table/CharacterCl5.xlsx";
            }

            string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            OleDbConnection conn = new OleDbConnection(stringcoon);
            // conn.Open();

            try
            {
                if (rbtnMan.Checked == true)
                {
                    if (language == true)
                    {
                        read = Character(conn, "[Чоловіки$]", read, i);
                        conn.Close();
                    }
                    else if (language == false)
                    {
                        read = Character(conn, "[Men$]", read, i);
                        conn.Close();
                    }

                }
                else
                {
                    if (language == true)
                    {
                        read = Character(conn, "[Жінки$]", read, i);
                        conn.Close();
                    }
                    else if (language == false)
                    {
                        read = Character(conn, "[Women$]", read, i);
                        conn.Close();
                    }


                }
            }
            catch
            {
                MessageBox.Show("Файл з рекомендаціями не знайдено");
                read = "\nДані відснутні";
            }

            return read;
        }

        private void Next()
        {
            try
            {
                flag = true;
                if (cbMan.Checked == true && cbWoman.Checked == true)
                {
                    MessageBox.Show("Виберіть один варінт статі!");
                }
                else if ((tbStudentTicket.Text != "" && tbStudentName.Text != ""
                    && tbSudentSurname.Text != "" && tbStudentFatherName.Text != "")
                    && (cbMan.Checked == true || cbWoman.Checked == true))
                {
                    int course = Convert.ToInt16(tbCourse.Text);
                    int height = Convert.ToInt16(tbStudentHeight.Text);
                    int weight = Convert.ToInt16(tbStudentWeight.Text);
                    int age = Convert.ToInt16(tbStudentAge.Text);

                    tabPageDB.Parent = tabControl1;
                    tabPageScience.Parent = tabControl1;
                    tabControl1.SelectedTab = tabPageScience;

                }
                else
                {
                    MessageBox.Show("Заповніть усі поля!");
                }
            }
            catch
            {
                MessageBox.Show("Перевірте коректність введених даних!\nДив.інструкцію користувача\"Програма->Інструкція користувача\"");
            }
        }

        private void Save()
        {
            try
            {
                Data();
                //string studentDB = "StudentsDB.mdb";
                string studentDB = Environment.CurrentDirectory + "\\Table\\StudentsDB.mdb";
                if (cbMan.Checked == true && cbWoman.Checked == true)
                {
                    MessageBox.Show("Виберіть один варінт статі!");
                }
                else
                {
                    if (File.Exists(studentDB))
                    {
                        SaveDate();
                    }
                    else
                    {
                        CreateDBtablesColumn();
                        SaveDate();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Дані не збережено!\nПеревірте корректність введених даних у вкладці\n\"Дослідження\"");
            }
        }

        private void btnCulculate_Click(object sender, EventArgs e)
        {
            try
            {
                Culculate();
            }
            catch (AccessViolationException)
            {
                MessageBox.Show("Не вдається завантажити дані./nВідсутнє з'єднання з базою даних");
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbPathToFile.Text = ofd.FileName;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            flag = false;
            tabPageDB.Parent = tabControl1;
            tabPageScience.Parent = tabControl1;
            tabControl1.SelectedTab = tabPageScience;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void rbtCl8_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(Environment.CurrentDirectory + "/Table"))
                {
                    //work.CreateFile();
                    work.ReadFile(dataGridViewExcel, rbtnWoman, rbtnMan, rbtCl4, rbtCl8);
                    tbPathToFile.Text = work.ReadFile(dataGridViewExcel, rbtnWoman, rbtnMan, rbtCl4, rbtCl8);
                }
                else
                {
                    //DirectoryInfo di = Directory.CreateDirectory(Environment.CurrentDirectory + "/Table");
                    //work.CreateFile();
                    work.ReadFile(dataGridViewExcel, rbtnWoman, rbtnMan, rbtCl4, rbtCl8);
                    tbPathToFile.Text = work.ReadFile(dataGridViewExcel, rbtnWoman, rbtnMan, rbtCl4, rbtCl8);
                }
            }
            catch (AccessViolationException)
            {
                MessageBox.Show("Не вдається завантажити дані./nВідсутнє з'єднання з базою даних");
            }
        }

        private void rbtnMan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rbtCl8.Text = "7";
                work.ReadFile(dataGridViewExcel, rbtnWoman, rbtnMan, rbtCl4, rbtCl8);
            }
            catch (AccessViolationException)
            {
                MessageBox.Show("Не вдається завантажити дані./nВідсутнє з'єднання з базою даних");
            }
        }

        private void RbtnWoman_CheckedChanged(object sender, EventArgs e)
        {
            rbtCl8.Text = "8";
        }

        private void CbMan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMan.Checked)
            {
                cbWoman.Checked = false;
            }
        }

        private void CbWoman_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWoman.Checked)
            {
                cbMan.Checked = false;
            }
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

        private void MonoWindow_FormClosed(object sender, FormClosedEventArgs e)
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
