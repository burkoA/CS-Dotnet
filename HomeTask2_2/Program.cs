namespace HomeTask2_2;

class Program
{
    static void Main(string[] args)
    {
        DiagonalMatrix matrix1 = new DiagonalMatrix(2, 3, 6, 8);
        DiagonalMatrix matrix2 = new DiagonalMatrix(1, 2, 3);

        //Indexes get, set test
        Console.WriteLine();
        matrix1[1, 2] = 2;
        //Result - 0
        Console.WriteLine(matrix1[1, 2]);
        Console.WriteLine();

        Console.WriteLine("Matrix 1:");
        Console.WriteLine(matrix1);

        Console.WriteLine("Matrix 2:");
        Console.WriteLine(matrix2);

        // Matrix sum
        DiagonalMatrix sumMatrixOne = AddMatrices.Add(matrix2, matrix1);
        Console.WriteLine("Sum of matrix one:");
        Console.WriteLine(sumMatrixOne);

        DiagonalMatrix sumMatrixTwo = matrix1.Add(matrix2);
        Console.WriteLine("Sum of matrix two:");
        Console.WriteLine(sumMatrixTwo);

        // Track
        Console.WriteLine($"Trace of matrix1: {matrix1.Track()}");

        // Check equals
        Console.WriteLine($"Matrix1 equals Matrix2: {matrix1.Equals(matrix2)}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
