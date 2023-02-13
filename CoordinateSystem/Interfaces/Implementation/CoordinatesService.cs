using System.Text;

namespace CoordinateSystem.Interfaces.Implementation;
public class CoordinatesService : ICoordinates
{
    public string Calculate(Dictionary<double, List<Point>> points)
    {
        StringBuilder sb = new StringBuilder();

        double longestDistanceFromCenter = points.Keys.Max();

        var pointsWithLongestDistanceFromCenter = points[longestDistanceFromCenter].Select(point => point.Name);

        sb.Append("The point(s) that are farthest from the center (0, 0) in a straight line are: ");
        sb.AppendLine(string.Join(", ", pointsWithLongestDistanceFromCenter));

        foreach (var point in points[longestDistanceFromCenter])
        {
            sb.AppendLine(point.GetLocationOnCoordinateSystem());
        }

        return sb.ToString();
    }

}