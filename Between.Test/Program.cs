using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FSharp.Collections;

namespace Between.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new int[] { 5, 3, 4, 4 };
            var m = new int[][] {
                new int[] { 3, 1, 2, 3, 3 },
                new int[] { 4, 3, 4, 3, 5 },
                new int[] { 3, 3, 1, 5, 4 },
                new int[] { 1, 5, 5, 2, 1 }
            };

            for (int i = 0; i < m.Length; i++) {
                var user1 = new List<Tuple<int, double>>();
                var user2 = new List<Tuple<int, double>>();
                for (int j = 0; j < m[i].Length; j++) {
                    if (t.Length > j)
                        user1.Add(new Tuple<int, double>(j, (double)t[j]));
                    user2.Add(new Tuple<int, double>(j, (double)m[i][j]));
                }
                var coefficient = Pearsons.calculate(ListModule.OfSeq(user1), ListModule.OfSeq(user2));
                Console.WriteLine(coefficient);
            }

            //var user1 = new List<Tuple<int, double>>(); //new FSharpList<Tuple<int, double>>(new Tuple<int, double>(5, 1), null);
            //user1.Add(new Tuple<int, double>(1, 5));
            //user1.Add(new Tuple<int, double>(3, 5));
            //user1.Add(new Tuple<int, double>(2, 5));
            //user1.Add(new Tuple<int, double>(6, 1));
            //user1.Add(new Tuple<int, double>(4, 5));
            //user1.Add(new Tuple<int, double>(5, 1));

            //var user2 = new List<Tuple<int, double>>(); //new FSharpList<Tuple<int, double>>(new Tuple<int, double>(5, 1), null);
            //user2.Add(new Tuple<int, double>(3, 1));
            //user2.Add(new Tuple<int, double>(6, 5));
            //user2.Add(new Tuple<int, double>(1, 1));
            //user2.Add(new Tuple<int, double>(5, 5));

            //user1.ForEach(u => Console.WriteLine(String.Format("u1: {0} ", u)));
            //user2.ForEach(u => Console.WriteLine(String.Format("u2: {0} ", u)));

            //var coefficient = Pearsons.calculate(ListModule.OfSeq(user1), ListModule.OfSeq(user2));

            //Console.WriteLine(coefficient);

            //var coefficient = Pearsons.calculate(ListModule.OfSeq(user1), ListModule.OfSeq(user2)).ToList();

            //coefficient.ForEach(u => Console.WriteLine(String.Format("cofficient: {0} ", u)));

            Console.ReadLine();
        }
    }
}
