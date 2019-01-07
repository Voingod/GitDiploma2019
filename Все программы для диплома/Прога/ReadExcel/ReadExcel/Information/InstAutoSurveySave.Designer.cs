namespace ReadExcel
{
    partial class InstAutoSurveySave
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
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.btnOKInfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbInfo
            // 
            this.rtbInfo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbInfo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbInfo.Location = new System.Drawing.Point(12, 12);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.ReadOnly = true;
            this.rtbInfo.Size = new System.Drawing.Size(296, 172);
            this.rtbInfo.TabIndex = 1;
            this.rtbInfo.TabStop = false;
            this.rtbInfo.Text = "Інструкція";
            // 
            // btnOKInfo
            // 
            this.btnOKInfo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnOKInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOKInfo.Location = new System.Drawing.Point(233, 190);
            this.btnOKInfo.Name = "btnOKInfo";
            this.btnOKInfo.Size = new System.Drawing.Size(75, 23);
            this.btnOKInfo.TabIndex = 2;
            this.btnOKInfo.Text = "OK";
            this.btnOKInfo.UseVisualStyleBackColor = false;
            this.btnOKInfo.Click += new System.EventHandler(this.btnOKInfo_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(32, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Інструкція";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InstAutoSurveySave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(320, 221);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOKInfo);
            this.Controls.Add(this.rtbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstAutoSurveySave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstAutoSurveySave";
            this.Load += new System.EventHandler(this.InstAutoSurveySave_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInfo;
        private System.Windows.Forms.Button btnOKInfo;
        private System.Windows.Forms.Button button1;

    }
}