using NUnit.Framework;

namespace AdventOfCode2019.Day01.Tests
{
    public class Tests
    {
        [Test]
        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]
        public void TestGetFuelForMassComplete(
            int mass,
            int expected)
        {
            var actual = Program.GetFuelForMassComplete(mass);

            Assert.That(
                actual,
                Is.EqualTo(expected));
        }
    }
}