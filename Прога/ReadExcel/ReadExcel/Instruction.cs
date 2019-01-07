using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadExcel
{
    public partial class Instruction : Form
    {
        public Instruction()
        {
            InitializeComponent();
        }
        private void Instruction_Load(object sender, EventArgs e)
        {  
            btnAutorisation.Text = "Введення даних у вкладці \"Авторизація\"";
            btnBD.Text = "Налаштування імені та полів бази даних \nдля реєстрації результатів";
            btnSurvey.Text = "Введення даних у вкладці \"Дослідження\"";
            btnTable.Text = "Приведення резльутючої таблиці \nдо прийнятного вигляду";
        }
        private void btnAutorisation_Click(object sender, EventArgs e)
        {
            lbText.Text = "Для успішної авторизації в програмі необхідно "+ 
            "заповнити всі поля,що наведені на екрані. Слід зазначити, що "+
            "поля курс, вік, зріс та вага повинні містити лише цілі числа (0,1,2 і т.д.)."+
            "Всі інші поля, які передбачають введення даних, можуть містити як числа, так і букви "+
            "Якщо авторизація у програмі непотрібна, цього кроку можна уникнути, "+
            "натиснувши клавішу \"Пропустити\"."; 
            InstAutoSurveySave info = new InstAutoSurveySave(this);
            info.Text = "Авторизація";
            info.Show();
            this.Close();
        }
        private void btnSurvey_Click(object sender, EventArgs e)
        {
            lbText.Text = "Вкладка \"Дослідження\" передбачає заповнення всіх полів "+
            "артеріального тиску та пульсу (від АТС0, АТД0, ЧСС0 до АТС5, АТД5, ЧСС5) " +
            "цілими числами. Дані параметри мають верхню та нижню границі, що регулюються "+
            "автоматично. Параметри ваги та зросту повинні також містити лише цілі числа. "+
            "Ці значення необхідні лише для визначення індексу маси тіла і не впливають на "+
            "віднесення студенту до певного кластеру";
            InstAutoSurveySave info = new InstAutoSurveySave(this);
            info.Text = "Дослідження";
            info.Show();
            this.Close();
        }
        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            lbText.Text = "Щоб зберегти дані необхідно вибрати вкладку \"Файл->Зберегти\"\n"+
                "Для збереження даних до бази даних необхідно впевнитися, що "+
                "всі поля для визначення функціональних реакцій на тестове навантаження "+
                "заповнені коректно. Також необхідно переконатися, що при існуванні бази даних "+
                "\"StudentsDB.mdb\", вона містить необхідну таблицю для збереження даних з "+
                "відповідними полями.";
            InstAutoSurveySave info = new InstAutoSurveySave(this);
            info.Text = "Збереження";
            info.Show();
            this.Close();
        }
        public string MyMethod
        {
            set
            {
                lbText.Text = value;
            }
            get
            {
                return lbText.Text;
            }
        }
        private void btnBD_Click(object sender, EventArgs e)
        {
            InfoBD database = new InfoBD();
            database.Show();
            this.Close();
        }
        private void btnTable_Click(object sender, EventArgs e)
        {
            InfoTable table = new InfoTable();
            table.Show();
            this.Close();
        }
    }
}
