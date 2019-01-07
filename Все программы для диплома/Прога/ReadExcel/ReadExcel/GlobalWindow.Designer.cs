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
            this.опціїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GlobalClToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UniversalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModeClCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbtCl8 = new System.Windows.Forms.RadioButton();
            this.rbtCl4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobal)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCulc
            // 
            this.btnCulc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCulc.Location = new System.Drawing.Point(192, 502);
            this.btnCulc.Name = "btnCulc";
            this.btnCulc.Size = new System.Drawing.Size(128, 23);
            this.btnCulc.TabIndex = 0;
            this.btnCulc.Text = "Порахувати";
            this.btnCulc.UseVisualStyleBackColor = true;
            this.btnCulc.Click += new System.EventHandler(this.btnCulc_Click);
            // 
            // dataGridViewGlobal
            // 
            this.dataGridViewGlobal.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewGlobal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGlobal.Location = new System.Drawing.Point(29, 146);
            this.dataGridViewGlobal.Name = "dataGridViewGlobal";
            this.dataGridViewGlobal.Size = new System.Drawing.Size(654, 350);
            this.dataGridViewGlobal.TabIndex = 1;
            // 
            // rbtnWoman
            // 
            this.rbtnWoman.AutoSize = true;
            this.rbtnWoman.Checked = true;
            this.rbtnWoman.Location = new System.Drawing.Point(20, 23);
            this.rbtnWoman.Name = "rbtnWoman";
            this.rbtnWoman.Size = new System.Drawing.Size(56, 17);
            this.rbtnWoman.TabIndex = 2;
            this.rbtnWoman.TabStop = true;
            this.rbtnWoman.Text = "Жінки";
            this.rbtnWoman.UseVisualStyleBackColor = true;
            this.rbtnWoman.CheckedChanged += new System.EventHandler(this.rbtnWoman_CheckedChanged);
            // 
            // rbtnMan
            // 
            this.rbtnMan.AutoSize = true;
            this.rbtnMan.Location = new System.Drawing.Point(20, 46);
            this.rbtnMan.Name = "rbtnMan";
            this.rbtnMan.Size = new System.Drawing.Size(71, 17);
            this.rbtnMan.TabIndex = 3;
            this.rbtnMan.TabStop = true;
            this.rbtnMan.Text = "Чоловіки";
            this.rbtnMan.UseVisualStyleBackColor = true;
            // 
            // tbPathToFileGM
            // 
            this.tbPathToFileGM.Location = new System.Drawing.Point(347, 57);
            this.tbPathToFileGM.Name = "tbPathToFileGM";
            this.tbPathToFileGM.Size = new System.Drawing.Size(350, 20);
            this.tbPathToFileGM.TabIndex = 4;
            this.tbPathToFileGM.TextChanged += new System.EventHandler(this.tbPathToFileGM_TextChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(387, 83);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(131, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Відкрити";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnShow
            // 
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Location = new System.Drawing.Point(524, 83);
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
            this.опціїToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 24);
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
            this.ManualToolStripMenuItem});
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
            // опціїToolStripMenuItem
            // 
            this.опціїToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegressToolStripMenuItem,
            this.GlobalClToolStripMenuItem,
            this.UniversalToolStripMenuItem,
            this.ModeClCheckToolStripMenuItem});
            this.опціїToolStripMenuItem.Name = "опціїToolStripMenuItem";
            this.опціїToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.опціїToolStripMenuItem.Text = "Опції";
            // 
            // RegressToolStripMenuItem
            // 
            this.RegressToolStripMenuItem.Name = "RegressToolStripMenuItem";
            this.RegressToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.RegressToolStripMenuItem.Text = "Регресійне дослідження";
            this.RegressToolStripMenuItem.Click += new System.EventHandler(this.RegressToolStripMenuItem_Click);
            // 
            // GlobalClToolStripMenuItem
            // 
            this.GlobalClToolStripMenuItem.Name = "GlobalClToolStripMenuItem";
            this.GlobalClToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.GlobalClToolStripMenuItem.Text = "Одинична кластеризація";
            this.GlobalClToolStripMenuItem.Click += new System.EventHandler(this.GlobalClToolStripMenuItem_Click);
            // 
            // UniversalToolStripMenuItem
            // 
            this.UniversalToolStripMenuItem.Name = "UniversalToolStripMenuItem";
            this.UniversalToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.UniversalToolStripMenuItem.Text = "Універсальна кластеризація";
            this.UniversalToolStripMenuItem.Click += new System.EventHandler(this.UniversalToolStripMenuItem_Click);
            // 
            // ModeClCheckToolStripMenuItem
            // 
            this.ModeClCheckToolStripMenuItem.Name = "ModeClCheckToolStripMenuItem";
            this.ModeClCheckToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.ModeClCheckToolStripMenuItem.Text = "Вибір режиму кластеризації";
            this.ModeClCheckToolStripMenuItem.Click += new System.EventHandler(this.ModeClCheckToolStripMenuItem_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(679, 2);
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
            this.rbtCl8.Checked = true;
            this.rbtCl8.Location = new System.Drawing.Point(14, 22);
            this.rbtCl8.Name = "rbtCl8";
            this.rbtCl8.Size = new System.Drawing.Size(31, 17);
            this.rbtCl8.TabIndex = 61;
            this.rbtCl8.TabStop = true;
            this.rbtCl8.Text = "8";
            this.rbtCl8.UseVisualStyleBackColor = true;
            this.rbtCl8.CheckedChanged += new System.EventHandler(this.rbtCl8_CheckedChanged);
            // 
            // rbtCl4
            // 
            this.rbtCl4.AutoSize = true;
            this.rbtCl4.Location = new System.Drawing.Point(14, 45);
            this.rbtCl4.Name = "rbtCl4";
            this.rbtCl4.Size = new System.Drawing.Size(31, 17);
            this.rbtCl4.TabIndex = 62;
            this.rbtCl4.TabStop = true;
            this.rbtCl4.Text = "5";
            this.rbtCl4.UseVisualStyleBackColor = true;
            this.rbtCl4.CheckedChanged += new System.EventHandler(this.rbtCl4_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbtCl8);
            this.panel1.Controls.Add(this.rbtCl4);
            this.panel1.Location = new System.Drawing.Point(201, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 72);
            this.panel1.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Кількість кластерів:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.rbtnMan);
            this.panel2.Controls.Add(this.rbtnWoman);
            this.panel2.Location = new System.Drawing.Point(12, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 72);
            this.panel2.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Таблиця для кластеризації:";
            // 
            // btnShowUpdate
            // 
            this.btnShowUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowUpdate.Location = new System.Drawing.Point(390, 502);
            this.btnShowUpdate.Name = "btnShowUpdate";
            this.btnShowUpdate.Size = new System.Drawing.Size(128, 23);
            this.btnShowUpdate.TabIndex = 65;
            this.btnShowUpdate.Text = "Оновити результат";
            this.btnShowUpdate.UseVisualStyleBackColor = true;
            this.btnShowUpdate.Click += new System.EventHandler(this.btnShowUpdate_Click);
            // 
            // GlobalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 576);
            this.Controls.Add(this.btnShowUpdate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tbPathToFileGM);
            this.Controls.Add(this.dataGridViewGlobal);
            this.Controls.Add(this.btnCulc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GlobalWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GlobalWindow";
            this.Load += new System.EventHandler(this.GlobalWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobal)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbtCl8;
        private System.Windows.Forms.RadioButton rbtCl4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowUpdate;
        private System.Windows.Forms.ToolStripMenuItem опціїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GlobalClToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModeClCheckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CertificateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PurposeProgramTSMenu;
        private System.Windows.Forms.ToolStripMenuItem LegendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UniversalToolStripMenuItem;
    }
}