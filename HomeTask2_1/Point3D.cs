namespace HomeTask2_1
{
    public class Point3D
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
                    _mass = 0;
                }
                else
                {
                    _mass = value;
                }
            }
        }

        public Point3D(int x, int y, int z, double mass)
        {
            X = x;
            Y = y;
            Z = z;
            Mass = mass;
        }

        public bool IsZero()
        {
            return this.X == 0 && this.Y == 0 && this.Z == 0 ? true : false;
        }

        public double DistanceBetween(Point3D otherPoint)
        {
            if (otherPoint == null)
            {
                return -1;
            }

            return Math.Sqrt(Math.Pow(otherPoint.X - X, 2) + Math.Pow(otherPoint.Y - Y, 2) + Math.Pow(otherPoint.Z - Z, 2));
        }
    }
}
