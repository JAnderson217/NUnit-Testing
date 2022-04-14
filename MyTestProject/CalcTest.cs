using System;
using NUnit.Framework;

namespace MyTestProject
{
    [TestFixture]
    internal class CalcTest
    {
        [Test]
        public void AddTest()
        {
            Calc c = new Calc();
            double x = 4.0;
            double y = 5.0;
            double expectedValue = 9.0;
            double actualValue = c.Add(x, y);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void SubtractTest()
        {
            Calc c = new Calc();
            double x = 14.0;
            double y = 5.0;
            double expectedValue = 9.0;
            double actualValue = c.Subtract(x, y);
            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void AddFailTest()
        {
            Calc c = new Calc();
            double x = 24.0;
            double y = 5.0;
            double expectedValue = 9.0;
            double actualValue = c.Add(x, y);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
