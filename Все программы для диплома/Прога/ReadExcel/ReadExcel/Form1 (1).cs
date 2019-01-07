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
using System.IO;
using ADOX;


namespace ReadExcel
{
    public partial class Form1 : Form
    {

        bool flag = false;
        bool language=true;
        int cluster = 0;
        double distantiont = 0;
        double[] radiusCl = new double[8];
        double dataExcelFormat;

        public Form1()
        {
            InitializeComponent();
            //tbPathToFile.Visible = false;
            tbPathToFile.Visible = true;
            rbtnWoman.Checked = true;
            tabPageDB.Parent = null;
            tabPageScience.Parent = null;
            tabPageGlobalMode.Parent = null;


        }
        // Считывание с результирующей таблицы
        private void btnStart_Click()
        {
                tbPathToFile.Text = "D:\\Google\\МАГИСТРАТРА\\ДИПЛОМ\\ResultTableForReturn.xlsx";
               //tbPathToFile.Text = "C:\\Users\\Богдан\\Google Диск\\МАГИСТРАТРА\\ДИПЛОМ\\ResultTableForReturn.xlsx";
                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbPathToFile.Text + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                Console.WriteLine(stringcoon);
                OleDbConnection conn = new OleDbConnection(stringcoon);
                if (rbtnWoman.Checked)
                {
                    radiusCl = new double[] { 18.63, 22.13, 18.41, 20.53, 19.22, 20.60, 17.49, 18.95 };

                    OleDbDataAdapter da = new OleDbDataAdapter("Select Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7,Cl8 from [" + rbtnWoman.Text + "$]", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewExcel.AllowUserToAddRows = false;
                    dataGridViewExcel.DataSource = dt;
                }
                else if (rbtnMan.Checked)
                {
                    radiusCl = new double[] { 25.48, 20.49, 21.24, 27.49, 28.52, 23.79, 23.04 };

                    OleDbDataAdapter da = new OleDbDataAdapter("Select Parametr,Cl1,Cl2,Cl3,Cl4,Cl5,Cl6,Cl7 from [" + rbtnMan.Text + "$]", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewExcel.AllowUserToAddRows = false;
                    dataGridViewExcel.DataSource = dt;
                }

            //row- строка
            //column - столбец
        }
        private double[] Data ()
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
        //Определение минимального и субминимального расстояния, определение класстера и характеристик с выводом на экран
        private void btnCulculate_Click(object sender, EventArgs e)
        {
            if (tbPathToFile.Visible == true)
            { 
                try
                {
                    double[] DataEnter = new double[18];
                    double dist = 0.0;
                    Data();
                    DataEnter = Data();
                    btnStart_Click();

                   
                    List<double> SummClasters = new List<double>();

                    for (int i = 1; i < dataGridViewExcel.Columns.Count; ++i)
                    {
                        double summ = 0;
                        for (int j = 1; j < dataGridViewExcel.Rows.Count; ++j)
                        {
                            double.TryParse(dataGridViewExcel[i, j].Value.ToString(), out dataExcelFormat);
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
                    for (int i = 0; i < DataEnter.Length;i++ )
                    {
                        dist += DataEnter[i];
                    }
                    double middle = (dist / 18);
                    double min = SummClastersCopy[0];
                    double nextMin = SummClastersCopy[1];
                    string read = "";
                    double middlePoint=0.0;

                    for (int i = 0; i < DataEnter.Length;i++ )
                    {
                        middlePoint += Math.Abs(DataEnter[i] - middle);
                    }
                    tbResult.Clear();
                    tbRecomend.Clear();
                    tbIndexMass.Clear();

                    for (int i = 0; i < SummClasters.Count; i++)
                    {
                        if (min == SummClasters[i])
                        {
                            switch (i)
                            {
                                case 0: tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " +(distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 1: tbResult.Text += "The student belongs to the cluster *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " + (distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 2: tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " + (distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 3: tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " + (distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 4: tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " + (distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 5: tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " + (distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 6: tbResult.Text += "Студент відноситься до кластеру *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " + (distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                                case 7: tbResult.Text += "Студент відноситься до кластеру  *" + (i + 1) + "*" + Environment.NewLine +
                                    "Мінімальна відстань до кластеру становить: " + (distantiont=Math.Round(SummClasters[i], 2)) + Environment.NewLine + Environment.NewLine +
                                    "Кластер має наступні характристики: " + ReadFile(read, i + 1); cluster = i + 1; break;
                            }

                        }
                    }

                    if ((Math.Round((middlePoint/18),2)> radiusCl[cluster - 1]) || (nextMin < ((min * 0.16) + min)))
                    {
                        for (int i = 0; i < SummClasters.Count; i++)
                        {
                            if (nextMin == SummClasters[i])
                            {
                                switch (i)
                                {
                                    case 0: tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 1: tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 2: tbRecomend.Text += "The next distance after the minimum is *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "This is a cluster *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "The cluster has the following characteristics: " + ReadFile(read, i + 1); break;
                                    case 3: tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 4: tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 5: tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 6: tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                    case 7: tbRecomend.Text += "Наступна відстань після мінімальної становить *" + Math.Round(SummClasters[i], 2) + "*"
                                        + Environment.NewLine + "Це кластер *" + (i + 1) + "*" + Environment.NewLine + Environment.NewLine +
                                        "Кластер має наступні характристики: " + ReadFile(read, i + 1); break;
                                }
                            }
                        }
                    }
                    if(language==true)
                    {
                        BodyMassIndex();
                    }
                    else if(language==false)
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
                        tbPathToFile.Visible = true;
                        MessageBox.Show("Файл не знайдено\nВиберіть інший файл!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть файл\nНатисніть Файл->Відкрити");
            }    
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbPathToFile.Visible = true;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbPathToFile.Text = ofd.FileName;
            }
        }
        private string ReadFile(string read, int i)
        {
            try
            {
                string abc = Convert.ToString(i);
                
                if (rbtnMan.Checked == true)
                {
                    if (language == true)
                    {
                        read = System.IO.File.ReadAllText(@"Чоловіки\" + abc + ".txt", Encoding.Default);
                    }
                    else if (language == false)
                    {
                        read = System.IO.File.ReadAllText(@"Men\" + abc + ".txt", Encoding.Default);
                    }
                   
                }
                else
                {
                    if (language==true)
                    {
                        read = System.IO.File.ReadAllText(@"Жінки\" + abc + ".txt", Encoding.Default);
                    }
                    else if (language==false)
                    {
                        read = System.IO.File.ReadAllText(@"Women\" + abc + ".txt", Encoding.Default);
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
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(16)))), ((int)(((byte)(26)))));
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            
            try
            {
                flag = true;
                if (cbMan.Checked == true && cbWoman.Checked == true)
                {
                    MessageBox.Show("Виберіть один варінт статі!");
                }
                else if ((tbStudentTicket.Text != ""&&tbStudentName.Text!=""
                    &&tbSudentSurname.Text!=""&& tbStudentFatherName.Text!="")
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
        private void btnPass_Click(object sender, EventArgs e)
        {
            flag = false;
            tabPageDB.Parent = tabControl1;
            tabPageScience.Parent = tabControl1;
            tabControl1.SelectedTab = tabPageScience;
        }
        private void CreateDBtablesColumn()
        {
            try
            {
                string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=StudentsDB.mdb;Jet OLEDB:Engine Type=5";
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
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Data();
                string studentDB = "StudentsDB.mdb";
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
        private void SaveDate()
        {
            try
            {
                string sex = "";
                if(cbMan.Checked)
                {
                    sex = cbMan.Text;
                }
                else if(cbWoman.Checked)
                {
                    sex = cbWoman.Text;
                }
                
                using (var connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=StudentsDB.mdb;Jet OLEDB:Engine Type=5"))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        if(flag==true)
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
                if(Height!=100||Weight!=51)
                {
                    double BMindex;
                    BMindex=Math.Round((Weight/(Height*Height))*10000,2);
                    if (BMindex<=16)
                    {
                        tbIndexMass.Text +="Індекс маси тіла складає: "+ Convert.ToString(BMindex)+Environment.NewLine;
                        tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Виражений дефіцит ваги тіла";
                    }
                    else if (BMindex > 16 && BMindex<18.5)
                    {
                         tbIndexMass.Text +="Індекс маси тіла складає: "+ Convert.ToString(BMindex)+Environment.NewLine;
                         tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Недостатня ваги тіла";
                    }
                    else if (BMindex >= 18.5 && BMindex<25)
                    {
                         tbIndexMass.Text +="Індекс маси тіла складає: "+ Convert.ToString(BMindex)+Environment.NewLine;
                         tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Нормальний стан";
                    }
                    else if (BMindex >= 25 && BMindex < 30)
                    {
                         tbIndexMass.Text +="Індекс маси тіла складає: "+ Convert.ToString(BMindex)+Environment.NewLine;
                         tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Надлишкога вага тіла (передожиріння)";
                    }
                    else if (BMindex >= 30 && BMindex < 35)
                    {
                         tbIndexMass.Text +="Індекс маси тіла складає: "+ Convert.ToString(BMindex)+Environment.NewLine;
                         tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Ожиріння першого ступеня";
                    }
                    else if (BMindex >= 35 && BMindex < 40)
                    {
                         tbIndexMass.Text +="Індекс маси тіла складає: "+ Convert.ToString(BMindex)+Environment.NewLine;
                         tbIndexMass.Text += "*Характеристика:" + Environment.NewLine + "Ожиріння другого ступеня";
                    }
                    else if (BMindex >= 40)
                    {
                         tbIndexMass.Text +="Індекс маси тіла складає: "+ Convert.ToString(BMindex)+Environment.NewLine;
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

        private void PurposeProgramTSMenu_Click(object sender, EventArgs e)
        {
            About aboutProgramm = new About();
            aboutProgramm.Show();
        }
        private void LegendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Legend legend = new Legend();
            legend.Show();
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

        private void EngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            language = false;
            this.btnCulculate.Text = "Calculate";
            this.label21.Text = "Result and recomendation";
            this.label12.Text = "HR5";
            this.label13.Text = "SAP5";
            this.label14.Text = "DAP5";
            this.label15.Text = "HR4";
            this.label16.Text = "SAP4";
            this.label17.Text = "DAP4";
            this.label18.Text = "HR3";
            this.label19.Text = "SAP3";
            this.label20.Text = "DAP3";
            this.label9.Text = "HR2";
            this.label10.Text = "SAP2";
            this.label11.Text = "DAP2";
            this.label5.Text = "HR1";
            this.label6.Text = "SAP1";
            this.label7.Text = "DAP1";
            this.label4.Text = "HR0";
            this.label3.Text = "SAP0";
            this.label8.Text = "DAP0";
            this.toolStripMenuItem1.Text = "File";
            this.OpenToolStripMenuItem.Text = "Open";
            this.SaveToolStripMenuItem.Text = "Save";
            this.CertificateToolStripMenuItem.Text = "Information";
            this.PurposeProgramTSMenu.Text = "Purpose of the program";
            this.LegendToolStripMenuItem.Text = "Legend";
            this.ProgramToolStripMenuItem.Text = "Program";
            this.ManualToolStripMenuItem.Text = "User manual";
            this.AboutToolStripMenuItem.Text = "About us";
            this.rbtnWoman.Text = "Women";
            this.rbtnMan.Text = "Men";
            this.tabPageScience.Text = "Research";
            this.label32.Text = "Body mass index";
            this.label31.Text = "Height";
            this.label30.Text = "Weight";
            this.tabPageAutorisation.Text = "Autoruzation";
            this.btnPass.Text = "Miss";
            this.btnNext.Text = "Continue";
            this.cbWoman.Text = "Women";       
            this.cbMan.Text = "Men";           
            this.label29.Text = "Date of birth";
            this.label28.Text = "Weight";
            this.label27.Text = "Height";
            this.label26.Text = "Course";
            this.label25.Text = "Age";
            this.label24.Text = "Sex";
            this.label23.Text = "Middle name";
            this.label22.Text = "Surname";
            this.label2.Text = "Name";
            this.label1.Text = "Educational ticket";
            this.tabPageDB.Text = "Database";
            this.LanguageToolStripMenuItem.Text = "Language";
            this.EngToolStripMenuItem.Text = "English";
            this.UkrToolStripMenuItem.Text = "Ukrainian";
        }

        private void UkrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            language = true;
            this.btnCulculate.Text = "Порахувати";
            this.label21.Text = "Результат і рекомендації";
            this.label12.Text = "ЧСС5";
            this.label13.Text = "АТС5";
            this.label14.Text = "АТД5";
            this.label15.Text = "ЧСС4";
            this.label16.Text = "АТС4";
            this.label17.Text = "АТД4";
            this.label18.Text = "ЧСС3";
            this.label19.Text = "АТС3";
            this.label20.Text = "АТД3";
            this.label9.Text = "ЧСС2";
            this.label10.Text = "АТС2";
            this.label11.Text = "АТД2";
            this.label5.Text = "ЧСС1";
            this.label6.Text = "АТС1";
            this.label7.Text = "АТД1";
            this.label4.Text = "ЧСС0";
            this.label3.Text = "АТС0";
            this.label8.Text = "АТД0";
            this.toolStripMenuItem1.Text = "Файл";
            this.OpenToolStripMenuItem.Text = "Відкрити";
            this.SaveToolStripMenuItem.Text = "Зберегти";
            this.CertificateToolStripMenuItem.Text = "Довідка";
            this.PurposeProgramTSMenu.Text = "Призначення програми";
            this.LegendToolStripMenuItem.Text = "Умовні позначення";
            this.ProgramToolStripMenuItem.Text = "Програма";
            this.ManualToolStripMenuItem.Text = "Інструкція користувача";
            this.AboutToolStripMenuItem.Text = "Про нас";
            this.rbtnWoman.Text = "Жінки";
            this.rbtnMan.Text = "Чоловіки";
            this.tabPageScience.Text = "Дослідження";
            this.label32.Text = "Індекс маси тіла";
            this.label31.Text = "Зріст";
            this.label30.Text = "Вага";
            this.tabPageAutorisation.Text = "Авторизація";
            this.btnPass.Text = "Пропустити";
            this.btnNext.Text = "Продовжити";
            this.cbWoman.Text = "Жінка";
            this.cbMan.Text = "Чоловік";
            this.label29.Text = "Дата народження";
            this.label28.Text = "Вага";
            this.label27.Text = "Зріст";
            this.label26.Text = "Курс";
            this.label25.Text = "Вік";
            this.label24.Text = "Стать";
            this.label23.Text = "По батькові";
            this.label22.Text = "Прізвище";
            this.label2.Text = "Ім\'я";
            this.label1.Text = "№ учбового квитка";
            this.tabPageDB.Text = "База даних";
            this.LanguageToolStripMenuItem.Text = "Мова";
            this.EngToolStripMenuItem.Text = "Англійська";
            this.UkrToolStripMenuItem.Text = "Українська";
        }
        //Проведение глобального анализа с определением класстаре для каждого студента
        private void CheckBoxGM_Click(object sender, EventArgs e)
        {
            if (checkBoxGM.Checked)
            {
                double dataExcelGlobalFormat;
                tabPageGlobalMode.Parent = tabControl1;

                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    tbPathToFileGM.Text = ofd.FileName;
                }

                string stringcoon = " Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbPathToFileGM.Text + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
                Console.WriteLine(stringcoon);
                OleDbConnection conn = new OleDbConnection(stringcoon);
                if (rbtnWoman.Checked)
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from [Ж$] ", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewExcelGlobal.AllowUserToAddRows = false;
                    dataGridViewExcelGlobal.DataSource = dt;
                }
                else if (rbtnMan.Checked)
                {
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from [М$]", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewExcelGlobal.AllowUserToAddRows = false;
                    dataGridViewExcelGlobal.DataSource = dt;
                }

                //double.TryParse(dataGridViewExcelGlobal[1, 0].Value.ToString(), out dataExcelGlobalFormat);

                double summ = 0;
                for (int k=1;k<dataGridViewExcelGlobal.Columns.Count;k++)
                {
                    List<double> SummClasters = new List<double>();
                    for (int i = 1; i < dataGridViewExcel.Columns.Count; i++)
                    {
                        summ = 0;
                        for (int j = 1; j < dataGridViewExcel.Rows.Count; j++)
                        {

                            double.TryParse(dataGridViewExcel[i, j].Value.ToString(), out dataExcelFormat);
                            double.TryParse(dataGridViewExcelGlobal[k, j].Value.ToString(), out dataExcelGlobalFormat);
                            summ += Math.Pow((dataExcelFormat - dataExcelGlobalFormat), 2);

                            // Console.WriteLine(dataGridViewExcel[j, i].Value);
                            //Console.WriteLine(dataGridViewExcelGlobal[i, j].Value);
                        }
                        SummClasters.Add(summ);
                        Console.WriteLine(summ);

                    }
                    List<double> SummClastersCopy = new List<double>();

                    for (int i = 0; i < SummClasters.Count; i++)
                    {
                        SummClastersCopy.Add(SummClasters[i]);
                    }
                    SummClastersCopy.Sort();
                    double min = SummClastersCopy[0];
                    double nextMin = SummClastersCopy[1];
                    // StreamWriter sw = new StreamWriter("D:\\Test.txt", true);
                    StreamWriter sw = new StreamWriter("D:\\minCluster.txt", true);
                    for (int i = 0; i < SummClasters.Count; i++)
                    {
                        if (min == SummClasters[i])
                        {
                            switch (i)
                            {
                                case 0: sw.WriteLine(i + 1); sw.Close(); break;
                                case 1: sw.WriteLine(i + 1); sw.Close(); break;
                                case 2: sw.WriteLine(i + 1); sw.Close(); break;
                                case 3: sw.WriteLine(i + 1); sw.Close(); break;
                                case 4: sw.WriteLine(i + 1); sw.Close(); break;
                                case 5: sw.WriteLine(i + 1); sw.Close(); break;
                                case 6: sw.WriteLine(i + 1); sw.Close(); break;
                                case 7: sw.WriteLine(i + 1); sw.Close(); break;

                            }
                        }
                    }

                    StreamWriter sw2 = new StreamWriter("D:\\SubMinCluster.txt", true);
                    for (int i = 0; i < SummClasters.Count; i++)
                    {
                        if (nextMin == SummClasters[i])
                        {
                            switch (i)
                            {
                                case 0: sw2.WriteLine(i + 1); sw2.Close(); break;
                                case 1: sw2.WriteLine(i + 1); sw2.Close(); break;
                                case 2: sw2.WriteLine(i + 1); sw2.Close(); break;
                                case 3: sw2.WriteLine(i + 1); sw2.Close(); break;
                                case 4: sw2.WriteLine(i + 1); sw2.Close(); break;
                                case 5: sw2.WriteLine(i + 1); sw2.Close(); break;
                                case 6: sw2.WriteLine(i + 1); sw2.Close(); break;
                                case 7: sw2.WriteLine(i + 1); sw2.Close(); break;
                            }
                        }
                    }
                }



            }
        }
    }
}
