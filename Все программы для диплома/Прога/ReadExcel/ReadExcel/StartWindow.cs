using System;
using System.Windows.Forms;
using ClusterVector;
using UniversalWindow;

namespace ReadExcel
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
            GlobalWindow global = new GlobalWindow();
            global.ShowDialog();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.Show();
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
    

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void RegressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VectorFormStart vectorFormStart = new VectorFormStart();
            vectorFormStart.Show();
        }

        private void UniversalWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniversalWindowCl universalWindow = new UniversalWindowCl();
            universalWindow.Show();
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

        private void ManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instruction instruct = new Instruction();
            instruct.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUS us = new AboutUS();
            us.Show();
        }
    }
}
