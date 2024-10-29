namespace HomeTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize Queue and perform operations
            Queue<int> queue1 = new Queue<int>();
            Queue<int> queue2 = new Queue<int>();

            var queue3 = queue1.Tail(); // add default value to new Queue - 0

            // Enqueue items
            queue1.Enqueue(10);
            queue1.Enqueue(20);
            queue1.Enqueue(30);

            queue2.Enqueue(1);
            queue2.Enqueue(2);
            queue2.Enqueue(3);

            Console.WriteLine("Dequeuing an element from queue1...");
            queue1.Dequeue(); // should remove 10

            Console.WriteLine("Is queue1 empty? " + queue1.IsEmpty()); // false


            Console.WriteLine("\nCreating tail of queue1...");
            var tailQueue = queue1.Tail(); // 30 - 20/30

            Console.WriteLine("Is tailQueue empty? " + tailQueue.IsEmpty()); // false

            Console.WriteLine("\nTesting on empty queue...");
            Queue<int> emptyQueue = new Queue<int>();
            Console.WriteLine("Is emptyQueue empty?" + emptyQueue.IsEmpty()); // true


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
