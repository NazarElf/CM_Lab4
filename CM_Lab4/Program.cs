using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_Lab4
{
    class Program
    {

        static void Main(string[] args)
        {
            double[] F1A = new double[10]; 
            for (int i = 0; i < 10; i++)
            {
                F1A[i] = f3(i);
            }

            double[] F2A = new double[10];
            double[] x5 = new double[10];
            for (int i = 0; i < 10; i++)
            {
                F2A[i] = F(f5, F1A, i, out x5[i]);
            }

            double[] F3A = new double[16];
            double[] x1 = new double[16];
            for (int i = 0; i < 16; i++)
            {
                F3A[i] = F(f1, F2A, i, out x1[i]);
            }

            double[] F4A = new double[16];
            double[] x2 = new double[16];
            for (int i = 0; i < 16; i++)
            {
                F4A[i] = F(f2, F3A, i, out x2[i]);
            }

            double[] F5A = new double[16];
            double[] x4 = new double[16];
            for (int i = 0; i < 16; i++)
            {
                F5A[i] = F(f4, F4A, i, out x4[i]);
            }

            Console.WriteLine("Max res = " + F5A[15]);

            Console.WriteLine("x4 = " + x4[15]);
            double X2 = x2[x2.Length - 1 - (int)x4[15]];
            int _2 = x2.Length - 1 - (int)x4[15];
            Console.WriteLine("x2 = " + X2);
            double X1 = x1[_2 - (int)X2];
            int _1 = _2 - (int)X2;
            Console.WriteLine("x1 = " + X1);
            double X5 = x5[_1 - (int)X1];
            Console.WriteLine("x5 = " + X5);
            Console.WriteLine("x3 = " + (15 - X5 - x4[15] - X2 - X1));
            Console.WriteLine("A\tF1A\tx3\tF2A\tx5\tF3A\tx1\tF4A\tx2\tF5A\tx4");
            for (int i = 0; i < 16; i++)
            {
                string wr = i + "\t";
                if (i < 10)
                    wr += F1A[i] + "\t" + i + "\t" + F2A[i] + "\t" + x5[i] + "\t";
                else
                    wr += F1A[9] + "\t" + 9 + "\t" + F2A[9] + "\t" + x5[9] + "\t";
                wr += F3A[i] + "\t" + x1[i] + "\t" + F4A[i] + "\t" + x2[i] + "\t" + F5A[i] +"\t" + x4[i];
                Console.WriteLine(wr);
            }
            Console.Read();
        }
        
        static double F(Func<int, double> f, double[] F, int n, out double x)
        {
            x = 0.0;
            double res = 0.0;
            for (int i = 0; i < n+1; i++)
            {
                double t = 0;
                if (F.Length > n-i)
                    t = f(i) + (F[n - i]);
                else
                    t = f(i) + F[F.Length - 1];
                if (t > res)
                {
                    x = i;
                    res = t;
                }
            }
            return res;
        }

        static double f1(int x)
        {
            return 1.2 * x;
        }
        static double f2(int x)
        {
            if(x < 6)
            return 0.0;
            return 5 * (x - 6);
        }
        static double f3(int x)
        {
            if (x <= 3)
                return 3 * x;
            return x;
        }
        static double f4(int x)
        {
            if (x < 3)
                return x * x;
            return 5.0;
        }
        static double f5(int x)
        {
            if (x < 4)
                return x;
            return 3 * x;
        }
    }
}
