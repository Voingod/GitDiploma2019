namespace ReadExcel
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
            this.btnAutorisation = new System.Windows.Forms.Button();
            this.btnSurvey = new System.Windows.Forms.Button();
            this.btnBD = new System.Windows.Forms.Button();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.btnTable = new System.Windows.Forms.Button();
            this.lbText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAutorisation
            // 
            this.btnAutorisation.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnAutorisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutorisation.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAutorisation.Location = new System.Drawing.Point(12, 11);
            this.btnAutorisation.Name = "btnAutorisation";
            this.btnAutorisation.Size = new System.Drawing.Size(289, 29);
            this.btnAutorisation.TabIndex = 0;
            this.btnAutorisation.Text = "Авторизація";
            this.btnAutorisation.UseVisualStyleBackColor = false;
            this.btnAutorisation.Click += new System.EventHandler(this.btnAutorisation_Click);
            // 
            // btnSurvey
            // 
            this.btnSurvey.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSurvey.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSurvey.Location = new System.Drawing.Point(13, 46);
            this.btnSurvey.Name = "btnSurvey";
            this.btnSurvey.Size = new System.Drawing.Size(289, 29);
            this.btnSurvey.TabIndex = 1;
            this.btnSurvey.Text = "Дослідження";
            this.btnSurvey.UseVisualStyleBackColor = false;
            this.btnSurvey.Click += new System.EventHandler(this.btnSurvey_Click);
            // 
            // btnBD
            // 
            this.btnBD.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBD.Location = new System.Drawing.Point(13, 163);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(288, 41);
            this.btnBD.TabIndex = 2;
            this.btnBD.Text = "База даних";
            this.btnBD.UseVisualStyleBackColor = false;
            this.btnBD.Click += new System.EventHandler(this.btnBD_Click);
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnSaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveResult.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveResult.Location = new System.Drawing.Point(13, 81);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(289, 29);
            this.btnSaveResult.TabIndex = 3;
            this.btnSaveResult.Text = "Збереження результатів";
            this.btnSaveResult.UseVisualStyleBackColor = false;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // btnTable
            // 
            this.btnTable.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTable.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTable.Location = new System.Drawing.Point(12, 116);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(289, 41);
            this.btnTable.TabIndex = 4;
            this.btnTable.Text = "Результуюча таблиця";
            this.btnTable.UseVisualStyleBackColor = false;
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbText.Location = new System.Drawing.Point(278, 207);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(23, 7);
            this.lbText.TabIndex = 5;
            this.lbText.Text = "Текст";
            this.lbText.Visible = false;
            // 
            // Instruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(313, 215);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.btnBD);
            this.Controls.Add(this.btnSurvey);
            this.Controls.Add(this.btnAutorisation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Instruction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Інсутркція користувача";
            this.Load += new System.EventHandler(this.Instruction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutorisation;
        private System.Windows.Forms.Button btnSurvey;
        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Label lbText;
    }
}