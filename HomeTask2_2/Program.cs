namespace HomeTask2_2;

class Program
{
    static void Main(string[] args)
    {
        DiagonalMatrix matrix1 = new DiagonalMatrix(2, 3, 6, 8);
        DiagonalMatrix matrix2 = new DiagonalMatrix(1, 2, 3);

        Console.WriteLine("Matrix 1:");
        Console.WriteLine(matrix1);

        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matrix2);

        // Matrix sum
        DiagonalMatrix sumMatrix = DiagonalMatrix.SumTwoMatrix(matrix1, matrix2);
        Console.WriteLine("Sum of matrices:");
        Console.WriteLine(sumMatrix);

        // Track
        Console.WriteLine($"Trace of matrix1: {matrix1.Track()}");

        // Check equals
        Console.WriteLine($"Matrix1 equals Matrix2: {matrix1.Equals(matrix2)}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
