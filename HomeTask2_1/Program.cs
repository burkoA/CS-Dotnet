namespace HomeTask2_1;

class Program
{
    static void Main(string[] args)
    {
        Point point1 = new Point(1, 2, 3, 5.5);
        Point point2 = new Point(4, 6, -6, 2.3);
        Point point3 = new Point(0, 0, 0, -2.4);

        Console.WriteLine($"Point 1: ({point1.X}, {point1.Y}, {point1.Z}) with mass {point1.Mass}");
        Console.WriteLine($"Point 2: ({point2.X}, {point2.Y}, {point2.Z}) with mass {point2.Mass}");
        Console.WriteLine($"Point 2: ({point3.X}, {point3.Y}, {point3.Z}) with mass {point3.Mass}");

        // Distance method
        double distance = point1.DistanceBetween(point2);
        Console.WriteLine($"Distance between Point 1 and Point 2: {distance}");

        // IsZero method
        Console.WriteLine($"Is Point 1 at origin? {point1.IsZero()}");
        Console.WriteLine($"Is Point 2 at origin? {point2.IsZero()}");
        Console.WriteLine($"Is Point 2 at origin? {point3.IsZero()}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
