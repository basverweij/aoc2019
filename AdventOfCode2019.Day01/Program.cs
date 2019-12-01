using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day01
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        static void Puzzle1()
        {
            Console.WriteLine(
                "Day 01 - Puzzle 1: {0}",
                File
                    .ReadAllLines("input1.txt")
                    .Select(int.Parse)
                    .Select(GetFuelForMass)
                    .Sum());
        }

        public static int GetFuelForMass(
            int mass)
        {
            return (mass / 3) - 2;
        }
    }
}
