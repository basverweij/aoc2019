using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day06
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();

            Puzzle2();
        }

        static void Puzzle1()
        {
            var input = File
                .ReadAllLines("input1.txt")
                .Select(l => l.Split(')'))
                .Select(l => (orbitee: l[0], orbiter: l[1]))
                .ToArray();

            var orbitCountChecksum = GetOrbitCountChecksum(input);

            Console.WriteLine($"Day 06 - Puzzle 1: {orbitCountChecksum}");
        }

        static void Puzzle2()
        {
            var input = File
                .ReadAllLines("input1.txt")
                .Select(l => l.Split(')'))
                .Select(l => (orbitee: l[0], orbiter: l[1]))
                .ToArray();

            var transfers = GetTransfers(input);

            Console.WriteLine($"Day 06 - Puzzle 2: {transfers}");
        }

        private static object GetOrbitCountChecksum(
            (string orbitee, string orbiter)[] input)
        {
            var orbiters = input
                .GroupBy(
                    i => i.orbitee,
                    i => i.orbiter)
                .ToDictionary(
                    g => g.Key,
                    g => g);

            var counts = new Dictionary<string, int>
            {
                ["COM"] = 0,
            };

            var todo = new Stack<string>();

            todo.Push("COM");

            while (todo.Any())
            {
                var orbitee = todo.Pop();

                var count = counts[orbitee];

                if (orbiters.ContainsKey(orbitee))
                {
                    foreach (var orbiter in orbiters[orbitee])
                    {
                        counts[orbiter] = count + 1;

                        todo.Push(orbiter);
                    }
                }
            }

            return counts.Values.Sum();
        }

        private static int GetTransfers(
            (string orbitee, string orbiter)[] input)
        {
            var orbiters = input
                .ToDictionary(
                    i => i.orbiter,
                    i => i.orbitee);

            // special case if you and Santa are orbiting the same planet

            if (orbiters["YOU"] == orbiters["SAN"])
            {
                return 0;
            }

            var yourPath = GetPath(
                orbiters,
                "YOU");

            var santasPath = GetPath(
                orbiters,
                "SAN");

            while (yourPath.Pop() == santasPath.Pop())
            {
                // loop
            }

            return 2 + yourPath.Count + santasPath.Count;
        }

        private static Stack<string> GetPath(
            IReadOnlyDictionary<string, string> orbiters,
            string from)
        {
            var path = new Stack<string>();

            while (from != "COM")
            {
                from = orbiters[from];

                path.Push(from);
            }

            return path;
        }
    }
}
