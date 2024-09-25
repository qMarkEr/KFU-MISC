using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExcelDataReader;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Data;
using System.Windows.Threading;
using System.Media;

namespace TITANIC_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopwatch = new();
        private string FileName = String.Empty;
        private readonly Random y = new Random();
        private Vector theta;
        private Vector[] data = new Vector[887];
        private double[] result = new double[887];

        public MainWindow()
        {
            Random rnd = new Random();
            theta = new Vector(rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble());
            InitializeComponent();
        }

        private void parse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                FileName = dlg.FileName;
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var file = File.Open(FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(file))
                    {
                        var d = reader.AsDataSet();
                        dataGridView1.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = d.Tables[0] });

                        for (int i = 3; i < d.Tables[0].Rows.Count; ++i)
                        {
                            data[i - 3] = new Vector(d.Tables[0].Rows[i]);
                            result[i - 3] = Convert.ToDouble(d.Tables[0].Rows[i][0]);
                        }
                    }
                }
            }
        }
        private double log()
        {
            double res = 0;
            for (int i = 0; i < data.Length; ++i)
            {
                double y = result[i];
                res += Math.Log(Math.Pow(1 / (1 + Math.Exp(-(theta * data[i]))), y)
                    * Math.Pow(1 / (1 + Math.Exp((theta * data[i]))), 1 - y));
            }
            return res;
        }
        private void compute()
        {
            double eta = 0.000001;
            for (int i = 0; i < 100000; ++i)
            {
                theta = new(theta + eta * Gradient(theta));
                string sb = String.Format($"Iteration: {i};\nstep: {eta};\ntheta: [\n{theta.print("\n")}\n];\nlog(theta): {log()};\ntime: {stopwatch.Elapsed}");
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () { label1.Text = sb; } );
            }
        }

        private double ppf(double q, double mean, double variance)
        {
            const double alpha = (10 - Math.PI * Math.PI) / (5 * (Math.PI  - 3) * Math.PI);
            const double beta = (120 - 60 * Math.PI + 7 * Math.PI * Math.PI) / (15 * (Math.PI - 3) * Math.PI);

            double t = -Math.PI * Math.Log(1 - Math.Pow(2 * q - 1, 2)) / 4.0;
            double D = Math.Pow(1 - beta * t, 2) + 4 * alpha * t;
            double root = Math.Sqrt((beta * t - 1 + Math.Sqrt(D)) / (2 * alpha));

            return root * Math.Sqrt(2 * variance * variance) - mean;
        }
        private double fisher()
        {
            double res = 0;
            for (int i = 0; i < data.Length; ++i)
                res += (Math.Exp(-(theta * data[i])) * data[i] * data[i]) / Math.Pow(1 + Math.Exp(-(theta * data[i])), 2);
            
            return res;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
/*            SoundPlayer player = new SoundPlayer("D:\\Downloads\\sound_pscov.wav");
            player.Load();

            player.Play();*/

            stopwatch.Start();
            await Task.Run(compute);
            stopwatch.Stop();

            /*player.Stop();*/

            label1.Text = String.Format($"Iteration: {100000};\ntheta: [\n{theta.print("\n")}\n];\nlog(theta): {log()};\n\nTime: {stopwatch.Elapsed}");
        }
        private Vector Gradient(Vector theta)
        {
            Vector grad = new(theta);
            for (int i = 0; i < data.Length; ++i)
            {
                double y = result[i];
                double coefficient = y - (1 / (1 + Math.Exp(-(theta * data[i]))));
                grad += coefficient * data[i];
            }
            return grad;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] dataS = richTextBox1.Text.Split('\n');
            double[] dataD = new double[7];
            if (dataS.Length == 7)
            {
                for (int i = 0; i < dataS.Length; i++)
                    dataD[i] = Convert.ToDouble(dataS[i]);
                Vector x = new(dataD);
                double chance = Math.Round(1.0 / (1.0 + Math.Exp(-(theta * x))), 3);
                string summary = String.Empty;
                if (chance <= 0.2)
                {
                    summary = "You wouldn't have survived";
                }
                else if (chance <= 0.5)
                {
                    summary = "You would hardly have survived";
                }
                else if (chance <= 0.7)
                {
                    summary = "You would probably have survived";
                }
                else if (chance <= 1.0)
                {
                    summary = "You would have survived";
                }

                double tau = ppf(0.025, 0, (x * x) / fisher());
                interval.Content = String.Format($"({theta * x - tau}; {theta * x + tau})");
                label2.Text = String.Format($"Survive chance: {theta * x}\n{summary}");
            }
        }

    }
    public class Vector
    {
        private double[] values = new double[7];
        public readonly int len = 7;

        public Vector(DataRow x)
        {
            for (int i = 0; i < values.Length; ++i)
                values[i] = Convert.ToDouble(x[i]);
            values[0] = 1;
        }
        public Vector() { }
        public Vector(Vector a)
        {
            for (int i = 0; i < a.len; ++i)
                values[i] = a.values[i];
            values[0] = 1;
        }
        public Vector(double a1, double a2, double a3, double a4, double a5, double a6)
        {
            values[0] = 0;
            values[1] = a1;
            values[2] = a2;
            values[3] = a3;
            values[4] = a4;
            values[5] = a5;
            values[6] = a6;
        }
        public Vector(double[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                values[i] = (double)a[i];
            values[0] = 1;
        }
        public static Vector operator +(Vector a, Vector b)
        {
            var res = new Vector();
            for (int i = 0; i < a.len; ++i)
                res.values[i] = a.values[i] + b.values[i];

            return res;
        }
        public static double operator *(Vector a, Vector b)
        {
            double res = 0;
            for (int i = 0; i < a.len; ++i)
                res += a.values[i] * b.values[i];

            return res;
        }
        public static Vector operator *(double a, Vector b)
        {
            var res = new Vector();
            for (int i = 0; i < b.len; ++i)
                res.values[i] = a * b.values[i];

            return res;
        }
        public string print(string spliter) => String.Format($"{values[0]}{spliter}{values[1]}{spliter}{values[2]}{spliter}{values[3]}{spliter}{values[4]}{spliter}{values[5]}{spliter}{values[6]}");
        
    }
}
