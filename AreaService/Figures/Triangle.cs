using System;
using System.Collections.Generic;
using System.Linq;

namespace AreaService.Figures
{
  public class Triangle : Figure
  {
    private readonly List<double> Sides;
    private readonly bool IsRight;
    private readonly bool IsEquilateral; //равносторонний треугольник
    private readonly double MaxSide;

    public Triangle(double side1, double side2, double side3)
    {

      if (side1 <= 0 || side2 <= 0 || side3 <= 0)
        throw new ArgumentOutOfRangeException("Все стороны треугольника должны быть полжительными числами!");

      if (!(side1 + side2 > side3 && side2 + side3 > side1 && side3 + side1 > side2))
        throw new ArgumentException("Tакого треугольника не существует!");

      Sides = new List<double>() { side1, side2, side3 };

      if (side1 == side2 && side2 == side3)
        IsEquilateral = true;
      else
      {
        MaxSide = Sides.Max();
        IsRight = Math.Pow(MaxSide, 2) == Sides.Where(x => x != MaxSide).Sum(x => Math.Pow(x, 2));
      }
    }
    public override double CalculateArea()
    {
      double areaConstant = Math.Sqrt(3)/4; // для расчета равностороннего треугольника
      if (IsEquilateral)
        return areaConstant * Math.Pow(Sides[0], 2);
      if (IsRight)
        return 0.5 * Sides.Where(x => x != MaxSide).Aggregate((x, y) => x * y);
      var halfPerimeter = Sides.Sum()/ 2;
      return Math.Sqrt(halfPerimeter * (halfPerimeter - Sides[0]) * (halfPerimeter - Sides[1]) * (halfPerimeter - Sides[2]));
    }
  }
}
