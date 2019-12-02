using NUnit.Framework;

namespace AdventOfCode2019.Day02.Tests
{
    public class Tests
    {
        public static object[][] Programs =
        {
            new object[]{ new [] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 }, 3500, 0 },
            new object[]{ new [] { 1, 0, 0, 0, 99 }, 2, 0 },
            new object[]{ new [] { 2, 3, 0, 3, 99 }, 6, 3 },
            new object[]{ new [] { 2, 4, 4, 5, 99, 0 }, 9801, 5 },
            new object[]{ new [] { 1, 1, 1, 4, 99, 5, 6, 0, 99 }, 30, 0 },
        };

        [Test]
        [TestCaseSource(nameof(Programs))]
        public void RunIntcode(
            int[] i,
            int expectedAt,
            int at)
        {
            Program.RunIntcode(i);

            Assert.That(
                i[at],
                Is.EqualTo(expectedAt));
        }
    }
}