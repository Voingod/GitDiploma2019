namespace ClusterBox
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
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MonoClToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UniversalWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GlobalClToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClusterChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PurposeProgramTSMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LegendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbtCl8 = new System.Windows.Forms.RadioButton();
            this.rbtCl4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowUpdate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobal)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCulc
            // 
            this.btnCulc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCulc.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCulc.Location = new System.Drawing.Point(220, 3);
            this.btnCulc.Name = "btnCulc";
            this.btnCulc.Size = new System.Drawing.Size(128, 32);
            this.btnCulc.TabIndex = 0;
            this.btnCulc.Text = "Порахувати";
            this.btnCulc.UseVisualStyleBackColor = false;
            this.btnCulc.Click += new System.EventHandler(this.btnCulc_Click);
            // 
            // dataGridViewGlobal
            // 
            this.dataGridViewGlobal.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewGlobal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewGlobal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGlobal.Location = new System.Drawing.Point(3, 95);
            this.dataGridViewGlobal.Name = "dataGridViewGlobal";
            this.dataGridViewGlobal.Size = new System.Drawing.Size(703, 410);
            this.dataGridViewGlobal.TabIndex = 1;
            // 
            // rbtnWoman
            // 
            this.rbtnWoman.AutoSize = true;
            this.rbtnWoman.Checked = true;
            this.rbtnWoman.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnWoman.Location = new System.Drawing.Point(3, 3);
            this.rbtnWoman.Name = "rbtnWoman";
            this.rbtnWoman.Size = new System.Drawing.Size(63, 17);
            this.rbtnWoman.TabIndex = 2;
            this.rbtnWoman.TabStop = true;
            this.rbtnWoman.Text = "Жінки";
            this.rbtnWoman.UseVisualStyleBackColor = true;
            this.rbtnWoman.CheckedChanged += new System.EventHandler(this.rbtnWoman_CheckedChanged);
            // 
            // rbtnMan
            // 
            this.rbtnMan.AutoSize = true;
            this.rbtnMan.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnMan.Location = new System.Drawing.Point(72, 3);
            this.rbtnMan.Name = "rbtnMan";
            this.rbtnMan.Size = new System.Drawing.Size(147, 17);
            this.rbtnMan.TabIndex = 3;
            this.rbtnMan.TabStop = true;
            this.rbtnMan.Text = "Чоловіки";
            this.rbtnMan.UseVisualStyleBackColor = true;
            this.rbtnMan.CheckedChanged += new System.EventHandler(this.RbtnMan_CheckedChanged);
            // 
            // tbPathToFileGM
            // 
            this.tbPathToFileGM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbPathToFileGM.Location = new System.Drawing.Point(3, 17);
            this.tbPathToFileGM.Name = "tbPathToFileGM";
            this.tbPathToFileGM.Size = new System.Drawing.Size(223, 20);
            this.tbPathToFileGM.TabIndex = 4;
            this.tbPathToFileGM.TextChanged += new System.EventHandler(this.tbPathToFileGM_TextChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpen.Location = new System.Drawing.Point(3, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(105, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Відкрити";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShow.Location = new System.Drawing.Point(114, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(106, 23);
            this.btnShow.TabIndex = 6;
            this.btnShow.Text = "Вивести результат";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.OptionsToolStripMenuItem,
            this.CertificateToolStripMenuItem,
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
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MonoClToolStripMenuItem,
            this.UniversalWindowToolStripMenuItem,
            this.GlobalClToolStripMenuItem,
            this.RegressToolStripMenuItem,
            this.ClusterChangeToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.OptionsToolStripMenuItem.Text = "Дослідження";
            // 
            // MonoClToolStripMenuItem
            // 
            this.MonoClToolStripMenuItem.Name = "MonoClToolStripMenuItem";
            this.MonoClToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.MonoClToolStripMenuItem.Text = "Одинична кластеризація";
            this.MonoClToolStripMenuItem.Click += new System.EventHandler(this.btnMono_Click);
            // 
            // UniversalWindowToolStripMenuItem
            // 
            this.UniversalWindowToolStripMenuItem.Name = "UniversalWindowToolStripMenuItem";
            this.UniversalWindowToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.UniversalWindowToolStripMenuItem.Text = "Універсальна кластеризація";
            this.UniversalWindowToolStripMenuItem.Click += new System.EventHandler(this.btnUniversal_Click);
            // 
            // GlobalClToolStripMenuItem
            // 
            this.GlobalClToolStripMenuItem.Name = "GlobalClToolStripMenuItem";
            this.GlobalClToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.GlobalClToolStripMenuItem.Text = "Глобальна кластеризація";
            this.GlobalClToolStripMenuItem.Click += new System.EventHandler(this.btnGlobal_Click);
            // 
            // RegressToolStripMenuItem
            // 
            this.RegressToolStripMenuItem.Name = "RegressToolStripMenuItem";
            this.RegressToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.RegressToolStripMenuItem.Text = "Регресійне дослідження";
            this.RegressToolStripMenuItem.Click += new System.EventHandler(this.btnRegress_Click);
            // 
            // ClusterChangeToolStripMenuItem
            // 
            this.ClusterChangeToolStripMenuItem.Name = "ClusterChangeToolStripMenuItem";
            this.ClusterChangeToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.ClusterChangeToolStripMenuItem.Text = "Аналіз міжкластерних переходів";
            this.ClusterChangeToolStripMenuItem.Click += new System.EventHandler(this.ClusterChangeToolStripMenuItem_Click);
            // 
            // CertificateToolStripMenuItem
            // 
            this.CertificateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PurposeProgramTSMenu,
            this.InstructionToolStripMenuItem,
            this.LegendToolStripMenuItem});
            this.CertificateToolStripMenuItem.Name = "CertificateToolStripMenuItem";
            this.CertificateToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.CertificateToolStripMenuItem.Text = "Довідка";
            // 
            // PurposeProgramTSMenu
            // 
            this.PurposeProgramTSMenu.Name = "PurposeProgramTSMenu";
            this.PurposeProgramTSMenu.Size = new System.Drawing.Size(206, 22);
            this.PurposeProgramTSMenu.Text = "Призначення програми";
            this.PurposeProgramTSMenu.Click += new System.EventHandler(this.PurposeProgramTSMenu_Click);
            // 
            // InstructionToolStripMenuItem
            // 
            this.InstructionToolStripMenuItem.Name = "InstructionToolStripMenuItem";
            this.InstructionToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.InstructionToolStripMenuItem.Text = "Інструкція користувача";
            this.InstructionToolStripMenuItem.Click += new System.EventHandler(this.InstructionToolStripMenuItem_Click);
            // 
            // LegendToolStripMenuItem
            // 
            this.LegendToolStripMenuItem.Name = "LegendToolStripMenuItem";
            this.LegendToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.LegendToolStripMenuItem.Text = "Умовні позначення";
            this.LegendToolStripMenuItem.Click += new System.EventHandler(this.LegendToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.AboutToolStripMenuItem.Text = "Про нас";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // rbtCl8
            // 
            this.rbtCl8.AutoSize = true;
            this.rbtCl8.Checked = true;
            this.rbtCl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtCl8.Location = new System.Drawing.Point(3, 3);
            this.rbtCl8.Name = "rbtCl8";
            this.rbtCl8.Size = new System.Drawing.Size(39, 17);
            this.rbtCl8.TabIndex = 61;
            this.rbtCl8.TabStop = true;
            this.rbtCl8.Text = "8";
            this.rbtCl8.UseVisualStyleBackColor = true;
            this.rbtCl8.CheckedChanged += new System.EventHandler(this.rbtCl8_CheckedChanged);
            // 
            // rbtCl4
            // 
            this.rbtCl4.AutoSize = true;
            this.rbtCl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtCl4.Location = new System.Drawing.Point(48, 3);
            this.rbtCl4.Name = "rbtCl4";
            this.rbtCl4.Size = new System.Drawing.Size(171, 17);
            this.rbtCl4.TabIndex = 62;
            this.rbtCl4.TabStop = true;
            this.rbtCl4.Text = "5";
            this.rbtCl4.UseVisualStyleBackColor = true;
            this.rbtCl4.CheckedChanged += new System.EventHandler(this.rbtCl4_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Кількість кластерів:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Таблиця для кластеризації:";
            // 
            // btnShowUpdate
            // 
            this.btnShowUpdate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShowUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowUpdate.Location = new System.Drawing.Point(354, 3);
            this.btnShowUpdate.Name = "btnShowUpdate";
            this.btnShowUpdate.Size = new System.Drawing.Size(128, 32);
            this.btnShowUpdate.TabIndex = 65;
            this.btnShowUpdate.Text = "Оновити результат";
            this.btnShowUpdate.UseVisualStyleBackColor = false;
            this.btnShowUpdate.Click += new System.EventHandler(this.btnShowUpdate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(228, 80);
            this.tableLayoutPanel1.TabIndex = 66;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.53153F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.46847F));
            this.tableLayoutPanel2.Controls.Add(this.rbtnWoman, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rbtnMan, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(222, 54);
            this.tableLayoutPanel2.TabIndex = 67;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(237, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(228, 80);
            this.tableLayoutPanel3.TabIndex = 67;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.72072F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.27928F));
            this.tableLayoutPanel4.Controls.Add(this.rbtCl4, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.rbtCl8, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(222, 54);
            this.tableLayoutPanel4.TabIndex = 67;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tbPathToFileGM, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(471, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(229, 80);
            this.tableLayoutPanel5.TabIndex = 68;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btnOpen, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnShow, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(223, 34);
            this.tableLayoutPanel6.TabIndex = 67;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel5, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(703, 86);
            this.tableLayoutPanel7.TabIndex = 69;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.dataGridViewGlobal, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.36232F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.789855F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(709, 552);
            this.tableLayoutPanel8.TabIndex = 70;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.btnCulc, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnShowUpdate, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 511);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(703, 38);
            this.tableLayoutPanel9.TabIndex = 71;
            // 
            // GlobalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 576);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GlobalWindow";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Глобальна кластеризація";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GlobalWindow_FormClosed);
            this.Load += new System.EventHandler(this.GlobalWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlobal)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton rbtCl8;
        private System.Windows.Forms.RadioButton rbtCl4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowUpdate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MonoClToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UniversalWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GlobalClToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CertificateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PurposeProgramTSMenu;
        private System.Windows.Forms.ToolStripMenuItem InstructionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LegendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.ToolStripMenuItem ClusterChangeToolStripMenuItem;
    }
}