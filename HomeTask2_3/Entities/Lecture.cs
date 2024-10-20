namespace HomeTask2_3.Entities
{
    internal class Lecture : TrainingElement
    {
        public string? Topic { get; set; }

        public Lecture(string? description, string? topic) : base(description)
        {
            Topic = topic;
        }
    }
}
