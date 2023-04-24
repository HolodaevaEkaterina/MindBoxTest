using AreaService;
using AreaService.Figures;
using NUnit.Framework;
using System;

namespace AreaServiceTests
{
  public class CalculateServiceTests
  {
    [Test]
    public void CircleNegativeRadius()
    {
      Assert.Catch<ArgumentException>(() => new Circle(-2));
    }

    [Test]
    [TestCase(1, 3.1416)]
    [TestCase(0.5, 0.7854)]
    [TestCase(10, 314.1593)]
    public void CirclePositiveRadius(double radius, double expectedValue)
    {
      var circle = new Circle(radius);
      Assert.AreEqual(expectedValue, Math.Round(CalculateService<Circle>.GetArea(circle), 4));
    }

    [Test]
    public void CircleZeroRadius()
    {
      Assert.Catch<ArgumentException>(() => new Circle(0));
    }

    [Test]
    public void TriangleNegativeSide()
    {
      Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(-2, 2, 2));
      Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(2, -2, 2));
      Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(2, 2, -2));
    }

    [Test]
    public void TriangleZeroSide()
    {
      Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(0, 2, 2));
      Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(2, 0, 2));
      Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(2, 2, 0));
    }


    [Test]
    [TestCase(2, 3, 4, 2.904738)]
    [TestCase(10, 20, 25, 94.991776)]
    [TestCase(0.5, 0.7, 0.9, 0.174123)]
    [TestCase(3, 4, 5, 6)]
    [TestCase(0.6, 0.7, 0.922, 0.21)]
    [TestCase(3, 3, 3, 3.897114)]
    [TestCase(0.2, 0.2, 0.2, 0.017321)]
    [TestCase(10000, 20000, 25000, 94991775.959817)]
    [TestCase(20000, 20000, 20000, 173205080.756888)]
    public void PositiveTriangle(double side1, double side2, double side3, double expectedValue)
    {
      var triangle = new Triangle(side1, side2, side3);
      Assert.AreEqual(expectedValue, Math.Round(CalculateService<Triangle>.GetArea(triangle), 6));
    }

    [Test]
    public void NonexistentTriangle()
    {
      Assert.Catch<ArgumentException>(() => new Triangle(5, 3, 2));
      Assert.Catch<ArgumentException>(() => new Triangle(1, 2, 4));
      Assert.Catch<ArgumentException>(() => new Triangle(5, 8, 1));
    }
  }
}
