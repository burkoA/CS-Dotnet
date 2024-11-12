namespace HomeTask4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber r1 = new RationalNumber(2, 6);
            RationalNumber r2 = new RationalNumber(1, 3);
            
            Console.WriteLine($"Rational 1: {r1}"); // 1/3
            Console.WriteLine($"Rational 2: {r2}"); // 1/3

            // "Equals" testing
            RationalNumber r3 = new RationalNumber(4, 8);
            Console.WriteLine($"Rational 3: {r3}");

            Console.WriteLine($"R1 equals R2: {r1.Equals(r2)}"); // true
            Console.WriteLine($"R1 equals R3: {r1.Equals(r3)}"); // false

            // Arithmetic operations
            RationalNumber sum = r1 + r3;
            Console.WriteLine($"Sum: {sum}"); // 5/6

            RationalNumber difference = r1 - r3;
            Console.WriteLine($"Difference: {difference}"); // -1/6

            RationalNumber product = r1 * r3;
            Console.WriteLine($"Product: {product}"); // 1/6

            RationalNumber quotient = r1 / r3; 
            Console.WriteLine($"Quotient: {quotient}"); // 2/3

            // Comparison
            RationalNumber r4 = new RationalNumber(2, 5);
            Console.WriteLine($"Rational 4: {r4}"); // 2/5
            Console.WriteLine($"Comparison R1 to R4: {r1.CompareTo(r4)}"); // -1

            // Casting
            double r1AsDouble = (double)r1;
            Console.WriteLine($"R1 as double: {r1AsDouble}"); // 0.333

            int r1AsInt = (int)r1;
            Console.WriteLine($"R1 as int: {r1AsInt}"); // 0

            // Error for zero denominator
            RationalNumber r5 = new RationalNumber(1, 0); // Throw an exception

        }
    }
}
