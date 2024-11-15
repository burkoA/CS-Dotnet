namespace HomeTask5_1;

class Program
{
    static void Main(string[] args)
    {
        SparseMatrix test = new SparseMatrix(4, 2);

        test[1, 1] = 2;

        var testTwo = test.GetNonzeroElements();

        int count = test.GetCount(2);

        long value = test[0, 0];

        var tejip = test.GetEnumerator();

        Console.WriteLine(test);
    }
}
