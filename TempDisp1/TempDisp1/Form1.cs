using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;
//using System.DateTime;

namespace TempDisp1
{
    public partial class TempDispFM : Form
    {
        public static DateTime TimeStart = new DateTime();
        public static DateTime TimeNow = new DateTime();
        public static double valX = 0;
        public static double valY = 100;
        public static double aimX = 0;
        public static double aimY = 0;
        //public static double intermS1 = 0;
        //public static double interSec1 = intermS1 / 1000;
        //public static double intermS2 = 0;
        //public static double interSec2 = intermS2 / 1000;
        public List<double> valXList = new List<double>();
        public List<double> valYList = new List<double>();
        public List<double> aimYList = new List<double>();
        public List<double> aimXList = new List<double>();

        public List<double> Aimtime = new List<double>();
        public List<double> Aimtemp = new List<double>();
        public List<double> AimKList = new List<double>();
        public List<double> AimBList = new List<double>();

        public static bool BLposition=true;
        public static string currT = "";

        public TempDispFM()
        {
            InitializeComponent();
            InitChart();

        }

        private void InitChart()
        {
            DateTime time = DateTime.Now;
            timer1.Interval = 300;
            timer1.Tick += timer1_Tick;
            //intermS1 = timer1.Interval;
            timer2.Interval = 300;
            timer2.Tick += timer2_Tick;
            //intermS2 = timer2.Interval;
            chart1.DoubleClick += chart1_DoubleClick;

            Series series1 = new Series("ss1");
            chart1.Series.Add(series1);
            chart1.Series[0].ChartType = SeriesChartType.Spline;
            Series series2 = new Series("ss2");
            chart1.Series.Add(series2);
            chart1.Series[1].ChartType = SeriesChartType.Spline;

            //chart1.ChartAreas[0].AxisX.ScaleView.Size = 30;
            //chart1.ChartAreas[0].AxisY.ScaleView.Size = 30;

            chart1.ChartAreas[0].AxisX.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            //chart1.ChartAreas[0].AxisY.Maximum = 200;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f1}";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f1}";


            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.Enabled = false;
            chart1.Legends[0].Enabled = false;



        }

        public double AimCurve(double time)
        {
            double KBY;
            if (time + 1 < Aimtime[Aimtime.Count-1])
            {
                int idxKB = Aimtime.FindIndex(p => p > (time + 1)) - 1;
                KBY = AimKList[idxKB] * (time+1) + AimBList[idxKB];
                return KBY;
            }
            else
                KBY = 220;
            return KBY;
        }
        
            
        

            void chart1_DoubleClick(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.Size = 5;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
        }


        private void DispTempBT_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void TempDispFM_Load(object sender, EventArgs e)
        {

            //comNumCB.SelectedIndex = 4;
            //DispTempBT.Enabled = false;
            serialPort1.PortName = comNumCB.Text;//端口号
            serialPort1.BaudRate = Convert.ToInt32(BaudRateCB.Text, 10);//波特率
            try
            {
                serialPort1.Open();     //打开串口
            }
            catch
            {
                MessageBox.Show("串口打开失败！");
            }
            button1.Enabled = false;
            finishBT.Enabled = false;
            exportBT.Enabled = false; ;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double intermS1 = timer1.Interval;
            double interSec1 = intermS1 / 1000;
            valX += interSec1;
            valXList.Add(valX);
            readSeries();
            valY = Convert.ToDouble(currT);
            valYList.Add(valY);

            Series series1 = chart1.Series[0];

            if (valYList.Max()>25)
            {
                chart1.ChartAreas[0].AxisY.ScaleView.Size = 200;
                chart1.ChartAreas[0].AxisY.ScaleView.Position = valYList.Max() - 35;
            }
            if (valX/60 > 0.8)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 1;
                chart1.ChartAreas[0].AxisX.ScaleView.Position = Math.Round((valX/60 - 0.2),1);
            }

            series1.Points.AddXY(valX / 60, valY);

            CurrTempLB.Text = "当前温度："+Math.Round(valY,1).ToString()+"度";

        }

