namespace HomeTask4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create two DiagonalMatrix instances
            var matrix1 = new DiagonalMatrix<int>(3);
            var matrix2 = new DiagonalMatrix<int>(3);

            // Define the addition function
            Func<int, int, int> addFunc = (a, b) => a + b;

            // Use the Add extension method
            var resultMatrix = matrix1.Add(matrix2, addFunc);
            Console.WriteLine("Result Matrix (Matrix 1 + Matrix 2):");
            Console.WriteLine(resultMatrix);

            // Create a MatrixTracker
            var tracker = new MatrixTracker<int>(matrix1);
            Console.WriteLine("Original Matrix 1:");
            Console.WriteLine(matrix1);

            // Change a value in the matrix
            matrix1[0, 0] = 10; // Change 1 to 10
            Console.WriteLine("Matrix 1 after change:");
            Console.WriteLine(matrix1);

            // Undo the change
            tracker.Undo();
            Console.WriteLine("Matrix 1 after undo:");
            Console.WriteLine(matrix1);

            // Another change
            matrix1[1, 1] = 20; // Change 2 to 20
            Console.WriteLine("Matrix 1 after another change:");
            Console.WriteLine(matrix1);

            // Undo the last change
            tracker.Undo();
            Console.WriteLine("Matrix 1 after undo again:");
            Console.WriteLine(matrix1);

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
