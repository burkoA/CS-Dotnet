namespace HomeTask2_1;

public class Point
{
    private int[] _coordinates = new int[3];
    private double _mass;

    public int X
    {
        get { return _coordinates[0]; }
        set { _coordinates[0] = value; }
    }

    public int Y
    {
        get { return _coordinates[1]; }
        set { _coordinates[1] = value; }
    }

    public int Z
    {
        get { return _coordinates[2]; }
        set { _coordinates[2] = value; }
    }

    public double Mass
    {
        get { return _mass; }
        set
        {
            if (value < 0)
            {
                value = 0;
                _mass = value;
            }
            _mass = value;
        }
    }

    public Point(int x, int y, int z, double mass)
    {
        X = x;
        Y = y;
        Z = z;
        Mass = mass;
    }

    public bool IsZero()
    {
        int count = 0;

        for (int i = 0; i < _coordinates.Length; i++)
        {
            if (_coordinates[i] == 0)
            {
                count++;
            }
        }

        if (count == _coordinates.Length)
        {
            return true;
        }
        return false;
    }

    public double DistanceBetween(Point otherPoint)
    {
        return Math.Sqrt(Math.Pow(otherPoint.X - X, 2) + Math.Pow(otherPoint.Y - Y, 2) + Math.Pow(otherPoint.Z - Z, 2));
    }
}