        private void setCurve_Click(object sender, EventArgs e)
        {
            int cntLines = AimCurveTB.Lines.Length;
            double aimK = 0;
            double aimB = 0;
            for (int i = 0; i <= cntLines - 1; i++)
            {
                Aimtime.Add(Convert.ToDouble(AimCurveTB.Lines[i].Split(',')[0]));
                Aimtemp.Add(Convert.ToDouble(AimCurveTB.Lines[i].Split(',')[1]));

            }
            for (int i = 0; i <= cntLines - 2; i++)
            {
                aimK = (Aimtemp[i + 1] - Aimtemp[i]) / (Aimtime[i + 1] - Aimtime[i]);
                AimKList.Add(aimK);
                aimB = Aimtemp[i + 1] - aimK * Aimtime[i + 1];
                AimBList.Add(aimB);
            }
            button1.Enabled = true;
            setCurve.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;

            chart1.Series.Clear();
            Series series1 = new Series("ss1");
            chart1.Series.Add(series1);
            chart1.Series[0].ChartType = SeriesChartType.Spline;
            chart1.Series[0].BorderWidth = 3;
            Series series2 = new Series("ss2");
            chart1.Series.Add(series2);
            chart1.Series[1].ChartType = SeriesChartType.Spline;
            chart1.Series[1].BorderWidth = 7;
            chart1.Series[0].ShadowOffset=1;


            //chart1.ChartAreas[0].AxisY.Maximum = 50;
            //chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("ChartArea1");
            chart1.ChartAreas.Add(chartArea1);
            chart1.ChartAreas[0].AxisX.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            //chart1.ChartAreas[0].AxisY.Maximum = 50;
            //chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f1}";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f0}";

            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.Enabled = false;
            //chart1.ChartAreas[0]. = true;
            chart1.ChartAreas[0].AxisY.MajorGrid.Interval = 1;

            //
            Series series3 = new Series("ss3");
            chart2.Series.Add(series3);
            chart2.Series[0].ChartType = SeriesChartType.Spline;
            chart2.Series[0].BorderWidth = 1;
            Series series4 = new Series("ss4");
            chart2.Series.Add(series4);
            chart2.Series[1].ChartType = SeriesChartType.Spline;
            chart2.Series[1].BorderWidth = 1;
            chart2.Series[0].ShadowOffset = 1;

            chart2.ChartAreas[0].AxisX.Maximum = 15;
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 270;
            chart2.ChartAreas[0].AxisY.Minimum = 70;
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "{0:f1}";
            chart2.ChartAreas[0].AxisY.LabelStyle.Format = "{0:f0}";

            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart2.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            chart2.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            chart2.ChartAreas[0].AxisY.ScrollBar.Enabled = false;
            //chart1.ChartAreas[0]. = true;
            chart2.ChartAreas[0].AxisY.MajorGrid.Interval = 10;
            chart2.Legends[0].Enabled = false;

            timer2.Enabled = true;
            button1.Enabled = false;
            finishBT.Enabled = true; ;
            exportBT.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //chart1.ChartAreas.Clear();
            //ChartArea chartArea1 = new ChartArea("ChartArea0");
            //chart1.ChartAreas.Add(chartArea1);
            double intermS2 = timer2.Interval;
            double interSec2 = intermS2 / 1000;
            valX += interSec2;
            aimX += interSec2;
            valXList.Add(valX);
            
            aimY = AimCurve((aimX+3)/60);
            aimXList.Add((aimX + 3) / 60);
            aimYList.Add(aimY);

            readSeries();
            valY = Convert.ToDouble(currT);
            valYList.Add(valY);

            Series series1 = chart1.Series[0];
            Series series2 = chart1.Series[1];

            if (valYList.Max() > 95)
            {

                

                if(BLposition)
                {
                    chart1.ChartAreas[0].AxisY.ScaleView.Size = 50;
                    chart1.ChartAreas[0].AxisY.ScaleView.Position = (valYList.Max() + aimYList.Max()) / 2 - 15;
                    //chart1.ChartAreas[0].AxisY.Maximum = chart1.ChartAreas[0].AxisY.ScaleView.Position+30;
                    //chart1.ChartAreas[0].AxisY.Minimum = chart1.ChartAreas[0].AxisY.ScaleView.Position-20;
                }
                //double valYListMean = (valYList[valYList.Count] + valYList[valYList.Count - 100]) / 2;
                //double aimYListMean = (aimYList[aimYList.Count] + aimYList[aimYList.Count - 100]) / 2;
                if (Math.Abs(chart1.ChartAreas[0].AxisY.ScaleView.Position - ((valY + aimY) / 2 - 15)) > 25)
                {
                    //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                    //chart1.ChartAreas[0].AxisY.ScaleView.Size = 50;
                    chart1.ChartAreas[0].AxisY.ScaleView.Position = (valY + aimY) / 2 - 15;
                    BLposition = false;
                    //chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;

                }

            }
           
            if (aimX / 60 > 0.8)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 1;
                chart1.ChartAreas[0].AxisX.ScaleView.Position = Math.Round(aimX / 60-0.7, 1);
            }

