namespace CoordinateSystem;
public interface ICoordinates
{
    string Calculate(Dictionary<double, List<Point>> points);
}
