namespace ClusterVector
{
    partial class FormGraf
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lbRegress = new System.Windows.Forms.Label();
            this.lbCoef = new System.Windows.Forms.Label();
            this.lbCoefM = new System.Windows.Forms.Label();
            this.lbRegressM = new System.Windows.Forms.Label();
            this.chrtRegress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chrtRegress)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRegress
            // 
            this.lbRegress.AutoSize = true;
            this.lbRegress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRegress.ForeColor = System.Drawing.Color.Maroon;
            this.lbRegress.Location = new System.Drawing.Point(149, 21);
            this.lbRegress.Name = "lbRegress";
            this.lbRegress.Size = new System.Drawing.Size(87, 13);
            this.lbRegress.TabIndex = 13;
            this.lbRegress.Text = "Уравнение Cl";
            // 
            // lbCoef
            // 
            this.lbCoef.AutoSize = true;
            this.lbCoef.Location = new System.Drawing.Point(149, 46);
            this.lbCoef.Name = "lbCoef";
            this.lbCoef.Size = new System.Drawing.Size(15, 13);
            this.lbCoef.TabIndex = 14;
            this.lbCoef.Text = "R";
            // 
            // lbCoefM
            // 
            this.lbCoefM.AutoSize = true;
            this.lbCoefM.Location = new System.Drawing.Point(290, 42);
            this.lbCoefM.Name = "lbCoefM";
            this.lbCoefM.Size = new System.Drawing.Size(15, 13);
            this.lbCoefM.TabIndex = 18;
            this.lbCoefM.Text = "R";
            // 
            // lbRegressM
            // 
            this.lbRegressM.AutoSize = true;
            this.lbRegressM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRegressM.ForeColor = System.Drawing.Color.Maroon;
            this.lbRegressM.Location = new System.Drawing.Point(291, 21);
            this.lbRegressM.Name = "lbRegressM";
            this.lbRegressM.Size = new System.Drawing.Size(86, 13);
            this.lbRegressM.TabIndex = 17;
            this.lbRegressM.Text = "Уравнение M";
            // 
            // chrtRegress
            // 
            chartArea1.AxisX.Title = "ЧСС";
            chartArea1.Name = "ChartArea1";
            this.chrtRegress.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrtRegress.Legends.Add(legend1);
            this.chrtRegress.Location = new System.Drawing.Point(3, 72);
            this.chrtRegress.Name = "chrtRegress";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.LegendText = "Линия регрессии";
            series1.Name = "RegressLineCL";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DodgerBlue;
            series2.Legend = "Legend1";
            series2.Name = "RegressLineM";
            this.chrtRegress.Series.Add(series1);
            this.chrtRegress.Series.Add(series2);
            this.chrtRegress.Size = new System.Drawing.Size(516, 250);
            this.chrtRegress.TabIndex = 19;
            this.chrtRegress.Text = "ChartForOneStudent";
            title1.Name = "Title1";
            title1.Text = "Графік лінії регресії";
            this.chrtRegress.Titles.Add(title1);
            // 
            // FormGraf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 324);
            this.Controls.Add(this.chrtRegress);
            this.Controls.Add(this.lbCoefM);
            this.Controls.Add(this.lbRegressM);
            this.Controls.Add(this.lbCoef);
            this.Controls.Add(this.lbRegress);
            this.Name = "FormGraf";
            this.Text = "FormGraf";
            ((System.ComponentModel.ISupportInitialize)(this.chrtRegress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRegress;
        private System.Windows.Forms.Label lbCoef;
        private System.Windows.Forms.Label lbCoefM;
        private System.Windows.Forms.Label lbRegressM;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtRegress;
    }
}