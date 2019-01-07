namespace UniversalWindow
{
    partial class UniversalWindowCl
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UniversalWindowCl));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnCunclusion = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.textBoxResultTable = new System.Windows.Forms.TextBox();
            this.dataGridViewFile = new System.Windows.Forms.DataGridView();
            this.dataGridViewResultTable = new System.Windows.Forms.DataGridView();
            this.rbtnWoman = new System.Windows.Forms.RadioButton();
            this.rbtnMan = new System.Windows.Forms.RadioButton();
            this.textBoxConclusion = new System.Windows.Forms.TextBox();
            this.textBoxFindStudent = new System.Windows.Forms.TextBox();
            this.btnResultTable = new System.Windows.Forms.Button();
            this.rbtnGlobal = new System.Windows.Forms.RadioButton();
            this.rbtnOne = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxVarInList = new System.Windows.Forms.TextBox();
            this.comboBoxList = new System.Windows.Forms.ComboBox();
            this.btnOutputFileData = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Location = new System.Drawing.Point(15, 254);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(168, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Таблиця для дослідження";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnCunclusion
            // 
            this.btnCunclusion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCunclusion.Location = new System.Drawing.Point(622, 361);
            this.btnCunclusion.Name = "btnCunclusion";
            this.btnCunclusion.Size = new System.Drawing.Size(83, 23);
            this.btnCunclusion.TabIndex = 1;
            this.btnCunclusion.Text = "Порахувати";
            this.btnCunclusion.UseVisualStyleBackColor = true;
            this.btnCunclusion.Click += new System.EventHandler(this.btnCunclusion_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(189, 254);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(187, 20);
            this.textBoxFile.TabIndex = 2;
            // 
            // textBoxResultTable
            // 
            this.textBoxResultTable.Location = new System.Drawing.Point(189, 56);
            this.textBoxResultTable.Name = "textBoxResultTable";
            this.textBoxResultTable.Size = new System.Drawing.Size(187, 20);
            this.textBoxResultTable.TabIndex = 3;
            // 
            // dataGridViewFile
            // 
            this.dataGridViewFile.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFile.Location = new System.Drawing.Point(385, 81);
            this.dataGridViewFile.Name = "dataGridViewFile";
            this.dataGridViewFile.Size = new System.Drawing.Size(364, 274);
            this.dataGridViewFile.TabIndex = 4;
            // 
            // dataGridViewResultTable
            // 
            this.dataGridViewResultTable.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResultTable.Location = new System.Drawing.Point(15, 80);
            this.dataGridViewResultTable.Name = "dataGridViewResultTable";
            this.dataGridViewResultTable.Size = new System.Drawing.Size(364, 168);
            this.dataGridViewResultTable.TabIndex = 5;
            // 
            // rbtnWoman
            // 
            this.rbtnWoman.AutoSize = true;
            this.rbtnWoman.Checked = true;
            this.rbtnWoman.Location = new System.Drawing.Point(12, 37);
            this.rbtnWoman.Name = "rbtnWoman";
            this.rbtnWoman.Size = new System.Drawing.Size(56, 17);
            this.rbtnWoman.TabIndex = 6;
            this.rbtnWoman.TabStop = true;
            this.rbtnWoman.Text = "Жінки";
            this.rbtnWoman.UseVisualStyleBackColor = true;
            // 
            // rbtnMan
            // 
            this.rbtnMan.AutoSize = true;
            this.rbtnMan.Location = new System.Drawing.Point(74, 37);
            this.rbtnMan.Name = "rbtnMan";
            this.rbtnMan.Size = new System.Drawing.Size(71, 17);
            this.rbtnMan.TabIndex = 7;
            this.rbtnMan.Text = "Чоловіки";
            this.rbtnMan.UseVisualStyleBackColor = true;
            // 
            // textBoxConclusion
            // 
            this.textBoxConclusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxConclusion.Location = new System.Drawing.Point(385, 406);
            this.textBoxConclusion.Multiline = true;
            this.textBoxConclusion.Name = "textBoxConclusion";
            this.textBoxConclusion.Size = new System.Drawing.Size(364, 64);
            this.textBoxConclusion.TabIndex = 8;
            this.textBoxConclusion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxFindStudent
            // 
            this.textBoxFindStudent.Location = new System.Drawing.Point(382, 55);
            this.textBoxFindStudent.Name = "textBoxFindStudent";
            this.textBoxFindStudent.Size = new System.Drawing.Size(364, 20);
            this.textBoxFindStudent.TabIndex = 9;
            this.textBoxFindStudent.TextChanged += new System.EventHandler(this.textBoxFindStudent_TextChanged);
            // 
            // btnResultTable
            // 
            this.btnResultTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResultTable.Location = new System.Drawing.Point(12, 56);
            this.btnResultTable.Name = "btnResultTable";
            this.btnResultTable.Size = new System.Drawing.Size(168, 23);
            this.btnResultTable.TabIndex = 11;
            this.btnResultTable.Text = "Результуюча таблиця";
            this.btnResultTable.UseVisualStyleBackColor = true;
            this.btnResultTable.Click += new System.EventHandler(this.btnResultTable_Click);
            // 
            // rbtnGlobal
            // 
            this.rbtnGlobal.AutoSize = true;
            this.rbtnGlobal.Location = new System.Drawing.Point(163, 24);
            this.rbtnGlobal.Name = "rbtnGlobal";
            this.rbtnGlobal.Size = new System.Drawing.Size(98, 30);
            this.rbtnGlobal.TabIndex = 12;
            this.rbtnGlobal.Text = "Глобальна \r\nкластеризація";
            this.rbtnGlobal.UseVisualStyleBackColor = true;
            this.rbtnGlobal.Visible = false;
            // 
            // rbtnOne
            // 
            this.rbtnOne.AutoSize = true;
            this.rbtnOne.Location = new System.Drawing.Point(267, 22);
            this.rbtnOne.Name = "rbtnOne";
            this.rbtnOne.Size = new System.Drawing.Size(98, 30);
            this.rbtnOne.TabIndex = 13;
            this.rbtnOne.Text = "Одинична\r\nкластеризація";
            this.rbtnOne.UseVisualStyleBackColor = true;
            this.rbtnOne.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Пошук студента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Лист для\r\nдослідження";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Список змінних\r\nу таблиці";
            // 
            // textBoxVarInList
            // 
            this.textBoxVarInList.Location = new System.Drawing.Point(189, 323);
            this.textBoxVarInList.Multiline = true;
            this.textBoxVarInList.Name = "textBoxVarInList";
            this.textBoxVarInList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxVarInList.Size = new System.Drawing.Size(187, 147);
            this.textBoxVarInList.TabIndex = 17;
            // 
            // comboBoxList
            // 
            this.comboBoxList.FormattingEnabled = true;
            this.comboBoxList.Location = new System.Drawing.Point(189, 290);
            this.comboBoxList.Name = "comboBoxList";
            this.comboBoxList.Size = new System.Drawing.Size(187, 21);
            this.comboBoxList.TabIndex = 18;
            this.comboBoxList.SelectionChangeCommitted += new System.EventHandler(this.comboBoxList_SelectionChangeCommitted);
            // 
            // btnOutputFileData
            // 
            this.btnOutputFileData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutputFileData.Location = new System.Drawing.Point(428, 361);
            this.btnOutputFileData.Name = "btnOutputFileData";
            this.btnOutputFileData.Size = new System.Drawing.Size(89, 23);
            this.btnOutputFileData.TabIndex = 19;
            this.btnOutputFileData.Text = "Вивести дані";
            this.btnOutputFileData.UseVisualStyleBackColor = true;
            this.btnOutputFileData.Click += new System.EventHandler(this.btnOutputFileData_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(727, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 22);
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 62;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // UniversalWindowCl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(756, 485);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOutputFileData);
            this.Controls.Add(this.comboBoxList);
            this.Controls.Add(this.textBoxVarInList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnOne);
            this.Controls.Add(this.rbtnGlobal);
            this.Controls.Add(this.btnResultTable);
            this.Controls.Add(this.textBoxFindStudent);
            this.Controls.Add(this.textBoxConclusion);
            this.Controls.Add(this.rbtnMan);
            this.Controls.Add(this.rbtnWoman);
            this.Controls.Add(this.dataGridViewResultTable);
            this.Controls.Add(this.dataGridViewFile);
            this.Controls.Add(this.textBoxResultTable);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.btnCunclusion);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UniversalWindowCl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResultTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnCunclusion;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.TextBox textBoxResultTable;
        private System.Windows.Forms.DataGridView dataGridViewFile;
        private System.Windows.Forms.DataGridView dataGridViewResultTable;
        private System.Windows.Forms.RadioButton rbtnWoman;
        private System.Windows.Forms.RadioButton rbtnMan;
        private System.Windows.Forms.TextBox textBoxConclusion;
        private System.Windows.Forms.TextBox textBoxFindStudent;
        private System.Windows.Forms.Button btnResultTable;
        private System.Windows.Forms.RadioButton rbtnGlobal;
        private System.Windows.Forms.RadioButton rbtnOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxVarInList;
        private System.Windows.Forms.ComboBox comboBoxList;
        private System.Windows.Forms.Button btnOutputFileData;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

