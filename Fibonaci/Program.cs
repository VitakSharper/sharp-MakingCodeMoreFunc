using System;
using System.Collections.Generic;

namespace Fibonaci
{
    class Program
    {
        static void Main(string[] args)
        {
            Demonstrate(QuickFibonacci);
        }

        private static readonly IList<long> DynamicCache = new List<long> { 0, 1 };

        // 1 fn variant
        static long DynamicFibonacci(int n)
        {
            while (DynamicCache.Count <= n)
            {
                DynamicCache.Add(-1);
            }

            if (DynamicCache[n] < 0)
            {
                DynamicCache[n] = n < 2
                    ? n
                    : DynamicFibonacci(n - 1) + DynamicFibonacci(n - 2);
            }

            return DynamicCache[n];
        }

        // 2 fn variant
        static long ForwardFibonacci(int n)
        {
            while (DynamicCache.Count <= n)
            {
                DynamicCache.Add(
                    DynamicCache[DynamicCache.Count - 1] + DynamicCache[DynamicCache.Count - 2]
                );
            }

            return DynamicCache[n];
        }

        // 3 fn variant
        private static long QuickFibonacci(int n)
        {
            if (n < 2) return n;
            long a = 0;
            long b = 1;
            for (var i = 0; i <= n; i++)
            {
                var c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

        static void Demonstrate(Func<int, long> fibonacci)
        {
            int offset = 5;
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{offset + i}\t{fibonacci(offset + i)}");
            Console.WriteLine();
        }
    }
}