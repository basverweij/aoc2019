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

            Puzzle2();
        }

        private static void Puzzle1()
        {
            var lines = File.ReadAllLines("input1.txt");

            var line1 = ParseLine(lines[0]);

            var line2 = ParseLine(lines[1]);

            var points1 = DrawLine(line1);

            var points2 = DrawLine(line2);

            var intersections = new HashSet<(int x, int y)>(points1.Keys);

            intersections.IntersectWith(points2.Keys);

            var closestDistance = intersections
                .Select(p => Distance(p.x, p.y))
                .Min();

            Console.WriteLine($"Day 03 - Puzzle 1: {closestDistance}");
        }

        private static void Puzzle2()
        {
            var lines = File.ReadAllLines("input1.txt");

            var line1 = ParseLine(lines[0]);

            var line2 = ParseLine(lines[1]);

            var points1 = DrawLine(line1);

            var points2 = DrawLine(line2);

            var intersections = new HashSet<(int x, int y)>(points1.Keys);

            intersections.IntersectWith(points2.Keys);

            var shortestLength = intersections
                .Select(p => points1[p] + points2[p])
                .Min()  ;

            Console.WriteLine($"Day 03 - Puzzle 1: {shortestLength}");
        }

        public static Segment[] ParseLine(
            string line)
        {
            return line
                .Split(',')
                .Select(Segment.FromString)
                .ToArray();
        }

        public static Dictionary<(int, int), int> DrawLine(
            Segment[] line)
        {
            var x = 0;

            var y = 0;

            var points = new Dictionary<(int, int), int>();

            var n = 0;

            foreach (var segment in line)
            {
                if (segment.DeltaY == 0)
                {
                    // move along x-axis
                    for (var i = 0; i < segment.Length; i++)
                    {
                        x += segment.DeltaX;

                        n++;

                        if (!points.ContainsKey((x, y)))
                        {
                            points[(x, y)] = n;
                        }
                    }
                }
                else
                {
                    // move along y-axis
                    for (var i = 0; i < segment.Length; i++)
                    {
                        y += segment.DeltaY;

                        n++;

                        if (!points.ContainsKey((x, y)))
                        {
                            points[(x, y)] = n;
                        }
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
