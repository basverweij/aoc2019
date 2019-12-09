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
        }

        static void Puzzle1()
        {
            var input = File
                .ReadAllLines("input1.txt")
                .Select(l => l.Split(')'))
                .Select(l => (orbitee: l[0], orbitter: l[1]))
                .ToArray();

            var orbitCountChecksum = GetOrbitCountChecksum(input);

            Console.WriteLine($"Day 06 - Puzzle 1: {orbitCountChecksum}");
        }

        private static object GetOrbitCountChecksum(
            (string orbitee, string orbitter)[] input)
        {
            var orbiters = input
                .GroupBy(
                    i => i.orbitee,
                    i => i.orbitter)
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
    }
}
