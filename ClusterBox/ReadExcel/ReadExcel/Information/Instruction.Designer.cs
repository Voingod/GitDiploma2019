namespace ClusterBox
{
    partial class Instruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instruction));
            this.btnAutorisation = new System.Windows.Forms.Button();
            this.btnSurvey = new System.Windows.Forms.Button();
            this.btnBD = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAutorisation
            // 
            this.btnAutorisation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAutorisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutorisation.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAutorisation.Location = new System.Drawing.Point(23, 8);
            this.btnAutorisation.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnAutorisation.Name = "btnAutorisation";
            this.btnAutorisation.Size = new System.Drawing.Size(226, 40);
            this.btnAutorisation.TabIndex = 0;
            this.btnAutorisation.Text = "Введення даних у вкладці \"Реєстрація\"";
            this.btnAutorisation.UseVisualStyleBackColor = false;
            this.btnAutorisation.Click += new System.EventHandler(this.btnAutorisation_Click);
            // 
            // btnSurvey
            // 
            this.btnSurvey.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSurvey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSurvey.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSurvey.Location = new System.Drawing.Point(23, 58);
            this.btnSurvey.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnSurvey.Name = "btnSurvey";
            this.btnSurvey.Size = new System.Drawing.Size(226, 40);
            this.btnSurvey.TabIndex = 1;
            this.btnSurvey.Text = "Введення даних у вкладці \"Дослідження\"";
            this.btnSurvey.UseVisualStyleBackColor = false;
            this.btnSurvey.Click += new System.EventHandler(this.btnSurvey_Click);
            // 
            // btnBD
            // 
            this.btnBD.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBD.Location = new System.Drawing.Point(23, 208);
            this.btnBD.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(226, 41);
            this.btnBD.TabIndex = 2;
            this.btnBD.Text = "Налаштування імені та полів бази даних для реєстрації результатів";
            this.btnBD.UseVisualStyleBackColor = false;
            this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveResult.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveResult.Location = new System.Drawing.Point(23, 108);
            this.btnSaveResult.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(226, 40);
            this.btnSaveResult.TabIndex = 3;
            this.btnSaveResult.Text = "Збереження результатів";
            this.btnSaveResult.UseVisualStyleBackColor = false;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTable.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTable.Location = new System.Drawing.Point(23, 158);
            this.btnTable.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(226, 40);
            this.btnTable.TabIndex = 4;
            this.btnTable.Text = "Приведення результуючої таблиці до прийнятного вигляду";
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnAutorisation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnBD, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnTable, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSurvey, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveResult, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(272, 257);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Instruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(272, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Instruction";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Інструкція користувача";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Instruction_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutorisation;
        private System.Windows.Forms.Button btnSurvey;
        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}