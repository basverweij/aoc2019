using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day01
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();

            Puzzle2();
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

        static void Puzzle2()
        {
            Console.WriteLine(
                "Day 01 - Puzzle 2: {0}",
                File
                    .ReadAllLines("input1.txt")
                    .Select(int.Parse)
                    .Select(GetFuelForMassComplete)
                    .Sum());
        }

        public static int GetFuelForMass(
            int mass)
        {
            return (mass / 3) - 2;
        }

        public static int GetFuelForMassComplete(
            int mass)
        {
            var totalFuel = 0;

            while (mass > 6)
            {
                mass = (mass / 3) - 2;

                totalFuel += mass;
            }

            return totalFuel;
        }
    }
}
