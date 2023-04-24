using AreaService.Figures;


namespace AreaService
{
  public static class CalculateService<T> where T : Figure
  {
    public static double GetArea(T figure) => figure.CalculateArea();
  }
}
