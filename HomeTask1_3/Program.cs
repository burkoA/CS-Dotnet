namespace HomeTask1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write your number of elements - ");
            string inputNumberElement = Console.ReadLine();

            int numberElements = int.Parse(inputNumberElement);
            int[] numbers = new int[numberElements];

            Console.WriteLine("Write number - ");
            for (int i = 0; i < numberElements; i++)
            {
                string inputNumber = Console.ReadLine();
                numbers[i] = int.Parse(inputNumber);
            }

            int[] unique = new int[numberElements];
            int uniqueCount = 0;

            for (int i = 0; i < numberElements; i++)
            {
                bool isDuplicate = false;

                for (int j = 0; j < uniqueCount; j++)
                {
                    if (numbers[i] == unique[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    unique[uniqueCount] = numbers[i];
                    uniqueCount++;
                }
            }

            int[] finalUnique = new int[uniqueCount];
            Array.Copy(unique, finalUnique, uniqueCount);

            Console.WriteLine(string.Join(", ", numbers));
            Console.WriteLine(string.Join(", ", finalUnique));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
