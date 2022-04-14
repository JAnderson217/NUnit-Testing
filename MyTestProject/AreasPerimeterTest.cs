using System;
using Interfaces;
using NUnit.Framework;

namespace MyTestProject
{
    [TestFixture]
    internal class AreasPerimeterTest
    {
        [Test]
        public void CircleAreaTest()
        {
            Circle circ = new Circle();
            double radius = 4.0;
            double expectedArea = Math.PI * Math.Pow(4.0, 2);
            double expectedPerimeter = 2 * Math.PI * 4.0;
            circ.radius = radius;
            double actualArea = circ.Area();
            Assert.AreEqual(expectedArea, actualArea);
            double actualPerimeter = circ.perimeter();
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }
        [Test]
        public void CirclePerimeterTest()
        {
            Circle circ = new Circle();
            double radius = 4.0;
            double expectedPerimeter = 2 * Math.PI * 4.0;
            circ.radius = radius;
            double actualPerimeter = circ.perimeter();
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }
        [Test]
        public void RectangleAreaTest()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.width = 4.0;
            rectangle.height = 5.0;
            double expected = 20.0;
            double actual = rectangle.Area();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RectanglePerimeterTest()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.width = 4.0;
            rectangle.height = 5.0;
            double expected = 18.0;
            double actual = rectangle.perimeter();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TriangleAreaTest()
        {
            Triangle triangle = new Triangle();
            triangle.sideOne = 5.0;
            triangle.sideTwo = 5.0;
            triangle.sideThree = 6.0;
            double expected = 12.0;
            double actual = triangle.Area();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TrianglePerimeterTest()
        {
            Triangle triangle = new Triangle();
            triangle.sideOne = 4.5;
            triangle.sideTwo = 5;
            triangle.sideThree = 6;
            double expected = 15.5;
            double actual = triangle.perimeter();
            Assert.AreEqual(expected, actual);
        }
    }
}
