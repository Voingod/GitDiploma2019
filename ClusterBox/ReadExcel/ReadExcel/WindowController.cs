using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClusterBox
{
    public static class WindowController
    {
        public static Instruction instr;
        public static Legend legend;
        public static About aboutProgram;
        public static AboutUS aboutUs;

        public static StartWindow startWindow;
        public static MonoWindow monoWindow;
        public static GlobalWindow globalWindow;
        public static YesNo yesNoWindow;
        public static UniversalWindow universalWindow;
        public static RegressionWindow vectorWindow;
        public static CuclClusterChange clusterChangeWindow;

        public static void ShowStartWindow()
        {
            if (startWindow == null)
            {
                startWindow = new StartWindow();
                startWindow.Show();
            }
            else
                startWindow.Show();
        }
        public static void ShowChangeWindow()
        {
            if (clusterChangeWindow == null)
            {
                clusterChangeWindow = new CuclClusterChange();
                clusterChangeWindow.Show();
            }
            else
                clusterChangeWindow.Show();
        }
        public static void ShowMonoWindow()
        {
            if (monoWindow == null)
            {
                monoWindow = new MonoWindow();
                monoWindow.Show();
            }
            else
                monoWindow.Show();
        }

        public static void ShowGlobalWindow()
        {
            if (globalWindow == null)
            {
                globalWindow = new GlobalWindow();
                globalWindow.Show();
            }
            else
                globalWindow.Show();
        }

        public static void ShowYesNoWindow()
        {
            if (yesNoWindow == null)
            {
                yesNoWindow = new YesNo();
                yesNoWindow.Show();
            }
            else
                yesNoWindow.Show();
        }

        public static void ShowUniversalWindow()
        {
            if (universalWindow == null)
            {
                universalWindow = new UniversalWindow();
                universalWindow.Show();
            }
            else
                universalWindow.Show();
        }

        public static void ShowVectorRegressionWindow()
        {
            if (vectorWindow == null)
            {
                vectorWindow = new RegressionWindow();
                vectorWindow.Show();
            }
            else
                vectorWindow.Show();
        }

        public static void ShowInstruction()
        {
            if (instr == null)
            {
                instr = new Instruction();
                instr.ShowDialog();
            }
            else
                instr.ShowDialog();
        }

        public static void ShowAboutProgram()
        {
            if (aboutProgram == null)
            {
                aboutProgram = new About();
                aboutProgram.ShowDialog();
            }
            else
                aboutProgram.ShowDialog();
        }

        public static void ShowAboutUs()
        {
            if (aboutUs == null)
            {
                aboutUs = new AboutUS();
                aboutUs.ShowDialog();
            }
            else
                aboutUs.ShowDialog();
        }

        public static void ShowLegend( )
        {
            if (legend == null)
            {
                legend = new Legend();
                legend.ShowDialog();
            }
            else
                legend.ShowDialog();
        }

        public static void ExitIfNoWindow()
        {
            if (!(
              (startWindow != null ? startWindow.Visible : false) ||
              (monoWindow != null ? startWindow.Visible : false) ||
              (globalWindow != null ? globalWindow.Visible : false) ||
              (universalWindow != null ? universalWindow.Visible : false) ||
              (vectorWindow != null ? vectorWindow.Visible : false) ||
              (yesNoWindow != null ? yesNoWindow.Visible : false)
             ))
            {
                Application.Exit();
            }
        }
    }
}
