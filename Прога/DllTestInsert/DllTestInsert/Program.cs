using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DllTestInsert
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {


            //Для обработки исключений в этом файле
            
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            //Запуск dll без ее выгрузки в папку
            // AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form2());
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Программные модули не загружены. \nТребуется перезагрузка приложения");
            }
        }
        //Запуск dll без ее выгрузки в папку
        //private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        //{
        //    var assemblyName = new AssemblyName(args.Name).Name;
        //    if (assemblyName == "DllTestOut")
        //    {
        //        using (var stream = typeof(Program).Assembly.GetManifestResourceStream("DllTestInsert." + assemblyName + ".dll"))
        //        {
        //            byte[] assemblyData = new byte[stream.Length];
        //            stream.Read(assemblyData, 0, assemblyData.Length);
        //            return Assembly.Load(assemblyData);
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
