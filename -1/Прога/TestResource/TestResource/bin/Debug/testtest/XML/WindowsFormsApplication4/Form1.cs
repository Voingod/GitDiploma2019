using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Data.OleDb;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;



namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(openFileDialog1.FileName);
                sr.Close();
            }

            try
            {
                const string CONNECTION_STRING = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 8.0;";
                const string QUERY_EXCEL = "SELECT * FROM[Лист1$]";
                string connection_String = string.Format(CONNECTION_STRING, openFileDialog1.FileName);
                OleDbDataAdapter adapter = new OleDbDataAdapter(QUERY_EXCEL, connection_String);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                MessageBox.Show("Файл успешно считан!", "Считывания excel файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка при считывании excel файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        
        private void button2_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Xml files (*.xml)|*.xml";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;
            saveDialog.InitialDirectory = "c:\\";
            saveDialog.FileName = "XML_File";
            saveDialog.Title = "XML_Export";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XDocument doc = new XDocument(new XElement(XName.Get("Root")));
                    XElement row = null;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        row = new XElement(XName.Get("Row"), new XAttribute(XName.Get("Number"), i));
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                           
                            XElement cell = new XElement(XName.Get("Column"), new XAttribute(XName.Get("Number"), j));
                            cell.Value = String.Format("{0:0.00}", dataGridView1.Rows[i].Cells[j].Value);
                            row.Add(cell); 
                        }    

                        doc.Root.Add(row);                 

                    } 
                    doc.Save(saveDialog.FileName);

                    MessageBox.Show("Файл успешно сохранен!", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }
}

