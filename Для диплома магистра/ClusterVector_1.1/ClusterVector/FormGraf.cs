using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterVector
{
    public partial class FormGraf : Form
    {
        public FormGraf()
        {
     
            InitializeComponent();
        }
        public void UpdateData()
        {
            lbRegress.Text = Form1.regressToGraf.ToString();
            lbCoef.Text = Form1.CoefToGraf.ToString();

            lbRegressM.Text = Form1.regressToGrafM.ToString();
            lbCoefM.Text = Form1.CoefToGrafM.ToString();

            List<int> ParametrsData = Form1.ParametrsDataToGraf;
            double[] ParametrsDataAfter = Form1.ParametrsDataAfterToGraf;

            List<int> ArrayMinutes = Form1.ArrayMinutesToGraf;

            List<int> ParametrsDataM = Form1.ParametrsDataToGrafM;
            List<int> ArrayMinutesM = Form1.ArrayMinutesToGrafM;

            chrtRegress.Series["RegressLineCL"].Points.Clear();
            chrtRegress.Series["RegressLineM"].Points.Clear();
            chrtRegress.ChartAreas[0].AxisY.Minimum = ParametrsData.Min() - 5;
            for (int i = 0; i < ParametrsData.Count; i++)
            {
                chrtRegress.Series["RegressLineCL"].Points.AddXY(ArrayMinutes[i], ParametrsDataAfter[i]);
            }

            for (int i = 0; i < ParametrsDataM.Count; i++)
            {
                chrtRegress.Series["RegressLineM"].Points.AddXY(ArrayMinutesM[i], ParametrsDataAfter[i]);
            }
            // код обновления


            //for (int i = 0; i < ParametrsDataAfter.Length; i++)
            //{
            //    Console.WriteLine(ParametrsDataAfter[i]);
            //}

            //for (int i = 0; i < ParametrsDataAfter.Length; i++)
            //{
            //    ParametrsDataAfterToGraf[i] = ParametrsDataAfter[i];
            //}
            //Console.WriteLine(Form1.ParametrsDataToGraf.Count);
        }
    }
}
