using System;
using System.Runtime.InteropServices;

namespace SBox
{
    class Program
    {
        private static System.Collections.ArrayList Array = new System.Collections.ArrayList(256);
        static int counter = 0;
        static void Main(string[] args)
        {
            Int64 a = 136;
            Int64 c = a;
            
            while (counter < (16 * 16))
            {
                BEL(a, c, 7);
                
                a = a + a;
                c += 1000;
            }
            Console.ReadLine();
        }
        public static void BEL(Int64 seed_, Int64 shift_, int Size)
        {
            long size = Size;

            long seed = seed_ + shift_;
            long a = shift_;
            long m = 100;
            long c = seed_ * 2;
            long p = 1007;
            long q = 1008;
            long X1, Y1, X2, Y2;
            string temp = "";
            if (size >= 0)
            {
                long s1 = seed, s2 = seed, s3 = seed;
                for (int n = 0; n < (size + 1); n++)
                {
                    s1 = (long)Math.Pow(s1, 2) % m; // BBS
                    s2 = (a * s2 + c) % m;  // LCG
                    X1 = Y1 = s3 * p;
                    s3 = X1;
                    X2 = Y2 = s3 * q;
                    seed = s1 + s2 + X2;
                    if (p < m)
                    {
                        seed = seed % m;
                    }
                    else
                    {
                        seed = seed % p;
                    }
                    if (seed % 2 == 0)
                        temp += "0";
                    else
                        temp += "1";
                }
            }
            if (!Array.Contains(temp))
            {

                counter++;
                Console.Title = counter.ToString();
                Array.Add(temp);
                Console.WriteLine("\n{0}   :    {1}\n", temp,Convert.ToByte(temp,2).ToString("X"));
            }
        }
    }
}
