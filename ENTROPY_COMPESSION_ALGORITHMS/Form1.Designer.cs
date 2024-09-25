namespace EntropyForms
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Upload = new System.Windows.Forms.Button();
            this.Img = new System.Windows.Forms.PictureBox();
            this.TextEntropyValue = new System.Windows.Forms.Label();
            this.ImageEntropyValue = new System.Windows.Forms.Label();
            this.ImageHist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Right = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.ExtractedText = new System.Windows.Forms.RichTextBox();
            this.ImageNum = new System.Windows.Forms.Label();
            this.compr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(652, 40);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(95, 42);
            this.Upload.TabIndex = 0;
            this.Upload.Text = "Upload file";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // Img
            // 
            this.Img.Location = new System.Drawing.Point(12, 12);
            this.Img.Name = "Img";
            this.Img.Size = new System.Drawing.Size(405, 285);
            this.Img.TabIndex = 1;
            this.Img.TabStop = false;
            // 
            // TextEntropyValue
            // 
            this.TextEntropyValue.AutoSize = true;
            this.TextEntropyValue.Location = new System.Drawing.Point(420, 369);
            this.TextEntropyValue.Name = "TextEntropyValue";
            this.TextEntropyValue.Size = new System.Drawing.Size(55, 13);
            this.TextEntropyValue.TabIndex = 4;
            this.TextEntropyValue.Text = "Entropy: 0";
            // 
            // ImageEntropyValue
            // 
            this.ImageEntropyValue.AutoSize = true;
            this.ImageEntropyValue.Location = new System.Drawing.Point(423, 113);
            this.ImageEntropyValue.Name = "ImageEntropyValue";
            this.ImageEntropyValue.Size = new System.Drawing.Size(55, 13);
            this.ImageEntropyValue.TabIndex = 5;
            this.ImageEntropyValue.Text = "Entropy: 0";
            // 
            // ImageHist
            // 
            chartArea1.Name = "ChartArea1";
            this.ImageHist.ChartAreas.Add(chartArea1);
            this.ImageHist.Location = new System.Drawing.Point(423, 129);
            this.ImageHist.Name = "ImageHist";
            this.ImageHist.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Name = "Series1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series2.Name = "Series2";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Name = "Series4";
            this.ImageHist.Series.Add(series1);
            this.ImageHist.Series.Add(series2);
            this.ImageHist.Series.Add(series3);
            this.ImageHist.Series.Add(series4);
            this.ImageHist.Size = new System.Drawing.Size(557, 199);
            this.ImageHist.TabIndex = 7;
            this.ImageHist.Text = "chart1";
            // 
            // chart1
            // 
            chartArea2.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea2.BorderColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(423, 385);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(557, 224);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // Right
            // 
            this.Right.Enabled = false;
            this.Right.Location = new System.Drawing.Point(12, 301);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(51, 30);
            this.Right.TabIndex = 9;
            this.Right.Text = "<";
            this.Right.UseVisualStyleBackColor = true;
            this.Right.Click += new System.EventHandler(this.Right_Click);
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.Color.Transparent;
            this.Left.Enabled = false;
            this.Left.Location = new System.Drawing.Point(362, 301);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(55, 30);
            this.Left.TabIndex = 10;
            this.Left.Text = ">";
            this.Left.UseVisualStyleBackColor = false;
            this.Left.Click += new System.EventHandler(this.Left_Click);
            // 
            // ExtractedText
            // 
            this.ExtractedText.Location = new System.Drawing.Point(12, 337);
            this.ExtractedText.Name = "ExtractedText";
            this.ExtractedText.Size = new System.Drawing.Size(405, 272);
            this.ExtractedText.TabIndex = 11;
            this.ExtractedText.Text = "";
            this.ExtractedText.TextChanged += new System.EventHandler(this.ExtractedText_TextChanged);
            // 
            // ImageNum
            // 
            this.ImageNum.AutoSize = true;
            this.ImageNum.Location = new System.Drawing.Point(198, 318);
            this.ImageNum.Name = "ImageNum";
            this.ImageNum.Size = new System.Drawing.Size(0, 13);
            this.ImageNum.TabIndex = 12;
            // 
            // compr
            // 
            this.compr.Location = new System.Drawing.Point(775, 21);
            this.compr.Name = "compr";
            this.compr.Size = new System.Drawing.Size(91, 42);
            this.compr.TabIndex = 13;
            this.compr.Text = "Compress LZW";
            this.compr.UseVisualStyleBackColor = true;
            this.compr.Click += new System.EventHandler(this.compr_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(775, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 42);
            this.button1.TabIndex = 14;
            this.button1.Text = "Compress Huffman";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 621);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.compr);
            this.Controls.Add(this.ImageNum);
            this.Controls.Add(this.ExtractedText);
            this.Controls.Add(this.Left);
            this.Controls.Add(this.Right);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.ImageHist);
            this.Controls.Add(this.ImageEntropyValue);
            this.Controls.Add(this.TextEntropyValue);
            this.Controls.Add(this.Img);
            this.Controls.Add(this.Upload);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.PictureBox Img;
        private System.Windows.Forms.Label TextEntropyValue;
        private System.Windows.Forms.Label ImageEntropyValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart ImageHist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Right;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.RichTextBox ExtractedText;
        private System.Windows.Forms.Label ImageNum;
        private System.Windows.Forms.Button compr;
        private System.Windows.Forms.Button button1;
    }
}

