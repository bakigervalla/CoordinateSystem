using System.Text.RegularExpressions;

namespace CoordinateSystem.Interfaces.Implementation
{
    public class FileFactory : IFileFactory
    {

        public Dictionary<double, List<Point>> ReadCoordinatePoints()
        {
            var points = new Dictionary<double, List<Point>>();

            using var reader = new StreamReader("Assets/coordinates.txt");

            while (true)
            {
                string line = reader.ReadLine();

                if (line is null)
                {
                    break;
                }

                if (!ValidateInputLine(line))
                {
                    continue;
                }

                char[] separators = { '(', ')' };
                string[] splitedLine = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string pointName = splitedLine[0];
                string[] pointCoordinates = splitedLine[1].Split(", ");
                double xCoordinate = ParseCoordinate(pointCoordinates[0]);
                double yCoordinate = ParseCoordinate(pointCoordinates[1]);

                Point point = new(pointName, xCoordinate, yCoordinate);

                double pointDistanceFromCenter = point.GetDistance();

                if (!points.ContainsKey(pointDistanceFromCenter))
                {
                    points[point.GetDistance()] = new List<Point>();
                }

                points[point.GetDistance()].Add(point);
            }

            return points;
        }

        public static bool ValidateInputLine(string inputLine)
        {
            string expression = @"^Point\d+\([-]?\d+(\.\d+)?, [-]?\d+(\.\d+)?\)$";
            return Regex.IsMatch(inputLine, expression);
        }

        public static double ParseCoordinate(string coordinate)
        {
            if (!double.TryParse(coordinate, out _))
            {
                throw new ArgumentException("The coordinate can not be parsed. It must be a number!");
            }

            return double.Parse(coordinate);
        }

    }
}
