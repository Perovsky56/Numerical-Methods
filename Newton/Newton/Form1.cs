using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] X, X0;
        void czytaj()
        {
            X0 = new double[3];
            X0[1] = double.Parse(textBox1.Text.ToString());
            X0[2] = double.Parse(textBox2.Text.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            czytaj();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            
            chart1.Series[0].Points.AddXY(X0[1], X0[2]);
            chart1.Series[0].Points.AddXY(5, 1);
            chart1.Series[0].Points.AddXY(5, -1);
            chart1.Series[0].Points.AddXY(-5, 1);
            chart1.Series[0].Points.AddXY(-5, -1);

            double t, dt, x1, x2, r, a, b;
            int N = 100;
            r = Math.Sqrt(26.0);
            //Parametry elipsy a, b 
            a = 10.0 / Math.Sqrt(3.0);
            b = 2.0;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            //Krok obliczeń dla wykresu ciągłego 
            dt = 2 * Math.PI / N;

            for (int i = 0; i <= N; i++)
            {
                t = i * dt;//Parametr do zapisu parametrycznego okręgu i elipsy 
                //Zapis parametryczny elipsy 
                x1 = a * Math.Cos(t);
                x2 = b * Math.Sin(t);
                //chart1.Series[0] wybrano jako typ Spline wykresu ciągłego  
                chart1.Series[1].Points.AddXY(x1, x2);
                //Zapis parametryczny okręgu 
                x1 = r * Math.Cos(t);
                x2 = r * Math.Sin(t);
                //chart1.Series[0] wybrano jako typ Spline wykresu ciągłego 
                chart1.Series[2].Points.AddXY(x1, x2);
            }
        }

    }
}