            series1.Points.AddXY(aimX / 60, valY);
            series2.Points.AddXY((aimX + 3) / 60, aimY);

            Series series3 = chart2.Series[0];
            Series series4 = chart2.Series[1];

            series3.Points.AddXY(aimX / 60, valY);
            series4.Points.AddXY((aimX + 3) / 60, aimY);

            CurrTempLB.Text = "当前温度：" + Math.Round(valY, 1).ToString() + "度";
        }

        private void reSet_Click(object sender, EventArgs e)
        {
            AimCurveTB.Text = "1,110"+Environment.NewLine + "4,190"+ Environment.NewLine + "7,220" + Environment.NewLine + "8,220";
            button1.Enabled = false;
            setCurve.Enabled = true;
            //Application.Exit();
            //System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);

        }

        private void finishBT_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            serialPort1.Close();
        }

        private void chart2_DoubleClick(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //设置文件类型 
            sfd.Filter = "JPEG图片（*.jpg）|*.jpg";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //设置默认的文件名

            sfd.FileName = "温度曲线图";// in wpf is  sfd.FileName = "YourFileName";

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                chart2.SaveImage(localFilePath,ChartImageFormat.Jpeg);
            }
        }

        private void exportBT_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            //设置文件类型 
            sfd.Filter = "CSV文件|*.csv";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //设置默认的文件名

            sfd.FileName = "温度曲线原始数据表";// in wpf is  sfd.FileName = "YourFileName";

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                FileStream fs = new FileStream(localFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Flush();
                // 使用StreamWriter来往文件中写入内容
                sw.BaseStream.Seek(0, SeekOrigin.Begin);
                if(aimXList.Count== aimYList.Count)
                {
                    for (int i = 0; i < aimXList.Count; i++)
                    {
                        sw.WriteLine(aimXList[i] + "," + aimYList[i]);
                    }
                }
                //关闭此文件
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        

        
        }

        private void comNumCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            if (!serialPort1.IsOpen)//如果串口是开
            {
                serialPort1.PortName = comNumCB.Text;//端口号
                serialPort1.BaudRate = Convert.ToInt32(BaudRateCB.Text, 10);//波特率
                try
                {
                    serialPort1.Open();     //打开串口
                    //MessageBox.Show(str);
                }
                catch
                {
                    MessageBox.Show("串口打开失败！");
                }
            }
            //else//如果串口是打开的则将其关闭
            //{
            //    serialPort1.Close();
            //}
            
        }

        private void readSeries()
        {
            if (!serialPort1.IsOpen)//如果串口是开
            {
                serialPort1.Open();
            }

            string str = serialPort1.ReadExisting();
            List<string> currTList = new List<string>();
            currTList.AddRange(str.Split(','));
            //string currT = "";
            if (currTList.Count >= 2)
            {
                currT = currTList[currTList.Count - 2];
            }
            //textBox1.Text += currT + Environment.NewLine;
        }

            private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void BaudRateCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.Close();
            if (!serialPort1.IsOpen)//如果串口是开
            {
                serialPort1.PortName = comNumCB.Text;//端口号
                serialPort1.BaudRate = Convert.ToInt32(BaudRateCB.Text, 10);//波特率
                try
                {
                    serialPort1.Open();     //打开串口
                    //MessageBox.Show(str);
                }
                catch
                {
                    MessageBox.Show("串口打开失败！");
                }
            }
        }
    }
}
