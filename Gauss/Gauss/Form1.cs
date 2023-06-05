using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIBLIOTEKA_L3.AlgebraLiniowa;
using System.Numerics;

namespace Gauss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //PIERWSZE URUCHOMIENIE
            format();
            wybierz = 1;
        }

        int N, wybierz; //N - rozmiar tablicy
        double[,] A;
        double[] B, X;

        Complex[,] AZ;
        Complex[] BZ, XZ;

        void format()
        {
            N = (int)numericUpDown1.Value;

            dataGridView1.ColumnCount = N;
            dataGridView1.RowCount = N;

            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = N;

            dataGridView3.ColumnCount = 1;
            dataGridView3.RowCount = N;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            format();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (wybierz == 1)
            {
                Random los = new Random();

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        dataGridView1[i, j].Value = los.Next(-100, 100);// + los.NextDouble().ToString("0.000");
                        dataGridView3[0, j].Value = los.Next(-100, 100);// + los.NextDouble().ToString("0.000");
                    }
                }
            } else
            {
                Random los = new Random();

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Complex x = new Complex(los.Next(-100, 100), los.Next(-100, 100));
                        Complex y = new Complex(los.Next(-100, 100), los.Next(-100, 100));
                        dataGridView1[i, j].Value = x; // + los.NextDouble().ToString("0.000");
                        dataGridView3[0, j].Value = y; // + los.NextDouble().ToString("0.000");
                    }
                }
            }
            //button3.Visible = true;
            button3.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            wybierz = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            wybierz = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random los = new Random();
            int suma, y = 0;
            for (int i = 0; i < N; i++)
            {
                
                suma = 0;
                {
                    for (int j = 0; j < N; j++)
                    {
                        y = los.Next(-100, 100);// + los.NextDouble().ToString("0.000");;
                        dataGridView1[j, i].Value = y;
                        suma += y;
                    }
                    dataGridView3[0, i].Value = suma;
                }
                
            }
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (wybierz == 1)
            {
                A = new double[N + 1, N + 1];
                B = new double[N + 1];
                X = new double[N + 1];

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        A[i, j] = double.Parse(dataGridView1[j - 1, i - 1].Value.ToString());
                        B[j] = double.Parse(dataGridView3[0, j - 1].Value.ToString());
                    }
                }

                int bl = Metoda_Gaussa.Rozwiaz(A, B, X, 1e-5);

                for (int i = 0; i < N; i++)
                {
                    dataGridView2[0, i].Value = X[i + 1].ToString("0.00");
                }
            } else
            {
                AZ = new Complex[N + 1, N + 1];
                BZ = new Complex[N + 1];
                XZ = new Complex[N + 1];

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        AZ[i, j] = (Complex)dataGridView1[j - 1, i - 1].Value;
                        BZ[j] = (Complex)dataGridView3[0, j - 1].Value;
                    }
                }

                int bl = Metoda_Gaussa.Rozwiaz(AZ, BZ, XZ, 1e-5);
                for (int i = 0; i < N; i++)
                {
                    dataGridView2[0, i].Value = XZ[i + 1].ToString("0.00");
                }
            }
        }
    }
}
