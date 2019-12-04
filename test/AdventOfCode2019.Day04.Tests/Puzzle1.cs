using NUnit.Framework;

namespace AdventOfCode2019.Day04.Tests
{
    public class Puzzle
    {

        [Test]
        [TestCase(111111, true)]
        [TestCase(223450, false)]
        [TestCase(123789, false)]
        public void IsValidPassword(
            int password,
            bool expected)
        {
            Assert.That(
                Program.IsValidPassword(password),
                Is.EqualTo(expected));
        }
    }
}