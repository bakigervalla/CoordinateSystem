namespace CoordinateSystem.Interfaces;

public interface IFileFactory
{
    Dictionary<double, List<Point>> ReadCoordinatePoints();
}