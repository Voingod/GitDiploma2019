namespace ReadExcel
{
    partial class GlobalWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalWindow));
            this.btnCulc = new System.Windows.Forms.Button();
            this.dataGridViewGlobal = new System.Windows.Forms.DataGridView();
            this.rbtnWoman = new System.Windows.Forms.RadioButton();
            this.rbtnMan = new System.Windows.Forms.RadioButton();
            this.tbPathToFileGM = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PurposeProgramTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LegendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UkrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbtCl8 = new System.Windows.Forms.RadioButton();
            this.rbtCl4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobal)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCulc
            // 
            this.btnCulc.Location = new System.Drawing.Point(60, 211);
            this.btnCulc.Name = "btnCulc";
            this.btnCulc.Size = new System.Drawing.Size(75, 23);
            this.btnCulc.TabIndex = 0;
            this.btnCulc.Text = "Порахувати";
            this.btnCulc.UseVisualStyleBackColor = true;
            this.btnCulc.Click += new System.EventHandler(this.btnCulc_Click);
            // 
            // dataGridViewGlobal
            // 
            this.dataGridViewGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGlobal.Location = new System.Drawing.Point(43, 42);
            this.dataGridViewGlobal.Name = "dataGridViewGlobal";
            this.dataGridViewGlobal.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewGlobal.TabIndex = 1;
            // 
            // rbtnWoman
            // 
            this.rbtnWoman.AutoSize = true;
            this.rbtnWoman.Location = new System.Drawing.Point(412, 79);
            this.rbtnWoman.Name = "rbtnWoman";
            this.rbtnWoman.Size = new System.Drawing.Size(56, 17);
            this.rbtnWoman.TabIndex = 2;
            this.rbtnWoman.TabStop = true;
            this.rbtnWoman.Text = "Жінки";
            this.rbtnWoman.UseVisualStyleBackColor = true;
            // 
            // rbtnMan
            // 
            this.rbtnMan.AutoSize = true;
            this.rbtnMan.Location = new System.Drawing.Point(412, 125);
            this.rbtnMan.Name = "rbtnMan";
            this.rbtnMan.Size = new System.Drawing.Size(71, 17);
            this.rbtnMan.TabIndex = 3;
            this.rbtnMan.TabStop = true;
            this.rbtnMan.Text = "Чоловіки";
            this.rbtnMan.UseVisualStyleBackColor = true;
            // 
            // tbPathToFileGM
            // 
            this.tbPathToFileGM.Location = new System.Drawing.Point(412, 171);
            this.tbPathToFileGM.Name = "tbPathToFileGM";
            this.tbPathToFileGM.Size = new System.Drawing.Size(100, 20);
            this.tbPathToFileGM.TabIndex = 4;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(191, 210);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Відкрити";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(99, 250);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(128, 23);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "Вивести результат";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.CertificateToolStripMenuItem,
            this.ProgramToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.OpenToolStripMenuItem.Text = "Відкрити";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // CertificateToolStripMenuItem
            // 
            this.CertificateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PurposeProgramTSMenu,
            this.LegendToolStripMenuItem});
            this.CertificateToolStripMenuItem.Name = "CertificateToolStripMenuItem";
            this.CertificateToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.CertificateToolStripMenuItem.Text = "Довідка";
            // 
            // PurposeProgramTSMenu
            // 
            this.PurposeProgramTSMenu.Name = "PurposeProgramTSMenu";
            this.PurposeProgramTSMenu.Size = new System.Drawing.Size(203, 22);
            this.PurposeProgramTSMenu.Text = "Призначення програми";
            this.PurposeProgramTSMenu.Click += new System.EventHandler(this.PurposeProgramTSMenu_Click);
            // 
            // LegendToolStripMenuItem
            // 
            this.LegendToolStripMenuItem.Name = "LegendToolStripMenuItem";
            this.LegendToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.LegendToolStripMenuItem.Text = "Умовні позначення";
            this.LegendToolStripMenuItem.Click += new System.EventHandler(this.LegendToolStripMenuItem_Click);
            // 
            // ProgramToolStripMenuItem
            // 
            this.ProgramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManualToolStripMenuItem,
            this.LanguageToolStripMenuItem});
            this.ProgramToolStripMenuItem.Name = "ProgramToolStripMenuItem";
            this.ProgramToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.ProgramToolStripMenuItem.Text = "Програма";
            // 
            // ManualToolStripMenuItem
            // 
            this.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem";
            this.ManualToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.ManualToolStripMenuItem.Text = "Інструкція користувача";
            this.ManualToolStripMenuItem.Click += new System.EventHandler(this.ManualToolStripMenuItem_Click);
            // 
            // LanguageToolStripMenuItem
            // 
            this.LanguageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EngToolStripMenuItem,
            this.UkrToolStripMenuItem});
            this.LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            this.LanguageToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.LanguageToolStripMenuItem.Text = "Мова";
            // 
            // EngToolStripMenuItem
            // 
            this.EngToolStripMenuItem.Name = "EngToolStripMenuItem";
            this.EngToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.EngToolStripMenuItem.Text = "Англійська";
            // 
            // UkrToolStripMenuItem
            // 
            this.UkrToolStripMenuItem.Name = "UkrToolStripMenuItem";
            this.UkrToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.UkrToolStripMenuItem.Text = "Українська";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.AboutToolStripMenuItem.Text = "Про нас";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(778, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.TabIndex = 60;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // rbtCl8
            // 
            this.rbtCl8.AutoSize = true;
            this.rbtCl8.Location = new System.Drawing.Point(10, 3);
            this.rbtCl8.Name = "rbtCl8";
            this.rbtCl8.Size = new System.Drawing.Size(31, 17);
            this.rbtCl8.TabIndex = 61;
            this.rbtCl8.TabStop = true;
            this.rbtCl8.Text = "8";
            this.rbtCl8.UseVisualStyleBackColor = true;
            // 
            // rbtCl4
            // 
            this.rbtCl4.AutoSize = true;
            this.rbtCl4.Location = new System.Drawing.Point(10, 39);
            this.rbtCl4.Name = "rbtCl4";
            this.rbtCl4.Size = new System.Drawing.Size(31, 17);
            this.rbtCl4.TabIndex = 62;
            this.rbtCl4.TabStop = true;
            this.rbtCl4.Text = "4";
            this.rbtCl4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtCl8);
            this.panel1.Controls.Add(this.rbtCl4);
            this.panel1.Location = new System.Drawing.Point(412, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 63;
            // 
            // GlobalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbPathToFileGM);
            this.Controls.Add(this.rbtnMan);
            this.Controls.Add(this.rbtnWoman);
            this.Controls.Add(this.dataGridViewGlobal);
            this.Controls.Add(this.btnCulc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GlobalWindow";
            this.Text = "GlobalWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GlobalWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobal)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCulc;
        private System.Windows.Forms.DataGridView dataGridViewGlobal;
        private System.Windows.Forms.RadioButton rbtnWoman;
        private System.Windows.Forms.RadioButton rbtnMan;
        private System.Windows.Forms.TextBox tbPathToFileGM;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CertificateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PurposeProgramTSMenu;
        private System.Windows.Forms.ToolStripMenuItem LegendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UkrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbtCl8;
        private System.Windows.Forms.RadioButton rbtCl4;
        private System.Windows.Forms.Panel panel1;
    }
}