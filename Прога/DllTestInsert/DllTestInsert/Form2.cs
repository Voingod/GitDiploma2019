using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DllTestOut;

namespace DllTestInsert
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
            NewDirectory("/Lib");
            Resource("DllTestInsert.exe.config","/DllTestInsert.exe.config");
            Resource("DllTestOut.dll","/Lib/DllTestOut.dll");
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void Resource(string res, string respath)
        {
            if (!File.Exists(Environment.CurrentDirectory + respath))
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                Stream stream = currentAssembly.GetManifestResourceStream("DllTestInsert."+ res);
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + respath, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
                
            }
        }
        private void NewDirectory(string dir)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + dir))
            {
                DirectoryInfo di = Directory.CreateDirectory(Environment.CurrentDirectory + dir);
            }
        }


    }

    }



