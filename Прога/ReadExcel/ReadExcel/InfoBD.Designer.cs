namespace ReadExcel
{
    partial class InfoBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoBD));
            this.rtbInfoBD = new System.Windows.Forms.RichTextBox();
            this.pictureBoxDB1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxDB2 = new System.Windows.Forms.PictureBox();
            this.btnInst = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pictureBoxDB3 = new System.Windows.Forms.PictureBox();
            this.lblPictureOne = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB3)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbInfoBD
            // 
            this.rtbInfoBD.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.rtbInfoBD.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbInfoBD.Location = new System.Drawing.Point(13, 13);
            this.rtbInfoBD.Name = "rtbInfoBD";
            this.rtbInfoBD.ReadOnly = true;
            this.rtbInfoBD.Size = new System.Drawing.Size(790, 124);
            this.rtbInfoBD.TabIndex = 3;
            this.rtbInfoBD.Text = "";
            // 
            // pictureBoxDB1
            // 
            this.pictureBoxDB1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDB1.Image")));
            this.pictureBoxDB1.Location = new System.Drawing.Point(12, 143);
            this.pictureBoxDB1.Name = "pictureBoxDB1";
            this.pictureBoxDB1.Size = new System.Drawing.Size(791, 81);
            this.pictureBoxDB1.TabIndex = 1;
            this.pictureBoxDB1.TabStop = false;
            // 
            // pictureBoxDB2
            // 
            this.pictureBoxDB2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDB2.Image")));
            this.pictureBoxDB2.Location = new System.Drawing.Point(12, 230);
            this.pictureBoxDB2.Name = "pictureBoxDB2";
            this.pictureBoxDB2.Size = new System.Drawing.Size(790, 81);
            this.pictureBoxDB2.TabIndex = 2;
            this.pictureBoxDB2.TabStop = false;
            // 
            // btnInst
            // 
            this.btnInst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInst.Location = new System.Drawing.Point(237, 427);
            this.btnInst.Name = "btnInst";
            this.btnInst.Size = new System.Drawing.Size(75, 23);
            this.btnInst.TabIndex = 2;
            this.btnInst.Text = "Інструкція";
            this.btnInst.UseVisualStyleBackColor = true;
            this.btnInst.Click += new System.EventHandler(this.btnInst_Click);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(530, 427);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pictureBoxDB3
            // 
            this.pictureBoxDB3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDB3.Image")));
            this.pictureBoxDB3.Location = new System.Drawing.Point(143, 317);
            this.pictureBoxDB3.Name = "pictureBoxDB3";
            this.pictureBoxDB3.Size = new System.Drawing.Size(536, 81);
            this.pictureBoxDB3.TabIndex = 4;
            this.pictureBoxDB3.TabStop = false;
            // 
            // lblPictureOne
            // 
            this.lblPictureOne.AutoSize = true;
            this.lblPictureOne.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPictureOne.Location = new System.Drawing.Point(315, 401);
            this.lblPictureOne.Name = "lblPictureOne";
            this.lblPictureOne.Size = new System.Drawing.Size(215, 17);
            this.lblPictureOne.TabIndex = 5;
            this.lblPictureOne.Text = "Рис.1. Назви полів бази даних";
            // 
            // InfoBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(815, 462);
            this.Controls.Add(this.lblPictureOne);
            this.Controls.Add(this.pictureBoxDB3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnInst);
            this.Controls.Add(this.pictureBoxDB2);
            this.Controls.Add(this.pictureBoxDB1);
            this.Controls.Add(this.rtbInfoBD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База даних";
            this.Load += new System.EventHandler(this.InfoBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDB3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInfoBD;
        private System.Windows.Forms.PictureBox pictureBoxDB1;
        private System.Windows.Forms.PictureBox pictureBoxDB2;
        private System.Windows.Forms.Button btnInst;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pictureBoxDB3;
        private System.Windows.Forms.Label lblPictureOne;
    }
}