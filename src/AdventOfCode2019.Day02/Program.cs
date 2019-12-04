using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day02
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();

            Puzzle2();
        }

        private static void Puzzle1()
        {
            var i = File
                .ReadAllText("input1.txt")
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            // apply 1202 program

            i[1] = 12;
            i[2] = 2;

            RunIntcode(i);

            Console.WriteLine($"Day 02 - Puzzle 1: {i[0]}");
        }

        private static void Puzzle2()
        {
            var i = File
                .ReadAllText("input1.txt")
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            var nounVerb = Enumerable
                .Range(0, 100 * 100)
                .AsParallel()
                .First(x =>
                {
                    var j = new int[i.Length];

                    Array.Copy(i, j, i.Length);

                    j[1] = x / 100; // noun

                    j[2] = x % 100; // verb

                    RunIntcode(j);

                    return j[0] == 19690720;
                });

            Console.WriteLine($"Day 02 - Puzzle 2: {nounVerb}");
        }


        public static void RunIntcode(
            int[] i)
        {
            var pc = 0;

            while (i[pc] != 99)
            {
                switch (i[pc])
                {
                    case 1: // addition

                        i[i[pc + 3]] = i[i[pc + 1]] + i[i[pc + 2]];

                        break;

                    case 2: // multiplication

                        i[i[pc + 3]] = i[i[pc + 1]] * i[i[pc + 2]];

                        break;

                    default:
                        throw new InvalidOperationException($"invalid opcode: '{i[pc]}'");
                }

                pc += 4;
            }
        }
    }
}
