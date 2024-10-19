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

            if(firstNumber > secondNumber)
            {
                int temp = firstNumber;
                firstNumber = secondNumber;
                secondNumber = temp;
            }

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                int currentValue = Math.Abs(i);
                int count = 0;

                while (currentValue > 0)
                {
                    int remainder = currentValue % 12;

                    if (Digits[remainder] == 'A')
                    {
                        count++;
                    } 

                    currentValue /= 12;
                }

                if (count == 2)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
