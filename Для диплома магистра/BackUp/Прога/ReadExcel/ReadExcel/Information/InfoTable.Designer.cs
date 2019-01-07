namespace ReadExcel
{
    partial class InfoTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoTable));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rtbTableInfo = new System.Windows.Forms.RichTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnInst = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(984, 423);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rtbTableInfo
            // 
            this.rtbTableInfo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rtbTableInfo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbTableInfo.Location = new System.Drawing.Point(13, 12);
            this.rtbTableInfo.Name = "rtbTableInfo";
            this.rtbTableInfo.ReadOnly = true;
            this.rtbTableInfo.Size = new System.Drawing.Size(984, 83);
            this.rtbTableInfo.TabIndex = 3;
            this.rtbTableInfo.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(799, 554);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnInst
            // 
            this.btnInst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInst.Location = new System.Drawing.Point(159, 554);
            this.btnInst.Name = "btnInst";
            this.btnInst.Size = new System.Drawing.Size(75, 23);
            this.btnInst.TabIndex = 2;
            this.btnInst.Text = "Інструкція";
            this.btnInst.UseVisualStyleBackColor = true;
            this.btnInst.Click += new System.EventHandler(this.btnInst_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(322, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Рис. 2. Приклад результуючої таблиці для чоловіків";
            // 
            // InfoTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1009, 589);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInst);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rtbTableInfo);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результуюча таблиця";
            this.Load += new System.EventHandler(this.InfoTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox rtbTableInfo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnInst;
        private System.Windows.Forms.Label label1;
    }
}