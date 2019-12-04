using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day03
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        private static void Puzzle1()
        {
            var lines = File.ReadAllLines("input1.txt");

            var line1 = ParseLine(lines[0]);

            var line2 = ParseLine(lines[1]);

            var points1 = DrawLine(line1);

            var points2 = DrawLine(line2);

            points1.IntersectWith(points2);

            var closestDistance = points1
                .Select(p => Distance(p.Item1, p.Item2))
                .Min();

            Console.WriteLine($"Day 03 - Puzzle 1: {closestDistance}");
        }

        public static Segment[] ParseLine(
            string line)
        {
            return line
                .Split(',')
                .Select(Segment.FromString)
                .ToArray();
        }

        public static HashSet<(int, int)> DrawLine(
            Segment[] line)
        {
            var x = 0;

            var y = 0;

            var points = new HashSet<(int, int)>();

            foreach (var segment in line)
            {
                if (segment.DeltaY == 0)
                {
                    // move along x-axis
                    for (var i = 0; i < segment.Length; i++)
                    {
                        x += segment.DeltaX;

                        points.Add((x, y));
                    }
                }
                else
                {
                    // move along y-axis
                    for (var i = 0; i < segment.Length; i++)
                    {
                        y += segment.DeltaY;

                        points.Add((x, y));
                    }
                }
            }

            return points;
        }

        private static int Distance(int x, int y)
        {
            if (x < 0)
            {
                x = -x;
            }

            if (y < 0)
            {
                y = -y;
            }

            return x + y;
        }
    }
}
