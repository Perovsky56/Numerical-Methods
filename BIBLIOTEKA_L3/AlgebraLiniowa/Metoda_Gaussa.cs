using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BIBLIOTEKA_L3.AlgebraLiniowa
{
    public static class Metoda_Gaussa
    {
        public static int Rozwiaz(double[,] A, double[] B, double[] X, double eps)
        {
            int i, j, k, blad, N, M, R;
            double T, MA, a1 = 1.0;
            double ZT, ZS;
            N = A.GetLength(0) - 1; M = A.GetLength(1) - 1; R = B.Length - 1;
            if (N == M && N == R)
            {
                //Konstrukcja ciągu macierzy A(i) oraz ciagu macierzy B(i)
                for (i = 1; i <= N; i++)
                {
                    //Wybór elementu głównego (11)
                    T = Math.Abs(A[i, i]); k = i;
                    for (j = i + 1; j <= N; j++)
                    {
                        MA = Math.Abs(A[j, i]);
                        if (MA > T) { T = MA; k = j; };
                    }
                    if (T < eps)
                    { //Warunek przerwania poszukiwania elementu głównego
                      // nie istnieje rozwiązanie równania macierzowego, detA=0 (14)
                        blad = 3;
                        return blad;
                    }
                    if (i == k) { ZT = A[i, i]; }
                    else
                    {
                        //Zamiana wiersza k-tego z i-tym macierzy B
                        ZS = B[k]; B[k] = B[i]; B[i] = ZS;
                        ZT = A[k, i];
                        for (j = N; j >= i; j--)
                        { //Zamiana wiersza k-tego z i-tym macierzy A
                            ZS = A[k, j]; A[k, j] = A[i, j]; A[i, j] = ZS;
                        }//j
                    }
                    ZT = a1 / ZT;
                    A[i, i] = ZT;
                    for (j = i + 1; j <= N; j++)
                    {
                        ZS = A[j, i] * ZT; // (8)
                        B[j] -= B[i] * ZS; // (7)
                        for (k = i + 1; k <= N; k++)
                            A[j, k] -= A[i, k] * ZS; //(6)
                    }//j
                }//i;
                 // Rozwiązywanie układu trójkątnego metodą postępowania wstecz (13)
                for (i = N; i >= 1; i--)
                {
                    ZT = B[i];
                    for (j = i + 1; j <= N; j++) ZT -= A[i, j] * X[j];
                    X[i] = ZT * A[i, i];
                }//i;
                blad = 0;
            }
            else blad = 2;
            return blad;
        }//Koniec RozRowMacGaussa  
        public static int Rozwiaz(Complex[,] A, Complex[] B, Complex[] X, double eps)
        {
            int i, j, k, blad, N, M, R;
            double T, MA, a1 = 1.0;
            Complex ZT, ZS;
            N = A.GetLength(0) - 1; M = A.GetLength(1) - 1; R = B.Length - 1;
            if (N == M && N == R)
            {
                //Konstrukcja ciągu macierzy A(i) oraz ciagu macierzy B(i)
                for (i = 1; i <= N; i++)
                {
                    //Wybór elementu głównego (11)
                    T = A[i, i].Magnitude; k = i;
                    for (j = i + 1; j <= N; j++)
                    {
                        MA = A[j, i].Magnitude;
                        if (MA > T) { T = MA; k = j; };
                    }
                    if (T < eps)
                    { //Warunek przerwania poszukiwania elementu głównego
                      // nie istnieje rozwiązanie równania macierzowego, detA=0 (14)
                        blad = 3;
                        return blad;
                    }
                    if (i == k) { ZT = A[i, i]; }
                    else
                    {
                        //Zamiana wiersza k-tego z i-tym macierzy B
                        ZS = B[k]; B[k] = B[i]; B[i] = ZS;
                        ZT = A[k, i];
                        for (j = N; j >= i; j--)
                        { //Zamiana wiersza k-tego z i-tym macierzy A
                            ZS = A[k, j]; A[k, j] = A[i, j]; A[i, j] = ZS;
                        }//j
                    }
                    ZT = a1 / ZT;
                    A[i, i] = ZT;
                    for (j = i + 1; j <= N; j++)
                    {
                        ZS = A[j, i] * ZT; // (8)
                        B[j] -= B[i] * ZS; // (7)
                        for (k = i + 1; k <= N; k++)
                            A[j, k] -= A[i, k] * ZS; //(6)
                    }//j
                }//i;
                 // Rozwiązywanie układu trójkątnego metodą postępowania wstecz (13)
                for (i = N; i >= 1; i--)
                {
                    ZT = B[i];
                    for (j = i + 1; j <= N; j++) ZT -= A[i, j] * X[j];
                    X[i] = ZT * A[i, i];
                }//i;
                blad = 0;
            }
            else blad = 2;
            return blad;
        }
    }
}
