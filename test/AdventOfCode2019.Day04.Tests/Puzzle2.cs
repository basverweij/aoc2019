using NUnit.Framework;

namespace AdventOfCode2019.Day04.Tests
{
    public class Puzzle2
    {
        [Test]
        [TestCase(112233, true)]
        [TestCase(123444, false)]
        [TestCase(111122, true)]
        public void IsValidPasswordExtended(
            int password,
            bool expected)
        {
            Assert.That(
                Program.IsValidPasswordExtended(password),
                Is.EqualTo(expected));
        }
    }
}