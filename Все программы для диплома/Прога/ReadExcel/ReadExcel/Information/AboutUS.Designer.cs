namespace ReadExcel
{
    partial class AboutUS
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
            this.rtbAboutUs = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOKus = new System.Windows.Forms.Button();
            this.labelCopy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbAboutUs
            // 
            this.rtbAboutUs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rtbAboutUs.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.rtbAboutUs.Location = new System.Drawing.Point(12, 12);
            this.rtbAboutUs.Name = "rtbAboutUs";
            this.rtbAboutUs.ReadOnly = true;
            this.rtbAboutUs.Size = new System.Drawing.Size(308, 146);
            this.rtbAboutUs.TabIndex = 0;
            this.rtbAboutUs.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дипломний керівник:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Консультанти:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label3.Location = new System.Drawing.Point(174, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "зав.каф. Настенко Є.А.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.label4.Location = new System.Drawing.Point(198, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "доц. Носовець О.К.";
            // 
            // btnOKus
            // 
            this.btnOKus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOKus.Location = new System.Drawing.Point(255, 235);
            this.btnOKus.Name = "btnOKus";
            this.btnOKus.Size = new System.Drawing.Size(75, 23);
            this.btnOKus.TabIndex = 0;
            this.btnOKus.Text = "OK";
            this.btnOKus.UseVisualStyleBackColor = false;
            this.btnOKus.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCopy
            // 
            this.labelCopy.AutoSize = true;
            this.labelCopy.Location = new System.Drawing.Point(15, 244);
            this.labelCopy.Name = "labelCopy";
            this.labelCopy.Size = new System.Drawing.Size(51, 13);
            this.labelCopy.TabIndex = 6;
            this.labelCopy.Text = "Copyright";
            // 
            // AboutUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(332, 264);
            this.Controls.Add(this.labelCopy);
            this.Controls.Add(this.btnOKus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbAboutUs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutUS";
            this.Text = "Про нас";
            this.Load += new System.EventHandler(this.AboutUS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbAboutUs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOKus;
        private System.Windows.Forms.Label labelCopy;
    }
}