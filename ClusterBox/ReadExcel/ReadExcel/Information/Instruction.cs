using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterBox
{
    public partial class Instruction : Form
    {
        public static InstAutoSurveySave infoUni;
        public static InfoBD database;
        public static InfoTable infoTable;

        public Instruction()
        {
            InitializeComponent();
        }

        private void btnAutorisation_Click(object sender, EventArgs e)
        {
            infoUni = new InstAutoSurveySave();
            infoUni.Text = "Авторизація";
            infoUni.infoText = "Для успішної авторизації в програмі необхідно " +
            "заповнити всі поля,що наведені на екрані. Слід зазначити, що " +
            "поля курс, вік, зріс та вага повинні містити лише цілі числа (0,1,2 і т.д.)." +
            "Всі інші поля, які передбачають введення даних, можуть містити як числа, так і букви " +
            "Якщо авторизація у програмі непотрібна, цього кроку можна уникнути, " +
            "натиснувши клавішу \"Пропустити\".";
            infoUni.Location = this.Location;
            infoUni.ShowDialog();
        }

        private void btnSurvey_Click(object sender, EventArgs e)
        {
            infoUni = new InstAutoSurveySave();
            infoUni.Text = "Дослідження";
            infoUni.infoText = "Вкладка \"Дослідження\" передбачає заповнення всіх полів " +
            "артеріального тиску та пульсу (від АТС0, АТД0, ЧСС0 до АТС5, АТД5, ЧСС5) " +
            "цілими числами. Дані параметри мають верхню та нижню границі, що регулюються " +
            "автоматично. Параметри ваги та зросту повинні також містити лише цілі числа. " +
            "Ці значення необхідні лише для визначення індексу маси тіла і не впливають на " +
            "віднесення студенту до певного кластеру";
            infoUni.Location = this.Location;
            infoUni.ShowDialog();
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            //lbText.Text = 
            infoUni = new InstAutoSurveySave();
            infoUni.Text = "Збереження";
            infoUni.infoText = "Щоб зберегти дані необхідно вибрати вкладку \"Файл->Зберегти\"\n" +
            "Для збереження даних до бази даних необхідно впевнитися, що " +
            "всі поля для визначення функціональних реакцій на тестове навантаження " +
            "заповнені коректно. Також необхідно переконатися, що при існуванні бази даних " +
            "\"StudentsDB.mdb\", вона містить необхідну таблицю для збереження даних з " +
            "відповідними полями.";
            infoUni.Location = this.Location;
            infoUni.ShowDialog();
        }

        private void btnBD_Click(object sender, EventArgs e)
        {
            database = new InfoBD();
            database.ShowDialog();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            infoTable = new InfoTable();
            infoTable.ShowDialog();
        }

        private void Instruction_FormClosed(object sender, FormClosedEventArgs e)
        {
            WindowController.instr = null;
        }
    }
}
