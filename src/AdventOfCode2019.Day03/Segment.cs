using System;

namespace AdventOfCode2019.Day03
{
    public class Segment
    {
        public int DeltaX { get; private set; }

        public int DeltaY { get; private set; }

        public int Length { get; private set; }

        public static Segment FromString(
            string s)
        {
            var (dx, dy) = s[0] switch
            {
                'L' => (-1, 0),
                'R' => (1, 0),
                'U' => (0, 1),
                'D' => (0, -1),

                _ => throw new ArgumentException(
                    $"invalid direction '{s[0]}': must be one of L, R, U, D",
                    nameof(s)),
            };

            var l = int.Parse(s.Substring(1));

            return new Segment { DeltaX = dx, DeltaY = dy, Length = l };
        }
    }
}
