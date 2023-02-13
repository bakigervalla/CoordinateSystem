namespace CoordinateSystem;

public class Point
{
    public Point(string name, double xCoordinate, double yCoordinate)
    {
        Name = name;
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
    }

    public string Name { get; }
    public double XCoordinate { get; }
    public double YCoordinate { get; }

    public double GetDistance()
    {
        return Math.Sqrt(Math.Pow(XCoordinate, 2) + Math.Pow(YCoordinate, 2));
    }

    public string GetLocationOnCoordinateSystem()
    {
        string message = "";

        if (XCoordinate > 0 && YCoordinate > 0)
        {
            message = this.ToString() + " is in the 1st quadrant.";
        }
        else if (XCoordinate < 0 && YCoordinate > 0)
        {
            message = this.ToString() + " is in the 2nd quadrant.";
        }
        else if (XCoordinate < 0 && YCoordinate < 0)
        {
            message = this.ToString() + " is in the 3rd quadrant.";
        }
        else if (XCoordinate > 0 && YCoordinate < 0)
        {
            message = this.ToString() + " is in the 4th quadrant.";
        }
        else if (XCoordinate == 0 && YCoordinate == 0)
        {
            message = this.ToString() + " is in the base of the coordinate system.";
        }
        else if (XCoordinate == 0 && YCoordinate != 0)
        {
            message = this.ToString() + " is in the Y-axis";
        }
        else if (XCoordinate != 0 && YCoordinate == 0)
        {
            message = this.ToString() + " is in the X-axis";
        }

        return message;
    }

    public override string ToString()
    {
        return $"{Name}({XCoordinate}, {YCoordinate})";
    }
}