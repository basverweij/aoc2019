using System;

namespace AdventOfCode2019.Day04
{
    public static class Program
    {
        const string input1 = "134792-675810";

        static void Main(string[] args)
        {
            Puzzle1();
        }

        private static void Puzzle1()
        {
            var from = int.Parse(input1.Split('-')[0]);

            var to = int.Parse(input1.Split('-')[1]);

            var n = 0;

            for (var i = from; i <= to; i++)
            {
                if (IsValidPassword(i))
                {
                    n++;
                }
            }

            Console.WriteLine($"Day 04 - Puzzle 1: {n}");
        }

        public static bool IsValidPassword(
            int i)
        {
            var hasAdjacent = false;

            var lastDigit = i % 10;

            while (true)
            {
                i /= 10;

                if (i == 0)
                {
                    break;
                }

                if (i % 10 > lastDigit)
                {
                    // decreasing digit

                    return false;
                }

                if (i % 10 == lastDigit)
                {
                    hasAdjacent = true;
                }

                lastDigit = i % 10;
            }

            return hasAdjacent;
        }
    }
}
