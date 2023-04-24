using System;

namespace AreaService.Figures
{
  public class Circle : Figure
  {
    private readonly double Radius;
    public Circle(double radius)
    {
      if (radius <=0)
        throw new ArgumentException("Радиус должен быть положительным числом!");
      Radius = radius;
    }

    public override double CalculateArea()
      => Math.PI * Math.Pow(Radius, 2);
  }
}
