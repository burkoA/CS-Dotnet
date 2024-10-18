namespace HomeTask1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 9 symbols for ISBN");
            string isbnInput = Console.ReadLine();

            int weight = 10;
            int result = 0;

            for (int i = 0; i < isbnInput.Length; i++)
            {
                int convertValue = isbnInput[i] - '0';

                result += weight * convertValue;

                weight--;
            }

            int checkDigit = (11 - (result % 11)) % 11;

            string isbn = isbnInput + (checkDigit == 10 ? "X" : checkDigit.ToString());

            Console.WriteLine(isbn);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
