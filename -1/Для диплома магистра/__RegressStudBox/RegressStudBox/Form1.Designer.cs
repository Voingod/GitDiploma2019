namespace RegressStudBox
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chrtForCluster = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbtnMan = new System.Windows.Forms.RadioButton();
            this.rbtnWoman = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.dataGridViewStudent = new System.Windows.Forms.DataGridView();
            this.tabPageFind = new System.Windows.Forms.TabPage();
            this.dataGridViewCoeff = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chartRegress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbCoef = new System.Windows.Forms.Label();
            this.lbRegress = new System.Windows.Forms.Label();
            this.lbCluster = new System.Windows.Forms.Label();
            this.lbMinThreeNumber = new System.Windows.Forms.Label();
            this.lbMinTwoNumber = new System.Windows.Forms.Label();
            this.lbMinOneNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMinThreeText = new System.Windows.Forms.Label();
            this.lbMinTwoText = new System.Windows.Forms.Label();
            this.lbMinOneText = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridViewFind = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtForCluster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).BeginInit();
            this.tabPageFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRegress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFind)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageFind);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 570);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.comboBox1);
            this.tabPageData.Controls.Add(this.chrtForCluster);
            this.tabPageData.Controls.Add(this.rbtnMan);
            this.tabPageData.Controls.Add(this.rbtnWoman);
            this.tabPageData.Controls.Add(this.btnStart);
            this.tabPageData.Controls.Add(this.dataGridViewStudent);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(702, 544);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Данные";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox1.Location = new System.Drawing.Point(584, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chrtForCluster
            // 
            this.chrtForCluster.BorderSkin.BackColor = System.Drawing.Color.Empty;
            chartArea1.AxisX.Interval = 0.5D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.Maximum = 3.5D;
            chartArea1.AxisX.Minimum = 0.5D;
            chartArea1.AxisY.Interval = 3D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chrtForCluster.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 15.44715F;
            legend1.Position.Width = 23.11047F;
            legend1.Position.X = 40F;
            this.chrtForCluster.Legends.Add(legend1);
            this.chrtForCluster.Location = new System.Drawing.Point(7, 275);
            this.chrtForCluster.Name = "chrtForCluster";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.SystemColors.HotTrack;
            series1.Legend = "Legend1";
            series1.LegendText = "График зависимости";
            series1.Name = "Parametr";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.LegendText = "Линия тренда";
            series2.Name = "RegressLine";
            this.chrtForCluster.Series.Add(series1);
            this.chrtForCluster.Series.Add(series2);
            this.chrtForCluster.Size = new System.Drawing.Size(689, 247);
            this.chrtForCluster.TabIndex = 14;
            this.chrtForCluster.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title1.Name = "Title1";
            this.chrtForCluster.Titles.Add(title1);
            // 
            // rbtnMan
            // 
            this.rbtnMan.AutoSize = true;
            this.rbtnMan.Location = new System.Drawing.Point(584, 43);
            this.rbtnMan.Name = "rbtnMan";
            this.rbtnMan.Size = new System.Drawing.Size(72, 17);
            this.rbtnMan.TabIndex = 3;
            this.rbtnMan.Text = "Мужчины";
            this.rbtnMan.UseVisualStyleBackColor = true;
            // 
            // rbtnWoman
            // 
            this.rbtnWoman.AutoSize = true;
            this.rbtnWoman.Checked = true;
            this.rbtnWoman.Location = new System.Drawing.Point(584, 20);
            this.rbtnWoman.Name = "rbtnWoman";
            this.rbtnWoman.Size = new System.Drawing.Size(77, 17);
            this.rbtnWoman.TabIndex = 2;
            this.rbtnWoman.TabStop = true;
            this.rbtnWoman.Text = "Женщины";
            this.rbtnWoman.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(606, 246);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dataGridViewStudent
            // 
            this.dataGridViewStudent.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudent.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewStudent.Name = "dataGridViewStudent";
            this.dataGridViewStudent.Size = new System.Drawing.Size(572, 263);
            this.dataGridViewStudent.TabIndex = 0;
            // 
            // tabPageFind
            // 
            this.tabPageFind.Controls.Add(this.dataGridViewCoeff);
            this.tabPageFind.Controls.Add(this.label2);
            this.tabPageFind.Controls.Add(this.label1);
            this.tabPageFind.Controls.Add(this.chartRegress);
            this.tabPageFind.Controls.Add(this.btnNext);
            this.tabPageFind.Controls.Add(this.lbCoef);
            this.tabPageFind.Controls.Add(this.lbRegress);
            this.tabPageFind.Controls.Add(this.lbCluster);
            this.tabPageFind.Controls.Add(this.lbMinThreeNumber);
            this.tabPageFind.Controls.Add(this.lbMinTwoNumber);
            this.tabPageFind.Controls.Add(this.lbMinOneNumber);
            this.tabPageFind.Controls.Add(this.label4);
            this.tabPageFind.Controls.Add(this.lbMinThreeText);
            this.tabPageFind.Controls.Add(this.lbMinTwoText);
            this.tabPageFind.Controls.Add(this.lbMinOneText);
            this.tabPageFind.Controls.Add(this.textBox1);
            this.tabPageFind.Controls.Add(this.dataGridViewFind);
            this.tabPageFind.Location = new System.Drawing.Point(4, 22);
            this.tabPageFind.Name = "tabPageFind";
            this.tabPageFind.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFind.Size = new System.Drawing.Size(702, 544);
            this.tabPageFind.TabIndex = 1;
            this.tabPageFind.Text = "Поиск";
            this.tabPageFind.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCoeff
            // 
            this.dataGridViewCoeff.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewCoeff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoeff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Cluster,
            this.a,
            this.b});
            this.dataGridViewCoeff.Location = new System.Drawing.Point(455, 40);
            this.dataGridViewCoeff.Name = "dataGridViewCoeff";
            this.dataGridViewCoeff.Size = new System.Drawing.Size(241, 246);
            this.dataGridViewCoeff.TabIndex = 16;
            // 
            // Index
            // 
            this.Index.HeaderText = "№";
            this.Index.Name = "Index";
            this.Index.Width = 31;
            // 
            // Cluster
            // 
            this.Cluster.HeaderText = "Кластер";
            this.Cluster.Name = "Cluster";
            this.Cluster.Width = 57;
            // 
            // a
            // 
            this.a.HeaderText = "a";
            this.a.Name = "a";
            this.a.Width = 55;
            // 
            // b
            // 
            this.b.HeaderText = "b";
            this.b.Name = "b";
            this.b.Width = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Коэфф. детерминации";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Уравнение регрессии";
            // 
            // chartRegress
            // 
            this.chartRegress.BorderSkin.BackColor = System.Drawing.Color.Empty;
            chartArea2.AxisX.Interval = 0.5D;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.Interval = 3D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea1";
            this.chartRegress.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 15.44715F;
            legend2.Position.Width = 23.11047F;
            legend2.Position.X = 40F;
            this.chartRegress.Legends.Add(legend2);
            this.chartRegress.Location = new System.Drawing.Point(7, 291);
            this.chartRegress.Name = "chartRegress";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.SystemColors.HotTrack;
            series3.Legend = "Legend1";
            series3.LegendText = "График зависимости";
            series3.Name = "Parametr";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.LegendText = "Линия тренда";
            series4.Name = "RegressLine";
            this.chartRegress.Series.Add(series3);
            this.chartRegress.Series.Add(series4);
            this.chartRegress.Size = new System.Drawing.Size(689, 247);
            this.chartRegress.TabIndex = 13;
            this.chartRegress.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title2.Name = "Title1";
            this.chartRegress.Titles.Add(title2);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(309, 122);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(94, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Перейти к АТД";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbCoef
            // 
            this.lbCoef.AutoSize = true;
            this.lbCoef.Location = new System.Drawing.Point(374, 177);
            this.lbCoef.Name = "lbCoef";
            this.lbCoef.Size = new System.Drawing.Size(15, 13);
            this.lbCoef.TabIndex = 11;
            this.lbCoef.Text = "R";
            // 
            // lbRegress
            // 
            this.lbRegress.AutoSize = true;
            this.lbRegress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRegress.ForeColor = System.Drawing.Color.Maroon;
            this.lbRegress.Location = new System.Drawing.Point(372, 158);
            this.lbRegress.Name = "lbRegress";
            this.lbRegress.Size = new System.Drawing.Size(72, 13);
            this.lbRegress.TabIndex = 10;
            this.lbRegress.Text = "Уравнение";
            // 
            // lbCluster
            // 
            this.lbCluster.AutoSize = true;
            this.lbCluster.Location = new System.Drawing.Point(362, 97);
            this.lbCluster.Name = "lbCluster";
            this.lbCluster.Size = new System.Drawing.Size(76, 13);
            this.lbCluster.TabIndex = 9;
            this.lbCluster.Text = "Номер класт.";
            // 
            // lbMinThreeNumber
            // 
            this.lbMinThreeNumber.AutoSize = true;
            this.lbMinThreeNumber.Location = new System.Drawing.Point(362, 77);
            this.lbMinThreeNumber.Name = "lbMinThreeNumber";
            this.lbMinThreeNumber.Size = new System.Drawing.Size(52, 13);
            this.lbMinThreeNumber.TabIndex = 8;
            this.lbMinThreeNumber.Text = "3 минута";
            // 
            // lbMinTwoNumber
            // 
            this.lbMinTwoNumber.AutoSize = true;
            this.lbMinTwoNumber.Location = new System.Drawing.Point(362, 57);
            this.lbMinTwoNumber.Name = "lbMinTwoNumber";
            this.lbMinTwoNumber.Size = new System.Drawing.Size(52, 13);
            this.lbMinTwoNumber.TabIndex = 7;
            this.lbMinTwoNumber.Text = "2 минута";
            // 
            // lbMinOneNumber
            // 
            this.lbMinOneNumber.AutoSize = true;
            this.lbMinOneNumber.Location = new System.Drawing.Point(362, 37);
            this.lbMinOneNumber.Name = "lbMinOneNumber";
            this.lbMinOneNumber.Size = new System.Drawing.Size(52, 13);
            this.lbMinOneNumber.TabIndex = 6;
            this.lbMinOneNumber.Text = "1 минута";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Кластер";
            // 
            // lbMinThreeText
            // 
            this.lbMinThreeText.AutoSize = true;
            this.lbMinThreeText.Location = new System.Drawing.Point(289, 77);
            this.lbMinThreeText.Name = "lbMinThreeText";
            this.lbMinThreeText.Size = new System.Drawing.Size(67, 13);
            this.lbMinThreeText.TabIndex = 4;
            this.lbMinThreeText.Text = "Параметр 3";
            // 
            // lbMinTwoText
            // 
            this.lbMinTwoText.AutoSize = true;
            this.lbMinTwoText.Location = new System.Drawing.Point(289, 57);
            this.lbMinTwoText.Name = "lbMinTwoText";
            this.lbMinTwoText.Size = new System.Drawing.Size(67, 13);
            this.lbMinTwoText.TabIndex = 3;
            this.lbMinTwoText.Text = "Параметр 2";
            // 
            // lbMinOneText
            // 
            this.lbMinOneText.AutoSize = true;
            this.lbMinOneText.Location = new System.Drawing.Point(289, 37);
            this.lbMinOneText.Name = "lbMinOneText";
            this.lbMinOneText.Size = new System.Drawing.Size(67, 13);
            this.lbMinOneText.TabIndex = 2;
            this.lbMinOneText.Text = "Параметр 1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridViewFind
            // 
            this.dataGridViewFind.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewFind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFind.Location = new System.Drawing.Point(6, 39);
            this.dataGridViewFind.Name = "dataGridViewFind";
            this.dataGridViewFind.Size = new System.Drawing.Size(249, 246);
            this.dataGridViewFind.TabIndex = 1;
            this.dataGridViewFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridViewFind_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(725, 595);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtForCluster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudent)).EndInit();
            this.tabPageFind.ResumeLayout(false);
            this.tabPageFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRegress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageFind;
        private System.Windows.Forms.DataGridView dataGridViewStudent;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.RadioButton rbtnMan;
        private System.Windows.Forms.RadioButton rbtnWoman;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridViewFind;
        private System.Windows.Forms.Label lbCoef;
        private System.Windows.Forms.Label lbRegress;
        private System.Windows.Forms.Label lbCluster;
        private System.Windows.Forms.Label lbMinThreeNumber;
        private System.Windows.Forms.Label lbMinTwoNumber;
        private System.Windows.Forms.Label lbMinOneNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbMinThreeText;
        private System.Windows.Forms.Label lbMinTwoText;
        private System.Windows.Forms.Label lbMinOneText;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRegress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCoeff;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cluster;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtForCluster;
    }
}

