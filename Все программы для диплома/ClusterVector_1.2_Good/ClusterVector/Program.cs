using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterVector
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new VectorFormStart());
            }
            catch (FileNotFoundException exeption)
            {
                string str = exeption.FileName;
                string trimmed = str.Trim();
                str = (trimmed.Substring(0, trimmed.IndexOf(',')));

                
                MessageBox.Show("Не знайдено модуль програми "+ str + ". Натисніть ОК,\nщоб завершити роботу програми.\nЗа необхідністю дивіться інструкцію користувача");
            }

        }
    }
}
