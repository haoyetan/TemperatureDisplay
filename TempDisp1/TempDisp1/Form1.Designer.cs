namespace TempDisp1
{
    partial class TempDispFM
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempDispFM));
            this.comNumCB = new System.Windows.Forms.ComboBox();
            this.BaudRateCB = new System.Windows.Forms.ComboBox();
            this.CurrTempLB = new System.Windows.Forms.Label();
            this.DispTempBT = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AimCurveTB = new System.Windows.Forms.TextBox();
            this.setCurve = new System.Windows.Forms.Button();
            this.reSet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.finishBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exportBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // comNumCB
            // 
            this.comNumCB.FormattingEnabled = true;
            this.comNumCB.Items.AddRange(new object[] {
            "com1",
            "com2",
            "com3",
            "com4",
            "com5",
            "com6",
            "com6",
            "com7",
            "com8",
            "com9"});
            this.comNumCB.Location = new System.Drawing.Point(548, 24);
            this.comNumCB.Name = "comNumCB";
            this.comNumCB.Size = new System.Drawing.Size(118, 20);
            this.comNumCB.TabIndex = 0;
            this.comNumCB.Text = "com5";
            this.comNumCB.SelectedIndexChanged += new System.EventHandler(this.comNumCB_SelectedIndexChanged);
            // 
            // BaudRateCB
            // 
            this.BaudRateCB.FormattingEnabled = true;
            this.BaudRateCB.Items.AddRange(new object[] {
            "19200",
            "38400",
            "57600",
            "74800"});
            this.BaudRateCB.Location = new System.Drawing.Point(672, 24);
            this.BaudRateCB.Name = "BaudRateCB";
            this.BaudRateCB.Size = new System.Drawing.Size(116, 20);
            this.BaudRateCB.TabIndex = 2;
            this.BaudRateCB.Text = "9600";
            this.BaudRateCB.SelectedIndexChanged += new System.EventHandler(this.BaudRateCB_SelectedIndexChanged);
            // 
            // CurrTempLB
            // 
            this.CurrTempLB.AutoSize = true;
            this.CurrTempLB.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrTempLB.Location = new System.Drawing.Point(557, 137);
            this.CurrTempLB.Name = "CurrTempLB";
            this.CurrTempLB.Size = new System.Drawing.Size(96, 28);
            this.CurrTempLB.TabIndex = 3;
            this.CurrTempLB.Text = "当前温度";
            // 
            // DispTempBT
            // 
            this.DispTempBT.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DispTempBT.Location = new System.Drawing.Point(550, 50);
            this.DispTempBT.Name = "DispTempBT";
            this.DispTempBT.Size = new System.Drawing.Size(166, 36);
            this.DispTempBT.TabIndex = 4;
            this.DispTempBT.Text = "显示温度";
            this.DispTempBT.UseVisualStyleBackColor = true;
            this.DispTempBT.Click += new System.EventHandler(this.DispTempBT_Click);
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(12, 24);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(530, 414);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart2
            // 
            chartArea6.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.chart2.Legends.Add(legend6);
            this.chart2.Location = new System.Drawing.Point(548, 172);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart2.Series.Add(series6);
            this.chart2.Size = new System.Drawing.Size(240, 209);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            this.chart2.DoubleClick += new System.EventHandler(this.chart2_DoubleClick);
            // 
            // AimCurveTB
            // 
            this.AimCurveTB.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AimCurveTB.Location = new System.Drawing.Point(801, 24);
            this.AimCurveTB.Multiline = true;
            this.AimCurveTB.Name = "AimCurveTB";
            this.AimCurveTB.Size = new System.Drawing.Size(83, 357);
            this.AimCurveTB.TabIndex = 7;
            this.AimCurveTB.Text = "1,110\r\n4,190\r\n7,220\r\n8,220";
            // 
            // setCurve
            // 
            this.setCurve.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setCurve.Location = new System.Drawing.Point(890, 24);
            this.setCurve.Name = "setCurve";
            this.setCurve.Size = new System.Drawing.Size(38, 198);
            this.setCurve.TabIndex = 8;
            this.setCurve.Text = "设定曲线";
            this.setCurve.UseVisualStyleBackColor = true;
            this.setCurve.Click += new System.EventHandler(this.setCurve_Click);
            // 
            // reSet
            // 
            this.reSet.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reSet.Location = new System.Drawing.Point(890, 228);
            this.reSet.Name = "reSet";
            this.reSet.Size = new System.Drawing.Size(38, 153);
            this.reSet.TabIndex = 9;
            this.reSet.Text = "重设曲线";
            this.reSet.UseVisualStyleBackColor = true;
            this.reSet.Click += new System.EventHandler(this.reSet_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(550, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "加豆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // finishBT
            // 
            this.finishBT.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.finishBT.Location = new System.Drawing.Point(723, 51);
            this.finishBT.Name = "finishBT";
            this.finishBT.Size = new System.Drawing.Size(65, 77);
            this.finishBT.TabIndex = 11;
            this.finishBT.Text = "完成";
            this.finishBT.UseVisualStyleBackColor = true;
            this.finishBT.Click += new System.EventHandler(this.finishBT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "双击保存图片";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(815, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 36);
            this.label2.TabIndex = 13;
            this.label2.Text = "时间(半角逗号)温度\r\n\r\n分钟   ,    摄氏度";
            // 
            // exportBT
            // 
            this.exportBT.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exportBT.Location = new System.Drawing.Point(672, 393);
            this.exportBT.Name = "exportBT";
            this.exportBT.Size = new System.Drawing.Size(116, 45);
            this.exportBT.TabIndex = 14;
            this.exportBT.Text = "原始数据导出";
            this.exportBT.UseVisualStyleBackColor = true;
            this.exportBT.Click += new System.EventHandler(this.exportBT_Click);
            // 
            // TempDispFM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.exportBT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finishBT);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reSet);
            this.Controls.Add(this.setCurve);
            this.Controls.Add(this.AimCurveTB);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.DispTempBT);
            this.Controls.Add(this.CurrTempLB);
            this.Controls.Add(this.BaudRateCB);
            this.Controls.Add(this.comNumCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TempDispFM";
            this.Text = "温度曲线";
            this.Load += new System.EventHandler(this.TempDispFM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comNumCB;
        private System.Windows.Forms.ComboBox BaudRateCB;
        private System.Windows.Forms.Label CurrTempLB;
        private System.Windows.Forms.Button DispTempBT;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TextBox AimCurveTB;
        private System.Windows.Forms.Button setCurve;
        private System.Windows.Forms.Button reSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button finishBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exportBT;
    }
}

