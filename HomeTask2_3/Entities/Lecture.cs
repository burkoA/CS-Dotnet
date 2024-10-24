namespace HomeTask2_3.Entities
{
    internal class Lecture : Lesson
    {
        public string? Topic { get; set; }

        public Lecture(string? description, string? topic) : base(description)
        {
            Topic = topic;
        }

        public override Lesson Clone()
        {
            return new Lecture(this.Description, this.Topic);
        }
    }
}
