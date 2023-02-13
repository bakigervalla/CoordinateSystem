namespace CoordinateSystem.Interfaces.Implementation
{
    public class ConsoleService : IConsole
    {
        private readonly ICoordinates _coordinates;
        private readonly IFileFactory _fileFactory;

        public ConsoleService(ICoordinates coordinates, IFileFactory fileFactory)
        {
            _coordinates = coordinates;
            _fileFactory = fileFactory;
        }

        public string GetResults()
        {

            var points = _fileFactory.ReadCoordinatePoints();

            if (points.Count == 0)
                return "The coordinates input file is empty.";

            var result = _coordinates.Calculate(points);

            return result;
        }
    }
}
