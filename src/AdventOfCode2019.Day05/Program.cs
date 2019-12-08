﻿using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day05
{
    static class Program
    {
        static void Main(string[] args)
        {
            Puzzle1();
        }

        private static void Puzzle1()
        {
            var i = File
                .ReadAllText("input1.txt")
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            RunIntcode(i, 1, out var output);

            Console.WriteLine($"Day 05 - Puzzle 1: {output}");
        }

        public static void RunIntcode(
            int[] i,
            int input,
            out int output)
        {
            int instruction, opcode, p1, p2 = 0;

            var pc = 0;

            output = 0;

            while (i[pc] != 99)
            {
                if (output != 0)
                {
                    throw new InvalidOperationException(
                        $"intermediate output must be zero, but was {output}");
                }

                instruction = i[pc++];

                opcode = instruction % 100;

                // all opcodes have at least 1 parameter

                p1 = i[pc++];

                if ((opcode == 1 || opcode == 2 || opcode == 4) && // parameter 1 for opcode 3 is always in position mode
                    (instruction / 100) % 10 == 0)
                {
                    // p1 is in position mode

                    p1 = i[p1];
                }

                if (opcode == 1 || opcode == 2)
                {
                    // opcodes 1 and 2 have two parameters

                    p2 = i[pc++];

                    if ((instruction / 1000) % 10 == 0)
                    {
                        // p2 is in position mode

                        p2 = i[p2];
                    }
                }

                switch (opcode)
                {
                    case 1: // addition

                        i[i[pc++]] = p1 + p2;

                        break;

                    case 2: // multiplication

                        i[i[pc++]] = p1 * p2;

                        break;

                    case 3: // input

                        i[p1] = input;

                        break;

                    case 4: // output

                        output = p1;

                        break;

                    default:
                        throw new InvalidOperationException(
                            $"invalid opcode: '{opcode}'");
                }
            }
        }
    }
}
