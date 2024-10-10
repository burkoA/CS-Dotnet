namespace HomeTask1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Digits = "0123456789AB";

            Console.WriteLine("Enter first number - ");
            string firstNumberInput = Console.ReadLine();

            Console.WriteLine("Enter second number - ");
            string secondNumberInput = Console.ReadLine();

            int firstNumber = int.Parse(firstNumberInput);
            int secondNumber = int.Parse(secondNumberInput);

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                string calculateValue = "";
                int currentValue = i;
                int count = 0;

                while (currentValue > 0)
                {
                    int remainder = currentValue % 12;

                    calculateValue = Digits[remainder] + calculateValue;
                    currentValue /= 12;
                }

                for (int j = 0; j < calculateValue.Length; j++)
                {
                    if (calculateValue[j] == 'A')
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    Console.WriteLine(i);
                }

                count = 0;
                calculateValue = "";
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
