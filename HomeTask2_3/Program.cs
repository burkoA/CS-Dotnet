using HomeTask2_3.Entities;

namespace HomeTask2_3;

class Program
{
    static void Main(string[] args)
    {
        Training training = new Training("C# Advanced Training");

        PracticalLesson practical1 = new PracticalLesson("Practice 1", "task1_link", "solution1_link");
        PracticalLesson practical2 = new PracticalLesson("Practice 2", "task2_link", "solution2_link");
        training.Add(practical1);
        training.Add(practical2);

        // Test practical method (true)
        Console.WriteLine($"Is the training practical-only? {training.IsPractical()}");

        // Cloning
        Training clonedTraining = training.Clone();
        Console.WriteLine($"Training cloned. Original description: {training.Description}, Clone description: {clonedTraining.Description}");

        Lecture lecture3 = new Lecture("Delegates and Events", "Advanced Delegates");
        training.Add(lecture3);

        // Check difference between training
        Console.WriteLine($"Original training now has {training.IsPractical()} practical-only.");
        Console.WriteLine($"Cloned training still has {clonedTraining.IsPractical()} practical-only.");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
