using System;
using System.Windows.Forms;

namespace ClusterBox
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
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

        //private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    base.Capture = false;
        //    Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
        //    this.WndProc(ref m);
        //}

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

        private void StartWindow_FormClosed(object sender, FormClosedEventArgs e)
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
